/*
 * TODO: 
 * * Change magic numbers to constants wherever it's not a pain in the ass
 * * Error handling, error handling, error handling. Wrap file writes in try/catch, handle malformed pokemon, incomplete writes, patterns not found, etc.
 */
using ntrbase.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace ntrbase
{
    public partial class MainForm : Form
    {
        //A "waiting room", where functions wait for data to be acquired.
        //Entries are indexed by their sequence number. Once a request with a given sequence number
        //is fulfilled, handleDataReady() uses information in DataReadyWaiting object to process the data.
        static Dictionary<uint, DataReadyWaiting> waitingForData = new Dictionary<uint, DataReadyWaiting>();

        // Set this boolean to true to enable the write feature for the party pokémon.
        public static readonly bool enablepartywrite = false;

        public enum GameType { None, X, Y, OR, AS, S, M };
        public bool gen7;
        public const int BOXES = 31;
        public const int BOXSIZE = 30;
        public const int POKEBYTES = 232;
        public const string FOLDERPOKE = "Pokemon";
        public const string FOLDERDELETE = "Deleted";
        public const string FOLDERBOT = "Bot";
        PKHeX dumpedPKHeX = new PKHeX();

        public byte[] selectedCloneData = new byte[232];
        public bool selectedCloneValid = false;

        // Variables for bots
        public bool botWorking = false;
        public bool botStop = false;
        public int botState = 0;
        public static readonly int timeout = 10;
        public uint lastmemoryread;
        public string lastlog;
        public int currentfilter = 0;
        public static readonly string readerror = "An error has ocurred while reading data from your 3DS RAM, please check connection and try again.";
        public static readonly string toucherror = "An error has ocurred while sending a touch screen command, please check connection and try again.\r\n\r\nIf the buttons of your 3DS system doesn't work, send any comand from the Remote Control tab to fix them";
        public static readonly string buttonerror = "An error has ocurred while sending a button command, please check connection and try again.\r\n\r\nIf the buttons of your 3DS system doesn't work, send any comand from the Remote Control tab to fix them";
        public static readonly string writeerror = "An error has ocurred while writting data to your 3DS RAM, please check connection and try again.";

        //Game information
        public int pid;
        public byte lang;
        public string pname;
        public GameType game = GameType.None;
        //Offsets for basic data
        public uint nameoff;
        public uint tidoff;
        public uint sidoff;
        public uint hroff;
        public uint langoff;
        public uint moneyoff;
        public uint milesoff;
        public uint currentFCoff;
        public uint totalFCoff;
        public uint bpoff;
        public uint eggoff;
        public uint mapidoff;
        public uint mapxoff;
        public uint mapyoff;
        public uint mapzoff;
        //Offsets for items data
        public uint itemsoff;
        public uint medsoff;
        public uint keysoff;
        public uint tmsoff;
        public uint bersoff;
        //Offsets for Pokemon sources
        public uint tradeoffrg;
        public uint partyOff;
        public uint boxOff;
        public uint daycare1Off;
        public uint daycare2Off;
        public uint battleBoxOff;
        //Offsets for HID
        public uint buttonsOff = 0x10df20;
        public uint touchscrOff = 0x10df24;
        public int hid_pid = 0x10;
        //Offsets for bot screen detection
        public uint savescrnOff;
        public uint savescrnIN;
        public uint savescrnOUT;
        public uint psssmenu1Off;
        public uint psssmenu1IN;
        public uint psssmenu1OUT;
        public uint wtconfirmationOff;
        public uint wtconfirmationIN;
        public uint wtconfirmationOUT;
        public uint wtboxesOff;
        public uint wtboxesIN;
        public uint wtboxesOUT;
        public uint wtboxviewOff;
        public uint wtboxviewIN;
        public uint wtboxviewOUT;
        public uint wtboxviewRange;
        public uint pssettingsOff;
        public uint pssettingsIN;
        public uint pssettingsOUT;
        public uint pssdisableOff;
        public uint pssdisableY;
        public uint pssdisableIN;
        public uint pssdisableOUT;
        public uint computerOff;
        public uint computerIN;
        public uint computerOUT;
        public uint organizeBoxIN;
        public uint organizeBoxOUT;

        //TODO: add opponent data offset (right now it's a constant)

        private byte[] itemData = new byte[1600];
        private byte[] keyData = new byte[384];
        private byte[] tmData = new byte[432];
        private byte[] medData = new byte[256];
        private byte[] berryData = new byte[288];
        public byte[] items;

        public int numofItems;
        public int numofKeys;
        public int numofTMs;
        public int numofMeds;
        public int numofBers;

        public uint itemsfinal;
        public uint amountfinal;
        public uint keysfinal;
        public uint keysamountfinal;
        public uint tmsfinal;
        public uint tmsamountfinal;
        public uint medsfinal;
        public uint medsamountfinal;
        public uint bersfinal;
        public uint bersamountfinal;

        #region constants
        //Data for an empty slot
        public static byte[] emptyData = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x83, 0x07, 0x00, 0x00, 0x7E, 0xE9, 0x71, 0x52, 0xB0, 0x31, 0x42, 0x8E, 0xCC, 0xE2, 0xC5, 0xAF, 0xDB, 0x67, 0x33, 0xFC, 0x2C, 0xEF, 0x5E, 0xFC, 0xC5, 0xCA, 0xD6, 0xEB, 0x3D, 0x99, 0xBC, 0x7A, 0xA7, 0xCB, 0xD6, 0x5D, 0x78, 0x91, 0xA6, 0x27, 0x8D, 0x61, 0x92, 0x16, 0xB8, 0xCF, 0x5D, 0x37, 0x80, 0x30, 0x7C, 0x40, 0xFB, 0x48, 0x13, 0x32, 0xE7, 0xFE, 0xE6, 0xDF, 0x0E, 0x3D, 0xF9, 0x63, 0x29, 0x1D, 0x8D, 0xEA, 0x96, 0x62, 0x68, 0x92, 0x97, 0xA3, 0x49, 0x1C, 0x03, 0x6E, 0xAA, 0x31, 0x89, 0xAA, 0xC5, 0xD3, 0xEA, 0xC3, 0xD9, 0x82, 0xC6, 0xE0, 0x5C, 0x94, 0x3B, 0x4E, 0x5F, 0x5A, 0x28, 0x24, 0xB3, 0xFB, 0xE1, 0xBF, 0x8E, 0x7B, 0x7F, 0x00, 0xC4, 0x40, 0x48, 0xC8, 0xD1, 0xBF, 0xB6, 0x38, 0x3B, 0x90, 0x23, 0xFB, 0x23, 0x7D, 0x34, 0xBE, 0x00, 0xDA, 0x6A, 0x70, 0xC5, 0xDF, 0x84, 0xBA, 0x14, 0xE4, 0xA1, 0x60, 0x2B, 0x2B, 0x38, 0x8F, 0xA0, 0xB6, 0x60, 0x41, 0x36, 0x16, 0x09, 0xF0, 0x4B, 0xB5, 0x0E, 0x26, 0xA8, 0xB6, 0x43, 0x7B, 0xCB, 0xF9, 0xEF, 0x68, 0xD4, 0xAF, 0x5F, 0x74, 0xBE, 0xC3, 0x61, 0xE0, 0x95, 0x98, 0xF1, 0x84, 0xBA, 0x11, 0x62, 0x24, 0x80, 0xCC, 0xC4, 0xA7, 0xA2, 0xB7, 0x55, 0xA8, 0x5C, 0x1C, 0x42, 0xA2, 0x3A, 0x86, 0x05, 0xAD, 0xD2, 0x11, 0x19, 0xB0, 0xFD, 0x57, 0xE9, 0x4E, 0x60, 0xBA, 0x1B, 0x45, 0x2E, 0x17, 0xA9, 0x34, 0x93, 0x2D, 0x66, 0x09, 0x2D, 0x11, 0xE0, 0xA1, 0x74, 0x42, 0xC4, 0x73, 0x65, 0x2F, 0x21, 0xF0, 0x43, 0x28, 0x54, 0xA6 };

        //Lookup tables
        public static readonly string[] itemList = { "[None]", "Master Ball", "Ultra Ball", "Great Ball", "Poke Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Potion", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Paralyze Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Full Heal", "Revive", "Max Revive", "Fresh Water", "Soda Pop", "Lemonade", "Moomoo Milk", "Energy Powder", "Energy Root", "Heal Powder", "Revival Herb", "Ether", "Max Ether", "Elixir", "Max Elixir", "Lava Cookie", "Berry Juice", "Sacred Ash", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "PP Up", "Zinc", "PP Max", "Old Gateau", "Guard Spec.", "Dire Hit", "X Attack", "X Defense", "X Speed", "X Accuracy", "X Sp. Atk", "X Sp. Def", "Poke Doll", "Fluffy Tail", "Blue Flute", "Yellow Flute", "Red Flute", "Black Flute", "White Flute", "Shoal Salt", "Shoal Shell", "Red Shard", "Blue Shard", "Yellow Shard", "Green Shard", "Super Repel", "Max Repel", "Escape Rope", "Repel", "Sun Stone", "Moon Stone", "Fire Stone", "Thunder Stone", "Water Stone", "Leaf Stone", "Tiny Mushroom", "Big Mushroom", "Pearl", "Big Pearl", "Stardust", "Star Piece", "Nugget", "Heart Scale", "Honey", "Growth Mulch", "Damp Mulch", "Stable Mulch", "Gooey Mulch", "Root Fossil", "Claw Fossil", "Helix Fossil", "Dome Fossil", "Old Amber", "Armor Fossil", "Skull Fossil", "Rare Bone", "Shiny Stone", "Dusk Stone", "Dawn Stone", "Oval Stone", "Odd Keystone", "Griseous Orb", "???", "???", "???", "Douse Drive", "Shock Drive", "Burn Drive", "Chill Drive", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Sweet Heart", "Adamant Orb", "Lustrous Orb", "Greet Mail", "Favored Mail", "RSVP Mail", "Thanks Mail", "Inquiry Mail", "Like Mail", "Reply Mail", "Bridge Mail S", "Bridge Mail D", "Bridge Mail T", "Bridge Mail V", "Bridge Mail M", "Cheri Berry", "Chesto Berry", "Pecha Berry", "Rawst Berry", "Aspear Berry", "Leppa Berry", "Oran Berry", "Persim Berry", "Lum Berry", "Sitrus Berry", "Figy Berry", "Wiki Berry", "Mago Berry", "Aguav Berry", "Iapapa Berry", "Razz Berry", "Bluk Berry", "Nanab Berry", "Wepear Berry", "Pinap Berry", "Pomeg Berry", "Kelpsy Berry", "Qualot Berry", "Hondew Berry", "Grepa Berry", "Tamato Berry", "Cornn Berry", "Magost Berry", "Rabuta Berry", "Nomel Berry", "Spelon Berry", "Pamtre Berry", "Watmel Berry", "Durin Berry", "Belue Berry", "Occa Berry", "Passho Berry", "Wacan Berry", "Rindo Berry", "Yache Berry", "Chople Berry", "Kebai Berry", "Shuca Berry", "Coba Berry", "Payapa Berry", "Tanga Berry", "Charti Berry", "Kasib Berry", "Haban Berry", "Colbur Berry", "Babiri Berry", "Chilan Berry", "Liechi Berry", "Ganlon Berry", "Salac Berry", "Petaya Berry", "Apicot Berry", "Lansat Berry", "Starf Berry", "Enigma Berry", "Micle Berry", "Custap Berry", "Jaboca Berry", "Rowap Berry", "Bright Powder", "White Herb", "Macho Brace", "Exp. Share", "Quick Claw", "Soothe Bell", "Mental Herb", "Choice Band", "King's Rock", "Silver Powder", "Amulet Coin", "Cleanse Tag", "Soul Dew", "Deep Sea Tooth", "Deep Sea Scale", "Smoke Ball", "Everstone", "Focus Band", "Lucky Egg", "Scope Lens", "Metal Coat", "Leftovers", "Dragon Scale", "Light Ball", "Soft Sand", "Hard Stone", "Miracle Seed", "Black Glasses", "Black Belt", "Magnet", "Mystic Water", "Sharp Beak", "Poison Barb", "Never-Melt Ice", "Spell Tag", "Twisted Spoon", "Charcoal", "Dragon Fang", "Silk Scarf", "Up-Grade", "Shell Bell", "Sea Incense", "Lax Incense", "Lucky Punch", "Metal Powder", "Thick Club", "Stick", "Red Scarf", "Blue Scarf", "Pink Scarf", "Green Scarf", "Yellow Scarf", "Wide Lens", "Muscle Band", "Wise Glasses", "Expert Belt", "Light Clay", "Life Orb", "Power Herb", "Toxic Orb", "Flame Orb", "Quick Powder", "Focus Sash", "Zoom Lens", "Metronome", "Iron Ball", "Lagging Tail", "Destiny Knot", "Black Sludge", "Icy Rock", "Smooth Rock", "Heat Rock", "Damp Rock", "Grip Claw", "Choice Scarf", "Sticky Barb", "Power Bracer", "Power Belt", "Power Lens", "Power Band", "Power Anklet", "Power Weight", "Shed Shell", "Big Root", "Choice Specs", "Flame Plate", "Splash Plate", "Zap Plate", "Meadow Plate", "Icicle Plate", "Fist Plate", "Toxic Plate", "Earth Plate", "Sky Plate", "Mind Plate", "Insect Plate", "Stone Plate", "Spooky Plate", "Draco Plate", "Dread Plate", "Iron Plate", "Odd Incense", "Rock Incense", "Full Incense", "Wave Incense", "Rose Incense", "Luck Incense", "Pure Incense", "Protector", "Electrizer", "Magmarizer", "Dubious Disc", "Reaper Cloth", "Razor Claw", "Razor Fang", "Hone Claws", "Dragon Claw", "Psyshock", "Calm Mind", "Roar", "Toxic", "Hail", "Bulk Up", "Venoshock", "Hidden Power", "Sunny Day", "Taunt", "Ice Beam", "Blizzard", "Hyper Beam", "Light Screen", "Protect", "Rain Dance", "Roost", "Safeguard", "Frustration", "Solar Beam", "Smack Down", "Thunderbolt", "Thunder", "Earthquake", "Return", "Dig", "Psychic", "Shadow Ball", "Brick Break", "Double Team", "Reflect", "Sludge Wave", "Flamethrower", "Sludge Bomb", "Sandstorm", "Fire Blast", "Rock Tomb", "Aerial Ace", "Torment", "Facade", "Flame Charge", "Rest", "Attract", "Thief", "Low Sweep", "Round", "Echoed Voice", "Overheat", "Steel Wing", "Focus Blast", "Energy Ball", "False Swipe", "Scald", "Fling", "Charge Beam", "Sky Drop", "Incinerate", "Quash", "Will-O-Wisp", "Acrobatics", "Embargo", "Explosion", "Shadow Claw", "Payback", "Retaliate", "Giga Impact", "Rock Polish", "Flash", "Stone Edge", "Volt Switch", "Thunder Wave", "Gyro Ball", "Swords Dance", "Struggle Bug", "Psych Up", "Bulldoze", "Frost Breath", "Rock Slide", "X-Scissor", "Dragon Tail", "Infestation", "Poison Jab", "Dream Eater", "Grass Knot", "Swagger", "Sleep Talk", "U-turn", "Substitute", "Flash Cannon", "Trick Room", "Cut", "Fly", "Surf", "Strength", "Waterfall", "Rock Smash", "???", "???", "Explorer Kit", "Loot Sack", "Rule Book", "Poke Radar", "Point Card", "Journal", "Seal Case", "Fashion Case", "Seal Bag", "Pal Pad", "Works key", "Old Charm", "Galactic Key", "Red Chain", "Town Map", "Vs. Seeker", "Coin Case", "Old Rod", "Good Rod", "Super Rod", "Sprayduck", "Poffin Case", "Bike", "Suite Key", "Oak's Letter", "Lunar Wing", "Member Card", "Azure Flute", "S.S. Ticket", "Contest Pass", "Magma Stone", "Parcel", "Coupon 1", "Coupon 2", "Coupon 3", "Storage Key", "Secret Potion", "Vs. Recorder", "Gracidea", "Secret Key", "Apricorn Box", "Unown Report", "Berry Pots", "Dowsing Machine", "Blue Card", "Slowpoke Tail", "Clear Bell", "Card Key", "Basement Key", "Squirt Bottle", "Red Scale", "Lost Item", "Pass", "Machine Part", "Silver Wing", "Rainbow Wing", "Mystery Egg", "Red Apricorn", "Blue Apricorn", "Yellow Apricorn", "Green Apricorn", "Pink Apricorn", "White Apricorn", "Black Apricorn", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Park Ball", "Photo Album", "GB Sounds", "Tidal Bell", "Rage Candy Bar", "Data Card 01", "Data Card 02", "Data Card 03", "Data Card 04", "Data Card 05", "Data Card 06", "Data Card 07", "Data Card 08", "Data Card 09", "Data Card 10", "Data Card 11", "Data Card 12", "Data Card 13", "Data Card 14", "Data Card 15", "Data Card 16", "Data Card 17", "Data Card 18", "Data Card 19", "Data Card 20", "Data Card 21", "Data Card 22", "Data Card 23", "Data Card 24", "Data Card 25", "Data Card 26", "Data Card 27", "Jade Orb", "Lock Capsule", "Red Orb", "Blue Orb", "Enigma Stone", "Prism Scale", "Eviolite", "Float Stone", "Rocky Helmet", "Air Balloon", "Red Card", "Ring Target", "Binding Band", "Absorb Bulb", "Cell Battery", "Eject Button", "Fire Gem", "Water Gem", "Electric Gem", "Grass Gem", "Ice Gem", "Fighting Gem", "Poison Gem", "Ground Gem", "Flying Gem", "Psychic Gem", "Bug Gem", "Rock Gem", "Ghost Gem", "Dragon Gem", "Dark Gem", "Steel Gem", "Normal Gem", "Health Wing", "Muscle Wing", "Resist Wing", "Genius Wing", "Clever Wing", "Swift Wing", "Pretty Wing", "Cover Fossil", "Plume Fossil", "Libery Pass", "Pass Orb", "Dream Ball", "Poke Toy", "Prop Case", "Dragon Skull", "Balm Mushroom", "Big Nugget", "Pearl String", "Comet Shard", "Relic Copper", "Relic Silver", "Relic Gold", "Relic Vase", "Relic Band", "Relic Statue", "Relic Crown", "Casteliacone", "Dire Hit 2", "X Speed 2", "X Sp. Atk 2", "X Sp. Def 2", "X Defense 2", "X Attack 2", "X Accuracy 2", "X Speed 3", "X Sp. Atk 3", "X Sp. Def 3", "X Defense 3", "X Attack 3", "X Accuracy 3", "X Speed 6", "X Sp. Atk 6", "X Sp. Def 6", "X Defense 6", "X Attack 6", "X Accuracy 6", "Ability Urge", "Item Drop", "Item Urge", "Reset Urge", "Dire Hit 3", "Light Stone", "Dark Stone", "Wild Charge", "Secret Power", "Snarl", "Xtransceiver(Male)", "???", "Gram 1", "Gram 2", "Gram 3", "Xtransceiver(Female)", "Medal Box", "DNA Splicers(Fuses)", "DNA Splicers(Seperates)", "Permit", "Oval Charm", "Shiny Charm", "Plasma Card", "Grubby Hanky", "Colress Machine", "Dropped Item (Xtransceiver Male)", "Dropped Item (Xtransceiver Female)", "Reveal Glass", "Weakness Policy", "Assault Vest", "Holo Caster", "Prof's Letter", "Roller Skates", "Pixie Plate", "Ability Capsule", "Whipped Dream", "Sachet", "Luminous Moss", "Snowball", "Safety Goggles", "Poke Flute", "Rich Mulch", "Surprise Mulch", "Boost Mulch", "Amaze Mulch", "Gengarite", "Gardevoirite", "Ampharosite", "Venusaurite", "Charizardite X", "Blastoisinite", "Mewtwonite X", "Mewtwonite Y", "Blazikenite", "Medichamite", "Houndoominite", "Aggronite", "Banettite", "Tyranitarite", "Scizorite", "Pinsirite", "Aerodactylite", "Lucarionite", "Abomasite", "Kangaskhanite", "Gyaradosite", "Absolite", "Charizardite Y", "Alakazite", "Heracronite", "Mawilite", "Manectite", "Garchompite", "Latiasite", "Latiosite", "Roseli Berry", "Kee Berry", "Maranga Berry", "Sprinklotad", "Nature Power", "Dark Pulse", "Power-Up Punch", "Dazzling Gleam", "Confide", "Power Plant Pass", "Mega Ring", "Intruiging Stone", "Common Stone", "Discount Coupon", "Elevator Key", "TMV Pass", "Honor of Kalos", "Adventure Rules", "Strange Souvenir", "Lens Case", "Travel Trunk (Silver)", "Travel Trunk (Gold)", "Lumiose Galette", "Shalour Sable", "Jaw Fossil", "Sail Fossil", "Looker Ticket", "Bike", "Holo Caster", "Fairy Gem", "Mega Charm", "Mega Glove", "Mach Bike", "Acro Bike", "Wailmer Pail", "Devon Parts", "Soot Sack", "Basement Key", "Pokeblock Kit", "Letter", "Eon Ticket", "Scanner", "Go-Goggles", "Meteorite (originally found)", "Key to Room 1", "Key to Room 2", "Key to Room 4", "Key to Room 6", "Storage Key", "Devon Scope", "S.S. Ticket", "Dive", "Devon Scuba Gear", "Contest Costume (Male)", "Contest Costume (Female)", "Magma Suit", "Aqua Suit", "Pair of Tickets", "Mega Bracelet", "Mega Pendant", "Mega Glasses", "Mega Anchor", "Mega Stickpin", "Mega Tiara", "Mega Anklet", "Meteorite (faint glow)", "Swampertite", "Sceptilite", "Sablenite", "Altarianite", "Galladite", "Audinite", "Metagrossite", "Sharpedonite", "Slowbronite", "Steelixite", "Pidgeotite", "Glalitite", "Diancite", "Prison Bottle", "Mega Cuff", "Cameruptite", "Lopunnite", "Salamencite", "Beedrillite", "Meteorite (1)", "Meteorite (2)", "Key Stone", "Meteorite Shard", "Eon Flute" };
        public static readonly string[] abilityList = { "Stench", "Drizzle", "Speed Boost", "Battle Armor", "Sturdy", "Damp", "Limber", "Sand Veil", "Static", "Volt Absorb", "Water Absorb", "Oblivious", "Cloud Nine", "Compound Eyes", "Insomnia", "Color Change", "Immunity", "Flash Fire", "Shield Dust", "Own Tempo", "Suction Cups", "Intimidate", "Shadow Tag", "Rough Skin", "Wonder Guard", "Levitate", "Effect Spore", "Synchronize", "Clear Body", "Natural Cure", "Lightning Rod", "Serene Grace", "Swift Swim", "Chlorophyll", "Illuminate", "Trace", "Huge Power", "Poison Point", "Inner Focus", "Magma Armor", "Water Veil", "Magnet Pull", "Soundproof", "Rain Dish", "Sand Stream", "Pressure", "Thick Fat", "Early Bird", "Flame Body", "Run Away", "Keen Eye", "Hyper Cutter", "Pickup", "Truant", "Hustle", "Cute Charm", "Plus", "Minus", "Forecast", "Sticky Hold", "Shed Skin", "Guts", "Marvel Scale", "Liquid Ooze", "Overgrow", "Blaze", "Torrent", "Swarm", "Rock Head", "Drought", "Arena Trap", "Vital Spirit", "White Smoke", "Pure Power", "Shell Armor", "Air Lock", "Tangled Feet", "Motor Drive", "Rivalry", "Steadfast", "Snow Cloak", "Gluttony", "Anger Point", "Unburden", "Heatproof", "Simple", "Dry Skin", "Download", "Iron Fist", "Poison Heal", "Adaptability", "Skill Link", "Hydration", "Solar Power", "Quick Feet", "Normalize", "Sniper", "Magic Guard", "No Guard", "Stall", "Technician", "Leaf Guard", "Klutz", "Mold Breaker", "Super Luck", "Aftermath", "Anticipation", "Forewarn", "Unaware", "Tinted Lens", "Filter", "Slow Start", "Scrappy", "Storm Drain", "Ice Body", "Solid Rock", "Snow Warning", "Honey Gather", "Frisk", "Reckless", "Multitype", "Flower Gift", "Bad Dreams", "Pickpocket", "Sheer Force", "Contrary", "Unnerve", "Defiant", "Defeatist", "Cursed Body", "Healer", "Friend Guard", "Weak Armor", "Heavy Metal", "Light Metal", "Multiscale", "Toxic Boost", "Flare Boost", "Harvest", "Telepathy", "Moody", "Overcoat", "Poison Touch", "Regenerator", "Big Pecks", "Sand Rush", "Wonder Skin", "Analytic", "Illusion", "Imposter", "Infiltrator", "Mummy", "Moxie", "Justified", "Rattled", "Magic Bounce", "Sap Sipper", "Prankster", "Sand Force", "Iron Barbs", "Zen Mode", "Victory Star", "Turboblaze", "Teravolt", "Aroma Veil", "Flower Veil", "Cheek Pouch", "Protean", "Fur Coat", "Magician", "Bulletproof", "Competitive", "Strong Jaw", "Refrigerate", "Sweet Veil", "Stance Change", "Gale Wings", "Mega Launcher", "Grass Pelt", "Symbiosis", "Tough Claws", "Pixilate", "Gooey", "Aerilate", "Parental Bond", "Dark Aura", "Fairy Aura", "Aura Break", "Primordial Sea", "Desolate Land", "Delta Stream" };
        public static readonly string[] speciesList = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch’d", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr-Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime-Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Egg" };
        public static readonly string[] moveList = { "[None]", "Pound", "Karate Chop", "Double Slap", "Comet Punch", "Mega Punch", "Pay Day", "Fire Punch", "Ice Punch", "Thunder Punch", "Scratch", "Vice Grip", "Guillotine", "Razor Wind", "Swords Dance", "Cut", "Gust", "Wing Attack", "Whirlwind", "Fly", "Bind", "Slam", "Vine Whip", "Stomp", "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack", "Headbutt", "Horn Attack", "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take Down", "Thrash", "Double-Edge", "Tail Whip", "Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite", "Growl", "Roar", "Sing", "Supersonic", "Sonic Boom", "Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump", "Surf", "Ice Beam", "Blizzard", "Psybeam", "Bubble Beam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck", "Submission", "Low Kick", "Counter", "Seismic Toss", "Strength", "Absorb", "Mega Drain", "Leech Seed", "Growth", "Razor Leaf", "Solar Beam", "Poison Powder", "Stun Spore", "Sleep Powder", "Petal Dance", "String Shot", "Dragon Rage", "Fire Spin", "Thunder Shock", "Thunderbolt", "Thunder Wave", "Thunder", "Rock Throw", "Earthquake", "Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate", "Agility", "Quick Attack", "Rage", "Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover", "Harden", "Minimize", "Smokescreen", "Confuse Ray", "Withdraw", "Defense Curl", "Barrier", "Light Screen", "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move", "Self-Destruct", "Egg Bomb", "Lick", "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift", "Skull Bash", "Spike Cannon", "Constrict", "Amnesia", "Kinesis", "Soft-Boiled", "High Jump Kick", "Glare", "Dream Eater", "Poison Gas", "Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash", "Psywave", "Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest", "Rock Slide", "Hyper Fang", "Sharpen", "Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute", "Struggle", "Sketch", "Triple Kick", "Thief", "Spider Web", "Mind Reader", "Nightmare", "Flame Wheel", "Snore", "Curse", "Flail", "Conversion 2", "Aeroblast", "Cotton Spore", "Reversal", "Spite", "Powder Snow", "Protect", "Mach Punch", "Scary Face", "Feint Attack", "Sweet Kiss", "Belly Drum", "Sludge Bomb", "Mud-Slap", "Octazooka", "Spikes", "Zap Cannon", "Foresight", "Destiny Bond", "Perish Song", "Icy Wind", "Detect", "Bone Rush", "Lock-On", "Outrage", "Sandstorm", "Giga Drain", "Endure", "Charm", "Rollout", "False Swipe", "Swagger", "Milk Drink", "Spark", "Fury Cutter", "Steel Wing", "Mean Look", "Attract", "Sleep Talk", "Heal Bell", "Return", "Present", "Frustration", "Safeguard", "Pain Split", "Sacred Fire", "Magnitude", "Dynamic Punch", "Megahorn", "Dragon Breath", "Baton Pass", "Encore", "Pursuit", "Rapid Spin", "Sweet Scent", "Iron Tail", "Metal Claw", "Vital Throw", "Morning Sun", "Synthesis", "Moonlight", "Hidden Power", "Cross Chop", "Twister", "Rain Dance", "Sunny Day", "Crunch", "Mirror Coat", "Psych Up", "Extreme Speed", "Ancient Power", "Shadow Ball", "Future Sight", "Rock Smash", "Whirlpool", "Beat Up", "Fake Out", "Uproar", "Stockpile", "Spit Up", "Swallow", "Heat Wave", "Hail", "Torment", "Flatter", "Will-O-Wisp", "Memento", "Facade", "Focus Punch", "Smelling Salts", "Follow Me", "Nature Power", "Charge", "Taunt", "Helping Hand", "Trick", "Role Play", "Wish", "Assist", "Ingrain", "Superpower", "Magic Coat", "Recycle", "Revenge", "Brick Break", "Yawn", "Knock Off", "Endeavor", "Eruption", "Skill Swap", "Imprison", "Refresh", "Grudge", "Snatch", "Secret Power", "Dive", "Arm Thrust", "Camouflage", "Tail Glow", "Luster Purge", "Mist Ball", "Feather Dance", "Teeter Dance", "Blaze Kick", "Mud Sport", "Ice Ball", "Needle Arm", "Slack Off", "Hyper Voice", "Poison Fang", "Crush Claw", "Blast Burn", "Hydro Cannon", "Meteor Mash", "Astonish", "Weather Ball", "Aromatherapy", "Fake Tears", "Air Cutter", "Overheat", "Odor Sleuth", "Rock Tomb", "Silver Wind", "Metal Sound", "Grass Whistle", "Tickle", "Cosmic Power", "Water Spout", "Signal Beam", "Shadow Punch", "Extrasensory", "Sky Uppercut", "Sand Tomb", "Sheer Cold", "Muddy Water", "Bullet Seed", "Aerial Ace", "Icicle Spear", "Iron Defense", "Block", "Howl", "Dragon Claw", "Frenzy Plant", "Bulk Up", "Bounce", "Mud Shot", "Poison Tail", "Covet", "Volt Tackle", "Magical Leaf", "Water Sport", "Calm Mind", "Leaf Blade", "Dragon Dance", "Rock Blast", "Shock Wave", "Water Pulse", "Doom Desire", "Psycho Boost", "Roost", "Gravity", "Miracle Eye", "Wake-Up Slap", "Hammer Arm", "Gyro Ball", "Healing Wish", "Brine", "Natural Gift", "Feint", "Pluck", "Tailwind", "Acupressure", "Metal Burst", "U-turn", "Close Combat", "Payback", "Assurance", "Embargo", "Fling", "Psycho Shift", "Trump Card", "Heal Block", "Wring Out", "Power Trick", "Gastro Acid", "Lucky Chant", "Me First", "Copycat", "Power Swap", "Guard Swap", "Punishment", "Last Resort", "Worry Seed", "Sucker Punch", "Toxic Spikes", "Heart Swap", "Aqua Ring", "Magnet Rise", "Flare Blitz", "Force Palm", "Aura Sphere", "Rock Polish", "Poison Jab", "Dark Pulse", "Night Slash", "Aqua Tail", "Seed Bomb", "Air Slash", "X-Scissor", "Bug Buzz", "Dragon Pulse", "Dragon Rush", "Power Gem", "Drain Punch", "Vacuum Wave", "Focus Blast", "Energy Ball", "Brave Bird", "Earth Power", "Switcheroo", "Giga Impact", "Nasty Plot", "Bullet Punch", "Avalanche", "Ice Shard", "Shadow Claw", "Thunder Fang", "Ice Fang", "Fire Fang", "Shadow Sneak", "Mud Bomb", "Psycho Cut", "Zen Headbutt", "Mirror Shot", "Flash Cannon", "Rock Climb", "Defog", "Trick Room", "Draco Meteor", "Discharge", "Lava Plume", "Leaf Storm", "Power Whip", "Rock Wrecker", "Cross Poison", "Gunk Shot", "Iron Head", "Magnet Bomb", "Stone Edge", "Captivate", "Stealth Rock", "Grass Knot", "Chatter", "Judgment", "Bug Bite", "Charge Beam", "Wood Hammer", "Aqua Jet", "Attack Order", "Defend Order", "Heal Order", "Head Smash", "Double Hit", "Roar of Time", "Spacial Rend", "Lunar Dance", "Crush Grip", "Magma Storm", "Dark Void", "Seed Flare", "Ominous Wind", "Shadow Force", "Hone Claws", "Wide Guard", "Guard Split", "Power Split", "Wonder Room", "Psyshock", "Venoshock", "Autotomize", "Rage Powder", "Telekinesis", "Magic Room", "Smack Down", "Storm Throw", "Flame Burst", "Sludge Wave", "Quiver Dance", "Heavy Slam", "Synchronoise", "Electro Ball", "Soak", "Flame Charge", "Coil", "Low Sweep", "Acid Spray", "Foul Play", "Simple Beam", "Entrainment", "After You", "Round", "Echoed Voice", "Chip Away", "Clear Smog", "Stored Power", "Quick Guard", "Ally Switch", "Scald", "Shell Smash", "Heal Pulse", "Hex", "Sky Drop", "Shift Gear", "Circle Throw", "Incinerate", "Quash", "Acrobatics", "Reflect Type", "Retaliate", "Final Gambit", "Bestow", "Inferno", "Water Pledge", "Fire Pledge", "Grass Pledge", "Volt Switch", "Struggle Bug", "Bulldoze", "Frost Breath", "Dragon Tail", "Work Up", "Electroweb", "Wild Charge", "Drill Run", "Dual Chop", "Heart Stamp", "Horn Leech", "Sacred Sword", "Razor Shell", "Heat Crash", "Leaf Tornado", "Steamroller", "Cotton Guard", "Night Daze", "Psystrike", "Tail Slap", "Hurricane", "Head Charge", "Gear Grind", "Searing Shot", "Techno Blast", "Relic Song", "Secret Sword", "Glaciate", "Bolt Strike", "Blue Flare", "Fiery Dance", "Freeze Shock", "Ice Burn", "Snarl", "Icicle Crash", "V-create", "Fusion Flare", "Fusion Bolt", "Flying Press", "Mat Block", "Belch", "Rototiller", "Sticky Web", "Fell Stinger", "Phantom Force", "Trick-or-Treat", "Noble Roar", "Ion Deluge", "Parabolic Charge", "Forest’s Curse", "Petal Blizzard", "Freeze-Dry", "Disarming Voice", "Parting Shot", "Topsy-Turvy", "Draining Kiss", "Crafty Shield", "Flower Shield", "Grassy Terrain", "Misty Terrain", "Electrify", "Play Rough", "Fairy Wind", "Moonblast", "Boomburst", "Fairy Lock", "King’s Shield", "Play Nice", "Confide", "Diamond Storm", "Steam Eruption", "Hyperspace Hole", "Water Shuriken", "Mystical Fire", "Spiky Shield", "Aromatic Mist", "Eerie Impulse", "Venom Drench", "Powder", "Geomancy", "Magnetic Flux", "Happy Hour", "Electric Terrain", "Dazzling Gleam", "Celebrate", "Hold Hands", "Baby-Doll Eyes", "Nuzzle", "Hold Back", "Infestation", "Power-Up Punch", "Oblivion Wing", "Thousand Arrows", "Thousand Waves", "Land’s Wrath", "Light of Ruin", "Origin Pulse", "Precipice Blades", "Dragon Ascent", "Hyperspace Fury" };
        public static readonly string[] hiddenPowerString = { "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel", "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark", };
        public static readonly Color[] hiddenPowerColor = { Color.FromArgb(192, 48, 40), Color.FromArgb(168, 144, 240), Color.FromArgb(160, 64, 160), Color.FromArgb(224, 192, 104), Color.FromArgb(184, 160, 56), Color.FromArgb(168, 184, 32), Color.FromArgb(112, 88, 152), Color.FromArgb(184, 184, 208), Color.FromArgb(240, 128, 48), Color.FromArgb(104, 144, 240), Color.FromArgb(120, 200, 80), Color.FromArgb(248, 208, 48), Color.FromArgb(248, 88, 136), Color.FromArgb(152, 216, 216), Color.FromArgb(112, 56, 248), Color.FromArgb(112, 88, 72), };
        public static readonly Bitmap[] ballImages = { Resources._0, Resources._1, Resources._2, Resources._3, Resources._4, Resources._5, Resources._6, Resources._7, Resources._8, Resources._9, Resources._10, Resources._11, Resources._12, Resources._13, Resources._14, Resources._15, Resources._16, Resources._17, Resources._18, Resources._19, Resources._20, Resources._21, Resources._22, Resources._23, Resources._24, };
        // Position in boxes
        public static readonly uint[] boxpokeXcord = { 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180 };
        public static readonly uint[] boxpokeYcord = { 60, 60, 60, 60, 60, 60, 90, 90, 90, 90, 90, 90, 120, 120, 120, 120, 120, 120, 150, 150, 150, 150, 150, 150, 180, 180, 180, 180, 180, 180 };
        public static readonly uint[] boxXcord = { 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260 };
        public static readonly uint[] boxYcord = { 24, 24, 24, 24, 24, 24, 24, 24, 72, 72, 72, 72, 72, 72, 72, 72, 120, 120, 120, 120, 120, 120, 120, 120, 168, 168, 168, 168, 168, 168, 168 };
        //HID values
        public static readonly uint nokey = 0xFFF;
        public static readonly uint keyA = 0xFFE;
        public static readonly uint keyB = 0xFFD;
        public static readonly uint keyX = 0xBFF;
        public static readonly uint keyY = 0x7FF;
        public static readonly uint keyR = 0xEFF;
        public static readonly uint keyL = 0xDFF;
        public static readonly uint keySTART = 0xFF7;
        public static readonly uint keySELECT = 0xFFB;
        public static readonly uint DpadUP = 0xFBF;
        public static readonly uint DpadDOWN = 0xF7F;
        public static readonly uint DpadLEFT = 0xFDF;
        public static readonly uint DpadRIGHT = 0xFEF;
        public static readonly uint runUP = 0xFBD;
        public static readonly uint runDOWN = 0xF7D;
        public static readonly uint runLEFT = 0xFDD;
        public static readonly uint runRIGHT = 0xFED;
        public static readonly uint softReset = 0xCF7;
        public static readonly uint notouch = 0x02000000;
        #endregion constants

        //This array will contain controls that should be enabled when connected and disabled when disconnected.
        Control[] enableWhenConnected = new Control[] { };
        Control[] enableWhenConnected7 = new Control[] { };

        public DataGridViewComboBoxColumn itemItem;
        public DataGridViewColumn itemAmount;
        public DataGridViewComboBoxColumn keyItem;
        public DataGridViewColumn keyAmount;
        public DataGridViewComboBoxColumn tmItem;
        public DataGridViewColumn tmAmount;
        public DataGridViewComboBoxColumn medItem;
        public DataGridViewColumn medAmount;
        public DataGridViewComboBoxColumn berItem;
        public DataGridViewColumn berAmount;
        public System.Windows.Forms.ToolTip ToolTipTSVtt = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip ToolTipTSVss = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip ToolTipTSVt = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip ToolTipTSVs = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip ToolTipPSV = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip ToolTipFC = new System.Windows.Forms.ToolTip();

        public delegate void LogDelegate(string l);
        public LogDelegate delAddLog;

        #region Main window

        private void MainForm_Load(object sender, EventArgs e)
        {
            label69.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            DataGridViewComboBoxColumn itemItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn itemAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn keyItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn keyAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn tmItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn tmAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn medItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn medAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn berItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn berAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            itemsGridView.Columns.Add(itemItem);
            itemsGridView.Columns.Add(itemAmount);
            keysGridView.Columns.Add(keyItem);
            keysGridView.Columns.Add(keyAmount);
            tmsGridView.Columns.Add(tmItem);
            tmsGridView.Columns.Add(tmAmount);
            medsGridView.Columns.Add(medItem);
            medsGridView.Columns.Add(medAmount);
            bersGridView.Columns.Add(berItem);
            bersGridView.Columns.Add(berAmount);
            foreach (string t in itemList)
            {
                itemItem.Items.Add(t);
                keyItem.Items.Add(t);
                tmItem.Items.Add(t);
                medItem.Items.Add(t);
                berItem.Items.Add(t);
            }
            host.Text = Settings.Default.IP;
            host.Focus();
        }

        public MainForm()
        {
            Program.ntrClient.DataReady += handleDataReady;
            Program.ntrClient.Connected += connectCheck;
            Program.ntrClient.InfoReady += getGame;
            delAddLog = new LogDelegate(Addlog);
            InitializeComponent();
            enableWhenConnected = new Control[] { boxDump, slotDump, nameek6, dumpPokemon, dumpBoxes, radioBoxes, radioDaycare, radioBattleBox, radioTrade, radioOpponent, radioParty, onlyView, button1, species, nickname, nature, ability, heldItem, ball, dPID, setShiny, randomPID, gender, isEgg, ExpPoints, friendship, ivHPNum, ivATKNum, ivDEFNum, ivSPANum, ivSPDNum, ivSPENum, evHPNum, evATKNum, evDEFNum, evSPANum, evSPDNum, evSPENum, move1, move2, move3, move4, relearnmove1, relearnmove2, relearnmove3, relearnmove4, otName, dTIDNum, dSIDNum, itemsGridView, medsGridView, tmsGridView, bersGridView, keysGridView, showItems, showMedicine, showTMs, showBerries, showKeys, itemWrite, itemAdd, playerName, pokeName, TIDNum, pokeTID, SIDNum, pokeSID, moneyNum, pokeMoney, milesNum, pokeMiles, bpNum, pokeBP, Lang, pokeLang, hourNum, minNum, secNum, pokeTime, cloneBoxTo, cloneSlotTo, cloneCopiesNo, cloneBoxFrom, cloneSlotFrom, cloneDoIt, writeBoxTo, writeSlotTo, writeCopiesNo, writeAutoInc, writeBrowse, writeDoIt, deleteBox, deleteSlot, deleteAmount, deleteKeepBackup, delPkm, manualDUp, ManualDDown, manualDLeft, manualDRight, manualA, manualB, manualX, manualY, manualL, manualR, manualStart, manualSelect, touchX, touchY, manualTouch, manualSR, modeBreed, boxBreed, slotBreed, eggsNoBreed, bFilterLoad, filterBreeding, ESVlistSave, TSVlistNum, TSVlistAdd, TSVlistRemove, TSVlistSave, TSVlistLoad, OrganizeMiddle, OrganizeTop, radioDayCare1, radioDayCare2, readESV, quickBreed, runBreedingBot, typeLSR, srFilterLoad, filtersSoftReset, RunLSRbot, resumeLSR, WTBox, WTSlot, WTtradesNo, RunWTbot };
            enableWhenConnected7 = new Control[] { boxDump, slotDump, nameek6, dumpPokemon, dumpBoxes, radioBoxes, radioDaycare, radioBattleBox, radioTrade, radioOpponent, radioParty, onlyView, button1, species, nickname, nature, ability, heldItem, ball, dPID, setShiny, randomPID, gender, isEgg, ExpPoints, friendship, ivHPNum, ivATKNum, ivDEFNum, ivSPANum, ivSPDNum, ivSPENum, evHPNum, evATKNum, evDEFNum, evSPANum, evSPDNum, evSPENum, move1, move2, move3, move4, relearnmove1, relearnmove2, relearnmove3, relearnmove4, otName, dTIDNum, dSIDNum, showMedicine, showTMs, showBerries, showKeys, itemWrite, itemAdd, playerName, pokeName, TIDNum, pokeTID, SIDNum, pokeSID, moneyNum, pokeMoney, milesNum, pokeMiles, bpNum, pokeBP, Lang, pokeLang, hourNum, minNum, secNum, pokeTime, cloneBoxTo, cloneSlotTo, cloneCopiesNo, cloneBoxFrom, cloneSlotFrom, cloneDoIt, writeBoxTo, writeSlotTo, writeCopiesNo, writeAutoInc, writeBrowse, writeDoIt, deleteBox, deleteSlot, deleteAmount, deleteKeepBackup, delPkm, manualDUp, ManualDDown, manualDLeft, manualDRight, manualA, manualB, manualX, manualY, manualL, manualR, manualStart, manualSelect, touchX, touchY, manualTouch, manualSR };
            disableControls();
            SetSelectedIndex(filterHPlogic, 0);
            SetSelectedIndex(filterATKlogic, 0);
            SetSelectedIndex(filterDEFlogic, 0);
            SetSelectedIndex(filterSPAlogic, 0);
            SetSelectedIndex(filterSPDlogic, 0);
            SetSelectedIndex(filterSPElogic, 0);
            SetSelectedIndex(filterPerIVlogic, 0);
        }

        private void enableControls()
        {
            if (gen7)
            {
                foreach (Control c in enableWhenConnected7)
                {
                    SetEnabled(c, true);
                }
            }
            else
            {
                foreach (Control c in enableWhenConnected)
                {
                    SetEnabled(c, true);
                }
            }
        }

        private void disableControls()
        {
            if (gen7)
            {
                foreach (Control c in enableWhenConnected7)
                {
                    SetEnabled(c, false);
                }
            }
            else
            {
                foreach (Control c in enableWhenConnected)
                {
                    SetEnabled(c, false);
                }
            }
        }

        public void Addlog(string l)
        {
            lastlog = l;
            if (!l.Contains("\r\n"))
            {
                l = l.Replace("\n", "\r\n");
            }
            if (!l.EndsWith("\n"))
            {
                l += "\r\n";
            }
            txtLog.AppendText(l);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Program.ntrClient.sendHeartbeatPacket();
            }
            catch (Exception)
            {
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ntrClient.disconnect();
        }

        public void startAutoDisconnect()
        {
            disconnectTimer.Enabled = true;
        }

        private void disconnectTimer_Tick(object sender, EventArgs e)
        {
            disconnectTimer.Enabled = false;
            Program.ntrClient.disconnect();
            game = GameType.None;
        }

        #endregion window

        #region Functions

        public int getHiddenPower()
        {
            int hp = (15 * ((dumpedPKHeX.IV_HP & 1) + 2 * (dumpedPKHeX.IV_ATK & 1) + 4 * (dumpedPKHeX.IV_DEF & 1) + 8 * (dumpedPKHeX.IV_SPE & 1) + 16 * (dumpedPKHeX.IV_SPA & 1) + 32 * (dumpedPKHeX.IV_SPD & 1)) / 63);

            SetText(hiddenPower, hiddenPowerString[hp]);
            SetColor(hiddenPower, hiddenPowerColor[hp], true);

            return hp;
        }

        public int getTSV(decimal TID, decimal SID)
        {
            return ((int)TID ^ (int)SID) >> 4;
        }

        public int getGen7ID(decimal TID, decimal SID)
        {
            return (int)((uint)((int)TID | ((int)SID << 16)) % 1000000);
        }

        #endregion Functions

        #region Connection
        public void connectCheck(object sender, EventArgs e)
        {
            Program.scriptHelper.listprocess();
            buttonConnect.Text = "Connected";
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            Settings.Default.IP = host.Text;
            Settings.Default.Save();
        }

        //This functions handles additional information events from NTR netcode. We are only interested in them if they are a process list, containing our game's PID and game type.
        public void getGame(object sender, EventArgs e)
        {
            InfoReadyEventArgs args = (InfoReadyEventArgs)e;
            if (args.info.Contains("kujira-1")) // X
            {
                game = GameType.X;
                gen7 = false;
                string log = args.info;
                pname = ", pname: kujira-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C6A6AC;
                milesoff = 0x8C82BA0;
                bpoff = 0x8C6A6E0;
                boxOff = 0x8C861C8;
                daycare1Off = 0x8C7FF4C;
                daycare2Off = 0x8C8003C;
                itemsoff = 0x8C67564;
                medsoff = 0x8C67ECC;
                keysoff = 0x8C67BA4;
                tmsoff = 0x8C67D24;
                bersoff = 0x8C67FCC;
                nameoff = 0x8C79C84;
                tidoff = 0x8C79C3C;
                sidoff = 0x8C79C3E;
                hroff = 0x8CE2814;
                langoff = 0x8C79C69;
                tradeoffrg = 0x8500000;
                battleBoxOff = 0x8C6AC2C;
                partyOff = 0x8CE1CF8;
                eggoff = 0x8C80124;
                mapidoff = 0x81828EC;
                mapxoff = 0x818290C;
                mapyoff = 0x8182914;
                mapzoff = 0x8182910;
                savescrnOff = 0x19AB78;
                savescrnIN = 0x7E0000;
                savescrnOUT = 0x4D0000;
                psssmenu1Off = 0x19ABC0;
                psssmenu1IN = 0x7E0000;
                psssmenu1OUT = 0x4D0000;
                wtconfirmationOff = 0x19A918;
                wtconfirmationIN = 0x4D0000;
                wtconfirmationOUT = 0x780000;
                wtboxesOff = 0x19A988;
                wtboxesIN = 0x6C0000;
                wtboxesOUT = 0x4D0000;
                wtboxviewOff = 0x627437;
                wtboxviewIN = 0x00000000;
                wtboxviewOUT = 0x20000000;
                wtboxviewRange = 0x1000000;
                pssettingsOff = 0x19ABF0;
                pssettingsIN = 0x7E0000;
                pssettingsOUT = 0x4D0000;
                pssdisableOff = 0x5EEEA4;
                pssdisableY = 100;
                pssdisableIN = 0x00000000;
                pssdisableOUT = 0x15000000;
                computerOff = 0x19A918;
                computerIN = 0x4D0000;
                computerOUT = 0x780000;
                organizeBoxIN = 0x6C0000;
                organizeBoxOUT = 0x4D0000;
                //opwroff = 0x8C7D23E;
                //shoutoutOff = 0x8803CF8;
            }
            else if (args.info.Contains("kujira-2")) // Y
            {
                game = GameType.Y;
                gen7 = false;
                string log = args.info;
                pname = ", pname: kujira-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C6A6AC;
                milesoff = 0x8C82BA0;
                bpoff = 0x8C6A6E0;
                boxOff = 0x8C861C8;
                daycare1Off = 0x8C7FF4C;
                daycare2Off = 0x8C8003C;
                itemsoff = 0x8C67564;
                medsoff = 0x8C67ECC;
                keysoff = 0x8C67BA4;
                tmsoff = 0x8C67D24;
                bersoff = 0x8C67FCC;
                nameoff = 0x8C79C84;
                tidoff = 0x8C79C3C;
                sidoff = 0x8C79C3E;
                hroff = 0x8CE2814;
                langoff = 0x8C79C69;
                tradeoffrg = 0x8500000;
                battleBoxOff = 0x8C6AC2C;
                partyOff = 0x8CE1CF8;
                eggoff = 0x8C80124;
                mapidoff = 0x81828EC;
                mapxoff = 0x818290C;
                mapyoff = 0x8182914;
                mapzoff = 0x8182910;
                savescrnOff = 0x19AB78;
                savescrnIN = 0x7E0000;
                savescrnOUT = 0x4D0000;
                psssmenu1Off = 0x19ABC0;
                psssmenu1IN = 0x7E0000;
                psssmenu1OUT = 0x4D0000;
                wtconfirmationOff = 0x19A918;
                wtconfirmationIN = 0x4D0000;
                wtconfirmationOUT = 0x780000;
                wtboxesOff = 0x19A988;
                wtboxesIN = 0x6C0000;
                wtboxesOUT = 0x4D0000;
                wtboxviewOff = 0x627437;
                wtboxviewIN = 0x00000000;
                wtboxviewOUT = 0x20000000;
                wtboxviewRange = 0x1000000;
                pssettingsOff = 0x19ABF0;
                pssettingsIN = 0x7E0000;
                pssettingsOUT = 0x4D0000;
                pssdisableOff = 0x5EEEA4;
                pssdisableY = 100;
                pssdisableIN = 0x00000000;
                pssdisableOUT = 0x15000000;
                computerOff = 0x19A918;
                computerIN = 0x4D0000;
                computerOUT = 0x780000;
                organizeBoxIN = 0x6C0000;
                organizeBoxOUT = 0x4D0000;
                //opwroff = 0x8C7D23E;
                //shoutoutOff = 0x8803CF8;
            }
            else if (args.info.Contains("sango-1")) //Omega Ruby
            {
                game = GameType.OR;
                gen7 = false;
                string log = args.info;
                pname = ", pname:  sango-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C71DC0;
                milesoff = 0x8C8B36C;
                bpoff = 0x8C71DE8;
                boxOff = 0x8C9E134;
                daycare1Off = 0x8C88370;
                daycare2Off = 0x8C88460;
                itemsoff = 0x8C6EC70;
                medsoff = 0x8C6F5E0;
                keysoff = 0x8C6F2B0;
                tmsoff = 0x8C6F430;
                bersoff = 0x8C6F6E0;
                nameoff = 0x8C81388;
                tidoff = 0x8C81340;
                sidoff = 0x8C81342;
                hroff = 0x8CFBD88;
                langoff = 0x8C8136D;
                tradeoffrg = 0x8520000;
                battleBoxOff = 0x8C72330;
                partyOff = 0x8CFB26C;
                eggoff = 0x8C88358;
                mapidoff = 0x8187BD4;
                mapxoff = 0x8187BF4;
                mapyoff = 0x8187BFC;
                mapzoff = 0x8187BF8;
                savescrnOff = 0x19C1CC;
                savescrnIN = 0x830000;
                savescrnOUT = 0x500000;
                psssmenu1Off = 0x19C21C;
                psssmenu1IN = 0x830000;
                psssmenu1OUT = 0x500000;
                wtconfirmationOff = 0x19C024;
                wtconfirmationIN = 0x500000;
                wtconfirmationOUT = 0x700000;
                wtboxesOff = 0x19BFCC;
                wtboxesIN = 0x710000;
                wtboxesOUT = 0x500000;
                wtboxviewOff = 0x66F5F2;
                wtboxviewIN = 0xC000;
                wtboxviewOUT = 0x4000;
                wtboxviewRange = 0x1000;
                pssettingsOff = 0x19C244;
                pssettingsIN = 0x830000;
                pssettingsOUT = 0x500000;
                pssdisableOff = 0x630DA5;
                pssdisableY = 120;
                pssdisableIN = 0x33000000;
                pssdisableOUT = 0x33100000;
                computerOff = 0x19BF5C;
                computerIN = 0x500000;
                computerOUT = 0x7D0000;
                organizeBoxIN = 0x710000;
                organizeBoxOUT = 0x500000;
                //opwroff = 0x8C83D94;
                //shoutoutOff = 0x8803CF8;
            }
            else if (args.info.Contains("sango-2")) //Alpha Sapphire
            {
                game = GameType.AS;
                gen7 = false;
                string log = args.info;
                pname = ", pname:  sango-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C71DC0;
                milesoff = 0x8C8B36C;
                bpoff = 0x8C71DE8;
                boxOff = 0x8C9E134;
                daycare1Off = 0x8C88370;
                daycare2Off = 0x8C88460;
                itemsoff = 0x8C6EC70;
                medsoff = 0x8C6F5E0;
                keysoff = 0x8C6F2B0;
                tmsoff = 0x8C6F430;
                bersoff = 0x8C6F6E0;
                nameoff = 0x8C81388;
                tidoff = 0x8C81340;
                sidoff = 0x8C81342;
                hroff = 0x8CFBD88;
                langoff = 0x8C8136D;
                tradeoffrg = 0x8520000;
                battleBoxOff = 0x8C72330;
                partyOff = 0x8CFB26C;
                eggoff = 0x8C88358;
                mapidoff = 0x8187BD4;
                mapxoff = 0x8187BF4;
                mapyoff = 0x8187BFC;
                mapzoff = 0x8187BF8;
                savescrnOff = 0x19C1CC;
                savescrnIN = 0x830000;
                savescrnOUT = 0x500000;
                psssmenu1Off = 0x19C21C;
                psssmenu1IN = 0x830000;
                psssmenu1OUT = 0x500000;
                wtconfirmationOff = 0x19C024;
                wtconfirmationIN = 0x500000;
                wtconfirmationOUT = 0x700000;
                wtboxesOff = 0x19BFCC;
                wtboxesIN = 0x710000;
                wtboxesOUT = 0x500000;
                wtboxviewOff = 0x66F5F2;
                wtboxviewIN = 0xC000;
                wtboxviewOUT = 0x4000;
                wtboxviewRange = 0x1000;
                pssettingsOff = 0x19C244;
                pssettingsIN = 0x830000;
                pssettingsOUT = 0x500000;
                pssdisableOff = 0x630DA5;
                pssdisableY = 120;
                pssdisableIN = 0x33000000;
                pssdisableOUT = 0x33100000;
                computerOff = 0x19BF5C;
                computerIN = 0x500000;
                computerOUT = 0x7D0000;
                organizeBoxIN = 0x710000;
                organizeBoxOUT = 0x500000;
                //opwroff = 0x8C83D94;
                //shoutoutOff = 0x8803CF8;
            }
            else if (args.info.Contains("niji_loc")) // Moon
            {
                game = GameType.M;
                gen7 = true;
                string log = args.info;
                pname = ", pname: niji_loc";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x330D8FC0;
                currentFCoff = 0x33124D58;
                totalFCoff = 0x33124D5C;
                //bpoff = 0x8C6A6E0;
                //boxOff = 0x8C861C8;
                //daycare1Off = 0x8C7FF4C;
                //daycare2Off = 0x8C8003C;
                //itemsoff = 0x8C67564;
                //medsoff = 0x8C67ECC;
                //keysoff = 0x8C67BA4;
                //tmsoff = 0x8C67D24;
                //bersoff = 0x8C67FCC;
                nameoff = 0x330D6808;
                tidoff = 0x330D67D0;
                sidoff = 0x330D67D2;
                //hroff = 0x8CE2814;
                //langoff = 0x8C79C69;
                //tradeoffrg = 0x8500000;
                //battleBoxOff = 0x8C6AC2C;
                //partyOff = 0x8CE1CF8;
                //eggoff = 0x8C80124;
            }
            else //not a process list or game not found - ignore packet
            {
                return;
            }
            if (game != GameType.None && gen7)
            {
                fillGen7();
                dumpAllData7();
            }
            if (game != GameType.None && !gen7)
            {
                fillGen6();
                dumpAllData();
            }
            if (!botWorking)
            {
                enableControls();
            }
        }

        private void fillGen6()
        {
            ComboboxFill(species, speciesList);
            ComboboxFill(ability, abilityList);
            ComboboxFill(filterAbility, abilityList);
            ComboboxFill(heldItem, itemList);
            ComboboxFill(move1, moveList);
            ComboboxFill(move2, moveList);
            ComboboxFill(move3, moveList);
            ComboboxFill(move4, moveList);
            ComboboxFill(relearnmove1, moveList);
            ComboboxFill(relearnmove2, moveList);
            ComboboxFill(relearnmove3, moveList);
            ComboboxFill(relearnmove4, moveList);
            SetLabel(label3, "Poké Miles:");
        }

        private void fillGen7()
        {
            SetLabel(label3, "Current FC:");
        }

        #endregion Connection

        #region dump

        public void dumpAllData()
        {
            dumpMoney();
            dumpTID();
            dumpSID();
            dumpName();
            dumpTime();
            dumpBP();
            dumpMiles();
            dumpLang();
            dumpItems();
        }

        public void dumpAllData7()
        {
            dumpMoney();
            dumpName();
            dumpTID();
            dumpSID();
            dumpFC();
        }

        public void dumpItems()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0xB90], handleItemData, null);
            waitingForData.Add(Program.scriptHelper.data(itemsoff, 0xB90, pid), myArgs);
        }

        public void handleItemData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            items = new byte[args.data.Length];
            Array.Copy(args.data, items, args.data.Length);
            //Final data processing will be done in GUI thread
            ItemDumpFinished();
        }

        private int countItems(byte[] data)
        {
            int i = 0;
            for (i = 0; i < data.Length; i += 4)
            {
                uint type = BitConverter.ToUInt16(data, i);
                uint amount = BitConverter.ToUInt16(data, i + 2);
                if (type == 0 && amount == 0)
                {
                    break;
                }
            }
            return i / 4;
        }

        private void addItemsToGridView(byte[] data, DataGridView gv)
        {
            int numOfItems = countItems(data);

            if (numOfItems > 0)
            {
                gv.Rows.Add(numOfItems);
                for (int i = 0; i < numOfItems; i++)
                {
                    int itemsfinal = BitConverter.ToUInt16(data, i * 4);
                    int amountfinal = BitConverter.ToUInt16(data, (i * 4) + 2);

                    gv.Rows[i].Cells[0].Value = itemList[itemsfinal];
                    gv.Rows[i].Cells[1].Value = amountfinal;
                }
            }
        }

        public void readItems()
        {
            const int itemsLength = 1600;
            const int keysLength = 384;
            const int tmsLength = 432;
            const int medsLength = 256;
            const int bersLength = 288;
            const int totalLength = itemsLength + keysLength + tmsLength + medsLength + bersLength;

            if (items == null || items.Length != totalLength)
                throw new ArgumentOutOfRangeException("Item data array is of wrong length");

            itemData = items.Skip(0).Take(itemsLength).ToArray();
            keyData = items.Skip((int)(keysoff - itemsoff)).Take(keysLength).ToArray();
            tmData = items.Skip((int)(tmsoff - itemsoff)).Take(tmsLength).ToArray();
            medData = items.Skip((int)(medsoff - itemsoff)).Take(medsLength).ToArray();
            berryData = items.Skip((int)(bersoff - itemsoff)).Take(bersLength).ToArray();

            addItemsToGridView(itemData, itemsGridView);
            addItemsToGridView(keyData, keysGridView);
            addItemsToGridView(tmData, tmsGridView);
            addItemsToGridView(medData, medsGridView);
            addItemsToGridView(berryData, bersGridView);
        }

        /*
         * Below are functions for requesting and handling data about basic info (name, money, trainer ID, etc.)
         */
        public void dumpName()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x18], handleNameData, null);
            waitingForData.Add(Program.scriptHelper.data(nameoff, 0x18, pid), myArgs);
        }

        public void handleNameData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetText(playerName, Encoding.Unicode.GetString(args.data));
        }

        public void dumpTID()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x02], handleTIDData, null);
            waitingForData.Add(Program.scriptHelper.data(tidoff, 0x02, pid), myArgs);
        }

        public void handleTIDData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(TIDNum, BitConverter.ToUInt16(args.data, 0));
        }

        public void dumpSID()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x02], handleSIDData, null);
            waitingForData.Add(Program.scriptHelper.data(sidoff, 0x02, pid), myArgs);
        }

        public void handleSIDData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(SIDNum, BitConverter.ToUInt16(args.data, 0));
        }

        public void dumpTime()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleHrData, null);
            waitingForData.Add(Program.scriptHelper.data(hroff, 0x04, pid), myArgs);
        }

        public void handleHrData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(hourNum, BitConverter.ToUInt16(args.data, 0));
            SetValue(minNum, args.data[2]);
            SetValue(secNum, args.data[3]);
        }

        public void dumpLang()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x01], handleLangData, null);
            waitingForData.Add(Program.scriptHelper.data(langoff, 0x01, pid), myArgs);
        }

        public void handleLangData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            byte langbyte = args.data[0];
            int i = 0;
            switch (langbyte)
            {
                case 1: i = 0; break;
                case 2: i = 1; break;
                case 3: i = 2; break;
                case 4: i = 3; break;
                case 5: i = 4; break;
                case 7: i = 5; break;
                case 8: i = 6; break;
            }
            SetSelectedIndex(Lang, i);
        }

        public void dumpMoney()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMoneyData, null);
            waitingForData.Add(Program.scriptHelper.data(moneyoff, 0x04, pid), myArgs);
        }

        public void handleMoneyData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(moneyNum, BitConverter.ToInt32(args.data, 0));
        }

        public void dumpMiles()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMilesData, null);
            waitingForData.Add(Program.scriptHelper.data(milesoff, 0x04, pid), myArgs);
        }

        public void handleMilesData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(milesNum, BitConverter.ToInt32(args.data, 0));
        }

        public void dumpFC()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMilesData, null);
            waitingForData.Add(Program.scriptHelper.data(currentFCoff, 0x04, pid), myArgs);
            DataReadyWaiting myArgs2 = new DataReadyWaiting(new byte[0x04], handleFCData, null);
            waitingForData.Add(Program.scriptHelper.data(totalFCoff, 0x04, pid), myArgs2);
        }

        public void handleFCData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetTooltip(ToolTipFC, milesNum, "Obtained FC: " + BitConverter.ToInt32(args.data, 0).ToString());
            //ToolTipFC.SetToolTip(milesNum, "Obtained FC: " + BitConverter.ToInt32(args.data, 0).ToString());
            //SetValue(milesNum, BitConverter.ToInt32(args.data, 0));
        }

        public void dumpBP()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleBPData, null);
            waitingForData.Add(Program.scriptHelper.data(bpoff, 0x04, pid), myArgs);
        }

        public void handleBPData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(bpNum, BitConverter.ToInt32(args.data, 0));
        }

        /*
        public static byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        */

        static List<uint> findOccurences(byte[] haystack, byte[] needle)
        {
            List<uint> occurences = new List<uint>();

            for (uint i = 0; i < haystack.Length; i++)
            {
                if (needle[0] == haystack[i])
                {
                    bool found = true;
                    uint j, k;
                    for (j = 0, k = i; j < needle.Length; j++, k++)
                    {
                        if (k >= haystack.Length || needle[j] != haystack[k])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        occurences.Add(i - 1);
                        i = k;
                    }
                }
            }
            return occurences;
        }

        private static string numberPattern = " ({0})";

        public static string NextAvailableFilename(string path)
        {
            if (!File.Exists(path))
                return path;

            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(tmp))
                return tmp;

            int min = 1, max = 2;

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }

        #endregion dump

        #region controls

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //Some people leave the default IP address, hoping it would work...
            if (host.Text == "0.0.0.0")
            {
                MessageBox.Show("Please input your console's local IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtLog.Clear();
            Program.scriptHelper.connect(host.Text, 8000);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Program.scriptHelper.disconnect();
            game = GameType.None;
            buttonConnect.Text = "Connect";
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            disableControls();
            itemsGridView.Rows.Clear();
            keysGridView.Rows.Clear();
            tmsGridView.Rows.Clear();
            medsGridView.Rows.Clear();
            bersGridView.Rows.Clear();
        }

        private void pokeName_Click(object sender, EventArgs e)
        {
            if (playerName.Text.Length <= 12)
            {
                string nameS = playerName.Text.PadRight(12, '\0');
                byte[] nameBytes = Encoding.Unicode.GetBytes(nameS);
                Program.scriptHelper.write(nameoff, nameBytes, pid);
            }
            else
            {
                MessageBox.Show("That name is too long, please choose a trainer name of 12 character or less.", "Name too long!");
            }
        }

        private void pokeTID_Click(object sender, EventArgs e)
        {
            byte[] tidbyte = BitConverter.GetBytes(Convert.ToUInt16(TIDNum.Value));
            Program.scriptHelper.write(tidoff, tidbyte, pid);
        }

        private void pokeSID_Click(object sender, EventArgs e)
        {
            byte[] sidbyte = BitConverter.GetBytes(Convert.ToUInt16(SIDNum.Value));
            Program.scriptHelper.write(sidoff, sidbyte, pid);
        }

        private void pokeTime_Click(object sender, EventArgs e)
        {
            byte[] timeData = new byte[4];
            BitConverter.GetBytes(Convert.ToUInt16(hourNum.Value)).CopyTo(timeData, 0);
            timeData[2] = Convert.ToByte(minNum.Value);
            timeData[3] = Convert.ToByte(secNum.Value);
            Program.scriptHelper.write(hroff, timeData, pid);
        }

        private void pokeMoney_Click(object sender, EventArgs e)
        {
            byte[] moneybyte = BitConverter.GetBytes(Convert.ToInt32(moneyNum.Value));
            Program.scriptHelper.write(moneyoff, moneybyte, pid);
        }

        private void pokeMiles_Click(object sender, EventArgs e)
        {
            if (gen7)
            { // Current Festival Coins
                byte[] FCbyte = BitConverter.GetBytes(Convert.ToInt32(milesNum.Value));
                Program.scriptHelper.write(currentFCoff, FCbyte, pid);
            }
            else
            { // Poké Miles
                byte[] milesbyte = BitConverter.GetBytes(Convert.ToInt32(milesNum.Value));
                Program.scriptHelper.write(milesoff, milesbyte, pid);
            }
        }

        private void pokeBP_Click(object sender, EventArgs e)
        {
            byte[] bpbyte = BitConverter.GetBytes(Convert.ToInt32(bpNum.Value));
            Program.scriptHelper.write(bpoff, bpbyte, pid);
        }

        private void dumpPokemon_Click(object sender, EventArgs e)
        {
            uint dumpOff = 0;

            if (radioOpponent.Checked == true)
            {
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x1FFFF], handleOpponentData, null);
                waitingForData.Add(Program.scriptHelper.data(0x8800000, 0x1FFFF, pid), myArgs);
            }
            else if (radioTrade.Checked == true)
            {
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x1FFFF], handleTradeData, null);
                waitingForData.Add(Program.scriptHelper.data(tradeoffrg, 0x1FFFF, pid), myArgs);
            }
            else
            {
                if (radioBattleBox.Checked == true)
                {
                    dumpOff = battleBoxOff + ((Decimal.ToUInt32(boxDump.Value) - 1) * POKEBYTES);
                }
                else if (radioBoxes.Checked == true)
                {
                    uint ssd = ((Decimal.ToUInt32(boxDump.Value) - 1) * BOXSIZE) + Decimal.ToUInt32(slotDump.Value) - 1;
                    dumpOff = boxOff + (ssd * POKEBYTES);
                }
                else if (radioDaycare.Checked == true)
                {
                    dumpOff = daycare1Off;
                }
                else if (radioParty.Checked == true)
                {
                    dumpOff = partyOff + (Decimal.ToUInt32(boxDump.Value) - 1) * 484;
                }

                if (radioParty.Checked == true)
                {
                    DataReadyWaiting myArgs = new DataReadyWaiting(new byte[260], handlePkmData, null);
                    uint mySeq = Program.scriptHelper.data(dumpOff, 260, pid);
                    waitingForData.Add(mySeq, myArgs);
                }
                else
                {
                    DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePkmData, null);
                    uint mySeq = Program.scriptHelper.data(dumpOff, POKEBYTES, pid);
                    waitingForData.Add(mySeq, myArgs);
                }
            }
        }

        private void dumpBoxes_Click(object sender, EventArgs e)
        {
            if (radioBoxes.Checked == true)
            {
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[BOXES * BOXSIZE * POKEBYTES], handleAllBoxesData, null);
                waitingForData.Add(Program.scriptHelper.data(boxOff, BOXES * BOXSIZE * POKEBYTES, pid), myArgs);
            }
            else if (radioDaycare.Checked == true)
            {
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePkmData, null);
                uint mySeq = Program.scriptHelper.data(daycare2Off, POKEBYTES, pid);
                waitingForData.Add(mySeq, myArgs);
            }
        }

        public void handleAllBoxesData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            string folderPath = @Application.StartupPath + "\\" + FOLDERPOKE + "\\";
            (new System.IO.FileInfo(folderPath)).Directory.Create();
            string fileName = nameek6.Text + "_boxes.ek6";
            writePokemonToFile(args.data, folderPath + fileName);
        }

        public void handleOpponentData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            byte[] relativePattern = null;
            uint offsetAfter = 0;

            //TODO: maybe set the relative pattern along with other variables in getGame()?
            if (game == GameType.X || game == GameType.Y)
            {
                relativePattern = new byte[] { 0x60, 0x75, 0xC6, 0x08, 0xDC, 0xA8, 0xC7, 0x08, 0xD0, 0xB6, 0xC7, 0x08 };
                offsetAfter = 637;
            }
            if (game == GameType.OR || game == GameType.AS)
            {
                relativePattern = new byte[] { 0x60, 0xE7, 0xC6, 0x08, 0x6C, 0xEC, 0xC6, 0x08, 0xE0, 0x1F, 0xC8, 0x08, 0x00, 0x39, 0xC8, 0x08 };
                offsetAfter = 673;
            }

            List<uint> occurences = findOccurences(args.data, relativePattern);
            int count = 0;
            foreach (uint occurence in occurences)
            {
                count++;
                int dataOffset = (int)(occurence + offsetAfter);
                DataReadyWaiting args_pkm = new DataReadyWaiting(args.data.Skip(dataOffset).Take(POKEBYTES).ToArray(), handlePkmData, null);
                handlePkmData(args_pkm);
            }
        }

        public void handleTradeData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            byte[] relativePattern = null;
            uint offsetAfter = 0;

            if (game == GameType.X || game == GameType.Y)
            {
                relativePattern = new byte[] { 0x08, 0x1C, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD8, 0xBE, 0x59 };
                offsetAfter += 98;
            }

            if (game == GameType.OR || game == GameType.AS)
            {
                relativePattern = new byte[] { 0x08, 0x1E, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x9C, 0xE8, 0x5D };
                offsetAfter += 98;
            }

            List<uint> occurences = findOccurences(args.data, relativePattern);
            int count = 0;
            foreach (uint occurence in occurences)
            {
                count++;
                if (count != 2) continue;
                int dataOffset = (int)(occurence + offsetAfter);
                DataReadyWaiting args_pkm = new DataReadyWaiting(args.data.Skip(dataOffset).Take(POKEBYTES).ToArray(), handlePkmData, null);
                handlePkmData(args_pkm);
            }
        }

        public void handlePkmData(object args_obj)
        {
            try
            { //TODO: TEMPORARY HACK, DO PROPER ERROR HANDLING
                DataReadyWaiting args = (DataReadyWaiting)args_obj;

                PKHeX validator = new PKHeX();
                validator.Data = PKHeX.decryptArray(args.data);

                bool dataCorrect = validator.Species != 0;

                if (!botWorking)
                {
                    if (!onlyView.Checked)
                    {
                        DialogResult res = DialogResult.Cancel;
                        if (!dataCorrect)
                        {
                            res = MessageBox.Show("This Pokemon's data seems to be empty.\r\nPress OK if you want to save it, Cancel if you don't.",
                               "Empty data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                        if (dataCorrect || res == DialogResult.OK)
                        {
                            string folderPath = @Application.StartupPath + "\\" + FOLDERPOKE + "\\";
                            (new System.IO.FileInfo(folderPath)).Directory.Create();
                            string fileName = nameek6.Text + ".pk6";
                            writePokemonToFile(validator.Data, folderPath + fileName);
                        }
                    }
                    else if (!dataCorrect)
                    {
                        MessageBox.Show("This Pokemon's data seems to be empty.", "Empty data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!dataCorrect)
                    return;

                dumpedPKHeX.Data = validator.Data;

                SetSelectedIndex(species, dumpedPKHeX.Species - 1);
                SetValue(ivHPNum, dumpedPKHeX.IV_HP);
                SetValue(ivATKNum, dumpedPKHeX.IV_ATK);
                SetValue(ivDEFNum, dumpedPKHeX.IV_DEF);
                SetValue(ivSPANum, dumpedPKHeX.IV_SPA);
                SetValue(ivSPDNum, dumpedPKHeX.IV_SPD);
                SetValue(ivSPENum, dumpedPKHeX.IV_SPE);
                SetValue(evHPNum, dumpedPKHeX.EV_HP);
                SetValue(evATKNum, dumpedPKHeX.EV_ATK);
                SetValue(evDEFNum, dumpedPKHeX.EV_DEF);
                SetValue(evSPANum, dumpedPKHeX.EV_SPA);
                SetValue(evSPDNum, dumpedPKHeX.EV_SPD);
                SetValue(evSPENum, dumpedPKHeX.EV_SPE);
                SetSelectedIndex(ball, dumpedPKHeX.Ball - 1);
                SetValue(friendship, dumpedPKHeX.HT_Friendship);

                SetValue(ExpPoints, dumpedPKHeX.EXP);

                switch (dumpedPKHeX.Gender)
                {
                    case 0:
                        SetColor(gender, Color.Blue, false);
                        SetText(gender, "♂");
                        break;
                    case 1:
                        SetColor(gender, Color.Red, false);
                        SetText(gender, "♀");
                        break;
                    case 2:
                        SetColor(gender, Color.Gray, false);
                        SetText(gender, "-");
                        break;
                }

                SetValue(dTIDNum, dumpedPKHeX.TID);
                SetValue(dSIDNum, dumpedPKHeX.SID);
                SetText(dPID, dumpedPKHeX.PID.ToString("X"));

                SetText(nickname, dumpedPKHeX.Nickname);
                SetText(otName, dumpedPKHeX.OT_Name);

                getHiddenPower();

                SetChecked(isEgg, dumpedPKHeX.IsEgg);

                SetSelectedIndex(heldItem, dumpedPKHeX.HeldItem);
                SetSelectedIndex(ability, dumpedPKHeX.Ability - 1);
                SetSelectedIndex(nature, dumpedPKHeX.Nature);

                SetSelectedIndex(move1, dumpedPKHeX.Move1);
                SetSelectedIndex(move2, dumpedPKHeX.Move2);
                SetSelectedIndex(move3, dumpedPKHeX.Move3);
                SetSelectedIndex(move4, dumpedPKHeX.Move4);
                SetSelectedIndex(relearnmove1, dumpedPKHeX.RelearnMove1);
                SetSelectedIndex(relearnmove2, dumpedPKHeX.RelearnMove2);
                SetSelectedIndex(relearnmove3, dumpedPKHeX.RelearnMove3);
                SetSelectedIndex(relearnmove4, dumpedPKHeX.RelearnMove4);

                //TODO: make it thread-safe!
                //ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((dumpedPKHeX.TID ^ dumpedPKHeX.SID) >> 4).ToString());
                //ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((dumpedPKHeX.TID ^ dumpedPKHeX.SID) >> 4).ToString());
                //ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((dumpedPKHeX.PID >> 16 ^ dumpedPKHeX.PID & 0xFFFF) >> 4)).ToString());

                SetEnabled(setShiny, !dumpedPKHeX.isShiny); //If it's already shiny, the box will be disabled
                SetText(setShiny, dumpedPKHeX.isShiny ? "★" : "☆");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;
            boxDump.Visible = false;
            slotDump.Visible = false;
            nameek6.Visible = true;
            dumpBoxes.Visible = false;
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            nameek6.Location = new System.Drawing.Point(6, 39);
            label9.Location = new System.Drawing.Point(6, 20);
            dumpPokemon.Size = new System.Drawing.Size(197, 23);
            nameek6.Size = new System.Drawing.Size(197, 23);
            dumpPokemon.Text = "Dump";
            dumpBoxes.Enabled = true;
            nameek6.Enabled = true;
            onlyView.Visible = false;
        }

        private void radioBoxes_CheckedChanged(object sender, EventArgs e)
        {
            boxDump.Minimum = 1;
            boxDump.Maximum = 31;
            label8.Text = "Box:";
            label7.Text = "Slot:";
            label9.Text = "Filename:";
            boxDump.Visible = true;
            slotDump.Visible = true;
            dumpBoxes.Visible = true;
            nameek6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label9.Location = new System.Drawing.Point(97, 20);
            nameek6.Location = new System.Drawing.Point(100, 39);
            nameek6.Size = new System.Drawing.Size(103, 20);
            dumpPokemon.Size = new System.Drawing.Size(86, 23);
            dumpBoxes.Size = new System.Drawing.Size(105, 23);
            dumpBoxes.Location = new System.Drawing.Point(98, 61);
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            dumpPokemon.Text = "Dump";
            dumpBoxes.Text = "Dump All Boxes";
            onlyView.Visible = true;
            onlyView.Checked = false;
        }

        private void radioDaycare_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;
            boxDump.Visible = false;
            slotDump.Visible = false;
            nameek6.Visible = true;
            dumpBoxes.Visible = true;
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            nameek6.Location = new System.Drawing.Point(6, 39);
            label9.Location = new System.Drawing.Point(6, 20);
            dumpPokemon.Size = new System.Drawing.Size(95, 23);
            dumpBoxes.Size = new System.Drawing.Size(95, 23);
            dumpBoxes.Location = new System.Drawing.Point(108, 61);
            nameek6.Size = new System.Drawing.Size(197, 23);
            dumpPokemon.Text = "Dump Slot 1";
            dumpBoxes.Text = "Dump Slot 2";
            dumpBoxes.Enabled = true;
            nameek6.Enabled = true;
            onlyView.Visible = false;
        }

        private void radioOpponent_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;
            boxDump.Visible = false;
            slotDump.Visible = false;
            nameek6.Visible = true;
            dumpBoxes.Visible = false;
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            nameek6.Location = new System.Drawing.Point(6, 39);
            label9.Location = new System.Drawing.Point(6, 20);
            dumpPokemon.Size = new System.Drawing.Size(197, 23);
            nameek6.Size = new System.Drawing.Size(197, 23);
            dumpPokemon.Text = "Dump";
            dumpBoxes.Enabled = true;
            nameek6.Enabled = true;
            onlyView.Visible = false;
        }

        void writeTab_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        //Returns 0 on success, other values on failure
        private int readPokemonFromFile(string filename, out byte[] result)
        {
            string extension = Path.GetExtension(filename);
            result = new byte[POKEBYTES];

            bool isEncrypted = false;

            if (extension == ".pk6" || extension == ".pkx")
                isEncrypted = false;
            else if (extension == ".ek6" || extension == ".ekx")
                isEncrypted = true;
            else
            {
                MessageBox.Show("Please make sure you are using a valid PKX/EKX file.", "Incorrect File Size");
                return 1;
            }

            byte[] tmpBytes = File.ReadAllBytes(filename);

            if (tmpBytes.Length == 260 || tmpBytes.Length == 232)
            {
                //All OK, commit
                if (isEncrypted)
                {
                    tmpBytes.CopyTo(result, 0);
                }
                else
                {
                    PKHeX.encryptArray(tmpBytes.Take(POKEBYTES).ToArray()).CopyTo(result, 0);
                }
            }
            else
            {
                MessageBox.Show("Please make sure you are using a valid PKX/EKX file.", "Incorrect File Size");
                return 2;
            }
            return 0;
        }

        //Returns 0 on success, positive value represents how many copies could not be written.
        private int writePokemonToBox(byte[] data, uint boxFrom, uint count)
        {
            if (data.Length != POKEBYTES)
                return -1;

            int ret = 0;
            if (boxFrom + count > BOXES * BOXSIZE)
            {
                uint newCount = BOXES * BOXSIZE - boxFrom;
                ret = (int)(count - newCount);
                count = newCount;
            }

            byte[] dataToWrite = new byte[count * POKEBYTES];
            for (int i = 0; i < count; i++)
            {
                data.CopyTo(dataToWrite, i * POKEBYTES);
            }
            uint offset = boxOff + boxFrom * POKEBYTES;
            Program.scriptHelper.write(offset, dataToWrite, pid);
            return ret;
        }

        private void writePokemonToFile(byte[] data, string fileName, bool overwrite = false)
        {
            if (!overwrite)
            {
                //if current filename is available, it won't be changed
                fileName = NextAvailableFilename(fileName);
            }

            FileStream fs = File.OpenWrite(fileName);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        #region housekeeping for cloning
        private uint cloneGetCopies()
        {
            return Decimal.ToUInt32(cloneCopiesNo.Value);
        }

        private uint cloneGetBoxIndexTo()
        {
            return Decimal.ToUInt32((cloneBoxTo.Value - 1) * BOXSIZE + cloneSlotTo.Value - 1);
        }

        private uint cloneGetBoxIndexFrom()
        {
            return Decimal.ToUInt32((cloneBoxFrom.Value - 1) * BOXSIZE + cloneSlotFrom.Value - 1);
        }

        private void cloneBoxTo_ValueChanged(object sender, EventArgs e)
        {
            cloneCopiesNo.Maximum = BOXES * BOXSIZE - cloneGetBoxIndexTo();
        }

        private void cloneSlotTo_ValueChanged(object sender, EventArgs e)
        {
            cloneCopiesNo.Maximum = BOXES * BOXSIZE - cloneGetBoxIndexTo();
        }

        #endregion housekeeping for cloning

        private void cloneDoIt_Click(object sender, EventArgs e)
        {
            uint offset = boxOff + cloneGetBoxIndexFrom() * POKEBYTES;
            uint mySeq = Program.scriptHelper.data(offset, POKEBYTES, pid);
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handleCloneData, null);
            waitingForData.Add(mySeq, myArgs);
        }

        private void handleCloneData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            writePokemonToBox(args.data, cloneGetBoxIndexTo(), cloneGetCopies());
        }

        #region housekeeping for write from file
        private uint writeGetCopies()
        {
            return Decimal.ToUInt32(writeCopiesNo.Value);
        }

        private uint writeGetBoxIndex()
        {
            return Decimal.ToUInt32((writeBoxTo.Value - 1) * BOXSIZE + writeSlotTo.Value - 1);
        }

        private void writeSetBoxIndex(uint index)
        {
            if (index >= BOXES * BOXSIZE)
                index = BOXES * BOXSIZE - 1;
            uint box = index / BOXSIZE;
            uint slot = index % BOXSIZE;
            SetValue(writeBoxTo, box + 1);
            SetValue(writeSlotTo, slot + 1);
        }

        private void writeBoxTo_ValueChanged(object sender, EventArgs e)
        {
            writeCopiesNo.Maximum = BOXES * BOXSIZE - writeGetBoxIndex();
        }

        private void writeSlotTo_ValueChanged(object sender, EventArgs e)
        {
            writeCopiesNo.Maximum = BOXES * BOXSIZE - writeGetBoxIndex();
        }

        #endregion housekeeping for write from file

        private void writeBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectWriteDialog = new OpenFileDialog();
            selectWriteDialog.Title = "Select an EKX/PKX file";
            selectWriteDialog.Filter = "EKX/PKX files|*.ek6;*.ekx;*.pk6;*.pkx";
            string path = @Application.StartupPath + "\\Pokemon";
            selectWriteDialog.InitialDirectory = path;
            if (selectWriteDialog.ShowDialog() == DialogResult.OK)
            {
                selectedCloneValid = (readPokemonFromFile(selectWriteDialog.FileName, out selectedCloneData) == 0);
            }
        }

        private void writeDoIt_Click(object sender, EventArgs e)
        {
            if (!selectedCloneValid)
            {
                MessageBox.Show("No Pokemon selected!", "Error");
                return;
            }
            int ret = writePokemonToBox(selectedCloneData, writeGetBoxIndex(), writeGetCopies());
            if (ret > 0)
                MessageBox.Show(ret + " write(s) failed because the end of boxes was reached.", "Error");
            else if (ret <= 0)
                if (writeAutoInc.Checked)
                {
                    writeSetBoxIndex(writeGetBoxIndex() + writeGetCopies());
                }
        }

        void writeTab_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length <= 0)
                return;
            //TODO: maybe show a message if importing multiple files?
            int fails = 0;
            foreach (string filename in files)
            {
                byte[] data = new byte[POKEBYTES];
                if (readPokemonFromFile(filename, out data) == 0)
                {
                    int ret = writePokemonToBox(data, writeGetBoxIndex(), writeGetCopies());
                    if (ret > 0)
                        fails += ret;
                    else if (ret < 0)
                        return;
                }

                if (writeAutoInc.Checked)
                {
                    writeSetBoxIndex(writeGetBoxIndex() + writeGetCopies());
                }
            }
            if (fails > 0)
            {
                MessageBox.Show(fails + " write(s) failed because end of boxes was reached.", "Error");
            }
        }

        #region housekeeping for delete
        private uint deleteGetAmount()
        {
            return Decimal.ToUInt32(deleteAmount.Value);
        }

        private uint deleteGetIndex()
        {
            return Decimal.ToUInt32((deleteBox.Value - 1) * BOXSIZE + deleteSlot.Value - 1);
        }

        private void deleteBox_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = BOXES * BOXSIZE - deleteGetIndex();
        }

        private void deleteSlot_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = BOXES * BOXSIZE - deleteGetIndex();
        }
        #endregion housekeeping for delete

        private void delPkm_Click(object sender, EventArgs e)
        {
            uint offset = boxOff + deleteGetIndex() * POKEBYTES;
            uint size = POKEBYTES * deleteGetAmount();
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[size], handleDeleteData, null);
            uint mySeq = Program.scriptHelper.data(offset, size, pid);
            waitingForData.Add(mySeq, myArgs);
        }

        private void handleDeleteData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            if (deleteKeepBackup.Checked)
            {
                string folderPath = @Application.StartupPath + "\\" + FOLDERPOKE + "\\" + FOLDERDELETE + "\\";
                System.IO.FileInfo folder = new System.IO.FileInfo(folderPath);
                folder.Directory.Create();
                PKHeX validator = new PKHeX();
                for (int i = 0; i < args.data.Length; i += POKEBYTES)
                {
                    validator.Data = PKHeX.decryptArray(args.data.Skip(i).Take(POKEBYTES).ToArray());
                    if (validator.Species == 0)
                        continue;
                    string fileName = folderPath + "backup.pk6";
                    writePokemonToFile(validator.Data, fileName);
                }
            }

            writePokemonToBox(emptyData, deleteGetIndex(), deleteGetAmount());
        }

        private void showItems_Click(object sender, EventArgs e)
        {
            itemsGridView.Visible = true;
            keysGridView.Visible = false;
            tmsGridView.Visible = false;
            medsGridView.Visible = false;
            bersGridView.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Green;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showMedicine_Click(object sender, EventArgs e)
        {
            itemsGridView.Visible = false;
            keysGridView.Visible = false;
            tmsGridView.Visible = false;
            medsGridView.Visible = true;
            bersGridView.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Green;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showTMs_Click(object sender, EventArgs e)
        {
            itemsGridView.Visible = false;
            keysGridView.Visible = false;
            tmsGridView.Visible = true;
            medsGridView.Visible = false;
            bersGridView.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Green;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showBerries_Click(object sender, EventArgs e)
        {
            itemsGridView.Visible = false;
            keysGridView.Visible = false;
            tmsGridView.Visible = false;
            medsGridView.Visible = false;
            bersGridView.Visible = true;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Green;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showKeys_Click(object sender, EventArgs e)
        {
            itemsGridView.Visible = false;
            keysGridView.Visible = true;
            tmsGridView.Visible = false;
            medsGridView.Visible = false;
            bersGridView.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Green;
        }

        public void itemWrite_Click(object sender, EventArgs e)
        {
            byte[] dataToWrite = new byte[0] { };
            uint offsetToWrite = 0;

            if (itemsGridView.Visible == true)
            {
                itemData = new byte[1600];
                for (int i = 0; i < itemsGridView.RowCount; i++)
                {
                    string datastring = itemsGridView.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(itemsGridView.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(itemData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(itemData, i * 4 + 2);
                }
                dataToWrite = itemData;
                offsetToWrite = itemsoff;
            }

            if (keysGridView.Visible == true)
            {
                keyData = new byte[384];
                for (int i = 0; i < keysGridView.RowCount; i++)
                {
                    string datastring = keysGridView.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(keysGridView.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(keyData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(keyData, i * 4 + 2);
                }
                dataToWrite = keyData;
                offsetToWrite = keysoff;
            }

            if (tmsGridView.Visible == true)
            {
                tmData = new byte[432];
                for (int i = 0; i < tmsGridView.RowCount; i++)
                {
                    string datastring = tmsGridView.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(tmsGridView.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(tmData, i * 4);
                    BitConverter.GetBytes((ushort)1).CopyTo(tmData, i * 4 + 2);
                }
                dataToWrite = tmData;
                offsetToWrite = tmsoff;
            }

            if (medsGridView.Visible == true)
            {
                medData = new byte[256];
                for (int i = 0; i < medsGridView.RowCount; i++)
                {
                    string datastring = medsGridView.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(medsGridView.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(medData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(medData, i * 4 + 2);
                }
                dataToWrite = medData;
                offsetToWrite = medsoff;
            }

            if (bersGridView.Visible == true)
            {
                berryData = new byte[288];
                for (int i = 0; i < bersGridView.RowCount; i++)
                {
                    string datastring = bersGridView.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(bersGridView.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(berryData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(berryData, i * 4 + 2);
                }
                dataToWrite = berryData;
                offsetToWrite = bersoff;
            }

            Program.scriptHelper.write(offsetToWrite, dataToWrite, pid);
        }

        private void itemAdd_Click(object sender, EventArgs e)
        {
            if (itemsGridView.Visible == true)
            {
                if (itemsGridView.RowCount >= 400)
                {
                    MessageBox.Show("You already have the max amount of items!", "Too many items");
                }
                else
                {
                    itemsGridView.Rows.Add("[None]", 0);
                }
            }

            if (keysGridView.Visible == true)
            {
                if (keysGridView.RowCount >= 96)
                {
                    MessageBox.Show("You already have the max amount of key items!", "Too many items");
                }
                else
                {
                    keysGridView.Rows.Add("[None]", 0);
                }
            }

            if (tmsGridView.Visible == true)
            {
                if (tmsGridView.RowCount >= 96)
                {
                    MessageBox.Show("You already have the max amount of medicine items!", "Too many items");
                }
                else
                {
                    tmsGridView.Rows.Add("[None]", 0);
                }
            }

            if (medsGridView.Visible == true)
            {
                if (medsGridView.RowCount >= 108)
                {
                    MessageBox.Show("You already have the max amount of TMs & HMs!", "Too many items");
                }
                else
                {
                    medsGridView.Rows.Add("[None]", 0);
                }
            }

            if (bersGridView.Visible == true)
            {
                if (bersGridView.RowCount >= 72)
                {
                    MessageBox.Show("You already have the max amount of berries!", "Too many items");
                }
                else
                {
                    bersGridView.Rows.Add("[None]", 0);
                }
            }
        }

        private void pokeLang_Click(object sender, EventArgs e)
        {
            switch (Lang.SelectedIndex)
            {
                case 0: lang = 0x01; break;
                case 1: lang = 0x02; break;
                case 2: lang = 0x03; break;
                case 3: lang = 0x04; break;
                case 4: lang = 0x05; break;
                case 5: lang = 0x07; break;
                case 6: lang = 0x08; break;
            }
            Program.scriptHelper.writebyte(langoff, lang, pid);
        }

        //TODO: are all these Array.Copy() really necessary? Shouldn't PKHeX just handle everything?
        private void pokeEkx_Click(object sender, EventArgs e)
        {
            if (dumpedPKHeX.Data == null)
            {
                MessageBox.Show("No Pokemon data found, please dump a Pokemon first to edit!", "No data to edit");
            }
            else if (evHPNum.Value + evATKNum.Value + evDEFNum.Value + evSPENum.Value + evSPANum.Value + evSPDNum.Value >= 511)
            {
                MessageBox.Show("Pokemon EV count is too high, the sum of all EVs should be 510 or less!", "EVs too high");
            }
            //This shouldn't be possible (length limited by text field), but better leave it
            else if (nickname.Text.Length > 12)
            {
                MessageBox.Show("Pokemon name length too long! Please use a name with a length of 12 or less.", "Name too long");
            }
            else if (otName.Text.Length > 12)
            {
                MessageBox.Show("OT name length too long! Please use a name with a length of 12 or less.", "Name too long");
            }
            else
            {
                if (evHPNum.Value + evATKNum.Value + evDEFNum.Value + evSPENum.Value + evSPANum.Value + evSPDNum.Value <= 510)
                {
                    if (nickname.Text.Length <= 12 && otName.Text.Length <= 12)
                    {
                        dumpedPKHeX.Nickname = nickname.Text.PadRight(12, '\0');
                        dumpedPKHeX.OT_Name = otName.Text.PadRight(12, '\0');
                        byte[] pkmToEdit = dumpedPKHeX.Data;
                        Array.Copy(Encoding.Unicode.GetBytes(dumpedPKHeX.Nickname), 0, pkmToEdit, 64, 24);
                        Array.Copy(BitConverter.GetBytes(dumpedPKHeX.Nature), 0, pkmToEdit, 28, 1);
                        Array.Copy(BitConverter.GetBytes(dumpedPKHeX.HeldItem), 0, pkmToEdit, 10, 2);
                        dumpedPKHeX.IV_HP = (int)ivHPNum.Value;
                        dumpedPKHeX.IV_ATK = (int)ivATKNum.Value;
                        dumpedPKHeX.IV_DEF = (int)ivDEFNum.Value;
                        dumpedPKHeX.IV_SPE = (int)ivSPENum.Value;
                        dumpedPKHeX.IV_SPA = (int)ivSPANum.Value;
                        dumpedPKHeX.IV_SPD = (int)ivSPDNum.Value;

                        dumpedPKHeX.EV_HP = (int)evHPNum.Value;
                        dumpedPKHeX.EV_ATK = (int)evATKNum.Value;
                        dumpedPKHeX.EV_DEF = (int)evDEFNum.Value;
                        dumpedPKHeX.EV_SPE = (int)evSPENum.Value;
                        dumpedPKHeX.EV_SPA = (int)evSPANum.Value;
                        dumpedPKHeX.EV_SPD = (int)evSPDNum.Value;

                        dumpedPKHeX.EXP = (uint)ExpPoints.Value;

                        dumpedPKHeX.Ball = ball.SelectedIndex + 1;

                        dumpedPKHeX.SID = (int)dSIDNum.Value;
                        dumpedPKHeX.TID = (int)dTIDNum.Value;

                        dumpedPKHeX.PID = PKHeX.getHEXval(dPID.Text);

                        if (isEgg.Checked == true) { dumpedPKHeX.IsEgg = true; }
                        if (isEgg.Checked == false) { dumpedPKHeX.IsEgg = false; }
                        dumpedPKHeX.Species = species.SelectedIndex + 1;
                        dumpedPKHeX.Nature = nature.SelectedIndex;
                        dumpedPKHeX.Ability = ability.SelectedIndex + 1;
                        dumpedPKHeX.HeldItem = heldItem.SelectedIndex;
                        dumpedPKHeX.Move1 = move1.SelectedIndex;
                        dumpedPKHeX.Move2 = move2.SelectedIndex;
                        dumpedPKHeX.Move3 = move3.SelectedIndex;
                        dumpedPKHeX.Move4 = move4.SelectedIndex;
                        dumpedPKHeX.RelearnMove1 = relearnmove1.SelectedIndex;
                        dumpedPKHeX.RelearnMove2 = relearnmove2.SelectedIndex;
                        dumpedPKHeX.RelearnMove3 = relearnmove3.SelectedIndex;
                        dumpedPKHeX.RelearnMove4 = relearnmove4.SelectedIndex;

                        Array.Copy(BitConverter.GetBytes(dumpedPKHeX.IV32), 0, pkmToEdit, 116, 4);
                        byte[] pkmEdited = PKHeX.encryptArray(pkmToEdit);
                        byte[] chkSum = BitConverter.GetBytes(PKHeX.getCHK(pkmToEdit));
                        Array.Copy(chkSum, 0, pkmEdited, 6, 2);

                        if (radioBoxes.Checked == true)
                        {
                            uint ssd = (Decimal.ToUInt32(boxDump.Value) * 30 - 30) + Decimal.ToUInt32(slotDump.Value) - 1;
                            uint ssdOff = boxOff + (ssd * 232);
                            Program.scriptHelper.write(ssdOff, pkmEdited, pid);
                            getHiddenPower();
                        }

                        if (radioBattleBox.Checked == true)
                        {
                            uint bbOff = battleBoxOff + ((Decimal.ToUInt32(boxDump.Value) - 1) * 232);
                            Program.scriptHelper.write(bbOff, pkmEdited, pid);
                            getHiddenPower();
                        }

                        if (radioParty.Checked == true)
                        {
                            uint pOff = partyOff + ((Decimal.ToUInt32(boxDump.Value) - 1) * 484);
                            string pfOff = pOff.ToString("X");
                            string ekx = BitConverter.ToString(pkmEdited).Replace("-", ", 0x");
                            Program.scriptHelper.write(pOff, pkmEdited, pid);
                            getHiddenPower();
                        }

                        if (radioOpponent.Checked == true)
                        {
                            MessageBox.Show("You can only edit Pokemon in your Boxes (for now)!", "Editing Unavailable");
                        }

                        if (radioDaycare.Checked == true)
                        {
                            MessageBox.Show("You can only edit Pokemon in your Boxes (for now)!", "Editing Unavailable");
                        }

                        if (radioTrade.Checked == true)
                        {
                            MessageBox.Show("You can only edit Pokemon in your Boxes (for now)!", "Editing Unavailable");
                        }
                    }
                }
            }
        }

        private void radioParty_CheckedChanged(object sender, EventArgs e)
        {
            boxDump.Minimum = 1;
            boxDump.Maximum = 6;
            label8.Text = "Slot:";
            label9.Text = "Filename:";
            boxDump.Visible = true;
            slotDump.Visible = true;
            dumpBoxes.Visible = true;
            nameek6.Visible = true;
            slotDump.Visible = false;
            label7.Visible = false;
            label8.Visible = true;
            label9.Visible = true;
            label9.Location = new System.Drawing.Point(50, 20);
            nameek6.Location = new System.Drawing.Point(54, 39);
            nameek6.Size = new System.Drawing.Size(149, 20);
            dumpPokemon.Size = new System.Drawing.Size(86, 23);
            dumpBoxes.Size = new System.Drawing.Size(105, 23);
            dumpBoxes.Location = new System.Drawing.Point(98, 61);
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            dumpPokemon.Text = "Dump";
            dumpBoxes.Text = "Dump All Boxes";
        }

        private void radioParty_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioParty.Checked && !botWorking && !enablepartywrite)
            {
                MessageBox.Show("Important:\r\n\r\nThis feature is experimental, the slots that is selected in this application might not be the same slots that are shown in your party. Due the unkonown mechanics of this, the write feature has been disabled.\r\n\r\nIf you wish to edit a pokémon in your party, deposit it in a box.\r\n\r\nCurrently, this only works in XY", "PKMN-NTR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            boxDump.Minimum = 1;
            boxDump.Maximum = 6;
            label8.Text = "Slot:";
            label9.Text = "Filename:";
            boxDump.Visible = true;
            slotDump.Visible = false;
            dumpBoxes.Visible = false;
            nameek6.Visible = true;
            label7.Visible = false;
            label8.Visible = true;
            label9.Visible = true;
            label9.Location = new System.Drawing.Point(50, 20);
            nameek6.Location = new System.Drawing.Point(53, 39);
            nameek6.Size = new System.Drawing.Size(150, 20);
            dumpPokemon.Size = new System.Drawing.Size(197, 23);
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            dumpPokemon.Text = "Dump";
        }

        private void dTIDNum_ValueChanged(object sender, EventArgs e)
        {
            ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + (((int)dTIDNum.Value ^ (int)dSIDNum.Value) >> 4).ToString());
            ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + (((int)dTIDNum.Value ^ (int)dSIDNum.Value) >> 4).ToString());
            ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((dumpedPKHeX.PID >> 16 ^ dumpedPKHeX.PID & 0xFFFF) >> 4)).ToString());
        }

        //TODO: are you sure it's not supposed to be the same as above?
        private void dSIDNum_ValueChanged(object sender, EventArgs e)
        {
            ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((dumpedPKHeX.TID ^ dumpedPKHeX.SID) >> 4).ToString());
            ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((dumpedPKHeX.TID ^ dumpedPKHeX.SID) >> 4).ToString());
            ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((dumpedPKHeX.PID >> 16 ^ dumpedPKHeX.PID & 0xFFFF) >> 4)).ToString());
        }

        private void dPID_TextChanged(object sender, EventArgs e)
        {
            ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((dumpedPKHeX.TID ^ dumpedPKHeX.SID) >> 4).ToString());
            ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((dumpedPKHeX.TID ^ dumpedPKHeX.SID) >> 4).ToString());
            ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((dumpedPKHeX.PID >> 16 ^ dumpedPKHeX.PID & 0xFFFF) >> 4)).ToString());
        }

        private void setShiny_Click(object sender, EventArgs e)
        {
            dumpedPKHeX.setShinyPID();
            dPID.Text = dumpedPKHeX.PID.ToString("X");

            setShiny.Text = dumpedPKHeX.isShiny ? "★" : "☆";
        }

        private void randomPID_Click(object sender, EventArgs e)
        {
            dumpedPKHeX.setRandomPID();
            dPID.Text = dumpedPKHeX.PID.ToString("X");

            setShiny.Text = dumpedPKHeX.isShiny ? "★" : "☆";
        }

        private void TIDNum_ValueChanged(object sender, EventArgs e)
        {
            int TSV = getTSV(TIDNum.Value, SIDNum.Value);
            if (gen7)
            {
                int G7ID = getGen7ID(TIDNum.Value, SIDNum.Value);
                ToolTipTSVtt.SetToolTip(TIDNum, "G7ID: " + G7ID.ToString("D6") + "\r\nTSV: " + TSV.ToString("D4"));
                ToolTipTSVss.SetToolTip(SIDNum, "G7ID: " + G7ID.ToString("D6") + "\r\nTSV: " + TSV.ToString("D4"));
            }
            else
            {
                ToolTipTSVtt.SetToolTip(TIDNum, "TSV: " + TSV.ToString("D4"));
                ToolTipTSVss.SetToolTip(SIDNum, "TSV: " + TSV.ToString("D4"));
            }
        }

        private void SIDNum_ValueChanged(object sender, EventArgs e)
        {
            int TSV = getTSV(TIDNum.Value, SIDNum.Value);
            if (gen7)
            {
                int G7ID = getGen7ID(TIDNum.Value, SIDNum.Value);
                ToolTipTSVtt.SetToolTip(TIDNum, "G7ID: " + G7ID.ToString("D6") + "\r\nTSV: " + TSV.ToString("D4"));
                ToolTipTSVss.SetToolTip(SIDNum, "G7ID: " + G7ID.ToString("D6") + "\r\nTSV: " + TSV.ToString("D4"));
            }
            else
            {
                ToolTipTSVtt.SetToolTip(TIDNum, "TSV: " + TSV.ToString("D4"));
                ToolTipTSVss.SetToolTip(SIDNum, "TSV: " + TSV.ToString("D4"));
            }
        }

        private void onlyView_CheckedChanged(object sender, EventArgs e)
        {
            if (onlyView.Checked == true)
            {
                dumpBoxes.Enabled = false;
                nameek6.Enabled = false;
            }
            else
            if (onlyView.Checked == false)
            {
                dumpBoxes.Enabled = true;
                nameek6.Enabled = true;
            }
        }

        private void ball_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = ballImages[ball.SelectedIndex];
        }

        //TODO: add checking if a gender is available for Pokemon
        private void gender_Click(object sender, EventArgs e)
        {
            if (dumpedPKHeX.Gender == 0)
            {
                gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                gender.ForeColor = Color.Red;
                gender.Text = "♀";
                dumpedPKHeX.Gender = 1;
            }
            else if (dumpedPKHeX.Gender == 1)
            {
                gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                gender.ForeColor = Color.Blue;
                gender.Text = "♂";
                dumpedPKHeX.Gender = 0;
            }
            else if (dumpedPKHeX.Gender == 2)
            {
                //If a Pokemon is genderless, there's nothing you can do...
            }
        }

        private void radioBattleBox_CheckedChanged(object sender, EventArgs e)
        {
            boxDump.Minimum = 1;
            boxDump.Maximum = 6;
            label8.Text = "Slot:";
            label9.Text = "Filename:";
            boxDump.Visible = true;
            slotDump.Visible = false;
            dumpBoxes.Visible = false;
            nameek6.Visible = true;
            label7.Visible = false;
            label8.Visible = true;
            label9.Visible = true;
            label9.Location = new System.Drawing.Point(50, 20);
            nameek6.Location = new System.Drawing.Point(53, 39);
            nameek6.Size = new System.Drawing.Size(150, 20);
            dumpPokemon.Size = new System.Drawing.Size(197, 23);
            dumpPokemon.Location = new System.Drawing.Point(6, 61);
            dumpPokemon.Text = "Dump";
        }

        static void handleDataReady(object sender, DataReadyEventArgs e)
        {
            //We move data processing to a separate thread
            //This way even if processing takes a long time, the netcode doesn't hang
            DataReadyWaiting args;
            if (waitingForData.TryGetValue(e.seq, out args))
            {
                Array.Copy(e.data, args.data, Math.Min(e.data.Length, args.data.Length));
                Thread t = new Thread(new ParameterizedThreadStart(args.handler));
                t.Start(args);
                waitingForData.Remove(e.seq);
            }
        }

        #endregion controls

        #region fucking thread safety
        //Hooray for forced thread-safety!
        //If Visual C# didn't throw an exception every time you tried to access controls from a different thread
        //this wouldn't be necessary. We're not sending a rocket into space, dammit, we're just messing around with Pokemon.
        //I appreciate your care, Microsoft, but we really don't need this.
        //And if you're wondering - no, this is not because I decided to run threads in handleDataReady().
        //If handleDataReady() just called the function directly, it would still run in packetRecvThreadStart()'s thread
        //which is different from the GUI thread.
        delegate void SetTextDelegate(Control ctrl, string text);

        public static void SetText(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextDelegate del = new SetTextDelegate(SetText);
                ctrl.Invoke(del, ctrl, text);
            }
            else
            {
                ctrl.Text = text;
            }
        }

        delegate void SetLabelDelegate(Label ctrl, string text);

        public static void SetLabel(Label ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetLabelDelegate del = new SetLabelDelegate(SetLabel);
                ctrl.Invoke(del, ctrl, text);
            }
            else
            {
                ctrl.Text = text;
            }
        }

        delegate void SetTooltipDelegate(ToolTip source, Control ctrl, string text);

        public static void SetTooltip(ToolTip source, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTooltipDelegate del = new SetTooltipDelegate(SetTooltip);
                ctrl.Invoke(del, source, ctrl, text);
            }
            else
            {
                source.SetToolTip(ctrl, text);
            }
        }

        delegate void RemoveTooltipDelegate(ToolTip source, Control ctrl);

        public static void RemoveTooltip(ToolTip source, Control ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                RemoveTooltipDelegate del = new RemoveTooltipDelegate(RemoveTooltip);
                ctrl.Invoke(del, source, ctrl);
            }
            else
            {
                source.RemoveAll();
            }
        }

        delegate void SetEnabledDelegate(Control ctrl, bool en);

        public static void SetEnabled(Control ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnabledDelegate del = new SetEnabledDelegate(SetEnabled);
                ctrl.Invoke(del, ctrl, en);
            }
            else
            {
                ctrl.Enabled = en;
            }
        }

        delegate void SetCheckedDelegate(CheckBox ctrl, bool en);

        public static void SetChecked(CheckBox ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetCheckedDelegate del = new SetCheckedDelegate(SetChecked);
                ctrl.Invoke(del, ctrl, en);
            }
            else
            {
                ctrl.Checked = en;
            }
        }

        delegate void SetValueDelegate(NumericUpDown ctrl, decimal val);

        public static void SetValue(NumericUpDown ctrl, decimal val)
        {
            if (ctrl.InvokeRequired)
            {
                SetValueDelegate del = new SetValueDelegate(SetValue);
                ctrl.Invoke(del, ctrl, val);
            }
            else
            {
                ctrl.Value = val;
            }
        }

        delegate void SetSelectedIndexDelegate(ComboBox ctrl, int i);

        public static void SetSelectedIndex(ComboBox ctrl, int i)
        {
            if (ctrl.InvokeRequired)
            {
                SetSelectedIndexDelegate del = new SetSelectedIndexDelegate(SetSelectedIndex);
                ctrl.Invoke(del, ctrl, i);
            }
            else
            {
                ctrl.SelectedIndex = i;
            }
        }

        delegate void ComboboxFillDelegate(ComboBox ctrl, string[] val);

        public static void ComboboxFill(ComboBox ctrl, string[] val)
        {
            if (ctrl.InvokeRequired)
            {
                ComboboxFillDelegate del = new ComboboxFillDelegate(ComboboxFill);
                ctrl.Invoke(del, ctrl, val);
            }
            else
            {
                ctrl.Items.AddRange(val);
            }
        }

        delegate void SetColorDelegate(Control ctrl, Color c, bool back);

        public static void SetColor(Control ctrl, Color c, bool back)
        {
            if (ctrl.InvokeRequired)
            {
                SetColorDelegate del = new SetColorDelegate(SetColor);
                ctrl.Invoke(del, ctrl, c, back);
            }
            else
            {
                if (back)
                    ctrl.BackColor = c;
                else
                    ctrl.ForeColor = c;
            }
        }

        private void ItemDumpFinished()
        {
            if (itemsGridView.InvokeRequired)
            {
                itemsGridView.Invoke((MethodInvoker)delegate { readItems(); });
            }
            else
            {
                readItems();
            }
        }

        #endregion fucking thread safety

        #region Remote control

        // Test for remote control

        public void sendButton(uint command)
        {
            byte[] buttonByte = BitConverter.GetBytes(command);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
        }

        // A button
        private void manualA_Click(object sender, EventArgs e)
        {
            sendButton(keyA);
            timer2.Start();
        }

        // B button
        private void manualB_Click(object sender, EventArgs e)
        {
            sendButton(keyB);
            timer2.Start();
        }

        // X button
        private void manualX_Click(object sender, EventArgs e)
        {
            sendButton(keyX);
            timer2.Start();
        }

        // Y Button
        private void manualY_Click(object sender, EventArgs e)
        {
            sendButton(keyY);
            timer2.Start();
        }

        //D-pad
        private void manualDUp_Click(object sender, EventArgs e)
        {
            sendButton(DpadUP);
            timer2.Start();
        }

        private void ManualDDown_Click(object sender, EventArgs e)
        {
            sendButton(DpadDOWN);
            timer2.Start();
        }

        private void manualDLeft_Click(object sender, EventArgs e)
        {
            sendButton(DpadLEFT);
            timer2.Start();
        }

        private void manualDRight_Click(object sender, EventArgs e)
        {
            sendButton(DpadRIGHT);
            timer2.Start();
        }

        // Start button
        private void manualStart_Click(object sender, EventArgs e)
        {
            sendButton(keySTART);
            timer2.Start();
        }

        //Select button
        private void manualSelect_Click(object sender, EventArgs e)
        {
            sendButton(keySELECT);
            timer2.Start();
        }

        //L button
        private void manualL_Click(object sender, EventArgs e)
        {
            sendButton(keyL);
            timer2.Start();
        }

        //R button
        private void manualR_Click(object sender, EventArgs e)
        {
            sendButton(keyR);
            timer2.Start();
        }

        // Soft-reset
        private async void manualSR_Click(object sender, EventArgs e)
        {
            DialogResult dialogr = MessageBox.Show("Are you sure that you want to send a soft-reset command? The application will automatically disconnect from the game afterwards.", "Remote Control", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogr == DialogResult.Yes)
            {
                sendButton(softReset);
                timer2.Start();
                await Task.Delay(500);
                buttonDisconnect.PerformClick();
            }
        }

        // Update touch coordenates
        public uint gethexcoord(decimal Xvalue, decimal Yvalue)
        {
            uint hexX = Convert.ToUInt32(Math.Round(Xvalue * 0xFFF / 319));
            uint hexY = Convert.ToUInt32(Math.Round(Yvalue * 0xFFF / 239));
            return 0x01000000 + hexY * 0x1000 + hexX;
        }

        public void sendTouch(uint coord)
        {
            byte[] buttonByte = BitConverter.GetBytes(coord);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
        }

        // Send manual touch command
        private void manualTouch_Click(object sender, EventArgs e)
        {
            sendTouch(gethexcoord(touchX.Value, touchY.Value));
            timer2.Start();
        }

        // Release buttons and touchscreen
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            sendButton(nokey);
            sendTouch(notouch);
        }

        #endregion Remote control

        #region Bots

        // R/W handlers
        public void handleMemoryRead(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            lastmemoryread = BitConverter.ToUInt32(args.data, 0);
            SetText(readResult, lastmemoryread.ToString("X8"));
        }

        async Task<int> waitNTRread(uint address)
        {
            lastmemoryread = 0;
            lastlog = "";
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
            waitingForData.Add(Program.scriptHelper.data(address, 0x04, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount == timeout * 10)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        async Task<int> waitbutton(uint key)
        {
            // Get and send hex coordinates
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(key);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Free the buttons
                lastlog = "";
                buttonByte = BitConverter.GetBytes(nokey);
                Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
                // Timeout 2
                for (readcount = 0; readcount < timeout * 10; readcount++)
                {
                    await Task.Delay(100);
                    if (lastlog.Contains("finished"))
                    {
                        break;
                    }
                }
                if (readcount >= timeout * 10)
                { // If not response in two seconds, return timeout
                    return -1;
                }
                else
                { // Return sucess
                    return 0;
                }
            }
        }

        async Task<int> quickbuton(uint key)
        {
            byte[] buttonByte = BitConverter.GetBytes(key);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            await Task.Delay(20);
            buttonByte = BitConverter.GetBytes(nokey);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            return 0;
        }

        async Task<int> waitholdbutton(uint key)
        {
            // Get and send hex coordinates
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(key);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Return sucess
                return 0;
            }
        }

        async Task<int> waitfreebutton()
        {
            // Get and send hex coordinates
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(nokey);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Return sucess
                return 0;
            }
        }

        async Task<int> waittouch(uint Xcoord, uint Ycoord)
        {
            // Get and send hex coordinates
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Free the touch screen
                lastlog = "";
                buttonByte = BitConverter.GetBytes(notouch);
                Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
                // Timeout 2
                for (readcount = 0; readcount < timeout * 10; readcount++)
                {
                    await Task.Delay(100);
                    if (lastlog.Contains("finished"))
                    {
                        break;
                    }
                }
                if (readcount >= timeout * 10)
                { // If not response in two seconds, return timeout
                    return -1;
                }
                else
                { // Return sucess
                    return 0;
                }
            }
        }

        async Task<int> waitholdtouch(uint Xcoord, uint Ycoord)
        {
            // Get and send hex coordinates
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Return sucess
                return 0;
            }
        }

        async Task<int> waitfreetouch()
        {
            // Get and send hex coordinates
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Return sucess
                return 0;
            }
        }

        async Task<int> waitsoftreset()
        {
            // Send soft-reset instruction
            lastlog = "";
            byte[] buttonByte = BitConverter.GetBytes(softReset);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            // Timeout 1
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10)
            { // If not response in two seconds, return timeout
                return -1;
            }
            else
            { // Wait for app restart
                lastlog = "";
                buttonByte = BitConverter.GetBytes(nokey);
                Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
                // Timeout 2
                for (readcount = 0; readcount < timeout; readcount++)
                {
                    await Task.Delay(1000);
                    if (lastlog.Contains("patching smdh") || lastlog.Contains("finished"))
                    {
                        break;
                    }
                }
                if (readcount == timeout)
                { // If not response return timeout
                    return -1;
                }
                else
                { // Return sucess
                    return 0;
                }
            }
        }

        private void stopBotButton_Click(object sender, EventArgs e)
        {
            botStop = true;
            stopBotButton.Enabled = false;
        }

        // Filter handlers
        public bool FilterCheck(DataGridView filters)
        {
            if (filters.Rows.Count > 0)
            {
                currentfilter = 0;
                int failedtests = 0;
                int perfectIVs = 0;
                foreach (DataGridViewRow row in filters.Rows)
                {
                    currentfilter++;
                    Addlog("Analyze pokémon using filter # " + currentfilter);
                    failedtests = 0;
                    // Test shiny
                    if ((int)row.Cells[0].Value == 1)
                    {
                        if (dumpedPKHeX.isShiny)
                        {
                            Addlog("Shiny: PASS");
                        }
                        else
                        {
                            Addlog("Shiny: FAIL");
                            failedtests++;
                        }
                    }
                    else
                    {
                        Addlog("Shiny: Don't care");
                    }
                    // Test nature
                    if ((int)row.Cells[1].Value < 0 || dumpedPKHeX.Nature == (int)row.Cells[1].Value)
                    {
                        Addlog("Nature: PASS");
                    }
                    else
                    {
                        Addlog("Nature: FAIL");
                        failedtests++;
                    }
                    // Test Ability
                    if ((int)row.Cells[2].Value < 0 || (dumpedPKHeX.Ability - 1) == (int)row.Cells[2].Value)
                    {
                        Addlog("Ability: PASS");
                    }
                    else
                    {
                        Addlog("Ability: FAIL");
                        failedtests++;
                    }
                    // Test Hidden Power
                    if ((int)row.Cells[3].Value < 0 || getHiddenPower() == (int)row.Cells[3].Value)
                    {
                        Addlog("Hidden Power: PASS");
                    }
                    else
                    {
                        Addlog("Hidden Power: FAIL");
                        failedtests++;
                    }
                    // Test Gender
                    if ((int)row.Cells[4].Value < 0 || (int)row.Cells[4].Value == dumpedPKHeX.Gender)
                    {
                        Addlog("Gender: PASS");
                    }
                    else
                    {
                        Addlog("Gender: FAIL");
                        failedtests++;
                    }
                    // Test HP
                    if (IVCheck((int)row.Cells[5].Value, dumpedPKHeX.IV_HP, (int)row.Cells[6].Value))
                    {
                        Addlog("Hit Points IV: PASS");
                    }
                    else
                    {
                        Addlog("Hit Points IV: FAIL");
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_HP == 31)
                    {
                        perfectIVs++;
                    }
                    // Test Atk
                    if (IVCheck((int)row.Cells[7].Value, dumpedPKHeX.IV_ATK, (int)row.Cells[8].Value))
                    {
                        Addlog("Attack IV: PASS");
                    }
                    else
                    {
                        Addlog("Attack IV: FAIL");
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_ATK == 31)
                    {
                        perfectIVs++;
                    }
                    // Test Def
                    if (IVCheck((int)row.Cells[9].Value, dumpedPKHeX.IV_DEF, (int)row.Cells[10].Value))
                    {
                        Addlog("Defense IV: PASS");
                    }
                    else
                    {
                        Addlog("Defense IV: FAIL");
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_DEF == 31)
                    {
                        perfectIVs++;
                    }
                    // Test SpA
                    if (IVCheck((int)row.Cells[11].Value, dumpedPKHeX.IV_SPA, (int)row.Cells[12].Value))
                    {
                        Addlog("Special Attack IV: PASS");
                    }
                    else
                    {
                        Addlog("Special Attack IV: FAIL");
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_SPA == 31)
                    {
                        perfectIVs++;
                    }
                    // Test SpD
                    if (IVCheck((int)row.Cells[13].Value, dumpedPKHeX.IV_SPD, (int)row.Cells[14].Value))
                    {
                        Addlog("Special Defense IV: PASS");
                    }
                    else
                    {
                        Addlog("Special Defense IV: FAIL");
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_SPD == 31)
                    {
                        perfectIVs++;
                    }
                    // Test Spe
                    if (IVCheck((int)row.Cells[15].Value, dumpedPKHeX.IV_SPE, (int)row.Cells[16].Value))
                    {
                        Addlog("Speed IV: PASS");
                    }
                    else
                    {
                        Addlog("Speed IV: FAIL");
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_SPE == 31)
                    {
                        perfectIVs++;
                    }
                    // Test Perfect IVs
                    if (IVCheck((int)row.Cells[17].Value, perfectIVs, (int)row.Cells[18].Value))
                    {
                        Addlog("Perfect IVs: PASS");
                    }
                    else
                    {
                        Addlog("Perfect IVs: FAIL");
                        failedtests++;
                    }
                    if (failedtests == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IVCheck(int refiv, int actualiv, int logic)
        {
            switch (logic)
            {
                case 0: // Greater or equal
                    if (actualiv >= refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 1: // Greater
                    if (actualiv > refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2: // Equal
                    if (actualiv == refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3: // Less
                    if (actualiv < refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 4: // Less or equal
                    if (actualiv <= refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 5: // Different
                    if (actualiv >= refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 6: // Even
                    if (actualiv % 2 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 7: // Odd
                    if (actualiv % 2 == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }

        private void filterAdd_Click(object sender, EventArgs e)
        {
            filterList.Rows.Add(filterShiny.Checked ? 1 : 0, Convert.ToInt32(filterNature.SelectedIndex), Convert.ToInt32(filterAbility.SelectedIndex), Convert.ToInt32(filterHPtype.SelectedIndex), Convert.ToInt32(filterGender.SelectedIndex), Convert.ToInt32(filterHPvalue.Value), Convert.ToInt32(filterHPlogic.SelectedIndex), Convert.ToInt32(filterATKvalue.Value), Convert.ToInt32(filterATKlogic.SelectedIndex), Convert.ToInt32(filterDEFvalue.Value), Convert.ToInt32(filterDEFlogic.SelectedIndex), Convert.ToInt32(filterSPAvalue.Value), Convert.ToInt32(filterSPAlogic.SelectedIndex), Convert.ToInt32(filterSPDvalue.Value), Convert.ToInt32(filterSPDlogic.SelectedIndex), Convert.ToInt32(filterSPEvalue.Value), Convert.ToInt32(filterSPElogic.SelectedIndex), Convert.ToInt32(filterPerIVvalue.Value), Convert.ToInt32(filterPerIVlogic.SelectedIndex));
        }

        private void filterRemove_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedRows.Count > 0 && filterList.Rows.Count > 0)
            {
                filterList.Rows.RemoveAt(filterList.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("There is no filter selected.");
            }
        }

        private void filterRead_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedRows.Count > 0)
            {
                if ((int)filterList.SelectedRows[0].Cells[0].Value == 1)
                {
                    SetChecked(filterShiny, true);
                }
                else
                {
                    SetChecked(filterShiny, false);
                }
                SetSelectedIndex(filterNature, (int)filterList.SelectedRows[0].Cells[1].Value);
                SetSelectedIndex(filterAbility, (int)filterList.SelectedRows[0].Cells[2].Value);
                SetSelectedIndex(filterHPtype, (int)filterList.SelectedRows[0].Cells[3].Value);
                SetSelectedIndex(filterGender, (int)filterList.SelectedRows[0].Cells[4].Value);
                SetValue(filterHPvalue, (int)filterList.SelectedRows[0].Cells[5].Value);
                SetSelectedIndex(filterHPlogic, (int)filterList.SelectedRows[0].Cells[6].Value);
                SetValue(filterATKvalue, (int)filterList.SelectedRows[0].Cells[7].Value);
                SetSelectedIndex(filterATKlogic, (int)filterList.SelectedRows[0].Cells[8].Value);
                SetValue(filterDEFvalue, (int)filterList.SelectedRows[0].Cells[9].Value);
                SetSelectedIndex(filterDEFlogic, (int)filterList.SelectedRows[0].Cells[10].Value);
                SetValue(filterSPAvalue, (int)filterList.SelectedRows[0].Cells[11].Value);
                SetSelectedIndex(filterSPAlogic, (int)filterList.SelectedRows[0].Cells[12].Value);
                SetValue(filterSPDvalue, (int)filterList.SelectedRows[0].Cells[13].Value);
                SetSelectedIndex(filterSPDlogic, (int)filterList.SelectedRows[0].Cells[14].Value);
                SetValue(filterSPEvalue, (int)filterList.SelectedRows[0].Cells[15].Value);
                SetSelectedIndex(filterSPElogic, (int)filterList.SelectedRows[0].Cells[16].Value);
                SetValue(filterPerIVvalue, (int)filterList.SelectedRows[0].Cells[17].Value);
                SetSelectedIndex(filterPerIVlogic, (int)filterList.SelectedRows[0].Cells[18].Value);
            }
            else
            {
                MessageBox.Show("There is no filter selected.");
            }
        }

        private void filterSave_Click(object sender, EventArgs e)
        {
            string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
            (new System.IO.FileInfo(folderPath)).Directory.Create();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
            saveFileDialog1.Title = "Save a filter set";
            saveFileDialog1.InitialDirectory = folderPath;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var filters = new StringBuilder();
                foreach (DataGridViewRow row in filterList.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    filters.AppendLine(string.Join(",", cells.Select(cell => cell.Value).ToArray()));
                }
                File.WriteAllText(saveFileDialog1.FileName, filters.ToString());
                MessageBox.Show("Breeding Filters saved");
            }
        }

        private void filterLoad_Click(object sender, EventArgs e)
        {
            string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
            (new System.IO.FileInfo(folderPath)).Directory.Create();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
            openFileDialog1.Title = "Select a filter set";
            openFileDialog1.InitialDirectory = folderPath;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                filterList.Rows.Clear();
                List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                foreach (int[] row in rows)
                {
                    filterList.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                }
                MessageBox.Show("Filter set loaded");
            }
        }

        private void bFilterLoad_Click(object sender, EventArgs e)
        {
            string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
            (new System.IO.FileInfo(folderPath)).Directory.Create();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
            openFileDialog1.Title = "Select a filter set";
            openFileDialog1.InitialDirectory = folderPath;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                filterList.Rows.Clear();
                List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                foreach (int[] row in rows)
                {
                    filterBreeding.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                }
                MessageBox.Show("Breeding Filters loaded");
            }
        }

        private void srFilterLoad_Click(object sender, EventArgs e)
        {
            string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
            (new System.IO.FileInfo(folderPath)).Directory.Create();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
            openFileDialog1.Title = "Select a filter set";
            openFileDialog1.InitialDirectory = folderPath;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                filterList.Rows.Clear();
                List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                foreach (int[] row in rows)
                {
                    filtersSoftReset.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                }
                MessageBox.Show("Soft-reset Filters loaded");
            }
        }

        // Wonder Trade bot
        private async void RunWTbot_Click(object sender, EventArgs e)
        {
            // Show warning
            DialogResult dialogResult = MessageBox.Show("This scirpt will try to Wonder Trade " + WTtradesNo.Value + " pokémon, starting from the slot " + WTSlot.Value + " of box " + WTBox.Value + ". Remember to read the wiki for this bot in GitHub before starting.\r\n\r\nDo you want to continue?", "Wonder Trade Bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.OK && WTtradesNo.Value > 0)
            { // Initialize bot
                botWorking = true;
                botStop = false;
                botState = 0;
                radioBoxes.Checked = true;
                onlyView.Checked = true;
                disableControls();
                stopBotButton.Enabled = true;
                txtLog.Clear();
            }
            else
            { // Exit bot
                botStop = true;
                return;
            }

            // Local variables
            Task<int> waitNTRtask;
            int waitresult = 0;
            int waittimeout = 0;
            int currentslot = Convert.ToInt16(WTSlot.Value - 1);
            int currentbox = Convert.ToInt16(WTBox.Value - 1);
            bool boxchange = true;
            string oldPID = "";

            // Bot procedure
            while (!botStop)
            { // Halts bot if Stop Bot button was click
                switch (botState)
                {
                    case 0:
                        Addlog("Test if the PSS menu is shown");
                        waitNTRtask = waitNTRread(psssmenu1Off);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread >= psssmenu1OUT && lastmemoryread < psssmenu1OUT + 0x10000)
                        {
                            MessageBox.Show("Please go to the PSS menu and try again.");
                            botState = -1;
                        }
                        else if (lastmemoryread >= psssmenu1IN && lastmemoryread < psssmenu1IN + 0x10000)
                        {
                            botState = 1;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 1:
                        Addlog("Reading Pokémon data from box " + (currentbox + 1).ToString() + ", slot " + (currentslot + 1).ToString());
                        dPID.Clear();
                        lastlog = "";
                        SetValue(boxDump, currentbox + 1);
                        SetValue(slotDump, currentslot + 1);
                        dumpPokemon.Enabled = true;
                        dumpPokemon.PerformClick();
                        dumpPokemon.Enabled = false;
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10 && dPID.Text.Length > 0)
                        {
                            botState = 2;
                        }
                        else if (waittimeout < timeout * 10 && dPID.Text.Length < 1)
                        { // Empty space
                            Addlog("Space is empty");
                            currentslot++;
                            if (currentslot >= 30)
                            {
                                currentslot = 0;
                                currentbox++;
                                boxchange = true;
                                if (currentbox >= 31)
                                {
                                    currentbox = 0;
                                }
                            }
                            WTtradesNo.Value--;
                            if (WTtradesNo.Value > 0)
                            {
                                botState = 1;
                            }
                            else
                            { // If no trades remaining, exit
                                botState = -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 2:
                        Addlog("Press Wonder Trade button");
                        waitNTRtask = waittouch(240, 120);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 3;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = -1;
                        }
                        break;
                    case 3:
                        Addlog("Test if the save screen is shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        { // Wait two seconds
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(savescrnOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= savescrnIN && lastmemoryread < savescrnIN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = 4;
                        }
                        else if (lastmemoryread >= savescrnOUT && lastmemoryread < savescrnOUT + 0x10000)
                        { // Still on the PSS menu
                            botState = 2;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 4:
                        Addlog("Press Yes");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 5;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = -1;
                        }
                        break;
                    case 5:
                        Addlog("Test if Wonder Trade screen is shown");
                        for (waittimeout = 0; waittimeout < timeout; waittimeout++)
                        { // Wait ten seconds
                            await Task.Delay(1000);
                            waitNTRtask = waitNTRread(wtconfirmationOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtconfirmationIN && lastmemoryread < wtconfirmationIN + 0x10000)
                            { //&& lastmemoryread < wtconfirmationIN + 10000
                                break;
                            }
                        }
                        if (waittimeout < timeout)
                        {
                            botState = 6;
                        }
                        else if (lastmemoryread >= wtconfirmationOUT && lastmemoryread < wtconfirmationOUT + 0x10000)
                        { // Still on the save screen
                            botState = 4;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 6:
                        Addlog("Touch Yes");
                        waitNTRtask = waittouch(160, 100);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 7;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = -1;
                        }
                        break;
                    case 7:
                        Addlog("Test if the boxes are shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxesOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtboxesIN && lastmemoryread < wtboxesIN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = 8;
                        }
                        else if (lastmemoryread >= wtboxesOUT && lastmemoryread < wtboxesOUT + 0x10000)
                        { // Still on the confirmation screen
                            botState = 6;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 8:
                        if (boxchange)
                        {
                            botState = 9;
                            boxchange = false;
                        }
                        else
                        {
                            botState = 14;
                        }
                        break;
                    case 9:
                        Addlog("Touch Box View");
                        await Task.Delay(500);
                        waitNTRtask = waittouch(30, 220);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 10;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = -1;
                        }
                        break;
                    case 10:
                        Addlog("Test if box view is shown");
                        await Task.Delay(500);
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxviewOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtboxviewIN && lastmemoryread < wtboxviewIN + wtboxviewRange)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = 11;
                        }
                        else if (lastmemoryread >= wtboxviewOUT && lastmemoryread < wtboxviewOUT + wtboxviewRange)
                        { // Still on the boxes
                            botState = 9;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 11:
                        Addlog("Touch New Box");
                        waitNTRtask = waittouch(boxXcord[currentbox], boxYcord[currentbox]);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 12;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = -1;
                        }
                        break;
                    case 12:
                        Addlog("Select New Box");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 13;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = -1;
                        }
                        break;
                    case 13:
                        Addlog("Test if box view is not shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxviewOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtboxviewOUT && lastmemoryread < wtboxviewOUT + wtboxviewRange)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = 14;
                        }
                        else if (lastmemoryread >= wtboxviewIN && lastmemoryread < wtboxviewIN + wtboxviewRange)
                        { // Still on the box view
                            botState = 11;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 14:
                        Addlog("Touch Pokémon");
                        await Task.Delay(500);
                        waitNTRtask = waittouch(boxpokeXcord[currentslot], boxpokeYcord[currentslot]);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 15;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = -1;
                        }
                        break;
                    case 15:
                        Addlog("Select Trade");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 16;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = -1;
                        }
                        break;
                    case 16:
                        Addlog("Select Yes");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = 17;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = -1;
                        }
                        break;
                    case 17:
                        Addlog("Test if the boxes are not shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxesOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtboxesOUT && lastmemoryread < wtboxesOUT + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = 18;
                        }
                        else if (lastmemoryread >= wtboxesOUT && lastmemoryread < wtboxesOUT + 0x10000)
                        { // Still on the box view
                            botState = 14;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 18:
                        Addlog("Wait for trade");
                        for (waittimeout = 0; waittimeout < 30; waittimeout++)
                        { // Wait 60 seconds
                            oldPID = dPID.Text;
                            lastlog = "";
                            dumpPokemon.Enabled = true;
                            dumpPokemon.PerformClick();
                            dumpPokemon.Enabled = false;
                            await Task.Delay(2000);
                            if (lastlog.Contains("finished") && dPID.Text != oldPID)
                            {
                                break;
                            }
                        }
                        if (waittimeout < 30)
                        {
                            botState = 19;
                        }
                        else
                        { // Timeout, not trade partner was found
                            botState = 21;
                        }
                        break;
                    case 19:
                        Addlog("Wait 30 seconds");
                        await Task.Delay(30000);
                        botState = 20;
                        break;
                    case 20:
                        Addlog("Test if back to the PSS menu");
                        for (waittimeout = 0; waittimeout < 45; waittimeout++)
                        { // Wait during 90 seconds
                            await Task.Delay(2000);
                            waitNTRtask = waitNTRread(psssmenu1Off);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= psssmenu1IN && lastmemoryread < psssmenu1IN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < 45)
                        { // Calculate next slot and return to begining
                            currentslot++;
                            if (currentslot >= 30)
                            {
                                currentslot = 0;
                                currentbox++;
                                boxchange = true;
                                if (currentbox >= 31)
                                {
                                    currentbox = 0;
                                }
                            }
                            WTtradesNo.Value--;
                            if (WTtradesNo.Value > 0)
                            {
                                botState = 1;
                            }
                            else
                            { // If no trades remaining, exit
                                botState = -1;
                            }
                        }
                        else if (lastmemoryread >= psssmenu1OUT && lastmemoryread < psssmenu1OUT + 0x10000)
                        { // Still waiting to complete trade
                            botState = 20;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    case 21:
                        Addlog("No trade partner is found");
                        for (waittimeout = 0; waittimeout < 30; waittimeout++)
                        { // Wait during 30 seconds
                            await Task.Delay(1000);
                            waitNTRtask = waitNTRread(psssmenu1Off);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= psssmenu1OUT && lastmemoryread < psssmenu1OUT + 0x10000)
                            {
                                await Task.Delay(2000);
                                break;
                            }
                            else
                            { // Press A button
                                waitNTRtask = waitbutton(keyA);
                                waitresult = await waitNTRtask;
                                if (waitresult != 0)
                                {
                                    MessageBox.Show(buttonerror);
                                    waittimeout = 45;
                                    botState = -1;
                                    break;
                                }
                            }
                        }
                        if (waittimeout < 30)
                        { // Return to begining
                            botState = 1;
                        }
                        else if (lastmemoryread >= psssmenu1OUT && lastmemoryread < psssmenu1OUT + 0x10000)
                        { // Still waiting to complete trade
                            botState = 21;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = -1;
                        }
                        break;
                    default:
                        botStop = true;
                        break;
                }
            }

            // Finish bot
            enableControls();
            stopBotButton.Enabled = false;
            botWorking = false;
            MessageBox.Show("Finished", "Wonder Trade Bot");
        }

        // Soft-reset bot
        public enum srbotstates { botstart, pssmenush, fixwifi, touchpssset, testpssset, touchpssdis, testpssdis, touchpssconf, testpssout, returncontrol, touchsave, testsave, saveconf, saveout, typesr, trigger, readopp, filter, testspassed, testshiny, testnature, testhp, testatk, testdef, testspa, testspd, testspe, testhdnpwr, testability, testgender, alltestsok, softreset, skipintro, skiptitle, startgame, reconnect, tms_start, tms_cont1, tms_cont2, tms_cont3, tst_start, tst_cont, tev_start, tev_cont1, tev_cont2, tev_cont3, tev_cont4, tev_cont5, tev_check, twk_start, botexit };

        private async void RunLSRbot_Click(object sender, EventArgs e)
        {
            // Show warning
            string typemessage;
            string resumemessage;
            switch (typeLSR.SelectedIndex)
            {
                case 0:
                    typemessage = "Regular - Make sure you are in front of the pokémon.";
                    resumemessage = "In front of pokémon, will press A to trigger start the battle";
                    break;
                case 1:
                    typemessage = "Mirage Spot - Make sure you are in front of the hole.";
                    resumemessage = "In front of hole, will press A to trigger dialog";
                    break;
                case 2:
                    typemessage = "Event - Make sure you are in front of the lady in the Pokémon Center. Also, you must only have one pokémon in your party.";
                    resumemessage = "In front of the lady, will press A to trigger dialog";
                    break;
                case 3:
                    typemessage = "Groudon/Kyogre - You must disable the PSS communications manually due PokéNav malfunction. Go in front of Groudon/Kyogre and save game before starting the battle.";
                    resumemessage = "In front of Groudon/Kyogre, will press A to trigger dialog";
                    break;
                case 4:
                    typemessage = "Walk - Make sure you are one step south of the pokémon.";
                    resumemessage = "One step south of the pokémon, will press up to trigger dialog";
                    break;
                default:
                    typemessage = "No type - Select one type of soft-reset and try again.";
                    resumemessage = "";
                    break;
            }
            DialogResult dialogResult = MessageBox.Show("This bot will trigger an encounter with a pokémon, and soft-reset if it doesn't match with the loaded filters.\r\n\r\nType: " + typemessage + "\r\nResume: " + resumemessage + "\r\n\r\nPlease read the wiki at GitHub before using this bot. Do you want to continue?", "Soft-reset bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.OK)
            { // Initialize bot
                botWorking = true;
                botStop = false;
                botState = (int)srbotstates.botstart;
                onlyView.Checked = true;
                radioOpponent.Checked = true;
                disableControls();
                stopBotButton.Enabled = true;
                txtLog.Clear();
            }
            else
            { // Exit bot
                botStop = true;
                return;
            }

            // Local Variables
            Task<int> waitNTRtask;
            int waitresult = 0;
            int waittimeout = 0;
            int currentslot = Convert.ToInt16(WTSlot.Value - 1);
            int currentbox = Convert.ToInt16(WTBox.Value - 1);
            int resetNo = 0;

            // Bot procedure
            while (!botStop)
            { // Halts bot if Stop Bot button was click
                switch (botState)
                {
                    case (int)srbotstates.botstart:
                        Addlog("Bot start");
                        switch (typeLSR.SelectedIndex)
                        {
                            case 0:
                                if (resumeLSR.Checked)
                                {
                                    botState = (int)srbotstates.tst_start;
                                }
                                else
                                {
                                    botState = (int)srbotstates.pssmenush;
                                }
                                break;
                            case 1:
                                if (resumeLSR.Checked)
                                {
                                    botState = (int)srbotstates.tms_start;
                                }
                                else
                                {
                                    botState = (int)srbotstates.pssmenush;
                                }
                                break;
                            case 2:
                                if (resumeLSR.Checked)
                                {
                                    botState = (int)srbotstates.tev_start;
                                    radioParty.Checked = true;
                                    SetValue(boxDump, 2);
                                }
                                else
                                {
                                    botState = (int)srbotstates.pssmenush;
                                    radioParty.Checked = true;
                                    SetValue(boxDump, 2);
                                    resetNo = -1;
                                }
                                break;
                            case 3:
                                if (resumeLSR.Checked)
                                {
                                    botState = (int)srbotstates.tst_start;
                                }
                                else
                                {
                                    botState = (int)srbotstates.fixwifi;
                                }
                                break;
                            case 4:
                                if (resumeLSR.Checked)
                                {
                                    botState = (int)srbotstates.twk_start;
                                }
                                else
                                {
                                    botState = (int)srbotstates.pssmenush;
                                }
                                break;
                            default:
                                botState = (int)srbotstates.botexit;
                                break;
                        }
                        break;
                    case (int)srbotstates.pssmenush:
                        Addlog("Test if the PSS menu is shown");
                        waitNTRtask = waitNTRread(psssmenu1Off);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread >= psssmenu1OUT && lastmemoryread < psssmenu1OUT + 0x10000)
                        {
                            MessageBox.Show("Please go to the PSS menu and try again.");
                            botState = (int)srbotstates.botexit;
                        }
                        else if (lastmemoryread >= psssmenu1IN && lastmemoryread < psssmenu1IN + 0x10000)
                        {
                            botState = (int)srbotstates.fixwifi;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.fixwifi:
                        Addlog("Fix Wi-Fi");
                        byte[] buttonByte = BitConverter.GetBytes(0x4770);
                        Program.scriptHelper.write(0x0105AE4, buttonByte, 0x1A);
                        for (waittimeout = 0; waittimeout < timeout; waittimeout++)
                        {
                            lastlog = "";
                            await Task.Delay(1000);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout)
                        {
                            if (typeLSR.SelectedIndex == 3)
                            {
                                botState = (int)srbotstates.tst_start;
                            }
                            else
                            {
                                botState = (int)srbotstates.touchpssset;
                            }
                        }
                        else
                        {
                            MessageBox.Show(writeerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.touchpssset:
                        Addlog("Touch PSS settings");
                        waitNTRtask = waittouch(240, 180);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.testpssset;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.testpssset:
                        Addlog("Test if the PSS setings are shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(pssettingsOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= pssettingsIN && lastmemoryread < pssettingsIN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)srbotstates.touchpssdis;
                        }
                        else if (lastmemoryread >= pssettingsOUT && lastmemoryread < pssettingsOUT + 0x10000)
                        { // Still on the PSS menu
                            botState = (int)srbotstates.touchpssset;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.touchpssdis:
                        Addlog("Touch Disable PSS communication");
                        waitNTRtask = waittouch(160, pssdisableY);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.testpssdis;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.testpssdis:
                        Addlog("Test if PSS disable confirmation appears");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(pssdisableOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= pssdisableIN && lastmemoryread < pssdisableIN + 0x100000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)srbotstates.touchpssconf;
                        }
                        else if (lastmemoryread >= pssdisableOUT && lastmemoryread < pssdisableOUT + 0x100000)
                        { // Still on PSS settings
                            botState = (int)srbotstates.touchpssdis;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.touchpssconf:
                        Addlog("Touch Yes");
                        waitNTRtask = waittouch(160, 120);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.testpssout;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.testpssout:
                        Addlog("Test if back to PSS screen");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(pssettingsOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= pssettingsOUT && lastmemoryread < pssettingsOUT + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)srbotstates.returncontrol;
                        }
                        else if (lastmemoryread >= pssettingsIN && lastmemoryread < pssettingsIN + 0x10000)
                        { // Still on the confirmation screen
                            botState = (int)srbotstates.touchpssconf;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.returncontrol:
                        Addlog("Return contol to character");
                        await Task.Delay(1000);
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.touchsave;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.touchsave:
                        Addlog("Touch Save button");
                        waitNTRtask = waittouch(220, 220);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.testsave;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.testsave:
                        Addlog("Test if the save screen is shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(savescrnOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= savescrnIN && lastmemoryread < savescrnIN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)srbotstates.saveconf;
                        }
                        else if (lastmemoryread >= savescrnOUT && lastmemoryread < savescrnOUT + 0x10000)
                        { // Still on the PSS menu
                            botState = (int)srbotstates.touchsave;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.saveconf:
                        Addlog("Press Yes");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.saveout;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.saveout:
                        Addlog("Test if out from save screen");
                        for (waittimeout = 0; waittimeout < timeout; waittimeout++)
                        { // Wait two seconds
                            await Task.Delay(1000);
                            waitNTRtask = waitNTRread(savescrnOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= savescrnOUT && lastmemoryread < savescrnOUT + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout)
                        {
                            if (typeLSR.SelectedIndex == 2)
                            {
                                Addlog("Soft-reset for party data intialize");
                                botState = (int)srbotstates.softreset;
                            }
                            else
                            {
                                botState = (int)srbotstates.typesr;
                            }
                        }
                        else if (lastmemoryread >= savescrnIN && lastmemoryread < savescrnIN + 0x10000)
                        { // Still on the save screen
                            botState = (int)srbotstates.saveconf;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.typesr:
                        switch (typeLSR.SelectedIndex)
                        {
                            case 0:
                                botState = (int)srbotstates.tst_start;
                                break;
                            case 1:
                                botState = (int)srbotstates.tms_start;
                                break;
                            case 2:
                                botState = (int)srbotstates.tev_start;
                                break;
                            case 3:
                                botState = (int)srbotstates.tst_start;
                                break;
                            case 4:
                                botState = (int)srbotstates.twk_start;
                                break;
                            default:
                                botState = (int)srbotstates.trigger;
                                break;
                        }
                        break;
                    case (int)srbotstates.trigger:
                        Addlog("Try to trigger encounter");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.readopp;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.readopp:
                        Addlog("Try to read opponent");
                        dPID.Clear();
                        lastlog = "";
                        dumpPokemon.Enabled = true;
                        dumpPokemon.PerformClick();
                        dumpPokemon.Enabled = false;
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10 && dPID.Text.Length < 1)
                        { // Battle not triggered yet
                            botState = (int)srbotstates.trigger;
                        }
                        else if (waittimeout < timeout * 10 && dPID.Text.Length > 0)
                        { // Battle triggered, data received
                            botState = (int)srbotstates.filter;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.filter:
                        bool testsok = FilterCheck(filtersSoftReset);
                        if (testsok)
                        {
                            botState = (int)srbotstates.testspassed;
                        }
                        else
                        {
                            botState = (int)srbotstates.softreset;
                        }
                        break;
                    case (int)srbotstates.testspassed:
                        Addlog("All tests passed!");
                        botState = (int)srbotstates.botexit; // All tests passed
                        break;
                    case (int)srbotstates.softreset:
                        resetNo++;
                        Addlog("Sof-reset #" + resetNo.ToString());
                        waitNTRtask = waitsoftreset();
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.skipintro;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.skipintro:
                        await Task.Delay(10000);
                        Addlog("Skip intro cutscene");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            if (game == GameType.X || game == GameType.Y)
                            {
                                botState = (int)srbotstates.startgame;
                            }
                            else
                            {
                                botState = (int)srbotstates.skiptitle;
                            }
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.skiptitle:
                        await Task.Delay(3000);
                        Addlog("Skip title screen");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.startgame;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.startgame:
                        await Task.Delay(4000);
                        Addlog("Start game");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.reconnect;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.reconnect:
                        Addlog("Reconnect");
                        Program.scriptHelper.connect(host.Text, 8000);
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(500);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            await Task.Delay(2000);
                            botState = (int)srbotstates.typesr;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tms_start:
                        Addlog("Start dialog");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tms_cont1;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tms_cont1:
                        Addlog("Continue dialog (A mysterious ring...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tms_cont2;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tms_cont2:
                        Addlog("Continue dialog (Would you like...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tms_cont3;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tms_cont3:
                        Addlog("Select yes");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.readopp;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tst_start:
                        Addlog("Trigger encounter");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tst_cont;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tst_cont:
                        Addlog("Skip pokemon dialog");
                        await Task.Delay(1000);
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.readopp;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tev_start:
                        Addlog("Talk to lady");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tev_cont1;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tev_cont1:
                        Addlog("Continue dialog (Good day!...");
                        waitNTRtask = waitbutton(keyB);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tev_cont2;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tev_cont2:
                        Addlog("Continue dialog (I've got a...");
                        waitNTRtask = waitbutton(keyB);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tev_cont3;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tev_cont3:
                        Addlog("Wait for fanfare");
                        await Task.Delay(1500);
                        waitNTRtask = waitbutton(keyB);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tev_cont4;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tev_cont4:
                        Addlog("Exit dialog");
                        waitNTRtask = waitbutton(keyB);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.tev_check;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.tev_check:
                        Addlog("Try to read party");
                        dPID.Clear();
                        lastlog = "";
                        await Task.Delay(2000);
                        dumpPokemon.Enabled = true;
                        dumpPokemon.PerformClick();
                        dumpPokemon.Enabled = false;
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10 && dPID.Text.Length > 0)
                        { // Pokemon received
                            botState = (int)srbotstates.filter;
                        }
                        else if (waittimeout < timeout * 10 && dPID.Text.Length < 1)
                        { // Pokémon not received yet
                            botState = (int)srbotstates.tev_cont4;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)srbotstates.twk_start:
                        Addlog("Walk one step");
                        waitNTRtask = waitbutton(runUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)srbotstates.trigger;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    default:
                        Addlog("Bot stop");
                        botStop = true;
                        break;
                }
            }

            // Finish bot
            enableControls();
            stopBotButton.Enabled = false;
            botWorking = false;
            MessageBox.Show("Finished, number of resets: " + resetNo, "Soft-reset bot");
        }

        // Breeding bot
        public enum breedbotstates { botstart, facedaycareman, quickegg, walk1, checkegg1, walk2, checkegg2, walk3, checkmap1, stopdaycare, triggerdialog, cont1, cont2, cont3, cont4, cont5, acceptegg, cont6, exitdialog, walktodaycare, checkmap2, fix1, entertodaycare, checkmap3, walktodesk, checkmap4, walktocomputer, checkmap5, fix2, facecomputer, startcomputer, testcomputer, computerdialog, pressPCstorage, touchOrganize, testboxes, readslot, testboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testviewout, touchegg, moveegg, releaseegg, exitcomputer, testexit, readegg, retirefromcomputer, checkmap6, fix3, retirefromdesk, checkmap7, retirefromdoor, checkmap8, fix5, walktodaycareman, checkmap9, fix4, filter, testspassed, botexit };

        private async void runBreedingBot_Click(object sender, EventArgs e)
        {
            // Show warning
            string modemessage;
            switch (modeBreed.SelectedIndex)
            {
                case 0:
                    modemessage = "Simple: This bot will produce " + eggsNoBreed.Value.ToString() + " eggs and deposit them in the pc, starting at box " + boxBreed.Value.ToString() + " slot " + slotBreed.Value.ToString() + ".\r\n\r\n";
                    break;
                case 1:
                    modemessage = "Filter: This bot will produce eggs and deposit them in the pc, starting at box " + boxBreed.Value.ToString() + " slot " + slotBreed.Value.ToString() + ". Then it will check against the selected filters and if it finds a match the bot will stop. The bot will also stop if it produces " + eggsNoBreed.Value.ToString() + " eggs before finding a match.\r\n\r\n";
                    break;
                case 2:
                    modemessage = "ESV/TSV: This bot will produce eggs and deposit them in the pc, starting at box " + boxBreed.Value.ToString() + " slot " + slotBreed.Value.ToString() + ". Then it will check the egg's ESV and if it finds a match with the values in the TSV list, the bot will stop. The bot will also stop if it produces " + eggsNoBreed.Value.ToString() + " eggs before finding a match.\r\n\r\n";
                    break;
                default:
                    modemessage = "No mode selected. Select one and try again.\r\n\r\n";
                    break;
            }

            DialogResult dialogResult = MessageBox.Show("This bot will start producing eggs from the day care using the following rules:\r\n\r\n" + modemessage + "Make sure that you only have one pokémon in your party. Please read the Wiki at Github before starting. Do you want to continue?", "Breeding bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.OK)
            { // Initialize bot
                onlyView.Checked = true;
                radioBoxes.Checked = true;
                stopBotButton.Enabled = true;
                disableControls();
                botStop = false;
                botWorking = true;
                botState = (int)breedbotstates.botstart;
                txtLog.Clear();
                ESVlist.Rows.Clear();
            }
            else
            { // Exit bot
                botStop = true;
                return;
            }

            // Local variables
            Task<int> waitNTRtask;
            int currentbox = Convert.ToInt32(boxBreed.Value - 1);
            int currentslot = Convert.ToInt32(slotBreed.Value - 1);
            int filterbox = 0;
            int filterslot = 0;
            int waitresult;
            int waittimeout;
            uint routemapid;
            uint daycaremapid;
            uint daycaremanx;
            uint daycaremany;
            uint daycaredoorx;
            //uint daycaredoory;
            uint daycareexitx;
            //uint daycareexity;
            uint computerx;
            uint computery;
            bool orasgame;
            bool boxchange = true;
            int[,] egglocations = new int[5, 2];
            int eggsinbatch = 0;
            int eggsinparty = 0;
            int currentesv = 0;
            string finishmessage = "Finished";
            if (game == GameType.X || game == GameType.Y)
            {
                orasgame = false;
                routemapid = 0x108;
                daycaremapid = 0x109;
                daycaremanx = 0x46219400;
                daycaremany = 0x460F9400;
                daycaredoorx = 0x4622FC00;
                //daycaredoory = 0x460F4C00;
                daycareexitx = 0x43610000;
                //daycareexity = 0x43AF8000;
                computerx = 0x43828000;
                computery = 0x43730000;
            }
            else
            {
                orasgame = true;
                if (radioDayCare1.Checked)
                {
                    routemapid = 0x2C;
                    daycaremapid = 0x187;
                    daycaremanx = 0x45553000;
                    daycaremany = 0x44D92000;
                    daycaredoorx = 0x455AD000;
                    //daycaredoory = 0x44D6E000;
                    daycareexitx = 0x43610000;
                    //daycareexity = 0x43A68000;
                    computerx = 0x43828000;
                    computery = 0x43730000;
                    eggoff = 0x8C88358;
                }
                else
                {
                    routemapid = 0xD2;
                    daycaremapid = 0x207;
                    daycaremanx = 0x44A9E000;
                    daycaremany = 0x44D92000;
                    daycaredoorx = 0x449C6000;
                    //daycaredoory = 0x44D4A000;
                    daycareexitx = 0x43610000;
                    //daycareexity = 0x43A68000;
                    computerx = 0x43828000;
                    computery = 0x43730000;
                    eggoff = 0x8C88548;
                }
            }


            // Bot procedure
            while (!botStop)
            {
                switch (botState)
                {
                    case (int)breedbotstates.botstart:
                        Addlog("Bot start");
                        if (quickBreed.Checked)
                        {
                            botState = (int)breedbotstates.facedaycareman;
                        }
                        else if (modeBreed.SelectedIndex >= 0)
                        {
                            botState = (int)breedbotstates.walk1;
                        }
                        else
                        {
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.facedaycareman:
                        Addlog("Turn to Day Care Man");
                        waitNTRtask = waitbutton(DpadUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.quickegg;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.quickegg:
                        byte[] command = BitConverter.GetBytes(0x01);
                        Program.scriptHelper.write(eggoff, command, pid);
                        for (waittimeout = 0; waittimeout < timeout; waittimeout++)
                        {
                            lastlog = "";
                            await Task.Delay(1000);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout)
                        {
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        else
                        {
                            MessageBox.Show(writeerror);
                            botState = (int)srbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.walk1:
                        Addlog("Run in direction 1");
                        waitNTRtask = waitholdbutton(runDOWN);
                        waitresult = await waitNTRtask;
                        await Task.Delay(1000);
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.walk2;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.checkegg1:
                        Addlog("Check if egg");
                        waitNTRtask = waitNTRread(eggoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == 0x01)
                        {
                            Addlog("Egg found");
                            botState = (int)breedbotstates.walk3;
                        }
                        else if (lastmemoryread == 0x00)
                        {
                            botState = (int)breedbotstates.walk2;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.walk2:
                        Addlog("Run in direction 2");
                        waitNTRtask = waitholdbutton(runUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.checkegg2;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.checkegg2:
                        Addlog("Check if egg");
                        waitNTRtask = waitNTRread(eggoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == 0x01)
                        {
                            Addlog("Egg found");
                            botState = (int)breedbotstates.checkmap1;
                        }
                        else if (lastmemoryread == 0x00)
                        {
                            botState = (int)breedbotstates.walk1;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.walk3:
                        Addlog("Return to day care man");
                        waitNTRtask = waitholdbutton(runUP);
                        await Task.Delay(500);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.checkmap1;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.checkmap1:
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(mapyoff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread == daycaremany)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)breedbotstates.stopdaycare;
                        }
                        else
                        { // Still far from day care man
                            botState = (int)breedbotstates.walk3;
                        }
                        break;
                    case (int)breedbotstates.stopdaycare:
                        Addlog("Stop moving");
                        waitNTRtask = waitfreebutton();
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.triggerdialog:
                        Addlog("Talk to Day Care Man");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.cont1;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.cont1:
                        Addlog("Continue dialog (Ah! You're back!)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.cont2;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.cont2:
                        Addlog("Continue dialog (We were raising...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.cont3;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.cont3:
                        Addlog("Continue dialog (While we were...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.cont4;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.cont4:
                        Addlog("Continue dialog (Don't know where...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.cont5;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.cont5:
                        Addlog("Continue dialog (You'll be wanting it...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.acceptegg;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.acceptegg:
                        Addlog("Accept egg");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.cont6;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.cont6:
                        Addlog("Continue dialog (Player received the Egg..)");
                        await Task.Delay(2000);
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.exitdialog;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.exitdialog:
                        Addlog("Exit dialog (Be sure to take...)");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            eggsinparty++;
                            SetValue(eggsNoBreed, eggsNoBreed.Value - 1);
                            if (eggsinparty >= 5 || eggsNoBreed.Value == 0)
                            {
                                botState = (int)breedbotstates.walktodaycare;
                            }
                            else if (quickBreed.Checked)
                            {
                                botState = (int)breedbotstates.quickegg;
                            }
                            else
                            {
                                botState = (int)breedbotstates.walk1;
                            }

                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.walktodaycare:
                        Addlog("Walk to Day Care");
                        if (orasgame && radioDayCare2.Checked)
                        {
                            waitNTRtask = quickbuton(DpadLEFT);
                        }
                        else
                        {
                            waitNTRtask = quickbuton(DpadRIGHT);
                        }
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap2;
                        break;
                    case (int)breedbotstates.checkmap2:
                        await Task.Delay(250);
                        waitNTRtask = waitNTRread(mapxoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == daycaredoorx)
                        {
                            botState = (int)breedbotstates.entertodaycare;
                        }
                        else if (lastmemoryread < daycaredoorx && orasgame && radioDayCare2.Checked)
                        {
                            botState = (int)breedbotstates.fix1;
                        }
                        else if (lastmemoryread > daycaredoorx && (!orasgame || !radioDayCare2.Checked))
                        {
                            botState = (int)breedbotstates.fix1;
                        }
                        else
                        { // Still far from day care man
                            botState = (int)breedbotstates.walktodaycare;
                        }
                        break;
                    case (int)breedbotstates.fix1:
                        Addlog("Missed day care, return");
                        if (orasgame && radioDayCare2.Checked)
                        {
                            waitNTRtask = quickbuton(DpadRIGHT);
                        }
                        else
                        {
                            waitNTRtask = quickbuton(DpadLEFT);
                        }
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap2;
                        break;
                    case (int)breedbotstates.entertodaycare:
                        Addlog("Enter to Day Care");
                        waitNTRtask = waitbutton(runUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.checkmap3;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.checkmap3:
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(1000);
                            waitNTRtask = waitNTRread(mapidoff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread == daycaremapid)
                            {
                                botState = (int)breedbotstates.walktodesk;
                                break;
                            }
                            else if (lastmemoryread == routemapid)
                            {
                                botState = (int)breedbotstates.entertodaycare;
                                break;
                            }
                        }
                        if (waittimeout >= timeout * 10)
                        {
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.walktodesk:
                        Addlog("Run to desk");
                        waitNTRtask = waitbutton(runUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.checkmap4;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.checkmap4:
                        waitNTRtask = waitNTRread(mapyoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == computery)
                        {
                            botState = (int)breedbotstates.walktocomputer;
                        }
                        else
                        { // Still far from day care man
                            botState = (int)breedbotstates.walktodesk;
                        }
                        break;
                    case (int)breedbotstates.walktocomputer:
                        Addlog("Walk to the PC");
                        waitNTRtask = quickbuton(DpadRIGHT);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap5;
                        break;
                    case (int)breedbotstates.checkmap5:
                        await Task.Delay(250);
                        waitNTRtask = waitNTRread(mapxoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == computerx)
                        {
                            botState = (int)breedbotstates.facecomputer;
                        }
                        else if (lastmemoryread > computerx)
                        {
                            botState = (int)breedbotstates.fix2;
                        }
                        else
                        { // Still far from computer
                            botState = (int)breedbotstates.walktocomputer;
                        }
                        break;
                    case (int)breedbotstates.fix2:
                        Addlog("Missed PC, return");
                        waitNTRtask = quickbuton(DpadLEFT);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap5;
                        break;
                    case (int)breedbotstates.facecomputer:
                        Addlog("Turn on the PC");
                        waitNTRtask = waitbutton(DpadUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.startcomputer;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.startcomputer:
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.testcomputer;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.testcomputer:
                        await Task.Delay(1000);
                        Addlog("Test if the PC is on");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(computerOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= computerIN && lastmemoryread < computerIN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)breedbotstates.computerdialog;
                        }
                        else if (lastmemoryread >= computerOUT && lastmemoryread < computerOUT + 0x10000)
                        { // Computer off
                            botState = (int)breedbotstates.facecomputer;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.computerdialog:
                        Addlog("Skip PC dialog");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.pressPCstorage;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.pressPCstorage:
                        Addlog("Press Access PC storage");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.touchOrganize;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.touchOrganize:
                        Addlog("Touch Organize boxes");
                        if (orasgame && OrganizeTop.Checked)
                        {
                            waitNTRtask = waittouch(160, 40);
                        }
                        else
                        {
                            waitNTRtask = waittouch(160, 120);
                        }
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.testboxes;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.testboxes:
                        Addlog("Test if the boxes are shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxesOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= organizeBoxIN && lastmemoryread < organizeBoxIN + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)breedbotstates.readslot;
                        }
                        else if (lastmemoryread >= organizeBoxOUT && lastmemoryread < organizeBoxOUT + 0x10000)
                        { // Still on PC mode screen
                            botState = (int)breedbotstates.touchOrganize;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.readslot:
                        Addlog("Check if box " + (currentbox + 1).ToString() + ", slot " + (currentslot + 1).ToString() + " is empty");
                        dPID.Clear();
                        lastlog = "";
                        SetValue(boxDump, currentbox + 1);
                        SetValue(slotDump, currentslot + 1);
                        SetValue(boxBreed, currentbox + 1);
                        SetValue(slotBreed, currentslot + 1);
                        dumpPokemon.Enabled = true;
                        dumpPokemon.PerformClick();
                        dumpPokemon.Enabled = false;
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            if (lastlog.Contains("finished"))
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10 && dPID.Text.Length < 1)
                        {
                            botState = (int)breedbotstates.testboxchange;
                        }
                        else if (waittimeout < timeout * 10 && dPID.Text.Length > 0)
                        { // Non empty space
                            Addlog("Space is not empty");
                            currentslot++;
                            if (currentslot >= 30)
                            {
                                currentslot = 0;
                                currentbox++;
                                boxchange = true;
                                if (currentbox >= 31)
                                {
                                    currentbox = 0;
                                }
                            }
                            botState = (int)breedbotstates.readslot;
                        }
                        else
                        {
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.testboxchange:
                        if (boxchange)
                        {
                            botState = (int)breedbotstates.touchboxview;
                            boxchange = false;
                        }
                        else
                        {
                            botState = (int)breedbotstates.touchegg;
                        }
                        break;
                    case (int)breedbotstates.touchboxview:
                        Addlog("Touch Box View");
                        await Task.Delay(500);
                        waitNTRtask = waittouch(30, 220);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.testboxview;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.testboxview:
                        Addlog("Test if box view is shown");
                        await Task.Delay(500);
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxviewOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtboxviewIN && lastmemoryread < wtboxviewIN + wtboxviewRange)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)breedbotstates.touchnewbox;
                        }
                        else if (lastmemoryread >= wtboxviewOUT && lastmemoryread < wtboxviewOUT + wtboxviewRange)
                        { // Still on the boxes
                            botState = (int)breedbotstates.touchboxview;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.touchnewbox:
                        Addlog("Touch New Box");
                        waitNTRtask = waittouch(boxXcord[currentbox], boxYcord[currentbox]);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.selectnewbox;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.selectnewbox:
                        Addlog("Select New Box");
                        waitNTRtask = waitbutton(keyA);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.testviewout;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.testviewout:
                        Addlog("Test if box view is not shown");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxviewOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= wtboxviewOUT && lastmemoryread < wtboxviewOUT + wtboxviewRange)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            botState = (int)breedbotstates.touchegg;
                        }
                        else if (lastmemoryread >= wtboxviewIN && lastmemoryread < wtboxviewIN + wtboxviewRange)
                        { // Still on the box view
                            botState = (int)breedbotstates.selectnewbox;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.touchegg:
                        Addlog("Select Egg");
                        waitNTRtask = waitholdtouch(300, 100);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.moveegg;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.moveegg:
                        Addlog("Move Egg");
                        waitNTRtask = waitholdtouch(boxpokeXcord[currentslot], boxpokeYcord[currentslot]);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.releaseegg;
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.releaseegg:
                        Addlog("Release Egg");
                        waitNTRtask = waitfreetouch();
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            egglocations[eggsinbatch, 0] = currentbox;
                            egglocations[eggsinbatch, 1] = currentslot;
                            eggsinbatch++;
                            currentslot++;
                            if (currentslot >= 30)
                            {
                                currentslot = 0;
                                currentbox++;
                                boxchange = true;
                                if (currentbox >= 31)
                                {
                                    currentbox = 0;
                                }
                            }
                            eggsinparty--;
                            if (eggsinparty > 0)
                            {
                                botState = (int)breedbotstates.readslot;
                            }
                            else
                            {
                                botState = (int)breedbotstates.exitcomputer;
                            }
                        }
                        else
                        {
                            MessageBox.Show(toucherror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.exitcomputer:
                        Addlog("Exit from PC");
                        waitNTRtask = waitbutton(keyX);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.testexit;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.testexit:
                        Addlog("Test if out from PC");
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(100);
                            waitNTRtask = waitNTRread(wtboxesOff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread >= organizeBoxOUT && lastmemoryread < organizeBoxOUT + 0x10000)
                            {
                                break;
                            }
                        }
                        if (waittimeout < timeout * 10)
                        {
                            if (modeBreed.SelectedIndex == 1 || modeBreed.SelectedIndex == 2 || readESV.Checked)
                            {
                                botState = (int)breedbotstates.filter;
                            }
                            else if (eggsNoBreed.Value > 0)
                            {
                                eggsinbatch = 0;
                                botState = (int)breedbotstates.retirefromcomputer;
                            }
                            else
                            {
                                botState = (int)breedbotstates.botexit;
                            }
                        }
                        else if (lastmemoryread >= organizeBoxIN && lastmemoryread < organizeBoxIN + 0x10000)
                        { // Still on PC mode screen
                            botState = (int)breedbotstates.exitcomputer;
                        }
                        else
                        { // Other error
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.retirefromcomputer:
                        Addlog("Retire from PC");
                        waitNTRtask = quickbuton(DpadLEFT);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap6;
                        break;
                    case (int)breedbotstates.checkmap6:
                        await Task.Delay(250);
                        waitNTRtask = waitNTRread(mapxoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == daycareexitx)
                        {
                            botState = (int)breedbotstates.retirefromdesk;
                        }
                        else if (lastmemoryread < daycareexitx)
                        {
                            botState = (int)breedbotstates.fix3;
                        }
                        else
                        { // Still far from exit
                            botState = (int)breedbotstates.retirefromcomputer;
                        }
                        break;
                    case (int)breedbotstates.fix3:
                        Addlog("Missed exit, return");
                        waitNTRtask = quickbuton(DpadRIGHT);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap6;
                        break;
                    case (int)breedbotstates.retirefromdesk:
                        Addlog("Run to exit");
                        waitNTRtask = waitbutton(runDOWN);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.checkmap7;
                        }
                        else
                        {
                            MessageBox.Show(buttonerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.checkmap7:
                        for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                        {
                            await Task.Delay(1000);
                            waitNTRtask = waitNTRread(mapidoff);
                            waitresult = await waitNTRtask;
                            if (lastmemoryread == routemapid)
                            {
                                botState = (int)breedbotstates.retirefromdoor;
                                break;
                            }
                            else if (lastmemoryread == daycaremapid)
                            {
                                botState = (int)breedbotstates.retirefromdesk;
                                break;
                            }
                        }
                        if (waittimeout >= timeout * 10)
                        {
                            MessageBox.Show(readerror);
                            botState = (int)breedbotstates.botexit;
                        }
                        break;
                    case (int)breedbotstates.retirefromdoor:
                        Addlog("Retire from door");
                        waitNTRtask = quickbuton(DpadDOWN);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap8;
                        break;
                    case (int)breedbotstates.checkmap8:
                        await Task.Delay(250);
                        waitNTRtask = waitNTRread(mapyoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == daycaremany)
                        {
                            botState = (int)breedbotstates.walktodaycareman;
                        }
                        else if (lastmemoryread > daycaremany)
                        {
                            botState = (int)breedbotstates.fix5;
                        }
                        else
                        { // Still far from day care man
                            botState = (int)breedbotstates.retirefromdoor;
                        }
                        break;
                    case (int)breedbotstates.fix5:
                        Addlog("Missed Day Care Man, return");
                        waitNTRtask = quickbuton(DpadUP);
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap8;
                        break;
                    case (int)breedbotstates.walktodaycareman:
                        Addlog("Walk to Day Care Man");
                        if (orasgame && radioDayCare2.Checked)
                        {
                            waitNTRtask = quickbuton(DpadRIGHT);
                        }
                        else
                        {
                            waitNTRtask = quickbuton(DpadLEFT);
                        }
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                        {
                            botState = (int)breedbotstates.checkmap9;
                        }
                        break;
                    case (int)breedbotstates.checkmap9:
                        await Task.Delay(250);
                        waitNTRtask = waitNTRread(mapxoff);
                        waitresult = await waitNTRtask;
                        if (lastmemoryread == daycaremanx)
                        {
                            if (quickBreed.Checked)
                            {
                                botState = (int)breedbotstates.facedaycareman;
                            }
                            else
                            {
                                botState = (int)breedbotstates.walk1;
                            }
                        }
                        else if (lastmemoryread > daycaremanx && orasgame && radioDayCare2.Checked)
                        {
                            botState = (int)breedbotstates.fix4;
                        }
                        else if (lastmemoryread < daycaremanx && (!orasgame || !radioDayCare2.Checked))
                        {
                            botState = (int)breedbotstates.fix4;
                        }
                        else
                        { // Still far day care man
                            botState = (int)breedbotstates.walktodaycareman;
                        }
                        break;
                    case (int)breedbotstates.fix4:
                        Addlog("Missed Day Care Man, return");
                        if (orasgame && radioDayCare2.Checked)
                        {
                            waitNTRtask = quickbuton(DpadLEFT);
                        }
                        else
                        {
                            waitNTRtask = quickbuton(DpadRIGHT);
                        }
                        waitresult = await waitNTRtask;
                        if (waitresult == 0)
                            botState = (int)breedbotstates.checkmap9;
                        break;
                    case (int)breedbotstates.filter:
                        for (int i = 0; i < eggsinbatch; i++)
                        {
                            filterbox = egglocations[i, 0] + 1;
                            filterslot = egglocations[i, 1] + 1;
                            bool testsok = false;
                            Addlog("Reading egg located at box " + filterbox + " slot  " + filterslot);
                            SetValue(boxDump, filterbox);
                            SetValue(slotDump, filterslot);
                            dumpPokemon.Enabled = true;
                            dumpPokemon.PerformClick();
                            dumpPokemon.Enabled = false;
                            for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
                            {
                                await Task.Delay(100);
                                if (lastlog.Contains("finished"))
                                {
                                    break;
                                }
                            }
                            if (waittimeout < timeout * 10)
                            {
                                if (readESV.Checked || modeBreed.SelectedIndex == 2)
                                {
                                    int esv = (int)((dumpedPKHeX.PID >> 16 ^ dumpedPKHeX.PID & 0xFFFF) >> 4);
                                    ESVlist.Rows.Add(filterbox, filterslot, esv.ToString("D4"));
                                    if (modeBreed.SelectedIndex == 2)
                                    {
                                        currentesv = esv;
                                        testsok = ESV_TSV_check(esv);
                                    }
                                }
                                if (modeBreed.SelectedIndex == 1)
                                {
                                    testsok = FilterCheck(filterBreeding);
                                }
                            }
                            else
                            {
                                MessageBox.Show(readerror);
                                break;
                            }
                            if (testsok)
                            {
                                botState = (int)breedbotstates.testspassed;
                                break;
                            }
                            else if (eggsNoBreed.Value > 0)
                            {
                                botState = (int)breedbotstates.retirefromcomputer;
                            }
                            else
                            {
                                if (modeBreed.SelectedIndex == 1 || modeBreed.SelectedIndex == 2)
                                {
                                    Addlog("No match found");
                                    finishmessage = "Finished. Maximum number of eggs reached without a match.";
                                }
                                botState = (int)breedbotstates.botexit;
                            }

                        }
                        eggsinbatch = 0;
                        break;
                    case (int)breedbotstates.testspassed:
                        if (modeBreed.SelectedIndex == 1)
                        {
                            Addlog("All tests passed");
                            finishmessage = "Finished. A match was found at box " + filterbox + ", slot " + filterslot + ", using filter #" + currentfilter;
                        }
                        else if (modeBreed.SelectedIndex == 2)
                        {
                            Addlog("ESV/TSV match found");
                            finishmessage = "Finished. A match was found at box " + filterbox + ", slot " + filterslot + ", the ESV/TSV value is: " + currentesv;
                        }
                        Addlog("Bot stop");
                        botStop = true;
                        break;
                    default:
                        waitNTRtask = waitfreebutton();
                        waitresult = await waitNTRtask;
                        waitNTRtask = waitfreetouch();
                        waitresult = await waitNTRtask;
                        Addlog("Bot stop");
                        botStop = true;
                        break;
                }
            }

            // Finish bot
            enableControls();
            stopBotButton.Enabled = false;
            botWorking = false;
            MessageBox.Show(finishmessage, "Breeding bot");

        }

        private void ESVlistSave_Click(object sender, EventArgs e)
        {
            if (ESVlist.Rows.Count > 0)
            {
                string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new System.IO.FileInfo(folderPath)).Directory.Create();
                string fileName = "ESVlist.csv";
                var esvlst = new StringBuilder();
                var headers = ESVlist.Columns.Cast<DataGridViewColumn>();
                esvlst.AppendLine(string.Join(",", headers.Select(column => column.HeaderText).ToArray()));
                foreach (DataGridViewRow row in ESVlist.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    esvlst.AppendLine(string.Join(",", cells.Select(cell => cell.Value).ToArray()));
                }
                File.WriteAllText(folderPath + fileName, esvlst.ToString());
                MessageBox.Show("ESV list saved");
            }
            else
            {
                MessageBox.Show("There are no eggs on the ESV list");
            }
        }

        private void TSVlistAdd_Click(object sender, EventArgs e)
        {
            TSVlist.Items.Add(((int)TSVlistNum.Value).ToString("D4"));
        }

        private void TSVlistRemove_Click(object sender, EventArgs e)
        {
            if (TSVlist.SelectedIndices.Count > 0)
            {
                TSVlist.Items.RemoveAt(TSVlist.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("No TSV selected for remove");
            }
        }

        private void TSVlistSave_Click(object sender, EventArgs e)
        {
            if (TSVlist.Items.Count > 0)
            {
                string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new System.IO.FileInfo(folderPath)).Directory.Create();
                string fileName = "TSVlist.csv";
                var tsvlst = new StringBuilder();
                foreach (var value in TSVlist.Items)
                {
                    tsvlst.AppendLine(value.ToString());
                }
                File.WriteAllText(folderPath + fileName, tsvlst.ToString());
                MessageBox.Show("TSV list saved");
            }
            else
            {
                MessageBox.Show("There are no numbers on the TSV list");
            }
        }

        private void TSVlistLoad_Click(object sender, EventArgs e)
        {
            string folderPath = @Application.StartupPath + "\\" + FOLDERBOT + "\\";
            (new System.IO.FileInfo(folderPath)).Directory.Create();
            string fileName = "TSVlist.csv";
            if (System.IO.File.Exists(folderPath + fileName))
            {
                string[] values = File.ReadAllLines(folderPath + fileName);
                TSVlist.Items.Clear();
                TSVlist.Items.AddRange(values);
            }
        }

        public bool ESV_TSV_check(int esv)
        {
            if (TSVlist.Items.Count > 0)
            {
                Addlog("Checking egg with ESV: " + esv);
                foreach (var tsv in TSVlist.Items)
                {
                    if (Convert.ToInt32(tsv) == esv)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion Bots
    }

    //Objects of this class contains an array for data that have been acquired, a delegate function 
    //to handle them and any additional arguments it might require.
    class DataReadyWaiting
    {
        public byte[] data;
        public object arguments;
        public delegate void DataHandler(object data_arguments);
        public DataHandler handler;

        public DataReadyWaiting(byte[] data_, DataHandler handler_, object arguments_)
        {
            this.data = data_;
            this.handler = handler_;
            this.arguments = arguments_;
        }
    }
}