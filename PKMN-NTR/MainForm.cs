/*
 * TODO: zmienić 930 na BOXES * BOXSIZE
 * zmienić wszystkie offsety na liczby hex, bo to siara wszystko trzymać w stringach
 */
using ntrbase.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ntrbase
{
    public partial class MainForm : Form
    {
        public const int BOXES = 31;
        public const int BOXSIZE = 30;
        public const int POKEBYTES = 232;
        PKHeX PKHeX = new PKHeX();
   
        public string dumpBattleBox;
        public string dumpEK6;
        public string dumpDay1;
        public string dumpParty;
        public int bboff;
        public bool isEncryptedFF { get; set; }
        public bool isEncryptedFFD { get; set; }
        public byte[] selectedCloneData  = new byte[232];
        public bool   selectedCloneValid = false;
        public byte[] emptyDatab = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x83, 0x07, 0x00, 0x00, 0x7E, 0xE9, 0x71, 0x52, 0xB0, 0x31, 0x42, 0x8E, 0xCC, 0xE2, 0xC5, 0xAF, 0xDB, 0x67, 0x33, 0xFC, 0x2C, 0xEF, 0x5E, 0xFC, 0xC5, 0xCA, 0xD6, 0xEB, 0x3D, 0x99, 0xBC, 0x7A, 0xA7, 0xCB, 0xD6, 0x5D, 0x78, 0x91, 0xA6, 0x27, 0x8D, 0x61, 0x92, 0x16, 0xB8, 0xCF, 0x5D, 0x37, 0x80, 0x30, 0x7C, 0x40, 0xFB, 0x48, 0x13, 0x32, 0xE7, 0xFE, 0xE6, 0xDF, 0x0E, 0x3D, 0xF9, 0x63, 0x29, 0x1D, 0x8D, 0xEA, 0x96, 0x62, 0x68, 0x92, 0x97, 0xA3, 0x49, 0x1C, 0x03, 0x6E, 0xAA, 0x31, 0x89, 0xAA, 0xC5, 0xD3, 0xEA, 0xC3, 0xD9, 0x82, 0xC6, 0xE0, 0x5C, 0x94, 0x3B, 0x4E, 0x5F, 0x5A, 0x28, 0x24, 0xB3, 0xFB, 0xE1, 0xBF, 0x8E, 0x7B, 0x7F, 0x00, 0xC4, 0x40, 0x48, 0xC8, 0xD1, 0xBF, 0xB6, 0x38, 0x3B, 0x90, 0x23, 0xFB, 0x23, 0x7D, 0x34, 0xBE, 0x00, 0xDA, 0x6A, 0x70, 0xC5, 0xDF, 0x84, 0xBA, 0x14, 0xE4, 0xA1, 0x60, 0x2B, 0x2B, 0x38, 0x8F, 0xA0, 0xB6, 0x60, 0x41, 0x36, 0x16, 0x09, 0xF0, 0x4B, 0xB5, 0x0E, 0x26, 0xA8, 0xB6, 0x43, 0x7B, 0xCB, 0xF9, 0xEF, 0x68, 0xD4, 0xAF, 0x5F, 0x74, 0xBE, 0xC3, 0x61, 0xE0, 0x95, 0x98, 0xF1, 0x84, 0xBA, 0x11, 0x62, 0x24, 0x80, 0xCC, 0xC4, 0xA7, 0xA2, 0xB7, 0x55, 0xA8, 0x5C, 0x1C, 0x42, 0xA2, 0x3A, 0x86, 0x05, 0xAD, 0xD2, 0x11, 0x19, 0xB0, 0xFD, 0x57, 0xE9, 0x4E, 0x60, 0xBA, 0x1B, 0x45, 0x2E, 0x17, 0xA9, 0x34, 0x93, 0x2D, 0x66, 0x09, 0x2D, 0x11, 0xE0, 0xA1, 0x74, 0x42, 0xC4, 0x73, 0x65, 0x2F, 0x21, 0xF0, 0x43, 0x28, 0x54, 0xA6 };
        public int tradedumpcount = 0;
        public string realoppoffset { get; set; }
        public string realtradeoffset { get; set; }
        public string tradeoffrg;
        public string moneyoff;
        public string milesoff;
        public string bpoff;
        public int partyoff;
        public static int boff;
        public string boffs;
        public static string pid;
        public string lang;
        public string opwroff;
        public int hpb;
        public int atkb;
        public int defb;
        public int speb;
        public int spab;
        public int spdb;
        public string pname { get; set; }
        public string game;
        public string d1off;
        public string d2off;
        public string itemsoff;
        public string medsoff;
        public string keysoff;
        public string tmsoff;
        public string bersoff;
        public bool firstcheck = false;
        public byte[] ek6;
        public byte[] ek6b { get; set; }
        public int additem = 0;
        public byte[] items { get; set; }
        private byte[] itemData = new byte[1600];
        private byte[] keyData = new byte[384];
        private byte[] tmData = new byte[432];
        private byte[] medData = new byte[256];
        private byte[] berryData = new byte[288];
        private byte[] pkmEncrypted { get; set; }
        public byte[] data;
        public byte[] keys;
        public byte[] tms;
        public byte[] meds;
        public byte[] bers;
        public byte[] writeitems;
        public string selectedek6;
        public int numofItems { get; set; }
        public int numofKeys;
        public int numofTMs;
        public int numofMeds;
        public int numofBers;
        public string nameoff;
        public string tidoff;
        public string sidoff;
        public string hroff;
        public string minoff;
        public string secoff;
        public string langoff;
        public int shoutoutOff;

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

        public string[] itemList = { "[None]", "Master Ball", "Ultra Ball", "Great Ball", "Poke Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Potion", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Paralyze Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Full Heal", "Revive", "Max Revive", "Fresh Water", "Soda Pop", "Lemonade", "Moomoo Milk", "Energy Powder", "Energy Root", "Heal Powder", "Revival Herb", "Ether", "Max Ether", "Elixir", "Max Elixir", "Lava Cookie", "Berry Juice", "Sacred Ash", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "PP Up", "Zinc", "PP Max", "Old Gateau", "Guard Spec.", "Dire Hit", "X Attack", "X Defense", "X Speed", "X Accuracy", "X Sp. Atk", "X Sp. Def", "Poke Doll", "Fluffy Tail", "Blue Flute", "Yellow Flute", "Red Flute", "Black Flute", "White Flute", "Shoal Salt", "Shoal Shell", "Red Shard", "Blue Shard", "Yellow Shard", "Green Shard", "Super Repel", "Max Repel", "Escape Rope", "Repel", "Sun Stone", "Moon Stone", "Fire Stone", "Thunder Stone", "Water Stone", "Leaf Stone", "Tiny Mushroom", "Big Mushroom", "Pearl", "Big Pearl", "Stardust", "Star Piece", "Nugget", "Heart Scale", "Honey", "Growth Mulch", "Damp Mulch", "Stable Mulch", "Gooey Mulch", "Root Fossil", "Claw Fossil", "Helix Fossil", "Dome Fossil", "Old Amber", "Armor Fossil", "Skull Fossil", "Rare Bone", "Shiny Stone", "Dusk Stone", "Dawn Stone", "Oval Stone", "Odd Keystone", "Griseous Orb", "???", "???", "???", "Douse Drive", "Shock Drive", "Burn Drive", "Chill Drive", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Sweet Heart", "Adamant Orb", "Lustrous Orb", "Greet Mail", "Favored Mail", "RSVP Mail", "Thanks Mail", "Inquiry Mail", "Like Mail", "Reply Mail", "Bridge Mail S", "Bridge Mail D", "Bridge Mail T", "Bridge Mail V", "Bridge Mail M", "Cheri Berry", "Chesto Berry", "Pecha Berry", "Rawst Berry", "Aspear Berry", "Leppa Berry", "Oran Berry", "Persim Berry", "Lum Berry", "Sitrus Berry", "Figy Berry", "Wiki Berry", "Mago Berry", "Aguav Berry", "Iapapa Berry", "Razz Berry", "Bluk Berry", "Nanab Berry", "Wepear Berry", "Pinap Berry", "Pomeg Berry", "Kelpsy Berry", "Qualot Berry", "Hondew Berry", "Grepa Berry", "Tamato Berry", "Cornn Berry", "Magost Berry", "Rabuta Berry", "Nomel Berry", "Spelon Berry", "Pamtre Berry", "Watmel Berry", "Durin Berry", "Belue Berry", "Occa Berry", "Passho Berry", "Wacan Berry", "Rindo Berry", "Yache Berry", "Chople Berry", "Kebai Berry", "Shuca Berry", "Coba Berry", "Payapa Berry", "Tanga Berry", "Charti Berry", "Kasib Berry", "Haban Berry", "Colbur Berry", "Babiri Berry", "Chilan Berry", "Liechi Berry", "Ganlon Berry", "Salac Berry", "Petaya Berry", "Apicot Berry", "Lansat Berry", "Starf Berry", "Enigma Berry", "Micle Berry", "Custap Berry", "Jaboca Berry", "Rowap Berry", "Bright Powder", "White Herb", "Macho Brace", "Exp. Share", "Quick Claw", "Soothe Bell", "Mental Herb", "Choice Band", "King's Rock", "Silver Powder", "Amulet Coin", "Cleanse Tag", "Soul Dew", "Deep Sea Tooth", "Deep Sea Scale", "Smoke Ball", "Everstone", "Focus Band", "Lucky Egg", "Scope Lens", "Metal Coat", "Leftovers", "Dragon Scale", "Light Ball", "Soft Sand", "Hard Stone", "Miracle Seed", "Black Glasses", "Black Belt", "Magnet", "Mystic Water", "Sharp Beak", "Poison Barb", "Never-Melt Ice", "Spell Tag", "Twisted Spoon", "Charcoal", "Dragon Fang", "Silk Scarf", "Up-Grade", "Shell Bell", "Sea Incense", "Lax Incense", "Lucky Punch", "Metal Powder", "Thick Club", "Stick", "Red Scarf", "Blue Scarf", "Pink Scarf", "Green Scarf", "Yellow Scarf", "Wide Lens", "Muscle Band", "Wise Glasses", "Expert Belt", "Light Clay", "Life Orb", "Power Herb", "Toxic Orb", "Flame Orb", "Quick Powder", "Focus Sash", "Zoom Lens", "Metronome", "Iron Ball", "Lagging Tail", "Destiny Knot", "Black Sludge", "Icy Rock", "Smooth Rock", "Heat Rock", "Damp Rock", "Grip Claw", "Choice Scarf", "Sticky Barb", "Power Bracer", "Power Belt", "Power Lens", "Power Band", "Power Anklet", "Power Weight", "Shed Shell", "Big Root", "Choice Specs", "Flame Plate", "Splash Plate", "Zap Plate", "Meadow Plate", "Icicle Plate", "Fist Plate", "Toxic Plate", "Earth Plate", "Sky Plate", "Mind Plate", "Insect Plate", "Stone Plate", "Spooky Plate", "Draco Plate", "Dread Plate", "Iron Plate", "Odd Incense", "Rock Incense", "Full Incense", "Wave Incense", "Rose Incense", "Luck Incense", "Pure Incense", "Protector", "Electrizer", "Magmarizer", "Dubious Disc", "Reaper Cloth", "Razor Claw", "Razor Fang", "Hone Claws", "Dragon Claw", "Psyshock", "Calm Mind", "Roar", "Toxic", "Hail", "Bulk Up", "Venoshock", "Hidden Power", "Sunny Day", "Taunt", "Ice Beam", "Blizzard", "Hyper Beam", "Light Screen", "Protect", "Rain Dance", "Roost", "Safeguard", "Frustration", "Solar Beam", "Smack Down", "Thunderbolt", "Thunder", "Earthquake", "Return", "Dig", "Psychic", "Shadow Ball", "Brick Break", "Double Team", "Reflect", "Sludge Wave", "Flamethrower", "Sludge Bomb", "Sandstorm", "Fire Blast", "Rock Tomb", "Aerial Ace", "Torment", "Facade", "Flame Charge", "Rest", "Attract", "Thief", "Low Sweep", "Round", "Echoed Voice", "Overheat", "Steel Wing", "Focus Blast", "Energy Ball", "False Swipe", "Scald", "Fling", "Charge Beam", "Sky Drop", "Incinerate", "Quash", "Will-O-Wisp", "Acrobatics", "Embargo", "Explosion", "Shadow Claw", "Payback", "Retaliate", "Giga Impact", "Rock Polish", "Flash", "Stone Edge", "Volt Switch", "Thunder Wave", "Gyro Ball", "Swords Dance", "Struggle Bug", "Psych Up", "Bulldoze", "Frost Breath", "Rock Slide", "X-Scissor", "Dragon Tail", "Infestation", "Poison Jab", "Dream Eater", "Grass Knot", "Swagger", "Sleep Talk", "U-turn", "Substitute", "Flash Cannon", "Trick Room", "Cut", "Fly", "Surf", "Strength", "Waterfall", "Rock Smash", "???", "???", "Explorer Kit", "Loot Sack", "Rule Book", "Poke Radar", "Point Card", "Journal", "Seal Case", "Fashion Case", "Seal Bag", "Pal Pad", "Works key", "Old Charm", "Galactic Key", "Red Chain", "Town Map", "Vs. Seeker", "Coin Case", "Old Rod", "Good Rod", "Super Rod", "Sprayduck", "Poffin Case", "Bike", "Suite Key", "Oak's Letter", "Lunar Wing", "Member Card", "Azure Flute", "S.S. Ticket", "Contest Pass", "Magma Stone", "Parcel", "Coupon 1", "Coupon 2", "Coupon 3", "Storage Key", "Secret Potion", "Vs. Recorder", "Gracidea", "Secret Key", "Apricorn Box", "Unown Report", "Berry Pots", "Dowsing Machine", "Blue Card", "Slowpoke Tail", "Clear Bell", "Card Key", "Basement Key", "Squirt Bottle", "Red Scale", "Lost Item", "Pass", "Machine Part", "Silver Wing", "Rainbow Wing", "Mystery Egg", "Red Apricorn", "Blue Apricorn", "Yellow Apricorn", "Green Apricorn", "Pink Apricorn", "White Apricorn", "Black Apricorn", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Park Ball", "Photo Album", "GB Sounds", "Tidal Bell", "Rage Candy Bar", "Data Card 01", "Data Card 02", "Data Card 03", "Data Card 04", "Data Card 05", "Data Card 06", "Data Card 07", "Data Card 08", "Data Card 09", "Data Card 10", "Data Card 11", "Data Card 12", "Data Card 13", "Data Card 14", "Data Card 15", "Data Card 16", "Data Card 17", "Data Card 18", "Data Card 19", "Data Card 20", "Data Card 21", "Data Card 22", "Data Card 23", "Data Card 24", "Data Card 25", "Data Card 26", "Data Card 27", "Jade Orb", "Lock Capsule", "Red Orb", "Blue Orb", "Enigma Stone", "Prism Scale", "Eviolite", "Float Stone", "Rocky Helmet", "Air Balloon", "Red Card", "Ring Target", "Binding Band", "Absorb Bulb", "Cell Battery", "Eject Button", "Fire Gem", "Water Gem", "Electric Gem", "Grass Gem", "Ice Gem", "Fighting Gem", "Poison Gem", "Ground Gem", "Flying Gem", "Psychic Gem", "Bug Gem", "Rock Gem", "Ghost Gem", "Dragon Gem", "Dark Gem", "Steel Gem", "Normal Gem", "Health Wing", "Muscle Wing", "Resist Wing", "Genius Wing", "Clever Wing", "Swift Wing", "Pretty Wing", "Cover Fossil", "Plume Fossil", "Libery Pass", "Pass Orb", "Dream Ball", "Poke Toy", "Prop Case", "Dragon Skull", "Balm Mushroom", "Big Nugget", "Pearl String", "Comet Shard", "Relic Copper", "Relic Silver", "Relic Gold", "Relic Vase", "Relic Band", "Relic Statue", "Relic Crown", "Casteliacone", "Dire Hit 2", "X Speed 2", "X Sp. Atk 2", "X Sp. Def 2", "X Defense 2", "X Attack 2", "X Accuracy 2", "X Speed 3", "X Sp. Atk 3", "X Sp. Def 3", "X Defense 3", "X Attack 3", "X Accuracy 3", "X Speed 6", "X Sp. Atk 6", "X Sp. Def 6", "X Defense 6", "X Attack 6", "X Accuracy 6", "Ability Urge", "Item Drop", "Item Urge", "Reset Urge", "Dire Hit 3", "Light Stone", "Dark Stone", "Wild Charge", "Secret Power", "Snarl", "Xtransceiver(Male)", "???", "Gram 1", "Gram 2", "Gram 3", "Xtransceiver(Female)", "Medal Box", "DNA Splicers(Fuses)", "DNA Splicers(Seperates)", "Permit", "Oval Charm", "Shiny Charm", "Plasma Card", "Grubby Hanky", "Colress Machine", "Dropped Item (Xtransceiver Male)", "Dropped Item (Xtransceiver Female)", "Reveal Glass", "Weakness Policy", "Assault Vest", "Holo Caster", "Prof's Letter", "Roller Skates", "Pixie Plate", "Ability Capsule", "Whipped Dream", "Sachet", "Luminous Moss", "Snowball", "Safety Goggles", "Poke Flute", "Rich Mulch", "Surprise Mulch", "Boost Mulch", "Amaze Mulch", "Gengarite", "Gardevoirite", "Ampharosite", "Venusaurite", "Charizardite X", "Blastoisinite", "Mewtwonite X", "Mewtwonite Y", "Blazikenite", "Medichamite", "Houndoominite", "Aggronite", "Banettite", "Tyranitarite", "Scizorite", "Pinsirite", "Aerodactylite", "Lucarionite", "Abomasite", "Kangaskhanite", "Gyaradosite", "Absolite", "Charizardite Y", "Alakazite", "Heracronite", "Mawilite", "Manectite", "Garchompite", "Latiasite", "Latiosite", "Roseli Berry", "Kee Berry", "Maranga Berry", "Sprinklotad", "Nature Power", "Dark Pulse", "Power-Up Punch", "Dazzling Gleam", "Confide", "Power Plant Pass", "Mega Ring", "Intruiging Stone", "Common Stone", "Discount Coupon", "Elevator Key", "TMV Pass", "Honor of Kalos", "Adventure Rules", "Strange Souvenir", "Lens Case", "Travel Trunk (Silver)", "Travel Trunk (Gold)", "Lumiose Galette", "Shalour Sable", "Jaw Fossil", "Sail Fossil", "Looker Ticket", "Bike", "Holo Caster", "Fairy Gem", "Mega Charm", "Mega Glove", "Mach Bike", "Acro Bike", "Wailmer Pail", "Devon Parts", "Soot Sack", "Basement Key", "Pokeblock Kit", "Letter", "Eon Ticket", "Scanner", "Go-Goggles", "Meteorite (originally found)", "Key to Room 1", "Key to Room 2", "Key to Room 4", "Key to Room 6", "Storage Key", "Devon Scope", "S.S. Ticket", "Dive", "Devon Scuba Gear", "Contest Costume (Male)", "Contest Costume (Female)", "Magma Suit", "Aqua Suit", "Pair of Tickets", "Mega Bracelet", "Mega Pendant", "Mega Glasses", "Mega Anchor", "Mega Stickpin", "Mega Tiara", "Mega Anklet", "Meteorite (faint glow)", "Swampertite", "Sceptilite", "Sablenite", "Altarianite", "Galladite", "Audinite", "Metagrossite", "Sharpedonite", "Slowbronite", "Steelixite", "Pidgeotite", "Glalitite", "Diancite", "Prison Bottle", "Mega Cuff", "Cameruptite", "Lopunnite", "Salamencite", "Beedrillite", "Meteorite (1)", "Meteorite (2)", "Key Stone", "Meteorite Shard", "Eon Flute" };
        public string[] abilityList = { "Stench", "Drizzle", "Speed Boost", "Battle Armor", "Sturdy", "Damp", "Limber", "Sand Veil", "Static", "Volt Absorb", "Water Absorb", "Oblivious", "Cloud Nine", "Compound Eyes", "Insomnia", "Color Change", "Immunity", "Flash Fire", "Shield Dust", "Own Tempo", "Suction Cups", "Intimidate", "Shadow Tag", "Rough Skin", "Wonder Guard", "Levitate", "Effect Spore", "Synchronize", "Clear Body", "Natural Cure", "Lightning Rod", "Serene Grace", "Swift Swim", "Chlorophyll", "Illuminate", "Trace", "Huge Power", "Poison Point", "Inner Focus", "Magma Armor", "Water Veil", "Magnet Pull", "Soundproof", "Rain Dish", "Sand Stream", "Pressure", "Thick Fat", "Early Bird", "Flame Body", "Run Away", "Keen Eye", "Hyper Cutter", "Pickup", "Truant", "Hustle", "Cute Charm", "Plus", "Minus", "Forecast", "Sticky Hold", "Shed Skin", "Guts", "Marvel Scale", "Liquid Ooze", "Overgrow", "Blaze", "Torrent", "Swarm", "Rock Head", "Drought", "Arena Trap", "Vital Spirit", "White Smoke", "Pure Power", "Shell Armor", "Air Lock", "Tangled Feet", "Motor Drive", "Rivalry", "Steadfast", "Snow Cloak", "Gluttony", "Anger Point", "Unburden", "Heatproof", "Simple", "Dry Skin", "Download", "Iron Fist", "Poison Heal", "Adaptability", "Skill Link", "Hydration", "Solar Power", "Quick Feet", "Normalize", "Sniper", "Magic Guard", "No Guard", "Stall", "Technician", "Leaf Guard", "Klutz", "Mold Breaker", "Super Luck", "Aftermath", "Anticipation", "Forewarn", "Unaware", "Tinted Lens", "Filter", "Slow Start", "Scrappy", "Storm Drain", "Ice Body", "Solid Rock", "Snow Warning", "Honey Gather", "Frisk", "Reckless", "Multitype", "Flower Gift", "Bad Dreams", "Pickpocket", "Sheer Force", "Contrary", "Unnerve", "Defiant", "Defeatist", "Cursed Body", "Healer", "Friend Guard", "Weak Armor", "Heavy Metal", "Light Metal", "Multiscale", "Toxic Boost", "Flare Boost", "Harvest", "Telepathy", "Moody", "Overcoat", "Poison Touch", "Regenerator", "Big Pecks", "Sand Rush", "Wonder Skin", "Analytic", "Illusion", "Imposter", "Infiltrator", "Mummy", "Moxie", "Justified", "Rattled", "Magic Bounce", "Sap Sipper", "Prankster", "Sand Force", "Iron Barbs", "Zen Mode", "Victory Star", "Turboblaze", "Teravolt", "Aroma Veil", "Flower Veil", "Cheek Pouch", "Protean", "Fur Coat", "Magician", "Bulletproof", "Competitive", "Strong Jaw", "Refrigerate", "Sweet Veil", "Stance Change", "Gale Wings", "Mega Launcher", "Grass Pelt", "Symbiosis", "Tough Claws", "Pixilate", "Gooey", "Aerilate", "Parental Bond", "Dark Aura", "Fairy Aura", "Aura Break", "Primordial Sea", "Desolate Land", "Delta Stream" };
        public string[] speciesList = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch’d", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr-Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime-Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Egg" };
        public string[] moveList = { "[None]", "Pound", "Karate Chop", "Double Slap", "Comet Punch", "Mega Punch", "Pay Day", "Fire Punch", "Ice Punch", "Thunder Punch", "Scratch", "Vice Grip", "Guillotine", "Razor Wind", "Swords Dance", "Cut", "Gust", "Wing Attack", "Whirlwind", "Fly", "Bind", "Slam", "Vine Whip", "Stomp", "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack", "Headbutt", "Horn Attack", "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take Down", "Thrash", "Double-Edge", "Tail Whip", "Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite", "Growl", "Roar", "Sing", "Supersonic", "Sonic Boom", "Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump", "Surf", "Ice Beam", "Blizzard", "Psybeam", "Bubble Beam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck", "Submission", "Low Kick", "Counter", "Seismic Toss", "Strength", "Absorb", "Mega Drain", "Leech Seed", "Growth", "Razor Leaf", "Solar Beam", "Poison Powder", "Stun Spore", "Sleep Powder", "Petal Dance", "String Shot", "Dragon Rage", "Fire Spin", "Thunder Shock", "Thunderbolt", "Thunder Wave", "Thunder", "Rock Throw", "Earthquake", "Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate", "Agility", "Quick Attack", "Rage", "Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover", "Harden", "Minimize", "Smokescreen", "Confuse Ray", "Withdraw", "Defense Curl", "Barrier", "Light Screen", "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move", "Self-Destruct", "Egg Bomb", "Lick", "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift", "Skull Bash", "Spike Cannon", "Constrict", "Amnesia", "Kinesis", "Soft-Boiled", "High Jump Kick", "Glare", "Dream Eater", "Poison Gas", "Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash", "Psywave", "Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest", "Rock Slide", "Hyper Fang", "Sharpen", "Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute", "Struggle", "Sketch", "Triple Kick", "Thief", "Spider Web", "Mind Reader", "Nightmare", "Flame Wheel", "Snore", "Curse", "Flail", "Conversion 2", "Aeroblast", "Cotton Spore", "Reversal", "Spite", "Powder Snow", "Protect", "Mach Punch", "Scary Face", "Feint Attack", "Sweet Kiss", "Belly Drum", "Sludge Bomb", "Mud-Slap", "Octazooka", "Spikes", "Zap Cannon", "Foresight", "Destiny Bond", "Perish Song", "Icy Wind", "Detect", "Bone Rush", "Lock-On", "Outrage", "Sandstorm", "Giga Drain", "Endure", "Charm", "Rollout", "False Swipe", "Swagger", "Milk Drink", "Spark", "Fury Cutter", "Steel Wing", "Mean Look", "Attract", "Sleep Talk", "Heal Bell", "Return", "Present", "Frustration", "Safeguard", "Pain Split", "Sacred Fire", "Magnitude", "Dynamic Punch", "Megahorn", "Dragon Breath", "Baton Pass", "Encore", "Pursuit", "Rapid Spin", "Sweet Scent", "Iron Tail", "Metal Claw", "Vital Throw", "Morning Sun", "Synthesis", "Moonlight", "Hidden Power", "Cross Chop", "Twister", "Rain Dance", "Sunny Day", "Crunch", "Mirror Coat", "Psych Up", "Extreme Speed", "Ancient Power", "Shadow Ball", "Future Sight", "Rock Smash", "Whirlpool", "Beat Up", "Fake Out", "Uproar", "Stockpile", "Spit Up", "Swallow", "Heat Wave", "Hail", "Torment", "Flatter", "Will-O-Wisp", "Memento", "Facade", "Focus Punch", "Smelling Salts", "Follow Me", "Nature Power", "Charge", "Taunt", "Helping Hand", "Trick", "Role Play", "Wish", "Assist", "Ingrain", "Superpower", "Magic Coat", "Recycle", "Revenge", "Brick Break", "Yawn", "Knock Off", "Endeavor", "Eruption", "Skill Swap", "Imprison", "Refresh", "Grudge", "Snatch", "Secret Power", "Dive", "Arm Thrust", "Camouflage", "Tail Glow", "Luster Purge", "Mist Ball", "Feather Dance", "Teeter Dance", "Blaze Kick", "Mud Sport", "Ice Ball", "Needle Arm", "Slack Off", "Hyper Voice", "Poison Fang", "Crush Claw", "Blast Burn", "Hydro Cannon", "Meteor Mash", "Astonish", "Weather Ball", "Aromatherapy", "Fake Tears", "Air Cutter", "Overheat", "Odor Sleuth", "Rock Tomb", "Silver Wind", "Metal Sound", "Grass Whistle", "Tickle", "Cosmic Power", "Water Spout", "Signal Beam", "Shadow Punch", "Extrasensory", "Sky Uppercut", "Sand Tomb", "Sheer Cold", "Muddy Water", "Bullet Seed", "Aerial Ace", "Icicle Spear", "Iron Defense", "Block", "Howl", "Dragon Claw", "Frenzy Plant", "Bulk Up", "Bounce", "Mud Shot", "Poison Tail", "Covet", "Volt Tackle", "Magical Leaf", "Water Sport", "Calm Mind", "Leaf Blade", "Dragon Dance", "Rock Blast", "Shock Wave", "Water Pulse", "Doom Desire", "Psycho Boost", "Roost", "Gravity", "Miracle Eye", "Wake-Up Slap", "Hammer Arm", "Gyro Ball", "Healing Wish", "Brine", "Natural Gift", "Feint", "Pluck", "Tailwind", "Acupressure", "Metal Burst", "U-turn", "Close Combat", "Payback", "Assurance", "Embargo", "Fling", "Psycho Shift", "Trump Card", "Heal Block", "Wring Out", "Power Trick", "Gastro Acid", "Lucky Chant", "Me First", "Copycat", "Power Swap", "Guard Swap", "Punishment", "Last Resort", "Worry Seed", "Sucker Punch", "Toxic Spikes", "Heart Swap", "Aqua Ring", "Magnet Rise", "Flare Blitz", "Force Palm", "Aura Sphere", "Rock Polish", "Poison Jab", "Dark Pulse", "Night Slash", "Aqua Tail", "Seed Bomb", "Air Slash", "X-Scissor", "Bug Buzz", "Dragon Pulse", "Dragon Rush", "Power Gem", "Drain Punch", "Vacuum Wave", "Focus Blast", "Energy Ball", "Brave Bird", "Earth Power", "Switcheroo", "Giga Impact", "Nasty Plot", "Bullet Punch", "Avalanche", "Ice Shard", "Shadow Claw", "Thunder Fang", "Ice Fang", "Fire Fang", "Shadow Sneak", "Mud Bomb", "Psycho Cut", "Zen Headbutt", "Mirror Shot", "Flash Cannon", "Rock Climb", "Defog", "Trick Room", "Draco Meteor", "Discharge", "Lava Plume", "Leaf Storm", "Power Whip", "Rock Wrecker", "Cross Poison", "Gunk Shot", "Iron Head", "Magnet Bomb", "Stone Edge", "Captivate", "Stealth Rock", "Grass Knot", "Chatter", "Judgment", "Bug Bite", "Charge Beam", "Wood Hammer", "Aqua Jet", "Attack Order", "Defend Order", "Heal Order", "Head Smash", "Double Hit", "Roar of Time", "Spacial Rend", "Lunar Dance", "Crush Grip", "Magma Storm", "Dark Void", "Seed Flare", "Ominous Wind", "Shadow Force", "Hone Claws", "Wide Guard", "Guard Split", "Power Split", "Wonder Room", "Psyshock", "Venoshock", "Autotomize", "Rage Powder", "Telekinesis", "Magic Room", "Smack Down", "Storm Throw", "Flame Burst", "Sludge Wave", "Quiver Dance", "Heavy Slam", "Synchronoise", "Electro Ball", "Soak", "Flame Charge", "Coil", "Low Sweep", "Acid Spray", "Foul Play", "Simple Beam", "Entrainment", "After You", "Round", "Echoed Voice", "Chip Away", "Clear Smog", "Stored Power", "Quick Guard", "Ally Switch", "Scald", "Shell Smash", "Heal Pulse", "Hex", "Sky Drop", "Shift Gear", "Circle Throw", "Incinerate", "Quash", "Acrobatics", "Reflect Type", "Retaliate", "Final Gambit", "Bestow", "Inferno", "Water Pledge", "Fire Pledge", "Grass Pledge", "Volt Switch", "Struggle Bug", "Bulldoze", "Frost Breath", "Dragon Tail", "Work Up", "Electroweb", "Wild Charge", "Drill Run", "Dual Chop", "Heart Stamp", "Horn Leech", "Sacred Sword", "Razor Shell", "Heat Crash", "Leaf Tornado", "Steamroller", "Cotton Guard", "Night Daze", "Psystrike", "Tail Slap", "Hurricane", "Head Charge", "Gear Grind", "Searing Shot", "Techno Blast", "Relic Song", "Secret Sword", "Glaciate", "Bolt Strike", "Blue Flare", "Fiery Dance", "Freeze Shock", "Ice Burn", "Snarl", "Icicle Crash", "V-create", "Fusion Flare", "Fusion Bolt", "Flying Press", "Mat Block", "Belch", "Rototiller", "Sticky Web", "Fell Stinger", "Phantom Force", "Trick-or-Treat", "Noble Roar", "Ion Deluge", "Parabolic Charge", "Forest’s Curse", "Petal Blizzard", "Freeze-Dry", "Disarming Voice", "Parting Shot", "Topsy-Turvy", "Draining Kiss", "Crafty Shield", "Flower Shield", "Grassy Terrain", "Misty Terrain", "Electrify", "Play Rough", "Fairy Wind", "Moonblast", "Boomburst", "Fairy Lock", "King’s Shield", "Play Nice", "Confide", "Diamond Storm", "Steam Eruption", "Hyperspace Hole", "Water Shuriken", "Mystical Fire", "Spiky Shield", "Aromatic Mist", "Eerie Impulse", "Venom Drench", "Powder", "Geomancy", "Magnetic Flux", "Happy Hour", "Electric Terrain", "Dazzling Gleam", "Celebrate", "Hold Hands", "Baby-Doll Eyes", "Nuzzle", "Hold Back", "Infestation", "Power-Up Punch", "Oblivion Wing", "Thousand Arrows", "Thousand Waves", "Land’s Wrath", "Light of Ruin", "Origin Pulse", "Precipice Blades", "Dragon Ascent", "Hyperspace Fury" };
        public Bitmap[] ballImages = {Properties.Resources._0, Properties.Resources._1, Properties.Resources._2, Properties.Resources._3, Properties.Resources._4, Properties.Resources._5, Properties.Resources._6, Properties.Resources._7, Properties.Resources._8, Properties.Resources._9, Properties.Resources._10, Properties.Resources._11, Properties.Resources._12, Properties.Resources._13, Properties.Resources._14, Properties.Resources._15, Properties.Resources._16, Properties.Resources._17, Properties.Resources._18, Properties.Resources._19, Properties.Resources._20, Properties.Resources._21, Properties.Resources._22, Properties.Resources._23, Properties.Resources._24, };

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


        private void MainForm_Load(object sender, EventArgs e)
        {
            groupBox1.Size = new System.Drawing.Size(154, 74);
            groupBox1.Location = new System.Drawing.Point(744, 339);

            if (PingHost("fadx.co.uk") == true)
            {
                string downloadURL = "";
                Version newVersion = null;
                string aboutUpdate = "";
                string xmlUrl = "http://fadx.co.uk/PKMN-NTR/update.xml";
                XmlTextReader reader = null;
                try
                {
                    reader = new XmlTextReader(xmlUrl);
                    reader.MoveToContent();
                    string elementName = "";
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo"))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                elementName = reader.Name;
                            }
                            else
                            {
                                if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                    switch (elementName)
                                    {
                                        case "version":
                                            newVersion = new Version(reader.Value);
                                            break;
                                        case "url":
                                            downloadURL = reader.Value;
                                            break;
                                        case "about":
                                            aboutUpdate = reader.Value;
                                            break;

                                    }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(1);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
                Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                if (applicationVersion.CompareTo(newVersion) < 0)
                {
                    groupBox1.Size = new System.Drawing.Size(154, 97);
                    groupBox1.Location = new System.Drawing.Point(744, 316);
                    versionCheck.Visible = true;
                }
                else
                {
                }
            }

            species.Items.AddRange(speciesList);
            ability.Items.AddRange(abilityList);
            heldItem.Items.AddRange(itemList);
            move1.Items.AddRange(moveList);
            move2.Items.AddRange(moveList);
            move3.Items.AddRange(moveList);
            move4.Items.AddRange(moveList);

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

            dataGridView1.Columns.Add(itemItem);
            dataGridView1.Columns.Add(itemAmount);
            dataGridView2.Columns.Add(keyItem);
            dataGridView2.Columns.Add(keyAmount);
            dataGridView3.Columns.Add(tmItem);
            dataGridView3.Columns.Add(tmAmount);
            dataGridView4.Columns.Add(medItem);
            dataGridView4.Columns.Add(medAmount);
            dataGridView5.Columns.Add(berItem);
            dataGridView5.Columns.Add(berAmount);
            foreach (string t in itemList)
            {
                itemItem.Items.Add(t);
                keyItem.Items.Add(t);
                tmItem.Items.Add(t);
                medItem.Items.Add(t);
                berItem.Items.Add(t);
            }
            host.Text = Settings.Default.IP;
            runCmd("import sys;sys.path.append('.\\python\\Lib')");
            runCmd("for n in [n for n in dir(nc) if not n.startswith('_')]: globals()[n] = getattr(nc,n)    ");
            runCmd("repr([n for n in dir(nc) if not n.startswith('_')])");
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {

            }
            return pingable;
        }

        public void UpdateCheck()
        {

            if (PingHost("fadx.co.uk") == true)
            {
                string downloadURL = "";
                Version newVersion = null;
                string aboutUpdate = "";
                string xmlUrl = "http://fadx.co.uk/PKMN-NTR/update.xml";
                XmlTextReader reader = null;
                try
                {
                    reader = new XmlTextReader(xmlUrl);
                    reader.MoveToContent();
                    string elementName = "";
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo"))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                elementName = reader.Name;
                            }
                            else
                            {
                                if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                    switch (elementName)
                                    {
                                        case "version":
                                            newVersion = new Version(reader.Value);
                                            break;
                                        case "url":
                                            downloadURL = reader.Value;
                                            break;
                                        case "about":
                                            aboutUpdate = reader.Value;
                                            break;

                                    }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(1);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
                Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                if (applicationVersion.CompareTo(newVersion) < 0)
                {
                    string str = String.Format("Current Version: {0}.\nLatest Vesion: {1}. \n\nWhat's new: {2} ", applicationVersion, newVersion, aboutUpdate);
                    if (DialogResult.No != MessageBox.Show(str + "\n\nDownload now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        try
                        {
                            Process.Start(downloadURL);
                        }
                        catch { }
                        return;
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        public static class Delay
        {

            static System.Windows.Forms.Timer runDelegates;
            static Dictionary<MethodInvoker, DateTime> delayedDelegates = new Dictionary<MethodInvoker, DateTime>();

            static Delay()
            {

                runDelegates = new System.Windows.Forms.Timer();
                runDelegates.Interval = 250;
                runDelegates.Tick += RunDelegates;
                runDelegates.Enabled = true;

            }

            public static void Add(MethodInvoker method, int delay)
            {

                delayedDelegates.Add(method, DateTime.Now + TimeSpan.FromSeconds(delay));

            }

            static void RunDelegates(object sender, EventArgs e)
            {

                List<MethodInvoker> removeDelegates = new List<MethodInvoker>();

                foreach (MethodInvoker method in delayedDelegates.Keys)
                {

                    if (DateTime.Now >= delayedDelegates[method])
                    {
                        method();
                        removeDelegates.Add(method);
                    }

                }

                foreach (MethodInvoker method in removeDelegates)
                {

                    delayedDelegates.Remove(method);

                }


            }

        }


        public delegate void LogDelegate(string l);
        public LogDelegate delAddLog;

        public MainForm()
        {
            delAddLog = new LogDelegate(Addlog);
            InitializeComponent();
        }

        void writeTab_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        //Returns 0 on success, other values on failure
        private int readPokemonFromFile(string filename, byte[] result)
        {
            string extension = Path.GetExtension(filename);

            bool isEncrypted = false;

            if (extension == ".pk6" || extension == ".pkx")
                isEncrypted = false;
            else if (extension == ".ek6" || extension == ".ekx")
                isEncrypted = true;
            else
            {
                MessageBox.Show("Please make sure you are using a valid PKX/EKX file.", "Incorrect File Size");
                txtLog.Clear();
                return 1;
            }

            byte[] tmpBytes = File.ReadAllBytes(filename);

            if (tmpBytes.Length == 260 || tmpBytes.Length == 232)
            {
                //All OK, commit
                if (isEncrypted)
                {
                    tmpBytes.CopyTo(result,0);
                }
                else
                {
                    PKHeX.encryptArray(tmpBytes.Take(POKEBYTES).ToArray()).CopyTo(result,0);
                }
            }
            else
            {
                MessageBox.Show("Please make sure you are using a valid PKX/EKX file.", "Incorrect File Size");
                txtLog.Clear();
                return 2;
            }
            return 0;
        }

        //Returns 0 on success, positive value represents how many copies could not be written.
        //TODO: przepisać, aby wykonywał jeden zapis - tak jak teraz jest bardzo powolny
        private int writePokemonToBox(byte[] data, int boxFrom, int count)
        {
            int i;
            if (data.Length != POKEBYTES)
                return -1;
            string dataString = BytesAsNTRString(data);

            for (i=0; i<count; i++)
            {
                if (boxFrom + i >= BOXES * BOXSIZE)
                { 
                    break;
                }
                int offset = boff + (boxFrom + i) * POKEBYTES;
                string pokeek6 = "write(0x" + offset.ToString("X") + ", " + dataString + ", pid=" + pid + ")";
                runCmd(pokeek6);
                txtLog.Clear();
            }
            return count - i; 
        }
        /*
        private int readPokemonFromBox(int boxIndex, byte[] dataOut)
        {
            int i;
            if (data.Length != POKEBYTES)
                return -1;
            string dataString = BytesAsNTRString(data);

            for (i = 0; i < count; i++)
            {
                if (boxFrom + i >= BOXES * BOXSIZE)
                {
                    break;
                }
                int offset = boff + (boxFrom + i) * POKEBYTES;
                string pokeek6 = "write(0x" + offset.ToString("X") + ", " + dataString + ", pid=" + pid + ")";
                runCmd(pokeek6);
                txtLog.Clear();
            }
            return count - i;
        }
        */
        private void cloneDoIt_Click(object sender, EventArgs e)
        {
            //TODO: na razie kod testowy
            UInt32 offset = (UInt32) boff;
            /*
            string dumpek6 = "data(0x" + offset.ToString("X") + ", 0xE8, filename='test1.bin', pid=" + pid + ")";
            runCmd(dumpek6);
            offset += POKEBYTES;
            dumpek6 = "data(0x" + offset.ToString("X") + ", 0xE8, filename='test2.bin', pid=" + pid + ")";
            runCmd(dumpek6);
            */
            int pid_num = Convert.ToInt32(pid, 16);
            Program.scriptHelper.data(offset, 0xe8, pid_num, "test3.bin");
        }

        #region housekeeping for write from file
        private int writeGetCopies()
        {
            return Decimal.ToInt32(writeCopiesNo.Value);
        }

        private int writeGetBoxIndex()
        {
            return Decimal.ToInt32((writeBoxTo.Value - 1) * BOXSIZE + writeSlotTo.Value - 1);
        }

        private void writeSetBoxIndex(int index)
        {
            if (index >= BOXES * BOXSIZE)
                index = BOXES * BOXSIZE - 1;
            int box = index / BOXSIZE;
            int slot = index % BOXSIZE;
            writeBoxTo.Value = box + 1;
            writeSlotTo.Value = slot + 1;
        }

        private void writeBoxTo_ValueChanged(object sender, EventArgs e)
        {
            writeCopiesNo.Maximum = 930 - writeGetBoxIndex();
        }

        private void writeSlotTo_ValueChanged(object sender, EventArgs e)
        {
            writeCopiesNo.Maximum = 930 - writeGetBoxIndex();
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
                selectedCloneValid = (readPokemonFromFile(selectWriteDialog.FileName, selectedCloneData) == 0);
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
                MessageBox.Show(ret + " write(s) failed because end of boxes was reached.", "Error");
            else if (ret < 0)
                return; // TODO: obsługa błędów?
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
            //TODO: może komunikat, jeśli importujemy wiele plików?
            int fails = 0;
            foreach (string filename in files)
            {
                //MessageBox.Show("Writing " + filename + "...");
                byte[] data = new byte[POKEBYTES];
                if (readPokemonFromFile(filename, data) == 0)
                {
                    int ret = writePokemonToBox(data, writeGetBoxIndex(), writeGetCopies());
                    if (ret > 0)
                        fails += ret;
                    else if (ret < 0)
                        return; // TODO: obsługa błędów?
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

        /* 
        public void isCloneDumped()
        {
            if (txtLog.Text.Contains("clone.temp successfully"))
            {
                afterCloneDump();
            }
        }

        public void afterCloneDump()
        {
            byte[] selectedclonebytes = File.ReadAllBytes(@Application.StartupPath + "\\clone.temp");
            int ss = (Decimal.ToInt32(clonetoBoxFB.Value) * 30 - 30) + Decimal.ToInt32(clonetoSlotFB.Value) - 1;
            int ssOff = boff + (ss * 232);
            string ssH = ssOff.ToString("X");
            int icloneAmount = (int)cloneAmountFB.Value * 232;
            byte[] clone = new byte[icloneAmount];
            for (int i = 0; i < cloneAmountFB.Value; i++)
            {
                selectedclonebytes.CopyTo(clone, (i) * 232);
            }
            string ek6 = BitConverter.ToString(clone).Replace("-", ", 0x");
            string ssr = "0x";
            string ssS = ssr + ssH;
            string pokeek6 = "write(0x" + ssH + ", (0x" + ek6 + "), pid=" + pid + ")";
            runCmd(pokeek6);
            txtLog.Clear();
            RMTemp();
        }

        private void cloneFB_Click(object sender, EventArgs e)
        {
            int ssd = (Decimal.ToInt32(clonefromBoxFB.Value) * 30 - 30) + Decimal.ToInt32(clonefromSlotFB.Value) - 1;
            int ssdOff = boff + (ssd * 232);
            string ssdH = ssdOff.ToString("X");
            string dumpek6 = "data(0x" + ssdH + ", 0xE8, filename='clone.temp', pid=" + pid + ")";
            runCmd(dumpek6);
        }

        private void clonetoBoxFB_ValueChanged(object sender, EventArgs e)
        {
            cloneAmountFB.Maximum = 930 - ((clonetoBoxFB.Value * 30 - 30) + (clonetoSlotFB.Value - 1));
        }

        private void clonetoSlotFB_ValueChanged(object sender, EventArgs e)
        {
            cloneAmountFB.Maximum = 930 - ((clonetoBoxFB.Value * 30 - 30) + (clonetoSlotFB.Value - 1));
        }

        private void cloneAmountFB_ValueChanged(object sender, EventArgs e)
        {
            cloneAmountFB.Maximum = 930 - ((clonetoBoxFB.Value * 30 - 30) + (clonetoSlotFB.Value - 1));
        }
        */

        public void Addlog(string l)
        {
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

        public void runCmd(String cmd)
        {
            try
            {
                object ret = Program.pyEngine.CreateScriptSourceFromString(cmd).Execute(Program.globalScope);
            }
            catch (Exception ex)
            {
                Addlog(ex.Message);
                Addlog(ex.StackTrace);
            }
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
            RMTempEK6();
            Program.ntrClient.disconnect();
        }


        public void startAutoDisconnect()
        {
            disconnectTimer.Enabled = true;

        }


        private void disconnectTimer_Tick(object sender, EventArgs e)
        {
            disconnectTimer.Enabled = false;
            runCmd("disconnect()");
        }

        public void listprocesses()
        {
            runCmd("listprocess()");
        }



        public void connectCheck()
        {

            if (txtLog.Text.Contains("Server connected"))
            {
                buttonConnect.Text = "Connected";
                listprocesses();
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                pokeMoney.Enabled = true;
                pokeMiles.Enabled = true;
                pokeBP.Enabled = true;
                moneyNum.Enabled = true;
                milesNum.Enabled = true;
                bpNum.Enabled = true;
                slotDump.Enabled = true;
                boxDump.Enabled = true;
                nameek6.Enabled = true;
                dumpek6.Enabled = true;
                dumpBoxes.Enabled = true;
                radioBoxes.Enabled = true;
                radioDaycare.Enabled = true;
                radioOpponent.Enabled = true;
                radioTrade.Enabled = true;
                pokeName.Enabled = true;
                playerName.Enabled = true;
                pokeTID.Enabled = true;
                pokeSID.Enabled = true;
                SIDNum.Enabled = true;
                TIDNum.Enabled = true;
                hourNum.Enabled = true;
                minNum.Enabled = true;
                secNum.Enabled = true;
                pokeTime.Enabled = true;
                dataGridView1.Enabled = true;
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = true;
                dataGridView5.Enabled = true;
                showItems.Enabled = true;
                showMedicine.Enabled = true;
                showTMs.Enabled = true;
                showBerries.Enabled = true;
                showKeys.Enabled = true;
                itemAdd.Enabled = true;
                itemWrite.Enabled = true;
                dataGridView1.Enabled = true;
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = true;
                dataGridView5.Enabled = true;
                delPkm.Enabled = true;
                deleteBox.Enabled = true;
                deleteSlot.Enabled = true;
                Lang.Enabled = true;
                pokeLang.Enabled = true;
                ivHPNum.Enabled = true;
                ivATKNum.Enabled = true;
                ivDEFNum.Enabled = true;
                ivSPENum.Enabled = true;
                ivSPANum.Enabled = true;
                ivSPDNum.Enabled = true;
                evHPNum.Enabled = true;
                evATKNum.Enabled = true;
                evDEFNum.Enabled = true;
                evSPENum.Enabled = true;
                evSPANum.Enabled = true;
                evSPDNum.Enabled = true;
                isEgg.Enabled = true;
                nickname.Enabled = true;
                nature.Enabled = true;
                button1.Enabled = true;
                heldItem.Enabled = true;
                species.Enabled = true;
                /*
                clonefromBoxFB.Enabled = true;
                clonefromSlotFB.Enabled = true;
                clonetoBoxFB.Enabled = true;
                clonetoSlotFB.Enabled = true;
                cloneAmountFB.Enabled = true;
                cloneFB.Enabled = true;
                cloneAmountFF.Enabled = true;
                cloneFF.Enabled = true;
                clonetoBoxFF.Enabled = true;
                clonetoSlotFF.Enabled = true;
                chooseCloneFF.Enabled = true;
                fromBoxes.Enabled = true;
                fromFile.Enabled = true;
                */
                deleteAmount.Enabled = true;
                ability.Enabled = true;
                move1.Enabled = true;
                move2.Enabled = true;
                move3.Enabled = true;
                move4.Enabled = true;
                ball.Enabled = true;
                radioParty.Enabled = true;
                dTIDNum.Enabled = true;
                dSIDNum.Enabled = true;
                otName.Enabled = true;
                dPID.Enabled = true;
                setShiny.Enabled = true;
                onlyView.Enabled = true;
                gender.Enabled = true;
                friendship.Enabled = true;
                randomPID.Enabled = true;
                radioBattleBox.Enabled = true;
                Settings.Default.IP = host.Text;
                Settings.Default.Save();
            }
        }

        public void getGame()
        {
            //XY
            if (txtLog.Text.Contains("kujira-1"))
            {
                string log = txtLog.Text;
                pname = ", pname: kujira-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                pid = "0x" + splitlog.Substring(0, 2);
                moneyoff = "0x8C6A6AC";
                milesoff = "0x8C82BA0";
                bpoff = "0x8C6A6E0";
                boff = 0x8C861C8;
                boffs = "0x8C861C8";
                d1off = "0x8C7FF4C";
                d2off = "0x8C8003C";
                itemsoff = "0x8C67564";
                medsoff = "0x8C67ECC";
                keysoff = "0x8C67BA4";
                tmsoff = "0x8C67D24";
                bersoff = "0x8C67FCC";
                nameoff = "0x8C79C84";
                tidoff = "0x8C79C3C";
                sidoff = "0x8C79C3E";
                hroff = "0x8CE2814";
                minoff = "0x8CE2816";
                secoff = "0x8CE2817";
                langoff = "0x8C79C69";
                tradeoffrg = "0x8500000";
                bboff = 147237932;
                opwroff = "0x8C7D23E";
                shoutoutOff = 0x8803CF8;
                dumpMoney();
            }

            if (txtLog.Text.Contains("kujira-2"))
            {
                string log = txtLog.Text;
                pname = ", pname: kujira-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                pid = "0x" + splitlog.Substring(0, 2);
                moneyoff = "0x8C6A6AC";
                milesoff = "0x8C82BA0";
                bpoff = "0x8C6A6E0";
                boff = 0x8C861C8;
                boffs = "0x8C861C8";
                d1off = "0x8C7FF4C";
                d2off = "0x8C8003C";
                itemsoff = "0x8C67564";
                medsoff = "0x8C67ECC";
                keysoff = "0x8C67BA4";
                tmsoff = "0x8C67D24";
                bersoff = "0x8C67FCC";
                nameoff = "0x8C79C84";
                tidoff = "0x8C79C3C";
                sidoff = "0x8C79C3E";
                hroff = "0x8CE2814";
                minoff = "0x8CE2816";
                secoff = "0x8CE2817";
                langoff = "0x8C79C69";
                tradeoffrg = "0x8500000";
                bboff = 147237932;
                opwroff = "0x8C7D23E";
                shoutoutOff = 0x8803CF8;
                dumpMoney();
            }

            //Omega Ruby
            if (txtLog.Text.Contains("sango-1"))
            {
                string log = txtLog.Text;
                pname = ", pname:  sango-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                pid = "0x" + splitlog.Substring(0, 2);
                moneyoff = "0x8C71DC0";
                milesoff = "0x8C8B36C";
                bpoff = "0x8C71DE8";
                boff = 0x8C9E134;
                boffs = "0x8C9E134";
                d1off = "0x8C88370";
                d2off = "0x8C88460";
                itemsoff = "0x8C6EC70";
                medsoff = "0x8C6F5E0";
                keysoff = "0x8C6F2B0";
                tmsoff = "0x8C6F430";
                bersoff = "0x8C6F6E0";
                nameoff = "0x8C81388";
                tidoff = "0x8C81340";
                sidoff = "0x8C81342";
                hroff = "0x8CFBD88";
                minoff = "0x8CFBD8A";
                secoff = "0x8CFBD8B";
                langoff = "0x8C8136D";
                tradeoffrg = "0x8520000";
                bboff = 147268400;
                opwroff = "0x8C83D94";
                shoutoutOff = 0x8803CF8;
                dumpMoney();
            }

            //Alpha Sapphire
            if (txtLog.Text.Contains("sango-2"))
            {
                string log = txtLog.Text;
                pname = ", pname:  sango-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                pid = "0x" + splitlog.Substring(0, 2);
                moneyoff = "0x8C71DC0";
                milesoff = "0x8C8B36C";
                bpoff = "0x8C71DE8";
                boff = 0x8C9E134;
                boffs = "0x8C9E134";
                d1off = "0x8C88370";
                d2off = "0x8C88460";
                itemsoff = "0x8C6EC70";
                medsoff = "0x8C6F5E0";
                keysoff = "0x8C6F2B0";
                tmsoff = "0x8C6F430";
                bersoff = "0x8C6F6E0";
                nameoff = "0x8C81388";
                tidoff = "0x8C81340";
                sidoff = "0x8C81342";
                hroff = "0x8CFBD88";
                minoff = "0x8CFBD8A";
                secoff = "0x8CFBD8B";
                langoff = "0x8C8136D";
                tradeoffrg = "0x8520000";
                bboff = 147268400;
                opwroff = "0x8C83D94";
                shoutoutOff = 0x8803CF8;
                dumpMoney();
            }
        }

        public void dumprealoppOff()
        {
            string dumpRealoppoff = "data(0x8800000, 0x1FFFF, filename='getoppoff.temp', pid=" + pid + ")";
            runCmd(dumpRealoppoff);
        }

        public void dumprealtradeOff()
        {
            string dumpRealtradeoff = "data(" + tradeoffrg + ", 0x1FFFF, filename='gettradeoff.temp', pid=" + pid + ")";
            runCmd(dumpRealtradeoff);
        }

        public void dumpItems()
        {
            string dumpItems = "data(" + itemsoff + ", 0x640, filename='items.temp', pid=" + pid + ")";
            runCmd(dumpItems);
        }

        public void dumpKeys()
        {
            string dumpKeys = "data(" + keysoff + ", 0x180, filename='keys.temp', pid=" + pid + ")";
            runCmd(dumpKeys);
        }

        public void dumpTMs()
        {
            string dumpTMs = "data(" + tmsoff + ", 0x1A8, filename='tms.temp', pid=" + pid + ")";
            runCmd(dumpTMs);
        }

        public void dumpMeds()
        {
            string dumpMeds = "data(" + medsoff + ", 0x100, filename='meds.temp', pid=" + pid + ")";
            runCmd(dumpMeds);
        }

        public void dumpBers()
        {
            string dumpBers = "data(" + bersoff + ", 0x120, filename='bers.temp', pid=" + pid + ")";
            runCmd(dumpBers);
        }

        public void dumpName()
        {
            string dumpName = "data(" + nameoff + ", 0x18, filename='name.temp', pid=" + pid + ")";
            runCmd(dumpName);
        }

        public void dumpTID()
        {
            string dumpTID = "data(" + tidoff + ", 0x02, filename='tid.temp', pid=" + pid + ")";
            runCmd(dumpTID);
        }

        public void dumpSID()
        {
            string dumpSID = "data(" + sidoff + ", 0x02, filename='sid.temp', pid=" + pid + ")";
            runCmd(dumpSID);
        }

        public void dumpHr()
        {
            string dumpHr = "data(" + hroff + ", 0x02, filename='hour.temp', pid=" + pid + ")";
            runCmd(dumpHr);
        }

        public void dumpMin()
        {
            string dumpMin = "data(" + minoff + ", 0x01, filename='min.temp', pid=" + pid + ")";
            runCmd(dumpMin);
        }

        public void dumpSec()
        {
            string dumpSec = "data(" + secoff + ", 0x01, filename='sec.temp', pid=" + pid + ")";
            runCmd(dumpSec);
        }

        public void dumpLang()
        {
            string dumpLang = "data(" + langoff + ", 0x01, filename='lang.temp', pid=" + pid + ")";
            runCmd(dumpLang);
        }

        public void dumpMoney()
        {
            string dumpMoney = "data(" + moneyoff + ", 0x04, filename='money.temp', pid=" + pid + ")";
            runCmd(dumpMoney);
        }

        public void dumpMiles()
        {
            string dumpMiles = "data(" + milesoff + ", 0x04, filename='miles.temp', pid=" + pid + ")";
            runCmd(dumpMiles);
        }

        public void dumpBP()
        {
            string dumpBP = "data(" + bpoff + ", 0x04, filename='bp.temp', pid=" + pid + ")";
            runCmd(dumpBP);
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }



        public void readItems()
        {
            const string dumpedItems = "items.temp";
            const string dumpedKeys = "keys.temp";
            const string dumpedTMs = "tms.temp";
            const string dumpedMeds = "meds.temp";
            const string dumpedBers = "bers.temp";

            if (File.Exists(dumpedItems))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedItems, FileMode.Open)))
                {
                    const int itemsLength = 1600;
                    items = reader.ReadBytes(itemsLength);
                    string itemsstring = BitConverter.ToString(items).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length / (Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    numofItems = Convert.ToInt32(numofItemsRounded);
                    if (numofItems <= 0)
                    {

                    }
                    else
                    {
                        dataGridView1.Rows.Add(numofItems);
                    }
                    for (int i = 0; i < numofItems; i++)
                    {
                        uint itemsfinal = BitConverter.ToUInt16(items, i * 4);
                        uint amountfinal = BitConverter.ToUInt16(items, (i * 4) + 2);
                        dataGridView1.Rows[i].Cells[0].Value = itemList[itemsfinal];
                        dataGridView1.Rows[i].Cells[1].Value = amountfinal;
                    }
                }
            }

            if (File.Exists(dumpedKeys))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedKeys, FileMode.Open)))
                {
                    const int itemsLength = 384;
                    byte[] keys = reader.ReadBytes(itemsLength);
                    string itemsstring = BitConverter.ToString(keys).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length / (Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    int numofKeys = Convert.ToInt32(numofItemsRounded);
                    if (numofKeys > 0)
                    { 
                        dataGridView2.Rows.Add(numofKeys);
                    }
                    for (int i = 0; i < numofKeys; i++)
                    {
                        uint keysfinal = BitConverter.ToUInt16(keys, i * 4);
                        uint keysamountfinal = BitConverter.ToUInt16(keys, (i * 4) + 2);
                        dataGridView2.Rows[i].Cells[0].Value = itemList[keysfinal];
                        dataGridView2.Rows[i].Cells[1].Value = keysamountfinal;

                    }
                }
            }

            if (File.Exists(dumpedTMs))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedTMs, FileMode.Open)))
                {
                    const int itemsLength = 432;
                    byte[] tms = reader.ReadBytes(itemsLength);
                    string itemsstring = BitConverter.ToString(tms).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length / (Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    int numofTMs = Convert.ToInt32(numofItemsRounded);
                    if (numofTMs > 0)
                    {
                        dataGridView3.Rows.Add(numofTMs);
                    }
                    for (int i = 0; i < numofTMs; i++)
                    {
                        uint tmsfinal = BitConverter.ToUInt16(tms, i * 4);
                        uint tmsamountfinal = BitConverter.ToUInt16(tms, (i * 4) + 2);
                        dataGridView3.Rows[i].Cells[0].Value = itemList[tmsfinal];
                        dataGridView3.Rows[i].Cells[1].Value = tmsamountfinal;

                    }
                }
            }

            if (File.Exists(dumpedMeds))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedMeds, FileMode.Open)))
                {
                    const int itemsLength = 256;
                    byte[] meds = reader.ReadBytes(itemsLength);
                    string itemsstring = BitConverter.ToString(meds).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length / (Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    int numofMeds = Convert.ToInt32(numofItemsRounded);
                    if (numofMeds > 0)
                    {
                        dataGridView4.Rows.Add(numofMeds);
                    }
                    for (int i = 0; i < numofMeds; i++)
                    {
                        uint medsfinal = BitConverter.ToUInt16(meds, i * 4);
                        uint medsamountfinal = BitConverter.ToUInt16(meds, (i * 4) + 2);
                        dataGridView4.Rows[i].Cells[0].Value = itemList[medsfinal];
                        dataGridView4.Rows[i].Cells[1].Value = medsamountfinal;

                    }
                }
            }

            if (File.Exists(dumpedBers))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedBers, FileMode.Open)))
                {
                    const int itemsLength = 288;
                    byte[] bers = reader.ReadBytes(itemsLength);
                    string itemsstring = BitConverter.ToString(bers).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length / (Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    int numofBers = Convert.ToInt32(numofItemsRounded);
                    if (numofBers > 0)
                    {
                        dataGridView5.Rows.Add(numofBers);
                    }
                    for (int i = 0; i < numofBers; i++)
                    {
                        uint bersfinal = BitConverter.ToUInt16(bers, i * 4);
                        uint bersamountfinal = BitConverter.ToUInt16(bers, (i * 4) + 2);
                        dataGridView5.Rows[i].Cells[0].Value = itemList[bersfinal];
                        dataGridView5.Rows[i].Cells[1].Value = bersamountfinal;

                    }
                }
            }
        }

        static List<int> findOccurences(byte[] haystack, byte[] needle)
        {
            List<int> occurences = new List<int>();

            for (int i = 0; i < haystack.Length; i++)
            {
                if (needle[0] == haystack[i])
                {
                    bool found = true;
                    int j, k;
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

        public void getoppOff()
        {
            const string dumpedoppOff = "getoppoff.temp";
            if (File.Exists(dumpedoppOff))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedoppOff, FileMode.Open)))
                {

                    if (moneyoff == "0x8C6A6AC")
                    {
                        byte[] relativePattern = { 0x60, 0x75, 0xC6, 0x08, 0xDC, 0xA8, 0xC7, 0x08, 0xD0, 0xB6, 0xC7, 0x08 };
                        byte[] dumpoppBytes = reader.ReadBytes(131070);
                        List<int> occurences = findOccurences(dumpoppBytes, relativePattern);

                        int i = 0;
                        foreach (int occurence in occurences)
                        {
                            int realoffsetint = 142606336 + occurence + 637;
                            realoppoffset = "0x" + realoffsetint.ToString("X");
                            string dumpOpp = "data(" + realoppoffset + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                            runCmd(dumpOpp);
                            i++;
                        }
                        MessageBox.Show("Dumped " + i);
                    }

                    if (moneyoff == "0x8C71DC0")
                    {
                        byte[] relativePattern = { 0x60, 0xE7, 0xC6, 0x08, 0x6C, 0xEC, 0xC6, 0x08, 0xE0, 0x1F, 0xC8, 0x08, 0x00, 0x39, 0xC8, 0x08 };
                        byte[] dumpoppBytes = reader.ReadBytes(131070);
                        List<int> occurences = findOccurences(dumpoppBytes, relativePattern);

                        foreach (int occurence in occurences)
                        {
                            int realoffsetint = 142606336 + occurence + 673;
                            string realoppoffset = "0x" + realoffsetint.ToString("X");
                            string dumpOpp = "data(" + realoppoffset + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                            runCmd(dumpOpp);
                        }
                    }
                }
            }
        }

        private void gettradeOff()
        {
            const string dumpedtradeOff = "gettradeoff.temp";
            if (File.Exists(dumpedtradeOff))
            {
                if (moneyoff == "0x8C6A6AC")
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(dumpedtradeOff, FileMode.Open)))
                    {
                        byte[] relativePattern = { 0x08, 0x1C, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD8, 0xBE, 0x59 };
                        byte[] dumptradeBytes = reader.ReadBytes(131070);
                        List<int> occurences = findOccurences(dumptradeBytes, relativePattern);


                        foreach (int occurence in occurences)
                        {
                            int realtradeoffsetint = 139460608 + occurence + 98;
                            realtradeoffset = "0x" + realtradeoffsetint.ToString("X");
                            string dumpTrade = "data(" + realtradeoffset + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                            runCmd(dumpTrade);
                        }

                    }
                }

                if (moneyoff == "0x8C71DC0")
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(dumpedtradeOff, FileMode.Open)))
                    {
                        byte[] relativePattern = { 0x08, 0x1E, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x9C, 0xE8, 0x5D };
                        byte[] dumptradeBytes = reader.ReadBytes(131070);
                        List<int> occurences = findOccurences(dumptradeBytes, relativePattern);


                        foreach (int occurence in occurences)
                        {
                            int realtradeoffsetint = 139591680 + occurence + 98;
                            string realtradeoffset = "0x" + realtradeoffsetint.ToString("X");
                            string dumpTrade = "data(" + realtradeoffset + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                            runCmd(dumpTrade);
                        }

                    }
                }


            }
        }


        public void readName()
        {
            const string dumpedName = "name.temp";
            if (File.Exists(dumpedName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedName, FileMode.Open)))
                {
                    byte[] nameBytes = reader.ReadBytes(24);
                    playerName.Text = Encoding.Unicode.GetString(nameBytes);
                }
            }
        }

        public void readTID()
        {
            const string dumpedTID = "tid.temp";
            if (File.Exists(dumpedTID))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedTID, FileMode.Open)))
                {
                    byte[] tidarray = reader.ReadBytes(2);
                    TIDNum.Value = 256 * tidarray[1] + tidarray[0];
                }
            }
        }

        public void readSID()
        {
            const string dumpedSID = "sid.temp";
            if (File.Exists(dumpedSID))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedSID, FileMode.Open)))
                {
                    byte[] sidarray = reader.ReadBytes(2);
                    SIDNum.Value = 256 * sidarray[1] + sidarray[0];
                }
            }
        }

        public void readHr()
        {
            const string dumpedHr = "hour.temp";
            if (File.Exists(dumpedHr))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedHr, FileMode.Open)))
                {
                    byte[] hrarray = reader.ReadBytes(2);
                    hourNum.Value = 256 * hrarray[1] + hrarray[0];
                }
            }
        }

        public void readMin()
        {
            const string dumpedMin = "min.temp";
            if (File.Exists(dumpedMin))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedMin, FileMode.Open)))
                {
                    byte minbyte = reader.ReadByte();
                    minNum.Value = minbyte;
                }
            }
        }

        public void readSec()
        {
            const string dumpedSec = "sec.temp";
            if (File.Exists(dumpedSec))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedSec, FileMode.Open)))
                {
                    byte secbyte = reader.ReadByte();
                    secNum.Value = secbyte;
                }
            }
        }

        public void readLang()
        {
            const string dumpedLang = "lang.temp";
            if (File.Exists(dumpedLang))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedLang, FileMode.Open)))
                {
                    byte langbyte = reader.ReadByte();
                    if (langbyte == 1) { Lang.SelectedIndex = 0; }
                    if (langbyte == 2) { Lang.SelectedIndex = 1; }
                    if (langbyte == 3) { Lang.SelectedIndex = 2; }
                    if (langbyte == 4) { Lang.SelectedIndex = 3; }
                    if (langbyte == 5) { Lang.SelectedIndex = 4; }
                    if (langbyte == 7) { Lang.SelectedIndex = 5; }
                    if (langbyte == 8) { Lang.SelectedIndex = 6; }
                }
            }
        }

        public void readMoney()
        {
            const string dumpedMoney = "money.temp";
            if (File.Exists(dumpedMoney))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedMoney, FileMode.Open)))
                {
                    moneyNum.Value = reader.ReadInt32();
                }
            }
        }

        public void readMiles()
        {
            const string dumpedMiles = "miles.temp";
            if (File.Exists(dumpedMiles))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedMiles, FileMode.Open)))
                {
                    milesNum.Value = reader.ReadInt32();
                }
            }
        }

        public void readBP()
        {
            const string dumpedBP = "bp.temp";
            if (File.Exists(dumpedBP))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedBP, FileMode.Open)))
                {
                    bpNum.Value = reader.ReadInt32();
                }
            }
        }

        public void RMTemp()
        {
            DirectoryInfo di = new DirectoryInfo(@Application.StartupPath);
            FileInfo[] files = di.GetFiles("*.temp")
                                 .Where(p => p.Extension == ".temp").ToArray();
            foreach (FileInfo file in files)
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch
                {
                }
        }

        public void RMTempEK6()
        {
            DirectoryInfo di = new DirectoryInfo(@Application.StartupPath);
            FileInfo[] files = di.GetFiles("*.tempek6")
                                 .Where(p => p.Extension == ".tempek6").ToArray();
            foreach (FileInfo file in files)
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch
                {
                }
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

        public static string NextAvailableBakFilename(string path)
        {
            if (!File.Exists(path))
                return path;

            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(".bak"), numberPattern));

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


        public void movebak()
        {
            if (txtLog.Text.Contains(".bak.ek6 successfully"))
            {
                string pkmfrom = @Application.StartupPath + "\\boxes.bak.ek6";
                string pkmto = @Application.StartupPath + "\\Pokemon\\Deleted\\boxes.bak.ek6";
                System.IO.FileInfo folder = new System.IO.FileInfo(@Application.StartupPath + "\\Pokemon\\Deleted\\");
                folder.Directory.Create();
                if (File.Exists(pkmto))
                {
                    File.Move(pkmfrom, NextAvailableBakFilename(pkmto));
                    pkmIsBackedUp();
                }
                else
                if (!File.Exists(pkmto))
                {
                    File.Move(pkmfrom, pkmto);
                    pkmIsBackedUp();
                }
            }
        }

        public void moveek6()
        {
            if (!txtLog.Text.Contains(nameek6.Text + ".bak.ek6 successfully"))
            {
                if (txtLog.Text.Contains(nameek6.Text + ".ek6 successfully"))
                {
                    txtLog.Clear();
                    string pkmfrom = @Application.StartupPath + "\\" + nameek6.Text + ".ek6";
                    string pkmto = @Application.StartupPath + "\\Pokemon\\" + nameek6.Text + ".ek6";
                    System.IO.FileInfo folder = new System.IO.FileInfo(@Application.StartupPath + "\\Pokemon\\");
                    folder.Directory.Create();
                    if (File.Exists(pkmto))
                    {
                        File.Move(pkmfrom, NextAvailableFilename(pkmto));
                    }
                    else
                    if (!File.Exists(pkmto))
                    {
                        File.Move(pkmfrom, pkmto);
                    }
                }
            }
        }



        public void isMoneyDumped()
        {
            if (txtLog.Text.Contains("money.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readMoney();
                    dumpMiles();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readMoney();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isMilesDumped()
        {
            if (txtLog.Text.Contains("miles.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readMiles();
                    dumpBP();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readMiles();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isBPDumped()
        {
            if (txtLog.Text.Contains("bp.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readBP();
                    dumpTID();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readBP();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isTIDDumped()
        {
            if (txtLog.Text.Contains("tid.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readTID();
                    dumpSID();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readTID();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isSIDDumped()
        {
            if (txtLog.Text.Contains("sid.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readSID();
                    dumpHr();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readSID();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isHrDumped()
        {
            if (txtLog.Text.Contains("hour.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readHr();
                    dumpMin();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readHr();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isMinDumped()
        {
            if (txtLog.Text.Contains("min.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readMin();
                    dumpSec();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readMin();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isSecDumped()
        {
            if (txtLog.Text.Contains("sec.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readSec();
                    dumpLang();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readSec();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isLangDumped()
        {
            if (txtLog.Text.Contains("lang.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readLang();
                    dumpName();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readLang();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isNameDumped()
        {
            if (txtLog.Text.Contains("name.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readName();
                    dumpKeys();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readName();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isKeysDumped()
        {
            if (txtLog.Text.Contains("keys.temp successfully"))
            {
                if (firstcheck == false)
                {
                    dumpTMs();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readItems();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isTMsDumped()
        {
            if (txtLog.Text.Contains("tms.temp successfully"))
            {
                if (firstcheck == false)
                {
                    dumpMeds();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readItems();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isMedsDumped()
        {
            if (txtLog.Text.Contains("meds.temp successfully"))
            {
                if (firstcheck == false)
                {
                    dumpBers();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readItems();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void isBersDumped()
        {
            if (txtLog.Text.Contains("bers.temp successfully"))
            {
                if (firstcheck == false)
                {
                    dumpItems();
                    txtLog.Clear();
                }
                else
                if (firstcheck == true)
                {
                    readItems();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }



        public void isItemsDumped()
        {
            if (txtLog.Text.Contains("items.temp successfully"))
            {
                if (firstcheck == false)
                {
                    readItems();
                    firstcheck = true;
                    txtLog.Clear();
                    RMTemp();
                }
                else
               if (firstcheck == true)
                {
                    readItems();
                    RMTemp();
                    txtLog.Clear();
                }
            }
        }

        public void istradeDumped()
        {
            if (txtLog.Text.Contains("gettradeoff.temp successfully"))
            {
                gettradeOff();
                RMTemp();
                txtLog.Clear();
            }
        }

        public void isoppDumped()
        {
            if (txtLog.Text.Contains("getoppoff.temp successfully"))
            {
                getoppOff();
                RMTemp();
                txtLog.Clear();
            }
        }

        public void pkmIsBackedUp()
        {
            int ideleteAmount = (int)deleteAmount.Value * 232;
            byte[] delete = new byte[ideleteAmount];
            for (int i = 0; i < deleteAmount.Value; i++)
            {
                emptyDatab.CopyTo(delete, (i) * 232);
            }
            string ek6 = BitConverter.ToString(delete).Replace("-", ", 0x");
            int ss = (Decimal.ToInt32(deleteBox.Value) * 30 - 30) + Decimal.ToInt32(deleteSlot.Value) - 1;
            int ssOff = boff + (ss * 232);
            string ssH = ssOff.ToString("X");
            string delPkm = "write(0x" + ssH + ", (" + ek6 + "), pid=" + pid + ")";
            runCmd(delPkm);
            txtLog.Clear();
        }

        public void getHP()
        {
            uint hp = (uint)(15 * ((PKHeX.IV_HP & 1) + 2 * (PKHeX.IV_ATK & 1) + 4 * (PKHeX.IV_DEF & 1) + 8 * (PKHeX.IV_SPE & 1) + 16 * (PKHeX.IV_SPA & 1) + 32 * (PKHeX.IV_SPD & 1)) / 63);

            if (hp == 0) { hiddenPower.Text = "Fighting"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(48)))), ((int)(((byte)(40))))); }
            if (hp == 1) { hiddenPower.Text = "Flying"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(144)))), ((int)(((byte)(240))))); }
            if (hp == 2) { hiddenPower.Text = "Poison"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(64)))), ((int)(((byte)(160))))); }
            if (hp == 3) { hiddenPower.Text = "Ground"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(192)))), ((int)(((byte)(104))))); }
            if (hp == 4) { hiddenPower.Text = "Rock"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(160)))), ((int)(((byte)(56))))); }
            if (hp == 5) { hiddenPower.Text = "Bug"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(184)))), ((int)(((byte)(32))))); }
            if (hp == 6) { hiddenPower.Text = "Ghost"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(88)))), ((int)(((byte)(152))))); }
            if (hp == 7) { hiddenPower.Text = "Steel"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(208))))); }
            if (hp == 8) { hiddenPower.Text = "Fire"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(48))))); }
            if (hp == 9) { hiddenPower.Text = "Water"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(144)))), ((int)(((byte)(240))))); }
            if (hp == 10) { hiddenPower.Text = "Grass"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(80))))); }
            if (hp == 11) { hiddenPower.Text = "Electric"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(208)))), ((int)(((byte)(48))))); }
            if (hp == 12) { hiddenPower.Text = "Psychic"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(88)))), ((int)(((byte)(136))))); }
            if (hp == 13) { hiddenPower.Text = "Ice"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(216)))), ((int)(((byte)(216))))); }
            if (hp == 14) { hiddenPower.Text = "Dragon"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(56)))), ((int)(((byte)(248))))); }
            if (hp == 15) { hiddenPower.Text = "Dark"; hiddenPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(88)))), ((int)(((byte)(72))))); }
        }

        public void isPkmDumped()
        {
            if (!txtLog.Text.Contains(nameek6.Text + ".bak.ek6 successfully"))
            {
                if (txtLog.Text.Contains("dump.tempek6 successfully"))
                {
                    string dumpedek6 = @Application.StartupPath + "\\dump.tempek6";
                    pkmEncrypted = System.IO.File.ReadAllBytes(dumpedek6);
                    PKHeX.Data = PKHeX.decryptArray(pkmEncrypted);
                    ivHPNum.Value = PKHeX.IV_HP;
                    ivATKNum.Value = PKHeX.IV_ATK;
                    ivDEFNum.Value = PKHeX.IV_DEF;
                    ivSPANum.Value = PKHeX.IV_SPA;
                    ivSPDNum.Value = PKHeX.IV_SPD;
                    ivSPENum.Value = PKHeX.IV_SPE;
                    evHPNum.Value = PKHeX.EV_HP;
                    evATKNum.Value = PKHeX.EV_ATK;
                    evDEFNum.Value = PKHeX.EV_DEF;
                    evSPANum.Value = PKHeX.EV_SPA;
                    evSPDNum.Value = PKHeX.EV_SPD;
                    evSPENum.Value = PKHeX.EV_SPE;
                    ball.SelectedIndex = PKHeX.Ball - 1;
                    friendship.Value = PKHeX.HT_Friendship;

                    xp.Value = PKHeX.EXP;

                    if (PKHeX.Gender == 0)
                    {
                        gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                        gender.ForeColor = Color.Blue;
                        gender.Text = "♂";
                    }
                    else
                    if (PKHeX.Gender == 1)
                    {
                        gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                        gender.ForeColor = Color.Red;
                        gender.Text = "♀";
                    }
                    else
                    if (PKHeX.Gender == 2)
                    {
                        gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                        gender.ForeColor = Color.Gray;
                        gender.Text = "-";
                    }

                    dTIDNum.Value = PKHeX.TID;
                    dSIDNum.Value = PKHeX.SID;
                    dPID.Text = PKHeX.PID.ToString("X");

                    nickname.Text = Encoding.Unicode.GetString(PKHeX.Data.Skip(64).Take(24).ToArray());
                    otName.Text = Encoding.Unicode.GetString(PKHeX.Data.Skip(176).Take(24).ToArray());

                    getHP();

                    if (PKHeX.IsEgg == true)
                    {
                        isEgg.Checked = true;
                    }
                    if (PKHeX.IsEgg == false)
                    {
                        isEgg.Checked = false;
                    }

                    species.SelectedIndex = PKHeX.Species - 1;

                    heldItem.SelectedIndex = PKHeX.HeldItem;

                    ability.SelectedIndex = PKHeX.Ability - 1;

                    nature.SelectedIndex = (int)PKHeX.Nature;

                    move1.SelectedIndex = (int)PKHeX.Move1;
                    move2.SelectedIndex = (int)PKHeX.Move2;
                    move3.SelectedIndex = (int)PKHeX.Move3;
                    move4.SelectedIndex = (int)PKHeX.Move4;

                    ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
                    ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
                    ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((PKHeX.PID >> 16 ^ PKHeX.PID & 0xFFFF) >> 4)).ToString());

                    if (PKHeX.isShiny == true)
                    {
                        setShiny.Enabled = false;
                        setShiny.Text = "★";
                    }
                    if (PKHeX.isShiny == false)
                    {
                        setShiny.Enabled = true;
                        setShiny.Text = "☆";
                    }
                }
                if (txtLog.Text.Contains(nameek6.Text + ".ek6 successfully"))
                {
                    string dumpedek6 = @Application.StartupPath + "\\" + nameek6.Text + ".ek6";
                    pkmEncrypted = System.IO.File.ReadAllBytes(dumpedek6);
                    PKHeX.Data = PKHeX.decryptArray(pkmEncrypted);
                    ivHPNum.Value = PKHeX.IV_HP;
                    ivATKNum.Value = PKHeX.IV_ATK;
                    ivDEFNum.Value = PKHeX.IV_DEF;
                    ivSPANum.Value = PKHeX.IV_SPA;
                    ivSPDNum.Value = PKHeX.IV_SPD;
                    ivSPENum.Value = PKHeX.IV_SPE;
                    evHPNum.Value = PKHeX.EV_HP;
                    evATKNum.Value = PKHeX.EV_ATK;
                    evDEFNum.Value = PKHeX.EV_DEF;
                    evSPANum.Value = PKHeX.EV_SPA;
                    evSPDNum.Value = PKHeX.EV_SPD;
                    evSPENum.Value = PKHeX.EV_SPE;
                    ball.SelectedIndex = PKHeX.Ball - 1;
                    friendship.Value = PKHeX.HT_Friendship;

                    xp.Value = PKHeX.EXP;

                    if (PKHeX.Gender == 0)
                    {
                        gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                        gender.ForeColor = Color.Blue;
                        gender.Text = "♂";
                    }
                    else
                    if (PKHeX.Gender == 1)
                    {
                        gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                        gender.ForeColor = Color.Red;
                        gender.Text = "♀";
                    }
                    else
                    if (PKHeX.Gender == 2)
                    {
                        gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                        gender.ForeColor = Color.Gray;
                        gender.Text = "-";
                    }

                    dTIDNum.Value = PKHeX.TID;
                    dSIDNum.Value = PKHeX.SID;
                    dPID.Text = PKHeX.PID.ToString("X");

                    nickname.Text = Encoding.Unicode.GetString(PKHeX.Data.Skip(64).Take(24).ToArray());
                    otName.Text = Encoding.Unicode.GetString(PKHeX.Data.Skip(176).Take(24).ToArray());

                    getHP();

                    if (PKHeX.IsEgg == false)
                    {
                        isEgg.Checked = false;
                    }
                    if (PKHeX.IsEgg == true)
                    {
                        isEgg.Checked = true;
                    }

                    species.SelectedIndex = PKHeX.Species - 1;

                    heldItem.SelectedIndex = PKHeX.HeldItem;

                    ability.SelectedIndex = PKHeX.Ability - 1;

                    nature.SelectedIndex = (int)PKHeX.Nature;

                    move1.SelectedIndex = (int)PKHeX.Move1;
                    move2.SelectedIndex = (int)PKHeX.Move2;
                    move3.SelectedIndex = (int)PKHeX.Move3;
                    move4.SelectedIndex = (int)PKHeX.Move4;

                    ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
                    ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
                    ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((PKHeX.PID >> 16 ^ PKHeX.PID & 0xFFFF) >> 4)).ToString());

                    if (PKHeX.isShiny == true)
                    {
                        setShiny.Enabled = false;
                        setShiny.Text = "★";
                    }
                    if (PKHeX.isShiny == false)
                    {
                        setShiny.Enabled = true;
                        setShiny.Text = "☆";
                    }
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            runCmd("connect('" + host.Text + "',8000)");
            Delay.Add(connectCheck, 2);
            Delay.Add(getGame, 3);
        }


        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            runCmd("disconnect()");
            buttonConnect.Text = "Connect";
            firstcheck = false;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            pokeMoney.Enabled = false;
            pokeMiles.Enabled = false;
            pokeBP.Enabled = false;
            moneyNum.Enabled = false;
            milesNum.Enabled = false;
            bpNum.Enabled = false;
            slotDump.Enabled = false;
            boxDump.Enabled = false;
            nameek6.Enabled = false;
            dumpek6.Enabled = false;
            dumpBoxes.Enabled = false;
            radioBoxes.Enabled = false;
            radioDaycare.Enabled = false;
            radioOpponent.Enabled = false;
            radioTrade.Enabled = false;
            pokeName.Enabled = false;
            playerName.Enabled = false;
            pokeTID.Enabled = false;
            TIDNum.Enabled = false;
            pokeSID.Enabled = false;
            SIDNum.Enabled = false;
            hourNum.Enabled = false;
            minNum.Enabled = false;
            secNum.Enabled = false;
            pokeTime.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            dataGridView3.Enabled = false;
            dataGridView4.Enabled = false;
            dataGridView5.Enabled = false;
            showItems.Enabled = false;
            showMedicine.Enabled = false;
            showTMs.Enabled = false;
            showBerries.Enabled = false;
            showKeys.Enabled = false;
            itemAdd.Enabled = false;
            itemWrite.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            dataGridView3.Enabled = false;
            dataGridView4.Enabled = false;
            dataGridView5.Enabled = false;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            delPkm.Enabled = false;
            deleteBox.Enabled = false;
            deleteSlot.Enabled = false;
            Lang.Enabled = false;
            pokeLang.Enabled = false;
            ivHPNum.Enabled = false;
            ivATKNum.Enabled = false;
            ivDEFNum.Enabled = false;
            ivSPENum.Enabled = false;
            ivSPANum.Enabled = false;
            ivSPDNum.Enabled = false;
            evHPNum.Enabled = false;
            evATKNum.Enabled = false;
            evDEFNum.Enabled = false;
            evSPENum.Enabled = false;
            evSPANum.Enabled = false;
            evSPDNum.Enabled = false;
            isEgg.Enabled = false;
            nickname.Enabled = false;
            nature.Enabled = false;
            button1.Enabled = false;
            heldItem.Enabled = false;
            species.Enabled = false;
            /*
            clonefromBoxFB.Enabled = false;
            clonefromSlotFB.Enabled = false;
            clonetoBoxFB.Enabled = false;
            clonetoSlotFB.Enabled = false;
            cloneAmountFB.Enabled = false;
            cloneFB.Enabled = false;
            cloneAmountFF.Enabled = false;
            cloneFF.Enabled = false;
            clonetoBoxFF.Enabled = false;
            clonetoSlotFF.Enabled = false;
            chooseCloneFF.Enabled = false;
            fromBoxes.Enabled = false;
            fromFile.Enabled = false;
            */
            deleteAmount.Enabled = false;
            ability.Enabled = false;
            move1.Enabled = false;
            move2.Enabled = false;
            move3.Enabled = false;
            move4.Enabled = false;
            ball.Enabled = false;
            radioParty.Enabled = false;
            dTIDNum.Enabled = false;
            dSIDNum.Enabled = false;
            otName.Enabled = false;
            dPID.Enabled = false;
            setShiny.Enabled = false;
            onlyView.Enabled = false;
            gender.Enabled = false;
            friendship.Enabled = false;
            randomPID.Enabled = false;
            radioBattleBox.Enabled = false;
        }

        public void txtLog_TextChanged(object sender, EventArgs e)
        {
            isMoneyDumped();
            isMilesDumped();
            isBPDumped();
            isTIDDumped();
            isSIDDumped();
            isHrDumped();
            isMinDumped();
            isSecDumped();
            isLangDumped();
            isNameDumped();
            isKeysDumped();
            isTMsDumped();
            isMedsDumped();
            isBersDumped();
            istradeDumped();
            isoppDumped();
            isPkmDumped();
            isItemsDumped();
            //isCloneDumped(); TODO: co ta funkcja właściwie robiła?
            moveek6();
            movebak();
        }

        private string BytesAsNTRString(byte[] bytes)
        {
            const string separator = ", 0x";
            if (bytes.Length == 0)
                return "";  //TODO: Czy to ma liczyć się jako błąd?
            else if (bytes.Length == 1)
                return "0x" + BitConverter.ToString(bytes);
            else
                return "(0x" + BitConverter.ToString(bytes).Replace("-", separator) + ")";
        }

        private void pokeMoney_Click(object sender, EventArgs e)
        {
            byte[] moneybyte = BitConverter.GetBytes(Convert.ToInt32(moneyNum.Value));
            string pokeString = "write(" + moneyoff + ", " + BytesAsNTRString(moneybyte) + ", pid=" + pid + ")";
            runCmd(pokeString);
        }

        private void pokeMiles_Click(object sender, EventArgs e)
        {
            byte[] milesbyte = BitConverter.GetBytes(Convert.ToInt32(milesNum.Value));
            string pokeString = "write(" + milesoff + ", " + BytesAsNTRString(milesbyte) + ", pid=" + pid + ")";
            runCmd(pokeString);
        }

        private void pokeBP_Click(object sender, EventArgs e)
        {
            byte[] bpbyte = BitConverter.GetBytes(Convert.ToInt32(bpNum.Value));
            string pokeString = "write(" + bpoff + ", " + BytesAsNTRString(bpbyte) + ", pid=" + pid + ")";
            runCmd(pokeString);
        }

        private void pokeShoutout_Click(object sender, EventArgs e)
        {
            //TODO: to tylko debug
            int shoutoutOff = 0x8818662;
            if (shoutoutOff == 0)
                return;

            if (shoutoutTextBox.Text.Length <= 16)
            {
                string shoutout = shoutoutTextBox.Text.PadRight(16, '\0');
                byte[] shoutoutbyte = Encoding.Unicode.GetBytes(shoutout);
                
                string pokeShoutout = "write(" + offsetzz.Text + 
                    ", " + BytesAsNTRString(shoutoutbyte) +
                    ", pid=" + pid + ")";
                MessageBox.Show(pokeShoutout);
                runCmd(pokeShoutout);
            }
            else
            {
                MessageBox.Show("That shoutout is too long, please choose a trainer name of 12 character or less.", "Name too long!");
            }
        }

        private void dumpek6_Click(object sender, EventArgs e)
        {
            if (onlyView.Checked == false)
            {
                int ssd = (Decimal.ToInt32(boxDump.Value) * 30 - 30) + Decimal.ToInt32(slotDump.Value) - 1;
                int ssdOff = boff + (ssd * 232);
                string ssdH = ssdOff.ToString("X");

                int pOff = partyoff + ((Decimal.ToInt32(boxDump.Value) - 1) * 484);
                string pfOff = pOff.ToString("X");

                int bbOff = bboff + ((Decimal.ToInt32(boxDump.Value) - 1) * 232);
                string bbfOff = bbOff.ToString("X");

                dumpEK6 = "data(0x" + ssdH + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                dumpDay1 = "data(" + d1off + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                dumpParty = "data(0x" + pfOff + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";
                dumpBattleBox = "data(0x" + bbfOff + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";


                if (radioBattleBox.Checked == true)
                {
                    runCmd(dumpBattleBox);
                }

                if (radioBoxes.Checked == true)
                {
                    runCmd(dumpEK6);
                }
                if (radioDaycare.Checked == true)
                {
                    runCmd(dumpDay1);
                }
                if (radioOpponent.Checked == true)
                {
                    dumprealoppOff();
                }
                if (radioTrade.Checked == true)
                {
                    dumprealtradeOff();
                }
                if (radioParty.Checked == true)
                {
                    runCmd(dumpParty);
                }

                txtLog.Clear();
            }

            if (onlyView.Checked == true)
            {
                int ssd = (Decimal.ToInt32(boxDump.Value) * 30 - 30) + Decimal.ToInt32(slotDump.Value) - 1;
                int ssdOff = boff + (ssd * 232);
                string ssdH = ssdOff.ToString("X");

                int pOff = partyoff + ((Decimal.ToInt32(boxDump.Value) - 1) * 484);
                string pfOff = pOff.ToString("X");

                int bbOff = bboff + ((Decimal.ToInt32(boxDump.Value) - 1) * 232);
                string bbfOff = bbOff.ToString("X");

                dumpEK6 = "data(0x" + ssdH + ", 0xE8, filename='dump.tempek6', pid=" + pid + ")";
                dumpDay1 = "data(" + d1off + ", 0xE8, filename='dump.tempek6', pid=" + pid + ")";
                dumpParty = "data(0x" + pfOff + ", 0xE8, filename='dump.tempek6', pid=" + pid + ")";
                dumpBattleBox = "data(0x" + bbfOff + ", 0xE8, filename='dump.tempek6', pid=" + pid + ")";


                if (radioBattleBox.Checked == true)
                {
                    runCmd(dumpBattleBox);
                }

                if (radioBoxes.Checked == true)
                {
                    runCmd(dumpEK6);
                }
                if (radioDaycare.Checked == true)
                {
                    runCmd(dumpDay1);
                }
                if (radioOpponent.Checked == true)
                {
                    dumprealoppOff();
                }
                if (radioTrade.Checked == true)
                {
                    dumprealtradeOff();
                }
                if (radioParty.Checked == true)
                {
                    runCmd(dumpParty);
                }
                txtLog.Clear();
            }
        }

        private void dumpBoxes_Click(object sender, EventArgs e)
        {
            string dumpBoxes = "data(" + boffs + ", 0x34AD0, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";

            string dumpDay2 = "data(" + d2off + ", 0xE8, filename='" + nameek6.Text + ".ek6', pid=" + pid + ")";

            if (radioBoxes.Checked == true)
            {
                runCmd(dumpBoxes);
            }
            if (radioDaycare.Checked == true)
            {
                runCmd(dumpDay2);
            }
            txtLog.Clear();
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
            dumpek6.Size = new System.Drawing.Size(86, 23);
            dumpBoxes.Size = new System.Drawing.Size(105, 23);
            dumpBoxes.Location = new System.Drawing.Point(98, 61);
            dumpek6.Location = new System.Drawing.Point(6, 61);
            dumpek6.Text = "Dump";
            dumpBoxes.Text = "Dump All Boxes";
            onlyView.Visible = true;
            label50.Visible = true;
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
            dumpek6.Location = new System.Drawing.Point(6, 61);
            nameek6.Location = new System.Drawing.Point(6, 39);
            label9.Location = new System.Drawing.Point(6, 20);
            dumpek6.Size = new System.Drawing.Size(95, 23);
            dumpBoxes.Size = new System.Drawing.Size(95, 23);
            dumpBoxes.Location = new System.Drawing.Point(108, 61);
            nameek6.Size = new System.Drawing.Size(197, 23);
            dumpek6.Text = "Dump Slot 1";
            dumpBoxes.Text = "Dump Slot 2";
            dumpBoxes.Enabled = true;
            nameek6.Enabled = true;
            onlyView.Visible = false;
            label50.Visible = false;
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
            dumpek6.Location = new System.Drawing.Point(6, 61);
            nameek6.Location = new System.Drawing.Point(6, 39);
            label9.Location = new System.Drawing.Point(6, 20);
            dumpek6.Size = new System.Drawing.Size(197, 23);
            nameek6.Size = new System.Drawing.Size(197, 23);
            dumpek6.Text = "Dump";
            dumpBoxes.Enabled = true;
            nameek6.Enabled = true;
            onlyView.Visible = false;
            label50.Visible = false;
        }


        private void pokeBoxName_Click(object sender, EventArgs e)
        {

        }

        private void pokeName_Click(object sender, EventArgs e)
        {
            if (playerName.Text.Length <= 12)
            {
                string nameS = playerName.Text.PadRight(12, '\0');
                byte[] namebyte = Encoding.Unicode.GetBytes(nameS);
                string namer = ", 0x";
                string name = BitConverter.ToString(namebyte).Replace("-", namer);
                string pokeName = "write(" + nameoff + ", (0x" + name + "), pid=" + pid + ")";
                runCmd(pokeName);
            }

            if (playerName.Text.Length > 12)
            {
                MessageBox.Show("That name is too long, please choose a trainer name of 12 character or less.", "Name too long!");
            }
        }


        private void pokeTID_Click(object sender, EventArgs e)
        {
            byte[] tidbyte = BitConverter.GetBytes(Convert.ToUInt16((double)TIDNum.Value));
            string tidr = ", 0x";
            string tid = BitConverter.ToString(tidbyte).Replace("-", tidr);
            string pokeTID = "write(" + tidoff + ", (0x" + tid + "), pid=" + pid + ")";
            runCmd(pokeTID);
        }

        private void pokeTime_Click(object sender, EventArgs e)
        {
            byte[] hrbyte = BitConverter.GetBytes(Convert.ToUInt16((double)hourNum.Value));
            string hrr = ", 0x";
            string hr = BitConverter.ToString(hrbyte).Replace("-", hrr);
            string pokeHr = "write(" + hroff + ", (0x" + hr + "), pid=" + pid + ")";
            runCmd(pokeHr);

            byte[] minbyte = BitConverter.GetBytes(Convert.ToInt32(minNum.Value));
            string min = BitConverter.ToString(minbyte);
            string pokeMin = "writebyte(" + minoff + ", 0x" + min + ", pid=" + pid + ")";
            runCmd(pokeMin);

            byte[] secbyte = BitConverter.GetBytes(Convert.ToInt32(secNum.Value));
            string sec = BitConverter.ToString(secbyte);
            string pokeSec = "writebyte(" + secoff + ", 0x" + sec + ", pid=" + pid + ")";
            runCmd(pokeSec);
        }

        private void showItems_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Green;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showMedicine_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            dataGridView5.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Green;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showTMs_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Green;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showBerries_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = true;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Green;
            showKeys.ForeColor = System.Drawing.Color.Black;
        }

        private void showKeys_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            showItems.ForeColor = System.Drawing.Color.Black;
            showMedicine.ForeColor = System.Drawing.Color.Black;
            showTMs.ForeColor = System.Drawing.Color.Black;
            showBerries.ForeColor = System.Drawing.Color.Black;
            showKeys.ForeColor = System.Drawing.Color.Green;
        }


        public void itemWrite_Click(object sender, EventArgs e)
        {
            itemData = new byte[1600];
            keyData = new byte[384];
            tmData = new byte[432];
            medData = new byte[256];
            berryData = new byte[288];
            if (dataGridView1.Visible == true)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string datastring = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(itemData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(itemData, i * 4 + 2);
                }
                string moneyr = ", 0x";
                string money = BitConverter.ToString(itemData).Replace("-", moneyr);
                string pokeItems = "write(" + itemsoff + ", (0x" + money + "), pid=" + pid + ")";
                runCmd(pokeItems);
            }

            if (dataGridView2.Visible == true)
            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string datastring = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(dataGridView2.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(keyData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(keyData, i * 4 + 2);
                }
                string keyr = ", 0x";
                string key = BitConverter.ToString(keyData).Replace("-", keyr);
                string pokeKey = "write(" + keysoff + ", (0x" + key + "), pid=" + pid + ")";
                runCmd(pokeKey);
            }

            if (dataGridView3.Visible == true)
            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    string datastring = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(dataGridView3.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(tmData, i * 4);
                    BitConverter.GetBytes((ushort)1).CopyTo(tmData, i * 4 + 2);
                }
                string tmr = ", 0x";
                string tm = BitConverter.ToString(tmData).Replace("-", tmr);
                string pokeTM = "write(" + tmsoff + ", (0x" + tm + "), pid=" + pid + ")";
                runCmd(pokeTM);
            }

            if (dataGridView4.Visible == true)
            {
                for (int i = 0; i < dataGridView4.RowCount; i++)
                {
                    string datastring = dataGridView4.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(dataGridView4.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(medData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(medData, i * 4 + 2);
                }
                string medr = ", 0x";
                string med = BitConverter.ToString(medData).Replace("-", medr);
                string pokeMeds = "write(" + medsoff + ", (0x" + med + "), pid=" + pid + ")";
                runCmd(pokeMeds);
            }

            if (dataGridView5.Visible == true)
            {
                for (int i = 0; i < dataGridView5.RowCount; i++)
                {
                    string datastring = dataGridView5.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(itemList, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToUInt16(dataGridView5.Rows[i].Cells[1].Value.ToString());

                    BitConverter.GetBytes((ushort)itemIndex).CopyTo(berryData, i * 4);
                    BitConverter.GetBytes((ushort)itemcnt).CopyTo(berryData, i * 4 + 2);
                }
                string berryr = ", 0x";
                string berry = BitConverter.ToString(berryData).Replace("-", berryr);
                string pokeBerry = "write(" + bersoff + ", (0x" + berry + "), pid=" + pid + ")";
                runCmd(pokeBerry);
            }

        }

        private void itemAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == true)
            {
                if (dataGridView1.RowCount >= 400)
                {
                    MessageBox.Show("You already have the max amount of items!", "Too many items");
                }
                else
                {
                    dataGridView1.Rows.Add("[None]", 0);
                }
            }

            if (dataGridView2.Visible == true)
            {
                if (dataGridView2.RowCount >= 96)
                {
                    MessageBox.Show("You already have the max amount of key items!", "Too many items");
                }
                else
                {
                    dataGridView2.Rows.Add("[None]", 0);
                }
            }

            if (dataGridView3.Visible == true)
            {
                if (dataGridView3.RowCount >= 96)
                {
                    MessageBox.Show("You already have the max amount of medicine items!", "Too many items");
                }
                else
                {
                    dataGridView3.Rows.Add("[None]", 0);
                }
            }

            if (dataGridView4.Visible == true)
            {
                if (dataGridView4.RowCount >= 108)
                {
                    MessageBox.Show("You already have the max amount of TMs & HMs!", "Too many items");
                }
                else
                {
                    dataGridView4.Rows.Add("[None]", 0);
                }
            }

            if (dataGridView5.Visible == true)
            {
                if (dataGridView5.RowCount >= 72)
                {
                    MessageBox.Show("You already have the max amount of berries!", "Too many items");
                }
                else
                {
                    dataGridView5.Rows.Add("[None]", 0);
                }
            }
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
            dumpek6.Location = new System.Drawing.Point(6, 61);
            nameek6.Location = new System.Drawing.Point(6, 39);
            label9.Location = new System.Drawing.Point(6, 20);
            dumpek6.Size = new System.Drawing.Size(197, 23);
            nameek6.Size = new System.Drawing.Size(197, 23);
            dumpek6.Text = "Dump";
            dumpBoxes.Enabled = true;
            nameek6.Enabled = true;
            onlyView.Visible = false;
            label50.Visible = false;
        }

        private void pokeSID_Click(object sender, EventArgs e)
        {
            byte[] sidbyte = BitConverter.GetBytes(Convert.ToUInt16((double)SIDNum.Value));
            string sidr = ", 0x";
            string sid = BitConverter.ToString(sidbyte).Replace("-", sidr);
            string pokeSID = "write(" + sidoff + ", (0x" + sid + "), pid=" + pid + ")";
            runCmd(pokeSID);
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog selectek6Dialog = new OpenFileDialog();
            selectek6Dialog.Title = "Select an EKX file";
            selectek6Dialog.Filter = "EKX files|*.ek6;*.ekx|All Files (*.*)|*.*";
            string path = @Application.StartupPath + "\\Pokemon";
            selectek6Dialog.InitialDirectory = path;
            if (selectek6Dialog.ShowDialog() == DialogResult.OK)
            {
                selectedek6 = selectek6Dialog.FileName;



            }
        }

        private void delPkm_Click(object sender, EventArgs e)
        {
            string ssH = boff.ToString("X");
            string bakPkm = "data(0x" + ssH + ", 0x34AD0, filename='boxes.bak.ek6', pid=" + pid + ")";
            runCmd(bakPkm);
        }

        private void pokeLang_Click(object sender, EventArgs e)
        {
            if (Lang.SelectedIndex == 0) { lang = "01"; }
            if (Lang.SelectedIndex == 1) { lang = "02"; }
            if (Lang.SelectedIndex == 2) { lang = "03"; }
            if (Lang.SelectedIndex == 3) { lang = "04"; }
            if (Lang.SelectedIndex == 4) { lang = "05"; }
            if (Lang.SelectedIndex == 5) { lang = "07"; }
            if (Lang.SelectedIndex == 6) { lang = "08"; }
            string pokeLang = "writebyte(" + langoff + ", 0x" + lang + ", pid=" + pid + ")";
            runCmd(pokeLang);
        }



        private void pokeEkx_Click(object sender, EventArgs e)
        {
            if (PKHeX.Data == null)
            {
                MessageBox.Show("No Pokemon data found, please dump a Pokemon first to edit!", "No data to edit");
            }
            if (evHPNum.Value + evATKNum.Value + evDEFNum.Value + evSPENum.Value + evSPANum.Value + evSPDNum.Value >= 511)
            {
                MessageBox.Show("Pokemon EV count is too high, the sum of all EVs should be 510 or less!", "EVs too high");
            }

            //This shouldn't be possible (length limited by text field), but better leave it
            if (nickname.Text.Length > 12)
            {
                MessageBox.Show("Pokemon name length too long! Please use a name with a length of 12 or less.", "Name too long");
            }

            if (otName.Text.Length > 12)
            {
                MessageBox.Show("OT name length too long! Please use a name with a length of 12 or less.", "Name too long");
            }

            if (PKHeX.Data != null)
            {
                if (evHPNum.Value + evATKNum.Value + evDEFNum.Value + evSPENum.Value + evSPANum.Value + evSPDNum.Value <= 510)
                {
                    if (nickname.Text.Length <= 12 && otName.Text.Length <= 12)
                    {
                        PKHeX.Nickname = nickname.Text.PadRight(12, '\0');
                        PKHeX.OT_Name = otName.Text.PadRight(12, '\0');
                        byte[] pkmToEdit = PKHeX.Data;
                        Array.Copy(Encoding.Unicode.GetBytes(PKHeX.Nickname), 0, pkmToEdit, 64, 24);
                        Array.Copy(BitConverter.GetBytes(PKHeX.Nature), 0, pkmToEdit, 28, 1);
                        Array.Copy(BitConverter.GetBytes(PKHeX.HeldItem), 0, pkmToEdit, 10, 2);
                        PKHeX.IV_HP = (int)ivHPNum.Value;
                        PKHeX.IV_ATK = (int)ivATKNum.Value;
                        PKHeX.IV_DEF = (int)ivDEFNum.Value;
                        PKHeX.IV_SPE = (int)ivSPENum.Value;
                        PKHeX.IV_SPA = (int)ivSPANum.Value;
                        PKHeX.IV_SPD = (int)ivSPDNum.Value;

                        PKHeX.EV_HP = (int)evHPNum.Value;
                        PKHeX.EV_ATK = (int)evATKNum.Value;
                        PKHeX.EV_DEF = (int)evDEFNum.Value;
                        PKHeX.EV_SPE = (int)evSPENum.Value;
                        PKHeX.EV_SPA = (int)evSPANum.Value;
                        PKHeX.EV_SPD = (int)evSPDNum.Value;

                        PKHeX.EXP = (uint)xp.Value;

                        PKHeX.Ball = ball.SelectedIndex + 1;

                        PKHeX.SID = (int)dSIDNum.Value;
                        PKHeX.TID = (int)dTIDNum.Value;

                        PKHeX.PID = PKHeX.getHEXval(dPID.Text);

                        if (isEgg.Checked == true) { PKHeX.IsEgg = true; }
                        if (isEgg.Checked == false) { PKHeX.IsEgg = false; }
                        PKHeX.Species = (int)species.SelectedIndex + 1;
                        PKHeX.Nature = nature.SelectedIndex;
                        PKHeX.Ability = ability.SelectedIndex + 1;
                        PKHeX.HeldItem = heldItem.SelectedIndex;
                        PKHeX.Move1 = move1.SelectedIndex;
                        PKHeX.Move2 = move2.SelectedIndex;
                        PKHeX.Move3 = move3.SelectedIndex;
                        PKHeX.Move4 = move4.SelectedIndex;

                        Array.Copy(BitConverter.GetBytes(PKHeX.IV32), 0, pkmToEdit, 116, 4);
                        byte[] pkmEdited = PKHeX.encryptArray(pkmToEdit);
                        byte[] chkSum = BitConverter.GetBytes(PKHeX.getCHK(pkmToEdit));
                        Array.Copy(chkSum, 0, pkmEdited, 6, 2);

                        if (radioBoxes.Checked == true)
                        {
                            int ssd = (Decimal.ToInt32(boxDump.Value) * 30 - 30) + Decimal.ToInt32(slotDump.Value) - 1;
                            int ssdOff = boff + (ssd * 232);
                            string ssdH = ssdOff.ToString("X");
                            string ekx = BitConverter.ToString(pkmEdited).Replace("-", ", 0x");
                            string pokeEkx = "write(0x" + ssdH + ", (0x" + ekx + "), pid=" + pid + ")";
                            runCmd(pokeEkx);
                            getHP();
                        }

                        if (radioBattleBox.Checked == true)
                        {
                            int bbOff = bboff + ((Decimal.ToInt32(boxDump.Value) - 1) * 232);
                            string bbfOff = bbOff.ToString("X");
                            string ekx = BitConverter.ToString(pkmEdited).Replace("-", ", 0x");
                            string pokeEkx = "write(0x" + bbfOff + ", (0x" + ekx + "), pid=" + pid + ")";
                            runCmd(pokeEkx);
                            getHP();
                        }

                        if (radioParty.Checked == true)
                        {
                            int pOff = partyoff + ((Decimal.ToInt32(boxDump.Value) - 1) * 484);
                            string pfOff = pOff.ToString("X");
                            string ekx = BitConverter.ToString(pkmEdited).Replace("-", ", 0x");
                            string pokeEkx = "write(0x" + pfOff + ", (0x" + ekx + "), pid=" + pid + ")";
                            runCmd(pokeEkx);
                            getHP();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOpponent.Checked == true)
            {
                dumprealoppOff();
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
            dumpek6.Size = new System.Drawing.Size(86, 23);
            dumpBoxes.Size = new System.Drawing.Size(105, 23);
            dumpBoxes.Location = new System.Drawing.Point(98, 61);
            dumpek6.Location = new System.Drawing.Point(6, 61);
            dumpek6.Text = "Dump";
            dumpBoxes.Text = "Dump All Boxes";
        }



        

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
        
        
        

        private void deleteBox_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = 930 - ((deleteBox.Value * 30 - 30) + (deleteSlot.Value - 1));
        }

        private void deleteSlot_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = 930 - ((deleteBox.Value * 30 - 30) + (deleteSlot.Value - 1));
        }

        private void deleteAmount_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = 930 - ((deleteBox.Value * 30 - 30) + (deleteSlot.Value - 1));
        }
        
        private void ball_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = ballImages[ball.SelectedIndex];
        }

        private void versionCheck_Click(object sender, EventArgs e)
        {
            UpdateCheck();
        }

        private void radioParty_CheckedChanged_1(object sender, EventArgs e)
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
            dumpek6.Size = new System.Drawing.Size(197, 23);
            dumpek6.Location = new System.Drawing.Point(6, 61);
            dumpek6.Text = "Dump";
        }


        private void dTIDNum_ValueChanged(object sender, EventArgs e)
        {
            ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + (((int)dTIDNum.Value ^ (int)dSIDNum.Value) >> 4).ToString());
            ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + (((int)dTIDNum.Value ^ (int)dSIDNum.Value) >> 4).ToString());
            ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((PKHeX.PID >> 16 ^ PKHeX.PID & 0xFFFF) >> 4)).ToString());
        }

        private void dSIDNum_ValueChanged(object sender, EventArgs e)
        {
            ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
            ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
            ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((PKHeX.PID >> 16 ^ PKHeX.PID & 0xFFFF) >> 4)).ToString());
        }

        private void dPID_TextChanged(object sender, EventArgs e)
        {
            ToolTipTSVt.SetToolTip(dTIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
            ToolTipTSVs.SetToolTip(dSIDNum, "TSV: " + ((PKHeX.TID ^ PKHeX.SID) >> 4).ToString());
            ToolTipPSV.SetToolTip(dPID, "PSV: " + ((int)((PKHeX.PID >> 16 ^ PKHeX.PID & 0xFFFF) >> 4)).ToString());
        }

        private void setShiny_Click(object sender, EventArgs e)
        {
            PKHeX.setShinyPID();
            dPID.Text = PKHeX.PID.ToString("X");
            if (PKHeX.isShiny == true)
            {
                setShiny.Text = "★";
            }
            if (PKHeX.isShiny == false)
            {
                setShiny.Text = "☆";
            }
        }

        private void TIDNum_ValueChanged(object sender, EventArgs e)
        {
            ToolTipTSVtt.SetToolTip(TIDNum, "TSV: " + (((int)TIDNum.Value ^ (int)SIDNum.Value) >> 4).ToString());
            ToolTipTSVss.SetToolTip(SIDNum, "TSV: " + (((int)TIDNum.Value ^ (int)SIDNum.Value) >> 4).ToString());
        }

        private void SIDNum_ValueChanged(object sender, EventArgs e)
        {
            ToolTipTSVtt.SetToolTip(TIDNum, "TSV: " + (((int)TIDNum.Value ^ (int)SIDNum.Value) >> 4).ToString());
            ToolTipTSVss.SetToolTip(SIDNum, "TSV: " + (((int)TIDNum.Value ^ (int)SIDNum.Value) >> 4).ToString());
        }

        private void randomPID_Click(object sender, EventArgs e)
        {
            Random theRandom = new Random();
            byte[] theBytes = new byte[4];
            theRandom.NextBytes(theBytes);
            StringBuilder buffer = new StringBuilder(8);
            for (int i = 0; i < 4; i++)
            {
                buffer.Append(theBytes[i].ToString("X").PadLeft(2));
            }

            dPID.Text = buffer.ToString().Replace(" ", "0");

            PKHeX.PID = PKHeX.getHEXval(dPID.Text);

            if (PKHeX.isShiny == true)
            {
                setShiny.Enabled = false;
                setShiny.Text = "★";
            }
            if (PKHeX.isShiny == false)
            {
                setShiny.Enabled = true;
                setShiny.Text = "☆";
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

        private void gender_Click(object sender, EventArgs e)
        {
            if (PKHeX.Gender == 0)
            {
                gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                gender.ForeColor = Color.Red;
                gender.Text = "♀";
                PKHeX.Gender = 1;
            }
            else
            if (PKHeX.Gender == 1)
            {
                gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                gender.ForeColor = Color.Gray;
                gender.Text = "-";
                PKHeX.Gender = 2;
            }
            else
            if (PKHeX.Gender == 2)
            {
                gender.Font = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Bold);
                gender.ForeColor = Color.Blue;
                gender.Text = "♂";
                PKHeX.Gender = 0;
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
            dumpek6.Size = new System.Drawing.Size(197, 23);
            dumpek6.Location = new System.Drawing.Point(6, 61);
            dumpek6.Text = "Dump";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dumpRealoppoff = "data("+offsetzz.Text+", 0xFFFFF, filename='test.bin', pid=" + pid + ")";
            runCmd(dumpRealoppoff);
        }
    }
}
