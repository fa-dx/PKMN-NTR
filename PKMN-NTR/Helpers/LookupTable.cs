using System.Drawing;

namespace ntrbase
{
    class LookupTable
    {
        #region NFC Patch

        public static readonly uint nfcOff = 0x3E14C0;
        // 1.0 offset was 0x3DFFD0

        public static readonly uint nfcVal = 0xE3A01000;

        #endregion NFC Patch

        #region Empty poke

        public static byte[] EmptyPoke6 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x83, 0x07, 0x00, 0x00, 0x7E, 0xE9, 0x71, 0x52, 0xB0, 0x31, 0x42, 0x8E, 0xCC, 0xE2, 0xC5, 0xAF, 0xDB, 0x67, 0x33, 0xFC, 0x2C, 0xEF, 0x5E, 0xFC, 0xC5, 0xCA, 0xD6, 0xEB, 0x3D, 0x99, 0xBC, 0x7A, 0xA7, 0xCB, 0xD6, 0x5D, 0x78, 0x91, 0xA6, 0x27, 0x8D, 0x61, 0x92, 0x16, 0xB8, 0xCF, 0x5D, 0x37, 0x80, 0x30, 0x7C, 0x40, 0xFB, 0x48, 0x13, 0x32, 0xE7, 0xFE, 0xE6, 0xDF, 0x0E, 0x3D, 0xF9, 0x63, 0x29, 0x1D, 0x8D, 0xEA, 0x96, 0x62, 0x68, 0x92, 0x97, 0xA3, 0x49, 0x1C, 0x03, 0x6E, 0xAA, 0x31, 0x89, 0xAA, 0xC5, 0xD3, 0xEA, 0xC3, 0xD9, 0x82, 0xC6, 0xE0, 0x5C, 0x94, 0x3B, 0x4E, 0x5F, 0x5A, 0x28, 0x24, 0xB3, 0xFB, 0xE1, 0xBF, 0x8E, 0x7B, 0x7F, 0x00, 0xC4, 0x40, 0x48, 0xC8, 0xD1, 0xBF, 0xB6, 0x38, 0x3B, 0x90, 0x23, 0xFB, 0x23, 0x7D, 0x34, 0xBE, 0x00, 0xDA, 0x6A, 0x70, 0xC5, 0xDF, 0x84, 0xBA, 0x14, 0xE4, 0xA1, 0x60, 0x2B, 0x2B, 0x38, 0x8F, 0xA0, 0xB6, 0x60, 0x41, 0x36, 0x16, 0x09, 0xF0, 0x4B, 0xB5, 0x0E, 0x26, 0xA8, 0xB6, 0x43, 0x7B, 0xCB, 0xF9, 0xEF, 0x68, 0xD4, 0xAF, 0x5F, 0x74, 0xBE, 0xC3, 0x61, 0xE0, 0x95, 0x98, 0xF1, 0x84, 0xBA, 0x11, 0x62, 0x24, 0x80, 0xCC, 0xC4, 0xA7, 0xA2, 0xB7, 0x55, 0xA8, 0x5C, 0x1C, 0x42, 0xA2, 0x3A, 0x86, 0x05, 0xAD, 0xD2, 0x11, 0x19, 0xB0, 0xFD, 0x57, 0xE9, 0x4E, 0x60, 0xBA, 0x1B, 0x45, 0x2E, 0x17, 0xA9, 0x34, 0x93, 0x2D, 0x66, 0x09, 0x2D, 0x11, 0xE0, 0xA1, 0x74, 0x42, 0xC4, 0x73, 0x65, 0x2F, 0x21, 0xF0, 0x43, 0x28, 0x54, 0xA6 };

        public static byte[] EmptyPoke7 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x26, 0x06, 0x00, 0x00, 0x7E, 0xE9, 0x71, 0x52, 0xB0, 0x31, 0x42, 0x8E, 0xCC, 0xE2, 0xC5, 0xAF, 0xDB, 0x67, 0x33, 0xFC, 0x2C, 0xEF, 0x5E, 0xFC, 0xC5, 0xCA, 0xD6, 0xEB, 0x3D, 0x99, 0xBC, 0x7A, 0xA7, 0xCB, 0xD6, 0x5D, 0x78, 0x91, 0xA6, 0x27, 0x8D, 0x61, 0x92, 0x16, 0xB8, 0xCF, 0x5D, 0x37, 0x80, 0x30, 0x7C, 0x40, 0xFB, 0x48, 0x13, 0x32, 0xE7, 0xFE, 0xE6, 0xDF, 0x0E, 0x3D, 0xF9, 0x63, 0x29, 0x1D, 0x8D, 0xEA, 0x96, 0x62, 0x68, 0x92, 0x97, 0xA3, 0x49, 0x1C, 0x03, 0x6E, 0xAA, 0x31, 0x89, 0xAA, 0xC5, 0xD3, 0xEA, 0xC3, 0xD9, 0x82, 0xC6, 0xE0, 0x5C, 0x94, 0x3B, 0x4E, 0x5F, 0x5A, 0x28, 0x24, 0xB3, 0xFB, 0xE1, 0xBF, 0x8E, 0x7B, 0x7F, 0x00, 0xC4, 0x40, 0x48, 0xC8, 0xD1, 0xBF, 0xB6, 0x38, 0x3B, 0x90, 0x23, 0xFB, 0x23, 0x7D, 0x34, 0xBE, 0x00, 0xDA, 0x6A, 0x70, 0xC5, 0xDF, 0x84, 0xBA, 0x14, 0xE4, 0xA1, 0x60, 0x2B, 0x2B, 0x38, 0x8F, 0xA0, 0xB6, 0x60, 0x41, 0x36, 0x16, 0x09, 0xF0, 0x4B, 0xB5, 0x0E, 0x26, 0xA8, 0xB6, 0x43, 0x7B, 0xCB, 0xF9, 0xEF, 0x68, 0xD4, 0xAF, 0x5F, 0x74, 0xBE, 0xC3, 0x61, 0xE0, 0x95, 0x98, 0xF1, 0x84, 0xBA, 0x11, 0x62, 0x24, 0x80, 0xCC, 0xC4, 0xA7, 0xA2, 0xB7, 0x55, 0xA8, 0x5C, 0x1C, 0x42, 0xA2, 0x3A, 0x86, 0x05, 0xAD, 0xD2, 0x11, 0x19, 0xB0, 0xFD, 0x57, 0xE9, 0x4E, 0x60, 0xBA, 0x1B, 0x45, 0x2E, 0x17, 0xA9, 0x34, 0x93, 0x2D, 0x66, 0x09, 0x2D, 0x11, 0xE0, 0xA1, 0x74, 0x42, 0xC4, 0x73, 0x19, 0x28, 0x22, 0xF0, 0x43, 0x28, 0x54, 0xA6 };

        #endregion Empty poke

        #region Items

        public static string[] Item6 = { "[None]", "Master Ball", "Ultra Ball", "Great Ball", "Poké Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Potion", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Paralyze Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Full Heal", "Revive", "Max Revive", "Fresh Water", "Soda Pop", "Lemonade", "Moomoo Milk", "Energy Powder", "Energy Root", "Heal Powder", "Revival Herb", "Ether", "Max Ether", "Elixir", "Max Elixir", "Lava Cookie", "Berry Juice", "Sacred Ash", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "PP Up", "Zinc", "PP Max", "Old Gateau", "Guard Spec.", "Dire Hit", "X Attack", "X Defense", "X Speed", "X Accuracy", "X Sp. Atk", "X Sp. Def", "Poké Doll", "Fluffy Tail", "Blue Flute", "Yellow Flute", "Red Flute", "Black Flute", "White Flute", "Shoal Salt", "Shoal Shell", "Red Shard", "Blue Shard", "Yellow Shard", "Green Shard", "Super Repel", "Max Repel", "Escape Rope", "Repel", "Sun Stone", "Moon Stone", "Fire Stone", "Thunder Stone", "Water Stone", "Leaf Stone", "Tiny Mushroom", "Big Mushroom", "Pearl", "Big Pearl", "Stardust", "Star Piece", "Nugget", "Heart Scale", "Honey", "Growth Mulch", "Damp Mulch", "Stable Mulch", "Gooey Mulch", "Root Fossil", "Claw Fossil", "Helix Fossil", "Dome Fossil", "Old Amber", "Armor Fossil", "Skull Fossil", "Rare Bone", "Shiny Stone", "Dusk Stone", "Dawn Stone", "Oval Stone", "Odd Keystone", "Griseous Orb", "???", "???", "???", "Douse Drive", "Shock Drive", "Burn Drive", "Chill Drive", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Sweet Heart", "Adamant Orb", "Lustrous Orb", "Greet Mail", "Favored Mail", "RSVP Mail", "Thanks Mail", "Inquiry Mail", "Like Mail", "Reply Mail", "Bridge Mail S", "Bridge Mail D", "Bridge Mail T", "Bridge Mail V", "Bridge Mail M", "Cheri Berry", "Chesto Berry", "Pecha Berry", "Rawst Berry", "Aspear Berry", "Leppa Berry", "Oran Berry", "Persim Berry", "Lum Berry", "Sitrus Berry", "Figy Berry", "Wiki Berry", "Mago Berry", "Aguav Berry", "Iapapa Berry", "Razz Berry", "Bluk Berry", "Nanab Berry", "Wepear Berry", "Pinap Berry", "Pomeg Berry", "Kelpsy Berry", "Qualot Berry", "Hondew Berry", "Grepa Berry", "Tamato Berry", "Cornn Berry", "Magost Berry", "Rabuta Berry", "Nomel Berry", "Spelon Berry", "Pamtre Berry", "Watmel Berry", "Durin Berry", "Belue Berry", "Occa Berry", "Passho Berry", "Wacan Berry", "Rindo Berry", "Yache Berry", "Chople Berry", "Kebia Berry", "Shuca Berry", "Coba Berry", "Payapa Berry", "Tanga Berry", "Charti Berry", "Kasib Berry", "Haban Berry", "Colbur Berry", "Babiri Berry", "Chilan Berry", "Liechi Berry", "Ganlon Berry", "Salac Berry", "Petaya Berry", "Apicot Berry", "Lansat Berry", "Starf Berry", "Enigma Berry", "Micle Berry", "Custap Berry", "Jaboca Berry", "Rowap Berry", "Bright Powder", "White Herb", "Macho Brace", "Exp. Share", "Quick Claw", "Soothe Bell", "Mental Herb", "Choice Band", "King’s Rock", "Silver Powder", "Amulet Coin", "Cleanse Tag", "Soul Dew", "Deep Sea Tooth", "Deep Sea Scale", "Smoke Ball", "Everstone", "Focus Band", "Lucky Egg", "Scope Lens", "Metal Coat", "Leftovers", "Dragon Scale", "Light Ball", "Soft Sand", "Hard Stone", "Miracle Seed", "Black Glasses", "Black Belt", "Magnet", "Mystic Water", "Sharp Beak", "Poison Barb", "Never-Melt Ice", "Spell Tag", "Twisted Spoon", "Charcoal", "Dragon Fang", "Silk Scarf", "Up-Grade", "Shell Bell", "Sea Incense", "Lax Incense", "Lucky Punch", "Metal Powder", "Thick Club", "Stick", "Red Scarf", "Blue Scarf", "Pink Scarf", "Green Scarf", "Yellow Scarf", "Wide Lens", "Muscle Band", "Wise Glasses", "Expert Belt", "Light Clay", "Life Orb", "Power Herb", "Toxic Orb", "Flame Orb", "Quick Powder", "Focus Sash", "Zoom Lens", "Metronome", "Iron Ball", "Lagging Tail", "Destiny Knot", "Black Sludge", "Icy Rock", "Smooth Rock", "Heat Rock", "Damp Rock", "Grip Claw", "Choice Scarf", "Sticky Barb", "Power Bracer", "Power Belt", "Power Lens", "Power Band", "Power Anklet", "Power Weight", "Shed Shell", "Big Root", "Choice Specs", "Flame Plate", "Splash Plate", "Zap Plate", "Meadow Plate", "Icicle Plate", "Fist Plate", "Toxic Plate", "Earth Plate", "Sky Plate", "Mind Plate", "Insect Plate", "Stone Plate", "Spooky Plate", "Draco Plate", "Dread Plate", "Iron Plate", "Odd Incense", "Rock Incense", "Full Incense", "Wave Incense", "Rose Incense", "Luck Incense", "Pure Incense", "Protector", "Electirizer", "Magmarizer", "Dubious Disc", "Reaper Cloth", "Razor Claw", "Razor Fang", "TM01", "TM02", "TM03", "TM04", "TM05", "TM06", "TM07", "TM08", "TM09", "TM10", "TM11", "TM12", "TM13", "TM14", "TM15", "TM16", "TM17", "TM18", "TM19", "TM20", "TM21", "TM22", "TM23", "TM24", "TM25", "TM26", "TM27", "TM28", "TM29", "TM30", "TM31", "TM32", "TM33", "TM34", "TM35", "TM36", "TM37", "TM38", "TM39", "TM40", "TM41", "TM42", "TM43", "TM44", "TM45", "TM46", "TM47", "TM48", "TM49", "TM50", "TM51", "TM52", "TM53", "TM54", "TM55", "TM56", "TM57", "TM58", "TM59", "TM60", "TM61", "TM62", "TM63", "TM64", "TM65", "TM66", "TM67", "TM68", "TM69", "TM70", "TM71", "TM72", "TM73", "TM74", "TM75", "TM76", "TM77", "TM78", "TM79", "TM80", "TM81", "TM82", "TM83", "TM84", "TM85", "TM86", "TM87", "TM88", "TM89", "TM90", "TM91", "TM92", "HM01", "HM02", "HM03", "HM04", "HM05", "HM06", "???", "???", "Explorer Kit", "Loot Sack", "Rule Book", "Poké Radar", "Point Card", "Journal", "Seal Case", "Fashion Case", "Seal Bag", "Pal Pad", "Works Key", "Old Charm", "Galactic Key", "Red Chain", "Town Map", "Vs. Seeker", "Coin Case", "Old Rod", "Good Rod", "Super Rod", "Sprayduck", "Poffin Case", "Bike", "Suite Key", "Oak’s Letter", "Lunar Wing", "Member Card", "Azure Flute", "S.S. Ticket", "Contest Pass", "Magma Stone", "Parcel", "Coupon 1", "Coupon 2", "Coupon 3", "Storage Key", "Secret Potion", "Vs. Recorder", "Gracidea", "Secret Key", "Apricorn Box", "Unown Report", "Berry Pots", "Dowsing Machine", "Blue Card", "Slowpoke Tail", "Clear Bell", "Card Key", "Basement Key", "Squirt Bottle", "Red Scale", "Lost Item", "Pass", "Machine Part", "Silver Wing", "Rainbow Wing", "Mystery Egg", "Red Apricorn", "Blue Apricorn", "Yellow Apricorn", "Green Apricorn", "Pink Apricorn", "White Apricorn", "Black Apricorn", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Park Ball", "Photo Album", "GB Sounds", "Tidal Bell", "Rage Candy Bar", "Data Card 01", "Data Card 02", "Data Card 03", "Data Card 04", "Data Card 05", "Data Card 06", "Data Card 07", "Data Card 08", "Data Card 09", "Data Card 10", "Data Card 11", "Data Card 12", "Data Card 13", "Data Card 14", "Data Card 15", "Data Card 16", "Data Card 17", "Data Card 18", "Data Card 19", "Data Card 20", "Data Card 21", "Data Card 22", "Data Card 23", "Data Card 24", "Data Card 25", "Data Card 26", "Data Card 27", "Jade Orb", "Lock Capsule", "Red Orb", "Blue Orb", "Enigma Stone", "Prism Scale", "Eviolite", "Float Stone", "Rocky Helmet", "Air Balloon", "Red Card", "Ring Target", "Binding Band", "Absorb Bulb", "Cell Battery", "Eject Button", "Fire Gem", "Water Gem", "Electric Gem", "Grass Gem", "Ice Gem", "Fighting Gem", "Poison Gem", "Ground Gem", "Flying Gem", "Psychic Gem", "Bug Gem", "Rock Gem", "Ghost Gem", "Dragon Gem", "Dark Gem", "Steel Gem", "Normal Gem", "Health Wing", "Muscle Wing", "Resist Wing", "Genius Wing", "Clever Wing", "Swift Wing", "Pretty Wing", "Cover Fossil", "Plume Fossil", "Liberty Pass", "Pass Orb", "Dream Ball", "Poké Toy", "Prop Case", "Dragon Skull", "Balm Mushroom", "Big Nugget", "Pearl String", "Comet Shard", "Relic Copper", "Relic Silver", "Relic Gold", "Relic Vase", "Relic Band", "Relic Statue", "Relic Crown", "Casteliacone", "Dire Hit 2", "X Speed 2", "X Sp. Atk 2", "X Sp. Def 2", "X Defense 2", "X Attack 2", "X Accuracy 2", "X Speed 3", "X Sp. Atk 3", "X Sp. Def 3", "X Defense 3", "X Attack 3", "X Accuracy 3", "X Speed 6", "X Sp. Atk 6", "X Sp. Def 6", "X Defense 6", "X Attack 6", "X Accuracy 6", "Ability Urge", "Item Drop", "Item Urge", "Reset Urge", "Dire Hit 3", "Light Stone", "Dark Stone", "TM93", "TM94", "TM95", "Xtransceiver", "???", "Gram 1", "Gram 2", "Gram 3", "Xtransceiver", "Medal Box", "DNA Splicers", "DNA Splicers", "Permit", "Oval Charm", "Shiny Charm", "Plasma Card", "Grubby Hanky", "Colress Machine", "Dropped Item", "Dropped Item", "Reveal Glass", "Weakness Policy", "Assault Vest", "Holo Caster", "Prof’s Letter", "Roller Skates", "Pixie Plate", "Ability Capsule", "Whipped Dream", "Sachet", "Luminous Moss", "Snowball", "Safety Goggles", "Poké Flute", "Rich Mulch", "Surprise Mulch", "Boost Mulch", "Amaze Mulch", "Gengarite", "Gardevoirite", "Ampharosite", "Venusaurite", "Charizardite X", "Blastoisinite", "Mewtwonite X", "Mewtwonite Y", "Blazikenite", "Medichamite", "Houndoominite", "Aggronite", "Banettite", "Tyranitarite", "Scizorite", "Pinsirite", "Aerodactylite", "Lucarionite", "Abomasite", "Kangaskhanite", "Gyaradosite", "Absolite", "Charizardite Y", "Alakazite", "Heracronite", "Mawilite", "Manectite", "Garchompite", "Latiasite", "Latiosite", "Roseli Berry", "Kee Berry", "Maranga Berry", "Sprinklotad", "TM96", "TM97", "TM98", "TM99", "TM100", "Power Plant Pass", "Mega Ring", "Intriguing Stone", "Common Stone", "Discount Coupon", "Elevator Key", "TMV Pass", "Honor of Kalos", "Adventure Rules", "Strange Souvenir", "Lens Case", "Makeup Bag", "Travel Trunk", "Lumiose Galette", "Shalour Sable", "Jaw Fossil", "Sail Fossil", "Looker Ticket", "Bike", "Holo Caster", "Fairy Gem", "Mega Charm", "Mega Glove", "Mach Bike", "Acro Bike", "Wailmer Pail", "Devon Parts", "Soot Sack", "Basement Key", "Pokéblock Kit", "Letter", "Eon Ticket", "Scanner", "Go-Goggles", "Meteorite", "Key to Room 1", "Key to Room 2", "Key to Room 4", "Key to Room 6", "Storage Key", "Devon Scope", "S.S. Ticket", "HM07", "Devon Scuba Gear", "Contest Costume", "Contest Costume", "Magma Suit", "Aqua Suit", "Pair of Tickets", "Mega Bracelet", "Mega Pendant", "Mega Glasses", "Mega Anchor", "Mega Stickpin", "Mega Tiara", "Mega Anklet", "Meteorite", "Swampertite", "Sceptilite", "Sablenite", "Altarianite", "Galladite", "Audinite", "Metagrossite", "Sharpedonite", "Slowbronite", "Steelixite", "Pidgeotite", "Glalitite", "Diancite", "Prison Bottle", "Mega Cuff", "Cameruptite", "Lopunnite", "Salamencite", "Beedrillite", "Meteorite", "Meteorite", "Key Stone", "Meteorite Shard", "Eon Flute" };

        public static string[] Item7 = { "None", "Master Ball", "Ultra Ball", "Great Ball", "Poké Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Potion", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Paralyze Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Full Heal", "Revive", "Max Revive", "Fresh Water", "Soda Pop", "Lemonade", "Moomoo Milk", "Energy Powder", "Energy Root", "Heal Powder", "Revival Herb", "Ether", "Max Ether", "Elixir", "Max Elixir", "Lava Cookie", "Berry Juice", "Sacred Ash", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "PP Up", "Zinc", "PP Max", "Old Gateau", "Guard Spec.", "Dire Hit", "X Attack", "X Defense", "X Speed", "X Accuracy", "X Sp. Atk", "X Sp. Def", "Poké Doll", "Fluffy Tail", "Blue Flute", "Yellow Flute", "Red Flute", "Black Flute", "White Flute", "Shoal Salt", "Shoal Shell", "Red Shard", "Blue Shard", "Yellow Shard", "Green Shard", "Super Repel", "Max Repel", "Escape Rope", "Repel", "Sun Stone", "Moon Stone", "Fire Stone", "Thunder Stone", "Water Stone", "Leaf Stone", "Tiny Mushroom", "Big Mushroom", "Pearl", "Big Pearl", "Stardust", "Star Piece", "Nugget", "Heart Scale", "Honey", "Growth Mulch", "Damp Mulch", "Stable Mulch", "Gooey Mulch", "Root Fossil", "Claw Fossil", "Helix Fossil", "Dome Fossil", "Old Amber", "Armor Fossil", "Skull Fossil", "Rare Bone", "Shiny Stone", "Dusk Stone", "Dawn Stone", "Oval Stone", "Odd Keystone", "Griseous Orb", "???", "???", "???", "Douse Drive", "Shock Drive", "Burn Drive", "Chill Drive", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Sweet Heart", "Adamant Orb", "Lustrous Orb", "Greet Mail", "Favored Mail", "RSVP Mail", "Thanks Mail", "Inquiry Mail", "Like Mail", "Reply Mail", "Bridge Mail S", "Bridge Mail D", "Bridge Mail T", "Bridge Mail V", "Bridge Mail M", "Cheri Berry", "Chesto Berry", "Pecha Berry", "Rawst Berry", "Aspear Berry", "Leppa Berry", "Oran Berry", "Persim Berry", "Lum Berry", "Sitrus Berry", "Figy Berry", "Wiki Berry", "Mago Berry", "Aguav Berry", "Iapapa Berry", "Razz Berry", "Bluk Berry", "Nanab Berry", "Wepear Berry", "Pinap Berry", "Pomeg Berry", "Kelpsy Berry", "Qualot Berry", "Hondew Berry", "Grepa Berry", "Tamato Berry", "Cornn Berry", "Magost Berry", "Rabuta Berry", "Nomel Berry", "Spelon Berry", "Pamtre Berry", "Watmel Berry", "Durin Berry", "Belue Berry", "Occa Berry", "Passho Berry", "Wacan Berry", "Rindo Berry", "Yache Berry", "Chople Berry", "Kebia Berry", "Shuca Berry", "Coba Berry", "Payapa Berry", "Tanga Berry", "Charti Berry", "Kasib Berry", "Haban Berry", "Colbur Berry", "Babiri Berry", "Chilan Berry", "Liechi Berry", "Ganlon Berry", "Salac Berry", "Petaya Berry", "Apicot Berry", "Lansat Berry", "Starf Berry", "Enigma Berry", "Micle Berry", "Custap Berry", "Jaboca Berry", "Rowap Berry", "Bright Powder", "White Herb", "Macho Brace", "Exp. Share", "Quick Claw", "Soothe Bell", "Mental Herb", "Choice Band", "King’s Rock", "Silver Powder", "Amulet Coin", "Cleanse Tag", "Soul Dew", "Deep Sea Tooth", "Deep Sea Scale", "Smoke Ball", "Everstone", "Focus Band", "Lucky Egg", "Scope Lens", "Metal Coat", "Leftovers", "Dragon Scale", "Light Ball", "Soft Sand", "Hard Stone", "Miracle Seed", "Black Glasses", "Black Belt", "Magnet", "Mystic Water", "Sharp Beak", "Poison Barb", "Never-Melt Ice", "Spell Tag", "Twisted Spoon", "Charcoal", "Dragon Fang", "Silk Scarf", "Up-Grade", "Shell Bell", "Sea Incense", "Lax Incense", "Lucky Punch", "Metal Powder", "Thick Club", "Stick", "Red Scarf", "Blue Scarf", "Pink Scarf", "Green Scarf", "Yellow Scarf", "Wide Lens", "Muscle Band", "Wise Glasses", "Expert Belt", "Light Clay", "Life Orb", "Power Herb", "Toxic Orb", "Flame Orb", "Quick Powder", "Focus Sash", "Zoom Lens", "Metronome", "Iron Ball", "Lagging Tail", "Destiny Knot", "Black Sludge", "Icy Rock", "Smooth Rock", "Heat Rock", "Damp Rock", "Grip Claw", "Choice Scarf", "Sticky Barb", "Power Bracer", "Power Belt", "Power Lens", "Power Band", "Power Anklet", "Power Weight", "Shed Shell", "Big Root", "Choice Specs", "Flame Plate", "Splash Plate", "Zap Plate", "Meadow Plate", "Icicle Plate", "Fist Plate", "Toxic Plate", "Earth Plate", "Sky Plate", "Mind Plate", "Insect Plate", "Stone Plate", "Spooky Plate", "Draco Plate", "Dread Plate", "Iron Plate", "Odd Incense", "Rock Incense", "Full Incense", "Wave Incense", "Rose Incense", "Luck Incense", "Pure Incense", "Protector", "Electirizer", "Magmarizer", "Dubious Disc", "Reaper Cloth", "Razor Claw", "Razor Fang", "TM01", "TM02", "TM03", "TM04", "TM05", "TM06", "TM07", "TM08", "TM09", "TM10", "TM11", "TM12", "TM13", "TM14", "TM15", "TM16", "TM17", "TM18", "TM19", "TM20", "TM21", "TM22", "TM23", "TM24", "TM25", "TM26", "TM27", "TM28", "TM29", "TM30", "TM31", "TM32", "TM33", "TM34", "TM35", "TM36", "TM37", "TM38", "TM39", "TM40", "TM41", "TM42", "TM43", "TM44", "TM45", "TM46", "TM47", "TM48", "TM49", "TM50", "TM51", "TM52", "TM53", "TM54", "TM55", "TM56", "TM57", "TM58", "TM59", "TM60", "TM61", "TM62", "TM63", "TM64", "TM65", "TM66", "TM67", "TM68", "TM69", "TM70", "TM71", "TM72", "TM73", "TM74", "TM75", "TM76", "TM77", "TM78", "TM79", "TM80", "TM81", "TM82", "TM83", "TM84", "TM85", "TM86", "TM87", "TM88", "TM89", "TM90", "TM91", "TM92", "HM01", "HM02", "HM03", "HM04", "HM05", "HM06", "???", "???", "Explorer Kit", "Loot Sack", "Rule Book", "Poké Radar", "Point Card", "Journal", "Seal Case", "Fashion Case", "Seal Bag", "Pal Pad", "Works Key", "Old Charm", "Galactic Key", "Red Chain", "Town Map", "Vs. Seeker", "Coin Case", "Old Rod", "Good Rod", "Super Rod", "Sprayduck", "Poffin Case", "Bike", "Suite Key", "Oak’s Letter", "Lunar Wing", "Member Card", "Azure Flute", "S.S. Ticket", "Contest Pass", "Magma Stone", "Parcel", "Coupon 1", "Coupon 2", "Coupon 3", "Storage Key", "Secret Potion", "Vs. Recorder", "Gracidea", "Secret Key", "Apricorn Box", "Unown Report", "Berry Pots", "Dowsing Machine", "Blue Card", "Slowpoke Tail", "Clear Bell", "Card Key", "Basement Key", "Squirt Bottle", "Red Scale", "Lost Item", "Pass", "Machine Part", "Silver Wing", "Rainbow Wing", "Mystery Egg", "Red Apricorn", "Blue Apricorn", "Yellow Apricorn", "Green Apricorn", "Pink Apricorn", "White Apricorn", "Black Apricorn", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Park Ball", "Photo Album", "GB Sounds", "Tidal Bell", "Rage Candy Bar", "Data Card 01", "Data Card 02", "Data Card 03", "Data Card 04", "Data Card 05", "Data Card 06", "Data Card 07", "Data Card 08", "Data Card 09", "Data Card 10", "Data Card 11", "Data Card 12", "Data Card 13", "Data Card 14", "Data Card 15", "Data Card 16", "Data Card 17", "Data Card 18", "Data Card 19", "Data Card 20", "Data Card 21", "Data Card 22", "Data Card 23", "Data Card 24", "Data Card 25", "Data Card 26", "Data Card 27", "Jade Orb", "Lock Capsule", "Red Orb", "Blue Orb", "Enigma Stone", "Prism Scale", "Eviolite", "Float Stone", "Rocky Helmet", "Air Balloon", "Red Card", "Ring Target", "Binding Band", "Absorb Bulb", "Cell Battery", "Eject Button", "Fire Gem", "Water Gem", "Electric Gem", "Grass Gem", "Ice Gem", "Fighting Gem", "Poison Gem", "Ground Gem", "Flying Gem", "Psychic Gem", "Bug Gem", "Rock Gem", "Ghost Gem", "Dragon Gem", "Dark Gem", "Steel Gem", "Normal Gem", "Health Wing", "Muscle Wing", "Resist Wing", "Genius Wing", "Clever Wing", "Swift Wing", "Pretty Wing", "Cover Fossil", "Plume Fossil", "Liberty Pass", "Pass Orb", "Dream Ball", "Poké Toy", "Prop Case", "Dragon Skull", "Balm Mushroom", "Big Nugget", "Pearl String", "Comet Shard", "Relic Copper", "Relic Silver", "Relic Gold", "Relic Vase", "Relic Band", "Relic Statue", "Relic Crown", "Casteliacone", "Dire Hit 2", "X Speed 2", "X Sp. Atk 2", "X Sp. Def 2", "X Defense 2", "X Attack 2", "X Accuracy 2", "X Speed 3", "X Sp. Atk 3", "X Sp. Def 3", "X Defense 3", "X Attack 3", "X Accuracy 3", "X Speed 6", "X Sp. Atk 6", "X Sp. Def 6", "X Defense 6", "X Attack 6", "X Accuracy 6", "Ability Urge", "Item Drop", "Item Urge", "Reset Urge", "Dire Hit 3", "Light Stone", "Dark Stone", "TM93", "TM94", "TM95", "Xtransceiver", "???", "Gram 1", "Gram 2", "Gram 3", "Xtransceiver", "Medal Box", "DNA Splicers", "DNA Splicers", "Permit", "Oval Charm", "Shiny Charm", "Plasma Card", "Grubby Hanky", "Colress Machine", "Dropped Item", "Dropped Item", "Reveal Glass", "Weakness Policy", "Assault Vest", "Holo Caster", "Prof’s Letter", "Roller Skates", "Pixie Plate", "Ability Capsule", "Whipped Dream", "Sachet", "Luminous Moss", "Snowball", "Safety Goggles", "Poké Flute", "Rich Mulch", "Surprise Mulch", "Boost Mulch", "Amaze Mulch", "Gengarite", "Gardevoirite", "Ampharosite", "Venusaurite", "Charizardite X", "Blastoisinite", "Mewtwonite X", "Mewtwonite Y", "Blazikenite", "Medichamite", "Houndoominite", "Aggronite", "Banettite", "Tyranitarite", "Scizorite", "Pinsirite", "Aerodactylite", "Lucarionite", "Abomasite", "Kangaskhanite", "Gyaradosite", "Absolite", "Charizardite Y", "Alakazite", "Heracronite", "Mawilite", "Manectite", "Garchompite", "Latiasite", "Latiosite", "Roseli Berry", "Kee Berry", "Maranga Berry", "Sprinklotad", "TM96", "TM97", "TM98", "TM99", "TM100", "Power Plant Pass", "Mega Ring", "Intriguing Stone", "Common Stone", "Discount Coupon", "Elevator Key", "TMV Pass", "Honor of Kalos", "Adventure Rules", "Strange Souvenir", "Lens Case", "Makeup Bag", "Travel Trunk", "Lumiose Galette", "Shalour Sable", "Jaw Fossil", "Sail Fossil", "Looker Ticket", "Bike", "Holo Caster", "Fairy Gem", "Mega Charm", "Mega Glove", "Mach Bike", "Acro Bike", "Wailmer Pail", "Devon Parts", "Soot Sack", "Basement Key", "Pokéblock Kit", "Letter", "Eon Ticket", "Scanner", "Go-Goggles", "Meteorite", "Key to Room 1", "Key to Room 2", "Key to Room 4", "Key to Room 6", "Storage Key", "Devon Scope", "S.S. Ticket", "HM07", "Devon Scuba Gear", "Contest Costume", "Contest Costume", "Magma Suit", "Aqua Suit", "Pair of Tickets", "Mega Bracelet", "Mega Pendant", "Mega Glasses", "Mega Anchor", "Mega Stickpin", "Mega Tiara", "Mega Anklet", "Meteorite", "Swampertite", "Sceptilite", "Sablenite", "Altarianite", "Galladite", "Audinite", "Metagrossite", "Sharpedonite", "Slowbronite", "Steelixite", "Pidgeotite", "Glalitite", "Diancite", "Prison Bottle", "Mega Cuff", "Cameruptite", "Lopunnite", "Salamencite", "Beedrillite", "Meteorite", "Meteorite", "Key Stone", "Meteorite Shard", "Eon Flute", "Normalium Z", "Firium Z", "Waterium Z", "Electrium Z", "Grassium Z", "Icium Z", "Fightinium Z", "Poisonium Z", "Groundium Z", "Flyinium Z", "Psychium Z", "Buginium Z", "Rockium Z", "Ghostium Z", "Dragonium Z", "Darkinium Z", "Steelium Z", "Fairium Z", "Pikanium Z", "Bottle Cap", "Gold Bottle Cap", "Z-Ring", "Decidium Z", "Incinium Z", "Primarium Z", "Tapunium Z", "Marshadium Z", "Aloraichium Z", "Snorlium Z", "Eevium Z", "Mewnium Z", "Normalium Z", "Firium Z", "Waterium Z", "Electrium Z", "Grassium Z", "Icium Z", "Fightinium Z", "Poisonium Z", "Groundium Z", "Flyinium Z", "Psychium Z", "Buginium Z", "Rockium Z", "Ghostium Z", "Dragonium Z", "Darkinium Z", "Steelium Z", "Fairium Z", "Pikanium Z", "Decidium Z", "Incinium Z", "Primarium Z", "Tapunium Z", "Marshadium Z", "Aloraichium Z", "Snorlium Z", "Eevium Z", "Mewnium Z", "Pikashunium Z", "Pikashunium Z", "???", "???", "???", "???", "Forage Bag", "Fishing Rod", "Professor’s Mask", "Festival Ticket", "Sparkling Stone", "Adrenaline Orb", "Zygarde Cube", "???", "Ice Stone", "Ride Pager", "Beast Ball", "Big Malasada", "Red Nectar", "Yellow Nectar", "Pink Nectar", "Purple Nectar", "Sun Flute", "Moon Flute", "???", "Enigmatic Card", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Terrain Extender", "Protective Pads", "Electric Seed", "Psychic Seed", "Misty Seed", "Grassy Seed", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Fighting Memory", "Flying Memory", "Poison Memory", "Ground Memory", "Rock Memory", "Bug Memory", "Ghost Memory", "Steel Memory", "Fire Memory", "Water Memory", "Grass Memory", "Electric Memory", "Psychic Memory", "Ice Memory", "Dragon Memory", "Dark Memory", "Fairy Memory" };

        #endregion Items

        #region Balls

        public static string[] Balls6 = { "Master Ball", "Ultra Ball", "Great Ball", "Poke Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Dream Ball" };

        public static string[] Balls7 = { "Master Ball", "Ultra Ball", "Great Ball", "Poke Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Dream Ball", "Beast Ball" };

        #endregion Balls

        #region Ability

        public static string[] Ability6 = { "Stench", "Drizzle", "Speed Boost", "Battle Armor", "Sturdy", "Damp", "Limber", "Sand Veil", "Static", "Volt Absorb", "Water Absorb", "Oblivious", "Cloud Nine", "Compound Eyes", "Insomnia", "Color Change", "Immunity", "Flash Fire", "Shield Dust", "Own Tempo", "Suction Cups", "Intimidate", "Shadow Tag", "Rough Skin", "Wonder Guard", "Levitate", "Effect Spore", "Synchronize", "Clear Body", "Natural Cure", "Lightning Rod", "Serene Grace", "Swift Swim", "Chlorophyll", "Illuminate", "Trace", "Huge Power", "Poison Point", "Inner Focus", "Magma Armor", "Water Veil", "Magnet Pull", "Soundproof", "Rain Dish", "Sand Stream", "Pressure", "Thick Fat", "Early Bird", "Flame Body", "Run Away", "Keen Eye", "Hyper Cutter", "Pickup", "Truant", "Hustle", "Cute Charm", "Plus", "Minus", "Forecast", "Sticky Hold", "Shed Skin", "Guts", "Marvel Scale", "Liquid Ooze", "Overgrow", "Blaze", "Torrent", "Swarm", "Rock Head", "Drought", "Arena Trap", "Vital Spirit", "White Smoke", "Pure Power", "Shell Armor", "Air Lock", "Tangled Feet", "Motor Drive", "Rivalry", "Steadfast", "Snow Cloak", "Gluttony", "Anger Point", "Unburden", "Heatproof", "Simple", "Dry Skin", "Download", "Iron Fist", "Poison Heal", "Adaptability", "Skill Link", "Hydration", "Solar Power", "Quick Feet", "Normalize", "Sniper", "Magic Guard", "No Guard", "Stall", "Technician", "Leaf Guard", "Klutz", "Mold Breaker", "Super Luck", "Aftermath", "Anticipation", "Forewarn", "Unaware", "Tinted Lens", "Filter", "Slow Start", "Scrappy", "Storm Drain", "Ice Body", "Solid Rock", "Snow Warning", "Honey Gather", "Frisk", "Reckless", "Multitype", "Flower Gift", "Bad Dreams", "Pickpocket", "Sheer Force", "Contrary", "Unnerve", "Defiant", "Defeatist", "Cursed Body", "Healer", "Friend Guard", "Weak Armor", "Heavy Metal", "Light Metal", "Multiscale", "Toxic Boost", "Flare Boost", "Harvest", "Telepathy", "Moody", "Overcoat", "Poison Touch", "Regenerator", "Big Pecks", "Sand Rush", "Wonder Skin", "Analytic", "Illusion", "Imposter", "Infiltrator", "Mummy", "Moxie", "Justified", "Rattled", "Magic Bounce", "Sap Sipper", "Prankster", "Sand Force", "Iron Barbs", "Zen Mode", "Victory Star", "Turboblaze", "Teravolt", "Aroma Veil", "Flower Veil", "Cheek Pouch", "Protean", "Fur Coat", "Magician", "Bulletproof", "Competitive", "Strong Jaw", "Refrigerate", "Sweet Veil", "Stance Change", "Gale Wings", "Mega Launcher", "Grass Pelt", "Symbiosis", "Tough Claws", "Pixilate", "Gooey", "Aerilate", "Parental Bond", "Dark Aura", "Fairy Aura", "Aura Break", "Primordial Sea", "Desolate Land", "Delta Stream" };

        public static string[] Ability7 = { "Stench", "Drizzle", "Speed Boost", "Battle Armor", "Sturdy", "Damp", "Limber", "Sand Veil", "Static", "Volt Absorb", "Water Absorb", "Oblivious", "Cloud Nine", "Compound Eyes", "Insomnia", "Color Change", "Immunity", "Flash Fire", "Shield Dust", "Own Tempo", "Suction Cups", "Intimidate", "Shadow Tag", "Rough Skin", "Wonder Guard", "Levitate", "Effect Spore", "Synchronize", "Clear Body", "Natural Cure", "Lightning Rod", "Serene Grace", "Swift Swim", "Chlorophyll", "Illuminate", "Trace", "Huge Power", "Poison Point", "Inner Focus", "Magma Armor", "Water Veil", "Magnet Pull", "Soundproof", "Rain Dish", "Sand Stream", "Pressure", "Thick Fat", "Early Bird", "Flame Body", "Run Away", "Keen Eye", "Hyper Cutter", "Pickup", "Truant", "Hustle", "Cute Charm", "Plus", "Minus", "Forecast", "Sticky Hold", "Shed Skin", "Guts", "Marvel Scale", "Liquid Ooze", "Overgrow", "Blaze", "Torrent", "Swarm", "Rock Head", "Drought", "Arena Trap", "Vital Spirit", "White Smoke", "Pure Power", "Shell Armor", "Air Lock", "Tangled Feet", "Motor Drive", "Rivalry", "Steadfast", "Snow Cloak", "Gluttony", "Anger Point", "Unburden", "Heatproof", "Simple", "Dry Skin", "Download", "Iron Fist", "Poison Heal", "Adaptability", "Skill Link", "Hydration", "Solar Power", "Quick Feet", "Normalize", "Sniper", "Magic Guard", "No Guard", "Stall", "Technician", "Leaf Guard", "Klutz", "Mold Breaker", "Super Luck", "Aftermath", "Anticipation", "Forewarn", "Unaware", "Tinted Lens", "Filter", "Slow Start", "Scrappy", "Storm Drain", "Ice Body", "Solid Rock", "Snow Warning", "Honey Gather", "Frisk", "Reckless", "Multitype", "Flower Gift", "Bad Dreams", "Pickpocket", "Sheer Force", "Contrary", "Unnerve", "Defiant", "Defeatist", "Cursed Body", "Healer", "Friend Guard", "Weak Armor", "Heavy Metal", "Light Metal", "Multiscale", "Toxic Boost", "Flare Boost", "Harvest", "Telepathy", "Moody", "Overcoat", "Poison Touch", "Regenerator", "Big Pecks", "Sand Rush", "Wonder Skin", "Analytic", "Illusion", "Imposter", "Infiltrator", "Mummy", "Moxie", "Justified", "Rattled", "Magic Bounce", "Sap Sipper", "Prankster", "Sand Force", "Iron Barbs", "Zen Mode", "Victory Star", "Turboblaze", "Teravolt", "Aroma Veil", "Flower Veil", "Cheek Pouch", "Protean", "Fur Coat", "Magician", "Bulletproof", "Competitive", "Strong Jaw", "Refrigerate", "Sweet Veil", "Stance Change", "Gale Wings", "Mega Launcher", "Grass Pelt", "Symbiosis", "Tough Claws", "Pixilate", "Gooey", "Aerilate", "Parental Bond", "Dark Aura", "Fairy Aura", "Aura Break", "Primordial Sea", "Desolate Land", "Delta Stream", "Stamina", "Wimp Out", "Emergency Exit", "Water Compaction", "Merciless", "Shields Down", "Stakeout", "Water Bubble", "Steelworker", "Berserk", "Slush Rush", "Long Reach", "Liquid Voice", "Triage", "Galvanize", "Surge Surfer", "Schooling", "Disguise", "Battle Bond", "Power Construct", "Corrosion", "Comatose", "Queenly Majesty", "Innards Out", "Dancer", "Battery", "Fluffy", "Dazzling", "Soul-Heart", "Tangling Hair", "Receiver", "Power of Alchemy", "Beast Boost", "RKS System", "Electric Surge", "Psychic Surge", "Misty Surge", "Grassy Surge", "Full Metal Body", "Shadow Shield", "Prism Armor" };

        public static int[] getAbilities(int species, int forme)
        {
            switch (species)
            {
                case 1: return new int[] { 65, 65, 34 }; // Bulbasaur
                case 2: return new int[] { 65, 65, 34 }; // Ivysaur
                case 3: return new int[] { 65, 65, 34 }; // Venusaur
                //case 3: return new int[] { 47, 47, 47 }; // Mega Venusaur
                case 4: return new int[] { 66, 66, 94 }; // Charmander
                case 5: return new int[] { 66, 66, 94 }; // Charmeleon
                case 6: return new int[] { 66, 66, 94 }; // Charizard
                //case 6: return new int[] { 181, 181, 181 }; // Mega Charizard X
                //case 6: return new int[] { 70, 70, 70 }; // Mega Charizard Y
                case 7: return new int[] { 67, 67, 44 }; // Squirtle
                case 8: return new int[] { 67, 67, 44 }; // Wartortle
                case 9: return new int[] { 67, 67, 44 }; // Blastoise
                //case 9: return new int[] { 178, 178, 178 }; // Mega Blastoise
                case 10: return new int[] { 19, 19, 50 }; // Caterpie
                case 11: return new int[] { 61, 61, 61 }; // Metapod
                case 12: return new int[] { 14, 14, 110 }; // Butterfree
                case 13: return new int[] { 19, 19, 50 }; // Weedle
                case 14: return new int[] { 61, 61, 61 }; // Kakuna
                case 15: return new int[] { 68, 68, 97 }; // Beedrill
                //case 15: return new int[] { 91, 91, 91 }; // Mega Beedrill
                case 16: return new int[] { 51, 77, 145 }; // Pidgey
                case 17: return new int[] { 51, 77, 145 }; // Pidgeotto
                case 18: return new int[] { 51, 77, 145 }; // Pidgeot
                //case 18: return new int[] { 99, 99, 99 }; // Mega Pidgeot
                case 19: return new int[] { 50, 62, 55 }; // Rattata
                case 20: return new int[] { 50, 62, 55 }; // Raticate
                case 21: return new int[] { 51, 51, 97 }; // Spearow
                case 22: return new int[] { 51, 51, 97 }; // Fearow
                case 23: return new int[] { 22, 61, 127 }; // Ekans
                case 24: return new int[] { 22, 61, 127 }; // Arbok
                case 25: return new int[] { 9, 9, 31 }; // Pikachu
                //case 25: return new int[] { 31, 31, 31 }; // Cosplay Pikachu
                case 26: return new int[] { 9, 9, 31 }; // Raichu
                case 27: return new int[] { 8, 8, 146 }; // Sandshrew
                case 28: return new int[] { 8, 8, 146 }; // Sandslash
                case 29: return new int[] { 38, 79, 55 }; // Nidoran♀
                case 30: return new int[] { 38, 79, 55 }; // Nidorina
                case 31: return new int[] { 38, 79, 125 }; // Nidoqueen
                case 32: return new int[] { 38, 79, 55 }; // Nidoran♂
                case 33: return new int[] { 38, 79, 55 }; // Nidorino
                case 34: return new int[] { 38, 79, 125 }; // Nidoking
                case 35: return new int[] { 56, 98, 132 }; // Clefairy
                case 36: return new int[] { 56, 98, 109 }; // Clefable
                case 37: return new int[] { 18, 18, 70 }; // Vulpix
                case 38: return new int[] { 18, 18, 70 }; // Ninetales
                case 39: return new int[] { 56, 172, 132 }; // Jigglypuff
                case 40: return new int[] { 56, 172, 119 }; // Wigglytuff
                case 41: return new int[] { 39, 39, 151 }; // Zubat
                case 42: return new int[] { 39, 39, 151 }; // Golbat
                case 43: return new int[] { 34, 34, 50 }; // Oddish
                case 44: return new int[] { 34, 34, 1 }; // Gloom
                case 45: return new int[] { 34, 34, 27 }; // Vileplume
                case 46: return new int[] { 27, 87, 6 }; // Paras
                case 47: return new int[] { 27, 87, 6 }; // Parasect
                case 48: return new int[] { 14, 110, 50 }; // Venonat
                case 49: return new int[] { 19, 110, 147 }; // Venomoth
                case 50: return new int[] { 8, 71, 159 }; // Diglett
                case 51: return new int[] { 8, 71, 159 }; // Dugtrio
                case 52: return new int[] { 53, 101, 127 }; // Meowth
                case 53: return new int[] { 7, 101, 127 }; // Persian
                case 54: return new int[] { 6, 13, 33 }; // Psyduck
                case 55: return new int[] { 6, 13, 33 }; // Golduck
                case 56: return new int[] { 72, 83, 128 }; // Mankey
                case 57: return new int[] { 72, 83, 128 }; // Primeape
                case 58: return new int[] { 22, 18, 154 }; // Growlithe
                case 59: return new int[] { 22, 18, 154 }; // Arcanine
                case 60: return new int[] { 11, 6, 33 }; // Poliwag
                case 61: return new int[] { 11, 6, 33 }; // Poliwhirl
                case 62: return new int[] { 11, 6, 33 }; // Poliwrath
                case 63: return new int[] { 28, 39, 98 }; // Abra
                case 64: return new int[] { 28, 39, 98 }; // Kadabra
                case 65: return new int[] { 28, 39, 98 }; // Alakazam
                //case 65: return new int[] { 36, 36, 36 }; // Mega Alakazam
                case 66: return new int[] { 62, 99, 80 }; // Machop
                case 67: return new int[] { 62, 99, 80 }; // Machoke
                case 68: return new int[] { 62, 99, 80 }; // Machamp
                case 69: return new int[] { 34, 34, 82 }; // Bellsprout
                case 70: return new int[] { 34, 34, 82 }; // Weepinbell
                case 71: return new int[] { 34, 34, 82 }; // Victreebel
                case 72: return new int[] { 29, 64, 44 }; // Tentacool
                case 73: return new int[] { 29, 64, 44 }; // Tentacruel
                case 74: return new int[] { 69, 5, 8 }; // Geodude
                case 75: return new int[] { 69, 5, 8 }; // Graveler
                case 76: return new int[] { 69, 5, 8 }; // Golem
                case 77: return new int[] { 50, 18, 49 }; // Ponyta
                case 78: return new int[] { 50, 18, 49 }; // Rapidash
                case 79: return new int[] { 12, 20, 144 }; // Slowpoke
                case 80: return new int[] { 12, 20, 144 }; // Slowbro
                //case 80: return new int[] { 75, 75, 75 }; // Mega Slowbro
                case 81: return new int[] { 42, 5, 148 }; // Magnemite
                case 82: return new int[] { 42, 5, 148 }; // Magneton
                case 83: return new int[] { 51, 39, 128 }; // Farfetch'd
                case 84: return new int[] { 50, 48, 77 }; // Doduo
                case 85: return new int[] { 50, 48, 77 }; // Dodrio
                case 86: return new int[] { 47, 93, 115 }; // Seel
                case 87: return new int[] { 47, 93, 115 }; // Dewgong
                case 88: return new int[] { 1, 60, 143 }; // Grimer
                case 89: return new int[] { 1, 60, 143 }; // Muk
                case 90: return new int[] { 75, 92, 142 }; // Shellder
                case 91: return new int[] { 75, 92, 142 }; // Cloyster
                case 92: return new int[] { 26, 26, 26 }; // Gastly
                case 93: return new int[] { 26, 26, 26 }; // Haunter
                case 94: return new int[] { 26, 26, 26 }; // Gengar
                //case 94: return new int[] { 23, 23, 23 }; // Mega Gengar
                case 95: return new int[] { 69, 5, 133 }; // Onix
                case 96: return new int[] { 15, 108, 39 }; // Drowzee
                case 97: return new int[] { 15, 108, 39 }; // Hypno
                case 98: return new int[] { 52, 75, 125 }; // Krabby
                case 99: return new int[] { 52, 75, 125 }; // Kingler
                case 100: return new int[] { 43, 9, 106 }; // Voltorb
                case 101: return new int[] { 43, 9, 106 }; // Electrode
                case 102: return new int[] { 34, 34, 139 }; // Exeggcute
                case 103: return new int[] { 34, 34, 139 }; // Exeggutor
                case 104: return new int[] { 69, 31, 4 }; // Cubone
                case 105: return new int[] { 69, 31, 4 }; // Marowak
                case 106: return new int[] { 7, 120, 84 }; // Hitmonlee
                case 107: return new int[] { 51, 89, 39 }; // Hitmonchan
                case 108: return new int[] { 20, 12, 13 }; // Lickitung
                case 109: return new int[] { 26, 26, 26 }; // Koffing
                case 110: return new int[] { 26, 26, 26 }; // Weezing
                case 111: return new int[] { 31, 69, 120 }; // Rhyhorn
                case 112: return new int[] { 31, 69, 120 }; // Rhydon
                case 113: return new int[] { 30, 32, 131 }; // Chansey
                case 114: return new int[] { 34, 102, 144 }; // Tangela
                case 115: return new int[] { 48, 113, 39 }; // Kangaskhan
                //case 115: return new int[] { 185, 185, 185 }; // Mega Kangaskhan
                case 116: return new int[] { 33, 97, 6 }; // Horsea
                case 117: return new int[] { 38, 97, 6 }; // Seadra
                case 118: return new int[] { 33, 41, 31 }; // Goldeen
                case 119: return new int[] { 33, 41, 31 }; // Seaking
                case 120: return new int[] { 35, 30, 148 }; // Staryu
                case 121: return new int[] { 35, 30, 148 }; // Starmie
                case 122: return new int[] { 43, 111, 101 }; // Mr. Mime
                case 123: return new int[] { 68, 101, 80 }; // Scyther
                case 124: return new int[] { 12, 108, 87 }; // Jynx
                case 125: return new int[] { 9, 9, 72 }; // Electabuzz
                case 126: return new int[] { 49, 49, 72 }; // Magmar
                case 127: return new int[] { 52, 104, 153 }; // Pinsir
                //case 127: return new int[] { 184, 184, 184 }; // Mega Pinsir
                case 128: return new int[] { 22, 83, 125 }; // Tauros
                case 129: return new int[] { 33, 33, 155 }; // Magikarp
                case 130: return new int[] { 22, 22, 153 }; // Gyarados
                //case 130: return new int[] { 104, 104, 104 }; // Mega Gyarados
                case 131: return new int[] { 11, 75, 93 }; // Lapras
                case 132: return new int[] { 7, 7, 150 }; // Ditto
                case 133: return new int[] { 50, 91, 107 }; // Eevee
                case 134: return new int[] { 11, 11, 93 }; // Vaporeon
                case 135: return new int[] { 10, 10, 95 }; // Jolteon
                case 136: return new int[] { 18, 18, 62 }; // Flareon
                case 137: return new int[] { 36, 88, 148 }; // Porygon
                case 138: return new int[] { 33, 75, 133 }; // Omanyte
                case 139: return new int[] { 33, 75, 133 }; // Omastar
                case 140: return new int[] { 33, 4, 133 }; // Kabuto
                case 141: return new int[] { 33, 4, 133 }; // Kabutops
                case 142: return new int[] { 69, 46, 127 }; // Aerodactyl
                //case 142: return new int[] { 181, 181, 181 }; // Mega Aerodactyl
                case 143: return new int[] { 17, 47, 82 }; // Snorlax
                case 144: return new int[] { 46, 46, 81 }; // Articuno
                case 145: return new int[] { 46, 46, 9 }; // Zapdos*
                case 146: return new int[] { 46, 46, 49 }; // Moltres
                case 147: return new int[] { 61, 61, 63 }; // Dratini
                case 148: return new int[] { 61, 61, 63 }; // Dragonair
                case 149: return new int[] { 39, 39, 136 }; // Dragonite
                case 150: return new int[] { 46, 46, 127 }; // Mewtwo
                //case 150: return new int[] { 80, 80, 80 }; // Mega Mewtwo X
                //case 150: return new int[] { 15, 15, 15 }; // Mega Mewtwo Y
                case 151: return new int[] { 28, 28, 28 }; // Mew
                case 152: return new int[] { 65, 65, 102 }; // Chikorita
                case 153: return new int[] { 65, 65, 102 }; // Bayleef
                case 154: return new int[] { 65, 65, 102 }; // Meganium
                case 155: return new int[] { 66, 66, 18 }; // Cyndaquil
                case 156: return new int[] { 66, 66, 18 }; // Quilava
                case 157: return new int[] { 66, 66, 18 }; // Typhlosion
                case 158: return new int[] { 67, 67, 125 }; // Totodile
                case 159: return new int[] { 67, 67, 125 }; // Croconaw
                case 160: return new int[] { 67, 67, 125 }; // Feraligatr
                case 161: return new int[] { 50, 51, 119 }; // Sentret
                case 162: return new int[] { 50, 51, 119 }; // Furret
                case 163: return new int[] { 15, 51, 110 }; // Hoothoot
                case 164: return new int[] { 15, 51, 110 }; // Noctowl
                case 165: return new int[] { 68, 48, 155 }; // Ledyba
                case 166: return new int[] { 68, 48, 89 }; // Ledian
                case 167: return new int[] { 68, 15, 97 }; // Spinarak
                case 168: return new int[] { 68, 15, 97 }; // Ariados
                case 169: return new int[] { 39, 39, 151 }; // Crobat
                case 170: return new int[] { 10, 35, 11 }; // Chinchou
                case 171: return new int[] { 10, 35, 11 }; // Lanturn
                case 172: return new int[] { 9, 9, 31 }; // Pichu
                case 173: return new int[] { 56, 98, 132 }; // Cleffa
                case 174: return new int[] { 56, 172, 132 }; // Igglybuff
                case 175: return new int[] { 55, 32, 105 }; // Togepi
                case 176: return new int[] { 55, 32, 105 }; // Togetic
                case 177: return new int[] { 28, 48, 156 }; // Natu
                case 178: return new int[] { 28, 48, 156 }; // Xatu
                case 179: return new int[] { 9, 9, 57 }; // Mareep
                case 180: return new int[] { 9, 9, 57 }; // Flaaffy
                case 181: return new int[] { 9, 9, 57 }; // Ampharos
                //case 181: return new int[] { 104, 104, 104 }; // Mega Ampharos
                case 182: return new int[] { 34, 34, 131 }; // Bellossom
                case 183: return new int[] { 47, 37, 157 }; // Marill
                case 184: return new int[] { 47, 37, 157 }; // Azumarill
                case 185: return new int[] { 5, 69, 155 }; // Sudowoodo
                case 186: return new int[] { 11, 6, 2 }; // Politoed
                case 187: return new int[] { 34, 102, 151 }; // Hoppip
                case 188: return new int[] { 34, 102, 151 }; // Skiploom
                case 189: return new int[] { 34, 102, 151 }; // Jumpluff
                case 190: return new int[] { 50, 53, 92 }; // Aipom
                case 191: return new int[] { 34, 94, 48 }; // Sunkern
                case 192: return new int[] { 34, 94, 48 }; // Sunflora
                case 193: return new int[] { 3, 14, 119 }; // Yanma
                case 194: return new int[] { 6, 11, 109 }; // Wooper
                case 195: return new int[] { 6, 11, 109 }; // Quagsire
                case 196: return new int[] { 28, 28, 156 }; // Espeon
                case 197: return new int[] { 28, 28, 39 }; // Umbreon
                case 198: return new int[] { 15, 105, 158 }; // Murkrow
                case 199: return new int[] { 12, 20, 144 }; // Slowking
                case 200: return new int[] { 26, 26, 26 }; // Misdreavus
                case 201: return new int[] { 26, 26, 26 }; // Unown
                case 202: return new int[] { 23, 23, 140 }; // Wobbuffet
                case 203: return new int[] { 39, 48, 157 }; // Girafarig
                case 204: return new int[] { 5, 5, 142 }; // Pineco
                case 205: return new int[] { 5, 5, 142 }; // Forretress
                case 206: return new int[] { 32, 50, 155 }; // Dunsparce
                case 207: return new int[] { 52, 8, 17 }; // Gligar
                case 208: return new int[] { 69, 5, 125 }; // Steelix
                //case 208: return new int[] { 159, 159, 159 }; // Mega Steelix
                case 209: return new int[] { 22, 50, 155 }; // Snubbull
                case 210: return new int[] { 22, 95, 155 }; // Granbull
                case 211: return new int[] { 38, 33, 22 }; // Qwilfish
                case 212: return new int[] { 68, 101, 135 }; // Scizor
                //case 212: return new int[] { 101, 101, 101 }; // Mega Scizor
                case 213: return new int[] { 5, 82, 126 }; // Shuckle
                case 214: return new int[] { 68, 62, 153 }; // Heracross
                //case 214: return new int[] { 92, 92, 92 }; // Mega Heracross
                case 215: return new int[] { 39, 51, 124 }; // Sneasel
                case 216: return new int[] { 53, 95, 118 }; // Teddiursa
                case 217: return new int[] { 62, 95, 127 }; // Ursaring
                case 218: return new int[] { 40, 49, 133 }; // Slugma
                case 219: return new int[] { 40, 49, 133 }; // Magcargo
                case 220: return new int[] { 12, 81, 47 }; // Swinub
                case 221: return new int[] { 12, 81, 47 }; // Piloswine
                case 222: return new int[] { 55, 30, 144 }; // Corsola
                case 223: return new int[] { 55, 97, 141 }; // Remoraid
                case 224: return new int[] { 21, 97, 141 }; // Octillery
                case 225: return new int[] { 72, 55, 15 }; // Delibird
                case 226: return new int[] { 33, 11, 41 }; // Mantine
                case 227: return new int[] { 51, 5, 133 }; // Skarmory
                case 228: return new int[] { 48, 18, 127 }; // Houndour
                case 229: return new int[] { 48, 18, 127 }; // Houndoom
                //case 229: return new int[] { 94, 94, 94 }; // Mega Houndoom
                case 230: return new int[] { 33, 97, 6 }; // Kingdra
                case 231: return new int[] { 53, 53, 8 }; // Phanpy
                case 232: return new int[] { 5, 5, 8 }; // Donphan
                case 233: return new int[] { 36, 88, 148 }; // Porygon2
                case 234: return new int[] { 22, 119, 157 }; // Stantler
                case 235: return new int[] { 20, 101, 141 }; // Smeargle
                case 236: return new int[] { 62, 80, 72 }; // Tyrogue
                case 237: return new int[] { 22, 101, 80 }; // Hitmontop
                case 238: return new int[] { 12, 108, 93 }; // Smoochum
                case 239: return new int[] { 9, 9, 72 }; // Elekid
                case 240: return new int[] { 49, 49, 72 }; // Magby
                case 241: return new int[] { 47, 113, 157 }; // Miltank
                case 242: return new int[] { 30, 32, 131 }; // Blissey
                case 243: return new int[] { 46, 46, 10 }; // Raikou
                case 244: return new int[] { 46, 46, 18 }; // Entei
                case 245: return new int[] { 46, 46, 11 }; // Suicune
                case 246: return new int[] { 62, 62, 8 }; // Larvitar
                case 247: return new int[] { 61, 61, 61 }; // Pupitar
                case 248: return new int[] { 45, 45, 127 }; // Tyranitar
                //case 248: return new int[] { 45, 45, 45 }; // Mega Tyranitar
                case 249: return new int[] { 46, 46, 136 }; // Lugia
                case 250: return new int[] { 46, 46, 144 }; // Ho-Oh
                case 251: return new int[] { 30, 30, 30 }; // Celebi
                case 252: return new int[] { 65, 65, 84 }; // Treecko
                case 253: return new int[] { 65, 65, 84 }; // Grovyle
                case 254: return new int[] { 65, 65, 84 }; // Sceptile
                //case 254: return new int[] { 31, 31, 31 }; // Mega Sceptile
                case 255: return new int[] { 66, 66, 3 }; // Torchic
                case 256: return new int[] { 66, 66, 3 }; // Combusken
                case 257: return new int[] { 66, 66, 3 }; // Blaziken
                //case 257: return new int[] { 3, 3, 3 }; // Mega Blaziken
                case 258: return new int[] { 67, 67, 6 }; // Mudkip
                case 259: return new int[] { 67, 67, 6 }; // Marshtomp
                case 260: return new int[] { 67, 67, 6 }; // Swampert
                //case 260: return new int[] { 33, 33, 33 }; // Mega Swampert
                case 261: return new int[] { 50, 95, 155 }; // Poochyena
                case 262: return new int[] { 22, 95, 153 }; // Mightyena
                case 263: return new int[] { 53, 82, 95 }; // Zigzagoon
                case 264: return new int[] { 53, 82, 95 }; // Linoone
                case 265: return new int[] { 19, 19, 50 }; // Wurmple
                case 266: return new int[] { 61, 61, 61 }; // Silcoon
                case 267: return new int[] { 68, 68, 79 }; // Beautifly
                case 268: return new int[] { 61, 61, 61 }; // Cascoon
                case 269: return new int[] { 19, 19, 14 }; // Dustox
                case 270: return new int[] { 33, 44, 20 }; // Lotad
                case 271: return new int[] { 33, 44, 20 }; // Lombre
                case 272: return new int[] { 33, 44, 20 }; // Ludicolo
                case 273: return new int[] { 34, 48, 124 }; // Seedot
                case 274: return new int[] { 34, 48, 124 }; // Nuzleaf
                case 275: return new int[] { 34, 48, 124 }; // Shiftry
                case 276: return new int[] { 62, 62, 113 }; // Taillow
                case 277: return new int[] { 62, 62, 113 }; // Swellow
                case 278: return new int[] { 51, 51, 44 }; // Wingull
                case 279: return new int[] { 51, 51, 44 }; // Pelipper
                case 280: return new int[] { 28, 36, 140 }; // Ralts
                case 281: return new int[] { 28, 36, 140 }; // Kirlia
                case 282: return new int[] { 28, 36, 140 }; // Gardevoir
                //case 282: return new int[] { 182, 182, 182 }; // Mega Gardevoir
                case 283: return new int[] { 33, 33, 44 }; // Surskit
                case 284: return new int[] { 22, 22, 127 }; // Masquerain
                case 285: return new int[] { 27, 90, 95 }; // Shroomish
                case 286: return new int[] { 27, 90, 101 }; // Breloom
                case 287: return new int[] { 54, 54, 54 }; // Slakoth
                case 288: return new int[] { 72, 72, 72 }; // Vigoroth
                case 289: return new int[] { 54, 54, 54 }; // Slaking
                case 290: return new int[] { 14, 14, 50 }; // Nincada
                case 291: return new int[] { 3, 3, 151 }; // Ninjask
                case 292: return new int[] { 25, 25, 25 }; // Shedinja
                case 293: return new int[] { 43, 43, 155 }; // Whismur
                case 294: return new int[] { 43, 43, 113 }; // Loudred
                case 295: return new int[] { 43, 43, 113 }; // Exploud
                case 296: return new int[] { 47, 62, 125 }; // Makuhita
                case 297: return new int[] { 47, 62, 125 }; // Hariyama
                case 298: return new int[] { 47, 37, 157 }; // Azurill
                case 299: return new int[] { 5, 42, 159 }; // Nosepass
                case 300: return new int[] { 56, 96, 147 }; // Skitty
                case 301: return new int[] { 56, 96, 147 }; // Delcatty
                case 302: return new int[] { 51, 100, 158 }; // Sableye
                //case 302: return new int[] { 156, 156, 156 }; // Mega Sableye
                case 303: return new int[] { 52, 22, 125 }; // Mawile
                //case 303: return new int[] { 37, 37, 37 }; // Mega Mawile
                case 304: return new int[] { 5, 69, 134 }; // Aron
                case 305: return new int[] { 5, 69, 134 }; // Lairon
                case 306: return new int[] { 5, 69, 134 }; // Aggron
                //case 306: return new int[] { 111, 111, 111 }; // Mega Aggron
                case 307: return new int[] { 74, 74, 140 }; // Meditite
                case 308: return new int[] { 74, 74, 140 }; // Medicham
                //case 308: return new int[] { 74, 74, 74 }; // Mega Medicham
                case 309: return new int[] { 9, 31, 58 }; // Electrike
                case 310: return new int[] { 9, 31, 58 }; // Manectric
                //case 310: return new int[] { 22, 22, 22 }; // Mega Manectric
                case 311: return new int[] { 57, 57, 31 }; // Plusle
                case 312: return new int[] { 58, 58, 10 }; // Minun
                case 313: return new int[] { 35, 68, 158 }; // Volbeat
                case 314: return new int[] { 12, 110, 158 }; // Illumise
                case 315: return new int[] { 30, 38, 102 }; // Roselia
                case 316: return new int[] { 64, 60, 82 }; // Gulpin
                case 317: return new int[] { 64, 60, 82 }; // Swalot
                case 318: return new int[] { 24, 24, 3 }; // Carvanha
                case 319: return new int[] { 24, 24, 3 }; // Sharpedo
                //case 319: return new int[] { 173, 173, 173 }; // Mega Sharpedo
                case 320: return new int[] { 41, 12, 46 }; // Wailmer
                case 321: return new int[] { 41, 12, 46 }; // Wailord
                case 322: return new int[] { 12, 86, 20 }; // Numel
                case 323: return new int[] { 40, 116, 83 }; // Camerupt
                //case 323: return new int[] { 125, 125, 125 }; // Mega Camerupt
                case 324: return new int[] { 73, 73, 75 }; // Torkoal
                case 325: return new int[] { 47, 20, 82 }; // Spoink
                case 326: return new int[] { 47, 20, 82 }; // Grumpig
                case 327: return new int[] { 20, 77, 126 }; // Spinda
                case 328: return new int[] { 52, 71, 125 }; // Trapinch
                case 329: return new int[] { 26, 26, 26 }; // Vibrava
                case 330: return new int[] { 26, 26, 26 }; // Flygon
                case 331: return new int[] { 8, 8, 11 }; // Cacnea
                case 332: return new int[] { 8, 8, 11 }; // Cacturne
                case 333: return new int[] { 30, 30, 13 }; // Swablu
                case 334: return new int[] { 30, 30, 13 }; // Altaria
                //case 334: return new int[] { 182, 182, 182 }; // Mega Altaria
                case 335: return new int[] { 17, 17, 137 }; // Zangoose
                case 336: return new int[] { 61, 61, 151 }; // Seviper
                case 337: return new int[] { 26, 26, 26 }; // Lunatone
                case 338: return new int[] { 26, 26, 26 }; // Solrock
                case 339: return new int[] { 12, 107, 93 }; // Barboach
                case 340: return new int[] { 12, 107, 93 }; // Whiscash
                case 341: return new int[] { 52, 75, 91 }; // Corphish
                case 342: return new int[] { 52, 75, 91 }; // Crawdaunt
                case 343: return new int[] { 26, 26, 26 }; // Baltoy
                case 344: return new int[] { 26, 26, 26 }; // Claydol
                case 345: return new int[] { 21, 21, 114 }; // Lileep
                case 346: return new int[] { 21, 21, 114 }; // Cradily
                case 347: return new int[] { 4, 4, 33 }; // Anorith
                case 348: return new int[] { 4, 4, 33 }; // Armaldo
                case 349: return new int[] { 33, 12, 91 }; // Feebas
                case 350: return new int[] { 63, 172, 56 }; // Milotic
                case 351: return new int[] { 59, 59, 59 }; // Castform - All formes
                case 352: return new int[] { 16, 16, 168 }; // Kecleon
                case 353: return new int[] { 15, 119, 130 }; // Shuppet
                case 354: return new int[] { 15, 119, 130 }; // Banette
                //case 354: return new int[] { 158, 158, 158 }; // Mega Banette
                case 355: return new int[] { 26, 26, 119 }; // Duskull
                case 356: return new int[] { 46, 46, 119 }; // Dusclops
                case 357: return new int[] { 34, 94, 139 }; // Tropius
                case 358: return new int[] { 26, 26, 26 }; // Chimecho
                case 359: return new int[] { 46, 105, 154 }; // Absol
                //case 359: return new int[] { 156, 156, 156 }; // Mega Absol
                case 360: return new int[] { 23, 23, 140 }; // Wynaut
                case 361: return new int[] { 39, 115, 141 }; // Snorunt
                case 362: return new int[] { 39, 115, 141 }; // Glalie
                //case 362: return new int[] { 174, 174, 174 }; // Mega Glalie
                case 363: return new int[] { 47, 115, 12 }; // Spheal
                case 364: return new int[] { 47, 115, 12 }; // Sealeo
                case 365: return new int[] { 47, 115, 12 }; // Walrein
                case 366: return new int[] { 75, 75, 155 }; // Clamperl
                case 367: return new int[] { 33, 33, 41 }; // Huntail
                case 368: return new int[] { 33, 33, 93 }; // Gorebyss
                case 369: return new int[] { 33, 69, 5 }; // Relicanth
                case 370: return new int[] { 33, 33, 93 }; // Luvdisc
                case 371: return new int[] { 69, 69, 125 }; // Bagon
                case 372: return new int[] { 69, 69, 142 }; // Shelgon
                case 373: return new int[] { 22, 22, 153 }; // Salamence
                //case 373: return new int[] { 184, 184, 184 }; // Mega Salamence
                case 374: return new int[] { 29, 29, 135 }; // Beldum
                case 375: return new int[] { 29, 29, 135 }; // Metang
                case 376: return new int[] { 29, 29, 135 }; // Metagross
                //case 376: return new int[] { 181, 181, 181 }; // Mega Metagross
                case 377: return new int[] { 29, 29, 5 }; // Regirock
                case 378: return new int[] { 29, 29, 115 }; // Regice
                case 379: return new int[] { 29, 29, 135 }; // Registeel
                case 380: return new int[] { 26, 26, 26 }; // Latias
                //case 380: return new int[] { 26, 26, 26 }; // Mega Latias
                case 381: return new int[] { 26, 26, 26 }; // Latios
                //case 381: return new int[] { 26, 26, 26 }; // Mega Latios
                case 382: return new int[] { 2, 2, 2 }; // Kyogre
                //case 382: return new int[] { 189, 189, 189 }; // Primal Kyogre
                case 383: return new int[] { 70, 70, 70 }; // Groudon
                //case 383: return new int[] { 190, 190, 190 }; // Primal Groudon
                case 384: return new int[] { 76, 76, 76 }; // Rayquaza
                //case 384: return new int[] { 191, 191, 191 }; // Mega Rayquaza
                case 385: return new int[] { 32, 32, 32 }; // Jirachi
                case 386: return new int[] { 46, 46, 46 }; // Deoxys - All formes
                case 387: return new int[] { 65, 65, 75 }; // Turtwig
                case 388: return new int[] { 65, 65, 75 }; // Grotle
                case 389: return new int[] { 65, 65, 75 }; // Torterra
                case 390: return new int[] { 66, 66, 89 }; // Chimchar
                case 391: return new int[] { 66, 66, 89 }; // Monferno
                case 392: return new int[] { 66, 66, 89 }; // Infernape
                case 393: return new int[] { 67, 67, 128 }; // Piplup
                case 394: return new int[] { 67, 67, 128 }; // Prinplup
                case 395: return new int[] { 67, 67, 128 }; // Empoleon
                case 396: return new int[] { 51, 51, 120 }; // Starly
                case 397: return new int[] { 22, 22, 120 }; // Staravia
                case 398: return new int[] { 22, 22, 120 }; // Staraptor
                case 399: return new int[] { 86, 109, 141 }; // Bidoof
                case 400: return new int[] { 86, 109, 141 }; // Bibarel
                case 401: return new int[] { 61, 61, 50 }; // Kricketot
                case 402: return new int[] { 68, 68, 101 }; // Kricketune
                case 403: return new int[] { 79, 22, 62 }; // Shinx
                case 404: return new int[] { 79, 22, 62 }; // Luxio
                case 405: return new int[] { 79, 22, 62 }; // Luxray
                case 406: return new int[] { 30, 38, 102 }; // Budew
                case 407: return new int[] { 30, 38, 101 }; // Roserade
                case 408: return new int[] { 104, 104, 125 }; // Cranidos
                case 409: return new int[] { 104, 104, 125 }; // Rampardos
                case 410: return new int[] { 5, 5, 43 }; // Shieldon
                case 411: return new int[] { 5, 5, 43 }; // Bastiodon
                case 412: return new int[] { 61, 61, 142 }; // Burmy - All formes
                case 413: return new int[] { 107, 107, 142 }; // Wormadam - All formes
                case 414: return new int[] { 68, 68, 110 }; // Mothim
                case 415: return new int[] { 118, 118, 55 }; // Combee
                case 416: return new int[] { 46, 46, 127 }; // Vespiquen
                case 417: return new int[] { 50, 53, 10 }; // Pachirisu
                case 418: return new int[] { 33, 33, 41 }; // Buizel
                case 419: return new int[] { 33, 33, 41 }; // Floatzel
                case 420: return new int[] { 34, 34, 34 }; // Cherubi
                case 421: return new int[] { 122, 122, 122 }; // Cherrim
                case 422: return new int[] { 60, 114, 159 }; // Shellos
                case 423: return new int[] { 60, 114, 159 }; // Gastrodon
                case 424: return new int[] { 101, 53, 92 }; // Ambipom
                case 425: return new int[] { 106, 84, 138 }; // Drifloon
                case 426: return new int[] { 106, 84, 138 }; // Drifblim
                case 427: return new int[] { 50, 103, 7 }; // Buneary
                case 428: return new int[] { 56, 103, 7 }; // Lopunny
                //case 428: return new int[] { 113, 113, 113 }; // Mega Lopunny
                case 429: return new int[] { 26, 26, 26 }; // Mismagius
                case 430: return new int[] { 15, 105, 153 }; // Honchkrow
                case 431: return new int[] { 7, 20, 51 }; // Glameow
                case 432: return new int[] { 47, 20, 128 }; // Purugly
                case 433: return new int[] { 26, 26, 26 }; // Chingling
                case 434: return new int[] { 1, 106, 51 }; // Stunky
                case 435: return new int[] { 1, 106, 51 }; // Skuntank
                case 436: return new int[] { 26, 85, 134 }; // Bronzor
                case 437: return new int[] { 26, 85, 134 }; // Bronzong
                case 438: return new int[] { 5, 69, 155 }; // Bonsly
                case 439: return new int[] { 43, 111, 101 }; // Mime Jr.
                case 440: return new int[] { 30, 32, 132 }; // Happiny
                case 441: return new int[] { 51, 77, 145 }; // Chatot
                case 442: return new int[] { 46, 46, 151 }; // Spiritomb
                case 443: return new int[] { 8, 8, 24 }; // Gible
                case 444: return new int[] { 8, 8, 24 }; // Gabite
                case 445: return new int[] { 8, 8, 24 }; // Garchomp
                //case 445: return new int[] { 159, 159, 159 }; // Mega Garchomp
                case 446: return new int[] { 53, 47, 82 }; // Munchlax
                case 447: return new int[] { 80, 39, 158 }; // Riolu
                case 448: return new int[] { 80, 39, 154 }; // Lucario
                //case 448: return new int[] { 91, 91, 91 }; // Mega Lucario
                case 449: return new int[] { 45, 45, 159 }; // Hippopotas
                case 450: return new int[] { 45, 45, 159 }; // Hippowdon
                case 451: return new int[] { 4, 97, 51 }; // Skorupi
                case 452: return new int[] { 4, 97, 51 }; // Drapion
                case 453: return new int[] { 107, 87, 143 }; // Croagunk
                case 454: return new int[] { 107, 87, 143 }; // Toxicroak
                case 455: return new int[] { 26, 26, 26 }; // Carnivine
                case 456: return new int[] { 33, 114, 41 }; // Finneon
                case 457: return new int[] { 33, 114, 41 }; // Lumineon
                case 458: return new int[] { 33, 11, 41 }; // Mantyke
                case 459: return new int[] { 117, 117, 43 }; // Snover
                case 460: return new int[] { 117, 117, 43 }; // Abomasnow
                //case 460: return new int[] { 117, 117, 117 }; // Mega Abomasnow
                case 461: return new int[] { 46, 46, 124 }; // Weavile
                case 462: return new int[] { 42, 5, 148 }; // Magnezone
                case 463: return new int[] { 20, 12, 13 }; // Lickilicky
                case 464: return new int[] { 31, 116, 120 }; // Rhyperior
                case 465: return new int[] { 34, 102, 144 }; // Tangrowth
                case 466: return new int[] { 78, 78, 72 }; // Electivire
                case 467: return new int[] { 49, 49, 72 }; // Magmortar
                case 468: return new int[] { 55, 32, 105 }; // Togekiss
                case 469: return new int[] { 3, 110, 119 }; // Yanmega
                case 470: return new int[] { 102, 102, 34 }; // Leafeon
                case 471: return new int[] { 81, 81, 115 }; // Glaceon
                case 472: return new int[] { 52, 8, 90 }; // Gliscor
                case 473: return new int[] { 12, 81, 47 }; // Mamoswine
                case 474: return new int[] { 91, 88, 148 }; // Porygon-Z
                case 475: return new int[] { 80, 80, 154 }; // Gallade
                //case 475: return new int[] { 39, 39, 39 }; // Mega Gallade
                case 476: return new int[] { 5, 42, 159 }; // Probopass
                case 477: return new int[] { 46, 46, 119 }; // Dusknoir
                case 478: return new int[] { 81, 81, 130 }; // Froslass
                case 479: return new int[] { 26, 26, 26 }; // Rotom - All formes
                case 480: return new int[] { 26, 26, 26 }; // Uxie
                case 481: return new int[] { 26, 26, 26 }; // Mesprit
                case 482: return new int[] { 26, 26, 26 }; // Azelf
                case 483: return new int[] { 46, 46, 140 }; // Dialga
                case 484: return new int[] { 46, 46, 140 }; // Palkia
                case 485: return new int[] { 18, 18, 49 }; // Heatran
                case 486: return new int[] { 112, 112, 112 }; // Regigigas
                case 487:
                    switch (forme)
                    {
                        case 1: return new int[] { 26, 26, 26 }; // Giratina - Origin
                        default: return new int[] { 46, 46, 140 }; // Giratina - Altered
                    }
                case 488: return new int[] { 26, 26, 26 }; // Cresselia
                case 489: return new int[] { 93, 93, 93 }; // Phione
                case 490: return new int[] { 93, 93, 93 }; // Manaphy
                case 491: return new int[] { 123, 123, 123 }; // Darkrai
                case 492:
                    switch (forme)
                    {
                        case 1: return new int[] { 32, 32, 32 }; // Shaymin - Sky
                        default: return new int[] { 30, 30, 30 }; // Shaymin - Land
                    }
                case 493: return new int[] { 121, 121, 121 }; // Arceus
                case 494: return new int[] { 162, 162, 162 }; // Victini
                case 495: return new int[] { 65, 65, 126 }; // Snivy
                case 496: return new int[] { 65, 65, 126 }; // Servine
                case 497: return new int[] { 65, 65, 126 }; // Serperior
                case 498: return new int[] { 66, 66, 47 }; // Tepig
                case 499: return new int[] { 66, 66, 47 }; // Pignite
                case 500: return new int[] { 66, 66, 120 }; // Emboar
                case 501: return new int[] { 67, 67, 75 }; // Oshawott
                case 502: return new int[] { 67, 67, 75 }; // Dewott
                case 503: return new int[] { 67, 67, 75 }; // Samurott
                case 504: return new int[] { 50, 51, 148 }; // Patrat
                case 505: return new int[] { 35, 51, 148 }; // Watchog
                case 506: return new int[] { 72, 53, 50 }; // Lillipup
                case 507: return new int[] { 22, 146, 113 }; // Herdier
                case 508: return new int[] { 22, 146, 113 }; // Stoutland
                case 509: return new int[] { 7, 84, 158 }; // Purrloin
                case 510: return new int[] { 7, 84, 158 }; // Liepard
                case 511: return new int[] { 82, 82, 65 }; // Pansage
                case 512: return new int[] { 82, 82, 65 }; // Simisage
                case 513: return new int[] { 82, 82, 66 }; // Pansear
                case 514: return new int[] { 82, 82, 66 }; // Simisear
                case 515: return new int[] { 82, 82, 67 }; // Panpour
                case 516: return new int[] { 82, 82, 67 }; // Simipour
                case 517: return new int[] { 108, 28, 140 }; // Munna
                case 518: return new int[] { 108, 28, 140 }; // Musharna
                case 519: return new int[] { 145, 105, 79 }; // Pidove
                case 520: return new int[] { 145, 105, 79 }; // Tranquill
                case 521: return new int[] { 145, 105, 79 }; // Unfezant
                case 522: return new int[] { 31, 78, 157 }; // Blitzle
                case 523: return new int[] { 31, 78, 157 }; // Zebstrika
                case 524: return new int[] { 5, 5, 159 }; // Roggenrola
                case 525: return new int[] { 5, 5, 159 }; // Boldore
                case 526: return new int[] { 5, 5, 159 }; // Gigalith
                case 527: return new int[] { 109, 103, 86 }; // Woobat
                case 528: return new int[] { 109, 103, 86 }; // Swoobat
                case 529: return new int[] { 146, 159, 104 }; // Drilbur
                case 530: return new int[] { 146, 159, 104 }; // Excadrill
                case 531: return new int[] { 131, 144, 103 }; // Audino
                //case 531: return new int[] { 131, 131, 131 }; // Mega Audino
                case 532: return new int[] { 62, 125, 89 }; // Timburr
                case 533: return new int[] { 62, 125, 89 }; // Gurdurr
                case 534: return new int[] { 62, 125, 89 }; // Conkeldurr
                case 535: return new int[] { 33, 93, 11 }; // Tympole
                case 536: return new int[] { 33, 93, 11 }; // Palpitoad
                case 537: return new int[] { 33, 143, 11 }; // Seismitoad
                case 538: return new int[] { 62, 39, 104 }; // Throh
                case 539: return new int[] { 5, 39, 104 }; // Sawk
                case 540: return new int[] { 68, 34, 142 }; // Sewaddle
                case 541: return new int[] { 102, 34, 142 }; // Swadloon
                case 542: return new int[] { 68, 34, 142 }; // Leavanny
                case 543: return new int[] { 38, 68, 3 }; // Venipede*
                case 544: return new int[] { 38, 68, 3 }; // Whirlipede*
                case 545: return new int[] { 38, 68, 3 }; // Scolipede*
                case 546: return new int[] { 158, 151, 34 }; // Cottonee
                case 547: return new int[] { 158, 151, 34 }; // Whimsicott
                case 548: return new int[] { 34, 20, 102 }; // Petilil
                case 549: return new int[] { 34, 20, 102 }; // Lilligant
                case 550:
                    switch (forme)
                    {
                        case 1: return new int[] { 69, 91, 104 }; // Basculin - Blue
                        default: return new int[] { 120, 91, 104 }; // Basculin - Red
                    }
                case 551: return new int[] { 22, 153, 83 }; // Sandile
                case 552: return new int[] { 22, 153, 83 }; // Krokorok
                case 553: return new int[] { 22, 153, 83 }; // Krookodile
                case 554: return new int[] { 55, 55, 39 }; // Darumaka
                case 555: return new int[] { 125, 125, 161 }; // Darmanitan
                case 556: return new int[] { 11, 34, 114 }; // Maractus
                case 557: return new int[] { 5, 75, 133 }; // Dwebble
                case 558: return new int[] { 5, 75, 133 }; // Crustle
                case 559: return new int[] { 61, 153, 22 }; // Scraggy
                case 560: return new int[] { 61, 153, 22 }; // Scrafty
                case 561: return new int[] { 147, 98, 110 }; // Sigilyph
                case 562: return new int[] { 152, 152, 152 }; // Yamask
                case 563: return new int[] { 152, 152, 152 }; // Cofagrigus
                case 564: return new int[] { 116, 5, 33 }; // Tirtouga
                case 565: return new int[] { 116, 5, 33 }; // Carracosta
                case 566: return new int[] { 129, 129, 129 }; // Archen
                case 567: return new int[] { 129, 129, 129 }; // Archeops
                case 568: return new int[] { 1, 60, 106 }; // Trubbish
                case 569: return new int[] { 1, 133, 106 }; // Garbodor
                case 570: return new int[] { 149, 149, 149 }; // Zorua
                case 571: return new int[] { 149, 149, 149 }; // Zoroark
                case 572: return new int[] { 56, 101, 92 }; // Minccino
                case 573: return new int[] { 56, 101, 92 }; // Cinccino
                case 574: return new int[] { 119, 172, 23 }; // Gothita
                case 575: return new int[] { 119, 172, 23 }; // Gothorita
                case 576: return new int[] { 119, 172, 23 }; // Gothitelle
                case 577: return new int[] { 142, 98, 144 }; // Solosis
                case 578: return new int[] { 142, 98, 144 }; // Duosion
                case 579: return new int[] { 142, 98, 144 }; // Reuniclus
                case 580: return new int[] { 51, 145, 93 }; // Ducklett
                case 581: return new int[] { 51, 145, 93 }; // Swanna
                case 582: return new int[] { 115, 115, 133 }; // Vanillite
                case 583: return new int[] { 115, 115, 133 }; // Vanillish
                case 584: return new int[] { 115, 115, 133 }; // Vanilluxe
                case 585: return new int[] { 34, 157, 32 }; // Deerling - All formes
                case 586: return new int[] { 34, 157, 32 }; // Sawsbuck - All formes
                case 587: return new int[] { 9, 9, 78 }; // Emolga
                case 588: return new int[] { 68, 61, 99 }; // Karrablast
                case 589: return new int[] { 68, 75, 142 }; // Escavalier
                case 590: return new int[] { 27, 27, 144 }; // Foongus
                case 591: return new int[] { 27, 27, 144 }; // Amoonguss
                case 592: return new int[] { 11, 130, 6 }; // Frillish
                case 593: return new int[] { 11, 130, 6 }; // Jellicent
                case 594: return new int[] { 131, 93, 144 }; // Alomomola
                case 595: return new int[] { 14, 127, 68 }; // Joltik
                case 596: return new int[] { 14, 127, 68 }; // Galvantula
                case 597: return new int[] { 160, 160, 160 }; // Ferroseed
                case 598: return new int[] { 160, 160, 107 }; // Ferrothorn
                case 599: return new int[] { 57, 58, 29 }; // Klink
                case 600: return new int[] { 57, 58, 29 }; // Klang
                case 601: return new int[] { 57, 58, 29 }; // Klinklang
                case 602: return new int[] { 26, 26, 26 }; // Tynamo
                case 603: return new int[] { 26, 26, 26 }; // Eelektrik
                case 604: return new int[] { 26, 26, 26 }; // Eelektross
                case 605: return new int[] { 140, 28, 148 }; // Elgyem
                case 606: return new int[] { 140, 28, 148 }; // Beheeyem
                case 607: return new int[] { 18, 49, 151 }; // Litwick
                case 608: return new int[] { 18, 49, 151 }; // Lampent
                case 609: return new int[] { 18, 49, 151 }; // Chandelure
                case 610: return new int[] { 79, 104, 127 }; // Axew
                case 611: return new int[] { 79, 104, 127 }; // Fraxure
                case 612: return new int[] { 79, 104, 127 }; // Haxorus
                case 613: return new int[] { 81, 81, 155 }; // Cubchoo
                case 614: return new int[] { 81, 81, 33 }; // Beartic
                case 615: return new int[] { 26, 26, 26 }; // Cryogonal
                case 616: return new int[] { 93, 75, 142 }; // Shelmet
                case 617: return new int[] { 93, 60, 84 }; // Accelgor
                case 618: return new int[] { 9, 7, 8 }; // Stunfisk
                case 619: return new int[] { 39, 144, 120 }; // Mienfoo
                case 620: return new int[] { 39, 144, 120 }; // Mienshao
                case 621: return new int[] { 24, 125, 104 }; // Druddigon
                case 622: return new int[] { 89, 103, 99 }; // Golett
                case 623: return new int[] { 89, 103, 99 }; // Golurk
                case 624: return new int[] { 128, 39, 46 }; // Pawniard
                case 625: return new int[] { 128, 39, 46 }; // Bisharp
                case 626: return new int[] { 120, 157, 43 }; // Bouffalant
                case 627: return new int[] { 51, 125, 55 }; // Rufflet
                case 628: return new int[] { 51, 125, 128 }; // Braviary
                case 629: return new int[] { 145, 142, 133 }; // Vullaby
                case 630: return new int[] { 145, 142, 133 }; // Mandibuzz
                case 631: return new int[] { 82, 18, 73 }; // Heatmor
                case 632: return new int[] { 68, 55, 54 }; // Durant
                case 633: return new int[] { 55, 55, 55 }; // Deino
                case 634: return new int[] { 55, 55, 55 }; // Zweilous
                case 635: return new int[] { 26, 26, 26 }; // Hydreigon
                case 636: return new int[] { 49, 49, 68 }; // Larvesta
                case 637: return new int[] { 49, 49, 68 }; // Volcarona
                case 638: return new int[] { 154, 154, 154 }; // Cobalion
                case 639: return new int[] { 154, 154, 154 }; // Terrakion
                case 640: return new int[] { 154, 154, 154 }; // Virizion
                case 641:
                    switch (forme)
                    {
                        case 1: return new int[] { 144, 144, 144 }; // Tornadus - Therian
                        default: return new int[] { 158, 158, 128 }; // Tornadus - Incarnate
                    }
                case 642:
                    switch (forme)
                    {
                        case 1: return new int[] { 10, 10, 10 }; // Thundurus - Therian
                        default: return new int[] { 158, 158, 128 }; // Thundurus - Incarnate
                    }
                case 643: return new int[] { 163, 163, 163 }; // Reshiram
                case 644: return new int[] { 164, 164, 164 }; // Zekrom
                case 645:
                    switch (forme)
                    {
                        case 1: return new int[] { 22, 22, 22 }; // Landorus - Therian
                        default: return new int[] { 159, 159, 125 }; // Landorus - Incarnate
                    }
                case 646:
                    switch (forme)
                    {
                        case 1: return new int[] { 163, 163, 163 }; // White Kyurem
                        case 2: return new int[] { 164, 164, 164 }; // Black Kyurem
                        default: return new int[] { 46, 46, 46 }; // Kyurem
                    }
                case 647: return new int[] { 154, 154, 154 }; // Keldeo
                case 648: return new int[] { 32, 32, 32 }; // Meloetta
                case 649: return new int[] { 88, 88, 88 }; // Genesect
                case 650: return new int[] { 65, 65, 171 }; // Chespin
                case 651: return new int[] { 65, 65, 171 }; // Quilladin
                case 652: return new int[] { 65, 65, 171 }; // Chesnaught
                case 653: return new int[] { 66, 66, 170 }; // Fennekin
                case 654: return new int[] { 66, 66, 170 }; // Braixen
                case 655: return new int[] { 66, 66, 170 }; // Delphox
                case 656: return new int[] { 67, 67, 168 }; // Froakie
                case 657: return new int[] { 67, 67, 168 }; // Frogadier
                case 658: return new int[] { 67, 67, 168 }; // Greninja
                case 659: return new int[] { 53, 167, 37 }; // Bunnelby
                case 660: return new int[] { 53, 167, 37 }; // Diggersby
                case 661: return new int[] { 145, 145, 177 }; // Fletchling
                case 662: return new int[] { 49, 49, 177 }; // Fletchinder
                case 663: return new int[] { 49, 49, 177 }; // Talonflame
                case 664: return new int[] { 19, 14, 132 }; // Scatterbug
                case 665: return new int[] { 61, 61, 132 }; // Spewpa
                case 666: return new int[] { 19, 14, 132 }; // Vivillon
                case 667: return new int[] { 79, 127, 153 }; // Litleo
                case 668: return new int[] { 79, 127, 153 }; // Pyroar
                case 669: return new int[] { 166, 166, 180 }; // Flabébé
                case 670: return new int[] { 166, 166, 180 }; // Floette
                case 671: return new int[] { 166, 166, 180 }; // Florges
                case 672: return new int[] { 157, 157, 179 }; // Skiddo
                case 673: return new int[] { 157, 157, 179 }; // Gogoat
                case 674: return new int[] { 89, 104, 113 }; // Pancham
                case 675: return new int[] { 89, 104, 113 }; // Pangoro
                case 676: return new int[] { 169, 169, 169 }; // Furfrou
                case 677: return new int[] { 51, 151, 20 }; // Espurr
                case 678:
                    switch (forme)
                    {
                        case 1: return new int[] { 51, 151, 172 }; // Meowstic♀
                        default: return new int[] { 51, 151, 158 }; // Meowstic♂
                    }
                case 679: return new int[] { 99, 99, 99 }; // Honedge
                case 680: return new int[] { 99, 99, 99 }; // Doublade
                case 681: return new int[] { 176, 176, 176 }; // Aegislash
                case 682: return new int[] { 131, 131, 165 }; // Spritzee
                case 683: return new int[] { 131, 131, 165 }; // Aromatisse
                case 684: return new int[] { 175, 175, 84 }; // Swirlix
                case 685: return new int[] { 175, 175, 84 }; // Slurpuff
                case 686: return new int[] { 126, 21, 151 }; // Inkay
                case 687: return new int[] { 126, 21, 151 }; // Malamar
                case 688: return new int[] { 97, 181, 124 }; // Binacle
                case 689: return new int[] { 97, 181, 124 }; // Barbaracle
                case 690: return new int[] { 38, 143, 91 }; // Skrelp
                case 691: return new int[] { 38, 143, 91 }; // Dragalge
                case 692: return new int[] { 178, 178, 178 }; // Clauncher
                case 693: return new int[] { 178, 178, 178 }; // Clawitzer
                case 694: return new int[] { 87, 8, 94 }; // Helioptile
                case 695: return new int[] { 87, 8, 94 }; // Heliolisk
                case 696: return new int[] { 173, 173, 5 }; // Tyrunt
                case 697: return new int[] { 173, 173, 69 }; // Tyrantrum
                case 698: return new int[] { 174, 174, 117 }; // Amaura
                case 699: return new int[] { 174, 174, 117 }; // Aurorus
                case 700: return new int[] { 56, 56, 182 }; // Sylveon
                case 701: return new int[] { 7, 84, 104 }; // Hawlucha
                case 702: return new int[] { 167, 53, 57 }; // Dedenne
                case 703: return new int[] { 29, 29, 5 }; // Carbink
                case 704: return new int[] { 157, 93, 183 }; // Goomy
                case 705: return new int[] { 157, 93, 183 }; // Sliggoo
                case 706: return new int[] { 157, 93, 183 }; // Goodra
                case 707: return new int[] { 158, 158, 170 }; // Klefki
                case 708: return new int[] { 30, 119, 139 }; // Phantump
                case 709: return new int[] { 30, 119, 139 }; // Trevenant
                case 710: return new int[] { 53, 119, 15 }; // Pumpkaboo
                case 711: return new int[] { 53, 119, 15 }; // Gourgeist
                case 712: return new int[] { 20, 115, 5 }; // Bergmite
                case 713: return new int[] { 20, 115, 5 }; // Avalugg
                case 714: return new int[] { 119, 151, 140 }; // Noibat
                case 715: return new int[] { 119, 151, 140 }; // Noivern
                case 716: return new int[] { 187, 187, 187 }; // Xerneas
                case 717: return new int[] { 186, 186, 186 }; // Yveltal
                case 718: return new int[] { 188, 188, 188 }; // Zygarde
                case 719: return new int[] { 29, 29, 29 }; // Diancie
                //case 719: return new int[] { 156, 156, 156 }; // Mega Diancie
                case 720: return new int[] { 170, 170, 170 }; // Hoopa Confined
                case 721: return new int[] { 11, 11, 11 }; // Volcanion
                default: return new int[] { 0, 0, 0 }; // No pokémon
            }
        }

        public static int[] getAbilities7(int species, int forme)
        {
            switch (species)
            {
                case 1: return new int[] { 65, 65, 34 }; // Bulbasaur
                case 2: return new int[] { 65, 65, 34 }; // Ivysaur
                case 3: return new int[] { 65, 65, 34 }; // Venusaur
                //case 3: return new int[] { 47, 47, 47 }; // Mega Venusaur
                case 4: return new int[] { 66, 66, 94 }; // Charmander
                case 5: return new int[] { 66, 66, 94 }; // Charmeleon
                case 6: return new int[] { 66, 66, 94 }; // Charizard
                //case 6: return new int[] { 181, 181, 181 }; // Mega Charizard X
                //case 6: return new int[] { 70, 70, 70 }; // Mega Charizard Y
                case 7: return new int[] { 67, 67, 44 }; // Squirtle
                case 8: return new int[] { 67, 67, 44 }; // Wartortle
                case 9: return new int[] { 67, 67, 44 }; // Blastoise
                //case 9: return new int[] { 178, 178, 178 }; // Mega Blastoise
                case 10: return new int[] { 19, 19, 50 }; // Caterpie
                case 11: return new int[] { 61, 61, 61 }; // Metapod
                case 12: return new int[] { 14, 14, 110 }; // Butterfree
                case 13: return new int[] { 19, 19, 50 }; // Weedle
                case 14: return new int[] { 61, 61, 61 }; // Kakuna
                case 15: return new int[] { 68, 68, 97 }; // Beedrill
                //case 15: return new int[] { 91, 91, 91 }; // Mega Beedrill
                case 16: return new int[] { 51, 77, 145 }; // Pidgey
                case 17: return new int[] { 51, 77, 145 }; // Pidgeotto
                case 18: return new int[] { 51, 77, 145 }; // Pidgeot
                //case 18: return new int[] { 99, 99, 99 }; // Mega Pidgeot
                case 19:
                    switch (forme)
                    {
                        case 1: return new int[] { 82, 55, 47 }; // Alolan Rattata
                        default: return new int[] { 50, 62, 55 }; // Rattata
                    }
                case 20:
                    switch (forme)
                    {
                        case 1: return new int[] { 82, 55, 47 }; // Alolan Raticate
                        default: return new int[] { 50, 62, 55 }; // Raticate
                    }
                case 21: return new int[] { 51, 51, 97 }; // Spearow
                case 22: return new int[] { 51, 51, 97 }; // Fearow
                case 23: return new int[] { 22, 61, 127 }; // Ekans
                case 24: return new int[] { 22, 61, 127 }; // Arbok
                case 25: return new int[] { 9, 9, 31 }; // Pikachu
                //case 25: return new int[] { 31, 31, 31 }; // Cosplay Pikachu
                case 26:
                    switch (forme)
                    {
                        case 1: return new int[] { 207, 207, 207 }; // Alolan Raichu
                        default: return new int[] { 9, 9, 31 }; // Raichu
                    }
                case 27:
                    switch (forme)
                    {
                        case 1: return new int[] { 81, 81, 202 }; // Alolan Sandshrew
                        default: return new int[] { 8, 8, 146 }; // Sandshrew
                    }
                case 28:
                    switch (forme)
                    {
                        case 1: return new int[] { 81, 81, 202 }; // Alolan Sandslash
                        default: return new int[] { 8, 8, 146 }; // Sandslash
                    }
                case 29: return new int[] { 38, 79, 55 }; // Nidoran♀
                case 30: return new int[] { 38, 79, 55 }; // Nidorina
                case 31: return new int[] { 38, 79, 125 }; // Nidoqueen
                case 32: return new int[] { 38, 79, 55 }; // Nidoran♂
                case 33: return new int[] { 38, 79, 55 }; // Nidorino
                case 34: return new int[] { 38, 79, 125 }; // Nidoking
                case 35: return new int[] { 56, 98, 132 }; // Clefairy
                case 36: return new int[] { 56, 98, 109 }; // Clefable
                case 37:
                    switch (forme)
                    {
                        case 1: return new int[] { 81, 81, 117 }; // Alolan Vulpix
                        default: return new int[] { 18, 18, 70 }; // Vulpix
                    }
                case 38:
                    switch (forme)
                    {
                        case 1: return new int[] { 81, 81, 117 }; // Alolan Ninetales
                        default: return new int[] { 18, 18, 70 }; // Ninetales
                    }
                case 39: return new int[] { 56, 172, 132 }; // Jigglypuff
                case 40: return new int[] { 56, 172, 119 }; // Wigglytuff
                case 41: return new int[] { 39, 39, 151 }; // Zubat
                case 42: return new int[] { 39, 39, 151 }; // Golbat
                case 43: return new int[] { 34, 34, 50 }; // Oddish
                case 44: return new int[] { 34, 34, 1 }; // Gloom
                case 45: return new int[] { 34, 34, 27 }; // Vileplume
                case 46: return new int[] { 27, 87, 6 }; // Paras
                case 47: return new int[] { 27, 87, 6 }; // Parasect
                case 48: return new int[] { 14, 110, 50 }; // Venonat
                case 49: return new int[] { 19, 110, 147 }; // Venomoth
                case 50:
                    switch (forme)
                    {
                        case 1: return new int[] { 8, 221, 159 }; // Alolan Diglett
                        default: return new int[] { 8, 71, 159 }; // Diglett
                    }
                case 51:
                    switch (forme)
                    {
                        case 1: return new int[] { 8, 221, 159 }; // Alolan Dugtrio
                        default: return new int[] { 8, 71, 159 }; // Dugtrio
                    }
                case 52:
                    switch (forme)
                    {
                        case 1: return new int[] { 53, 101, 155 }; // Alolan Meowth
                        default: return new int[] { 53, 101, 127 }; // Meowth
                    }
                case 53:
                    switch (forme)
                    {
                        case 1: return new int[] { 169, 101, 155 }; // Alolan Persian
                        default: return new int[] { 7, 101, 127 }; // Persian
                    }
                case 54: return new int[] { 6, 13, 33 }; // Psyduck
                case 55: return new int[] { 6, 13, 33 }; // Golduck
                case 56: return new int[] { 72, 83, 128 }; // Mankey
                case 57: return new int[] { 72, 83, 128 }; // Primeape
                case 58: return new int[] { 22, 18, 154 }; // Growlithe
                case 59: return new int[] { 22, 18, 154 }; // Arcanine
                case 60: return new int[] { 11, 6, 33 }; // Poliwag
                case 61: return new int[] { 11, 6, 33 }; // Poliwhirl
                case 62: return new int[] { 11, 6, 33 }; // Poliwrath
                case 63: return new int[] { 28, 39, 98 }; // Abra
                case 64: return new int[] { 28, 39, 98 }; // Kadabra
                case 65: return new int[] { 28, 39, 98 }; // Alakazam
                //case 65: return new int[] { 36, 36, 36 }; // Mega Alakazam
                case 66: return new int[] { 62, 99, 80 }; // Machop
                case 67: return new int[] { 62, 99, 80 }; // Machoke
                case 68: return new int[] { 62, 99, 80 }; // Machamp
                case 69: return new int[] { 34, 34, 82 }; // Bellsprout
                case 70: return new int[] { 34, 34, 82 }; // Weepinbell
                case 71: return new int[] { 34, 34, 82 }; // Victreebel
                case 72: return new int[] { 29, 64, 44 }; // Tentacool
                case 73: return new int[] { 29, 64, 44 }; // Tentacruel
                case 74:
                    switch (forme)
                    {
                        case 1: return new int[] { 42, 5, 206 }; // Alolan Geodude
                        default: return new int[] { 69, 5, 8 }; // Geodude
                    }
                case 75:
                    switch (forme)
                    {
                        case 1: return new int[] { 42, 5, 206 }; // Alolan Graveler
                        default: return new int[] { 69, 5, 8 }; // Graveler
                    }
                case 76:
                    switch (forme)
                    {
                        case 1: return new int[] { 42, 5, 206 }; // Alolan Golem
                        default: return new int[] { 69, 5, 8 }; // Golem
                    }
                case 77: return new int[] { 50, 18, 49 }; // Ponyta
                case 78: return new int[] { 50, 18, 49 }; // Rapidash
                case 79: return new int[] { 12, 20, 144 }; // Slowpoke
                case 80: return new int[] { 12, 20, 144 }; // Slowbro
                //case 80: return new int[] { 75, 75, 75 }; // Mega Slowbro
                case 81: return new int[] { 42, 5, 148 }; // Magnemite
                case 82: return new int[] { 42, 5, 148 }; // Magneton
                case 83: return new int[] { 51, 39, 128 }; // Farfetch'd
                case 84: return new int[] { 50, 48, 77 }; // Doduo
                case 85: return new int[] { 50, 48, 77 }; // Dodrio
                case 86: return new int[] { 47, 93, 115 }; // Seel
                case 87: return new int[] { 47, 93, 115 }; // Dewgong
                case 88:
                    switch (forme)
                    {
                        case 1: return new int[] { 143, 82, 223 }; // Alolan Grimer
                        default: return new int[] { 1, 60, 143 }; // Grimer
                    }
                case 89:
                    switch (forme)
                    {
                        case 1: return new int[] { 143, 82, 223 }; // Alolan Muk
                        default: return new int[] { 1, 60, 143 }; // Muk
                    }
                case 90: return new int[] { 75, 92, 142 }; // Shellder
                case 91: return new int[] { 75, 92, 142 }; // Cloyster
                case 92: return new int[] { 26, 26, 26 }; // Gastly
                case 93: return new int[] { 26, 26, 26 }; // Haunter
                case 94: return new int[] { 130, 130, 130 }; // Gengar
                //case 94: return new int[] { 23, 23, 23 }; // Mega Gengar
                case 95: return new int[] { 69, 5, 133 }; // Onix
                case 96: return new int[] { 15, 108, 39 }; // Drowzee
                case 97: return new int[] { 15, 108, 39 }; // Hypno
                case 98: return new int[] { 52, 75, 125 }; // Krabby
                case 99: return new int[] { 52, 75, 125 }; // Kingler
                case 100: return new int[] { 43, 9, 106 }; // Voltorb
                case 101: return new int[] { 43, 9, 106 }; // Electrode
                case 102: return new int[] { 34, 34, 139 }; // Exeggcute
                case 103:
                    switch (forme)
                    {
                        case 1: return new int[] { 119, 119, 139 }; // Alolan Exeggutor
                        default: return new int[] { 34, 34, 139 }; // Exeggutor
                    }
                case 104: return new int[] { 69, 31, 4 }; // Cubone
                case 105:
                    switch (forme)
                    {
                        case 1: return new int[] { 130, 31, 69 }; // Alolan Marowak
                        default: return new int[] { 69, 31, 4 }; // Marowak
                    }
                case 106: return new int[] { 7, 120, 84 }; // Hitmonlee
                case 107: return new int[] { 51, 89, 39 }; // Hitmonchan
                case 108: return new int[] { 20, 12, 13 }; // Lickitung
                case 109: return new int[] { 26, 26, 26 }; // Koffing
                case 110: return new int[] { 26, 26, 26 }; // Weezing
                case 111: return new int[] { 31, 69, 120 }; // Rhyhorn
                case 112: return new int[] { 31, 69, 120 }; // Rhydon
                case 113: return new int[] { 30, 32, 131 }; // Chansey
                case 114: return new int[] { 34, 102, 144 }; // Tangela
                case 115: return new int[] { 48, 113, 39 }; // Kangaskhan
                //case 115: return new int[] { 185, 185, 185 }; // Mega Kangaskhan
                case 116: return new int[] { 33, 97, 6 }; // Horsea
                case 117: return new int[] { 38, 97, 6 }; // Seadra
                case 118: return new int[] { 33, 41, 31 }; // Goldeen
                case 119: return new int[] { 33, 41, 31 }; // Seaking
                case 120: return new int[] { 35, 30, 148 }; // Staryu
                case 121: return new int[] { 35, 30, 148 }; // Starmie
                case 122: return new int[] { 43, 111, 101 }; // Mr. Mime
                case 123: return new int[] { 68, 101, 80 }; // Scyther
                case 124: return new int[] { 12, 108, 87 }; // Jynx
                case 125: return new int[] { 9, 9, 72 }; // Electabuzz
                case 126: return new int[] { 49, 49, 72 }; // Magmar
                case 127: return new int[] { 52, 104, 153 }; // Pinsir
                //case 127: return new int[] { 184, 184, 184 }; // Mega Pinsir
                case 128: return new int[] { 22, 83, 125 }; // Tauros
                case 129: return new int[] { 33, 33, 155 }; // Magikarp
                case 130: return new int[] { 22, 22, 153 }; // Gyarados
                //case 130: return new int[] { 104, 104, 104 }; // Mega Gyarados
                case 131: return new int[] { 11, 75, 93 }; // Lapras
                case 132: return new int[] { 7, 7, 150 }; // Ditto
                case 133: return new int[] { 50, 91, 107 }; // Eevee
                case 134: return new int[] { 11, 11, 93 }; // Vaporeon
                case 135: return new int[] { 10, 10, 95 }; // Jolteon
                case 136: return new int[] { 18, 18, 62 }; // Flareon
                case 137: return new int[] { 36, 88, 148 }; // Porygon
                case 138: return new int[] { 33, 75, 133 }; // Omanyte
                case 139: return new int[] { 33, 75, 133 }; // Omastar
                case 140: return new int[] { 33, 4, 133 }; // Kabuto
                case 141: return new int[] { 33, 4, 133 }; // Kabutops
                case 142: return new int[] { 69, 46, 127 }; // Aerodactyl
                //case 142: return new int[] { 181, 181, 181 }; // Mega Aerodactyl
                case 143: return new int[] { 17, 47, 82 }; // Snorlax
                case 144: return new int[] { 46, 46, 81 }; // Articuno
                case 145: return new int[] { 46, 46, 9 }; // Zapdos
                case 146: return new int[] { 46, 46, 49 }; // Moltres
                case 147: return new int[] { 61, 61, 63 }; // Dratini
                case 148: return new int[] { 61, 61, 63 }; // Dragonair
                case 149: return new int[] { 39, 39, 136 }; // Dragonite
                case 150: return new int[] { 46, 46, 127 }; // Mewtwo
                //case 150: return new int[] { 80, 80, 80 }; // Mega Mewtwo X
                //case 150: return new int[] { 15, 15, 15 }; // Mega Mewtwo Y
                case 151: return new int[] { 28, 28, 28 }; // Mew
                case 152: return new int[] { 65, 65, 102 }; // Chikorita
                case 153: return new int[] { 65, 65, 102 }; // Bayleef
                case 154: return new int[] { 65, 65, 102 }; // Meganium
                case 155: return new int[] { 66, 66, 18 }; // Cyndaquil
                case 156: return new int[] { 66, 66, 18 }; // Quilava
                case 157: return new int[] { 66, 66, 18 }; // Typhlosion
                case 158: return new int[] { 67, 67, 125 }; // Totodile
                case 159: return new int[] { 67, 67, 125 }; // Croconaw
                case 160: return new int[] { 67, 67, 125 }; // Feraligatr
                case 161: return new int[] { 50, 51, 119 }; // Sentret
                case 162: return new int[] { 50, 51, 119 }; // Furret
                case 163: return new int[] { 15, 51, 110 }; // Hoothoot
                case 164: return new int[] { 15, 51, 110 }; // Noctowl
                case 165: return new int[] { 68, 48, 155 }; // Ledyba
                case 166: return new int[] { 68, 48, 89 }; // Ledian
                case 167: return new int[] { 68, 15, 97 }; // Spinarak
                case 168: return new int[] { 68, 15, 97 }; // Ariados
                case 169: return new int[] { 39, 39, 151 }; // Crobat
                case 170: return new int[] { 10, 35, 11 }; // Chinchou
                case 171: return new int[] { 10, 35, 11 }; // Lanturn
                case 172: return new int[] { 9, 9, 31 }; // Pichu
                //case 172: return new int[] { 9, 9, 9 }; // Spiky-eared Pichu
                case 173: return new int[] { 56, 98, 132 }; // Cleffa
                case 174: return new int[] { 56, 172, 132 }; // Igglybuff
                case 175: return new int[] { 55, 32, 105 }; // Togepi
                case 176: return new int[] { 55, 32, 105 }; // Togetic
                case 177: return new int[] { 28, 48, 156 }; // Natu
                case 178: return new int[] { 28, 48, 156 }; // Xatu
                case 179: return new int[] { 9, 9, 57 }; // Mareep
                case 180: return new int[] { 9, 9, 57 }; // Flaaffy
                case 181: return new int[] { 9, 9, 57 }; // Ampharos
                //case 181: return new int[] { 104, 104, 104 }; // Mega Ampharos
                case 182: return new int[] { 34, 34, 131 }; // Bellossom
                case 183: return new int[] { 47, 37, 157 }; // Marill
                case 184: return new int[] { 47, 37, 157 }; // Azumarill
                case 185: return new int[] { 5, 69, 155 }; // Sudowoodo
                case 186: return new int[] { 11, 6, 2 }; // Politoed
                case 187: return new int[] { 34, 102, 151 }; // Hoppip
                case 188: return new int[] { 34, 102, 151 }; // Skiploom
                case 189: return new int[] { 34, 102, 151 }; // Jumpluff
                case 190: return new int[] { 50, 53, 92 }; // Aipom
                case 191: return new int[] { 34, 94, 48 }; // Sunkern
                case 192: return new int[] { 34, 94, 48 }; // Sunflora
                case 193: return new int[] { 3, 14, 119 }; // Yanma
                case 194: return new int[] { 6, 11, 109 }; // Wooper
                case 195: return new int[] { 6, 11, 109 }; // Quagsire
                case 196: return new int[] { 28, 28, 156 }; // Espeon
                case 197: return new int[] { 28, 28, 39 }; // Umbreon
                case 198: return new int[] { 15, 105, 158 }; // Murkrow
                case 199: return new int[] { 12, 20, 144 }; // Slowking
                case 200: return new int[] { 26, 26, 26 }; // Misdreavus
                case 201: return new int[] { 26, 26, 26 }; // Unown
                case 202: return new int[] { 23, 23, 140 }; // Wobbuffet
                case 203: return new int[] { 39, 48, 157 }; // Girafarig
                case 204: return new int[] { 5, 5, 142 }; // Pineco
                case 205: return new int[] { 5, 5, 142 }; // Forretress
                case 206: return new int[] { 32, 50, 155 }; // Dunsparce
                case 207: return new int[] { 52, 8, 17 }; // Gligar
                case 208: return new int[] { 69, 5, 125 }; // Steelix
                //case 208: return new int[] { 159, 159, 159 }; // Mega Steelix
                case 209: return new int[] { 22, 50, 155 }; // Snubbull
                case 210: return new int[] { 22, 95, 155 }; // Granbull
                case 211: return new int[] { 38, 33, 22 }; // Qwilfish
                case 212: return new int[] { 68, 101, 135 }; // Scizor
                //case 212: return new int[] { 101, 101, 101 }; // Mega Scizor
                case 213: return new int[] { 5, 82, 126 }; // Shuckle
                case 214: return new int[] { 68, 62, 153 }; // Heracross
                //case 214: return new int[] { 92, 92, 92 }; // Mega Heracross
                case 215: return new int[] { 39, 51, 124 }; // Sneasel
                case 216: return new int[] { 53, 95, 118 }; // Teddiursa
                case 217: return new int[] { 62, 95, 127 }; // Ursaring
                case 218: return new int[] { 40, 49, 133 }; // Slugma
                case 219: return new int[] { 40, 49, 133 }; // Magcargo
                case 220: return new int[] { 12, 81, 47 }; // Swinub
                case 221: return new int[] { 12, 81, 47 }; // Piloswine
                case 222: return new int[] { 55, 30, 144 }; // Corsola
                case 223: return new int[] { 55, 97, 141 }; // Remoraid
                case 224: return new int[] { 21, 97, 141 }; // Octillery
                case 225: return new int[] { 72, 55, 15 }; // Delibird
                case 226: return new int[] { 33, 11, 41 }; // Mantine
                case 227: return new int[] { 51, 5, 133 }; // Skarmory
                case 228: return new int[] { 48, 18, 127 }; // Houndour
                case 229: return new int[] { 48, 18, 127 }; // Houndoom
                //case 229: return new int[] { 94, 94, 94 }; // Mega Houndoom
                case 230: return new int[] { 33, 97, 6 }; // Kingdra
                case 231: return new int[] { 53, 53, 8 }; // Phanpy
                case 232: return new int[] { 5, 5, 8 }; // Donphan
                case 233: return new int[] { 36, 88, 148 }; // Porygon2
                case 234: return new int[] { 22, 119, 157 }; // Stantler
                case 235: return new int[] { 20, 101, 141 }; // Smeargle
                case 236: return new int[] { 62, 80, 72 }; // Tyrogue
                case 237: return new int[] { 22, 101, 80 }; // Hitmontop
                case 238: return new int[] { 12, 108, 93 }; // Smoochum
                case 239: return new int[] { 9, 9, 72 }; // Elekid
                case 240: return new int[] { 49, 49, 72 }; // Magby
                case 241: return new int[] { 47, 113, 157 }; // Miltank
                case 242: return new int[] { 30, 32, 131 }; // Blissey
                case 243: return new int[] { 46, 46, 39 }; // Raikou
                case 244: return new int[] { 46, 46, 39 }; // Entei
                case 245: return new int[] { 46, 46, 39 }; // Suicune
                case 246: return new int[] { 62, 62, 8 }; // Larvitar
                case 247: return new int[] { 61, 61, 61 }; // Pupitar
                case 248: return new int[] { 45, 45, 127 }; // Tyranitar
                //case 248: return new int[] { 45, 45, 45 }; // Mega Tyranitar
                case 249: return new int[] { 46, 46, 136 }; // Lugia
                case 250: return new int[] { 46, 46, 144 }; // Ho-Oh
                case 251: return new int[] { 30, 30, 30 }; // Celebi
                case 252: return new int[] { 65, 65, 84 }; // Treecko
                case 253: return new int[] { 65, 65, 84 }; // Grovyle
                case 254: return new int[] { 65, 65, 84 }; // Sceptile
                //case 254: return new int[] { 31, 31, 31 }; // Mega Sceptile
                case 255: return new int[] { 66, 66, 3 }; // Torchic
                case 256: return new int[] { 66, 66, 3 }; // Combusken
                case 257: return new int[] { 66, 66, 3 }; // Blaziken
                //case 257: return new int[] { 3, 3, 3 }; // Mega Blaziken
                case 258: return new int[] { 67, 67, 6 }; // Mudkip
                case 259: return new int[] { 67, 67, 6 }; // Marshtomp
                case 260: return new int[] { 67, 67, 6 }; // Swampert
                //case 260: return new int[] { 33, 33, 33 }; // Mega Swampert
                case 261: return new int[] { 50, 95, 155 }; // Poochyena
                case 262: return new int[] { 22, 95, 153 }; // Mightyena
                case 263: return new int[] { 53, 82, 95 }; // Zigzagoon
                case 264: return new int[] { 53, 82, 95 }; // Linoone
                case 265: return new int[] { 19, 19, 50 }; // Wurmple
                case 266: return new int[] { 61, 61, 61 }; // Silcoon
                case 267: return new int[] { 68, 68, 79 }; // Beautifly
                case 268: return new int[] { 61, 61, 61 }; // Cascoon
                case 269: return new int[] { 19, 19, 14 }; // Dustox
                case 270: return new int[] { 33, 44, 20 }; // Lotad
                case 271: return new int[] { 33, 44, 20 }; // Lombre
                case 272: return new int[] { 33, 44, 20 }; // Ludicolo
                case 273: return new int[] { 34, 48, 124 }; // Seedot
                case 274: return new int[] { 34, 48, 124 }; // Nuzleaf
                case 275: return new int[] { 34, 48, 124 }; // Shiftry
                case 276: return new int[] { 62, 62, 113 }; // Taillow
                case 277: return new int[] { 62, 62, 113 }; // Swellow
                case 278: return new int[] { 51, 93, 44 }; // Wingull
                case 279: return new int[] { 51, 2, 44 }; // Pelipper
                case 280: return new int[] { 28, 36, 140 }; // Ralts
                case 281: return new int[] { 28, 36, 140 }; // Kirlia
                case 282: return new int[] { 28, 36, 140 }; // Gardevoir
                //case 282: return new int[] { 182, 182, 182 }; // Mega Gardevoir
                case 283: return new int[] { 33, 33, 44 }; // Surskit
                case 284: return new int[] { 22, 22, 127 }; // Masquerain
                case 285: return new int[] { 27, 90, 95 }; // Shroomish
                case 286: return new int[] { 27, 90, 101 }; // Breloom
                case 287: return new int[] { 54, 54, 54 }; // Slakoth
                case 288: return new int[] { 72, 72, 72 }; // Vigoroth
                case 289: return new int[] { 54, 54, 54 }; // Slaking
                case 290: return new int[] { 14, 14, 50 }; // Nincada
                case 291: return new int[] { 3, 3, 151 }; // Ninjask
                case 292: return new int[] { 25, 25, 25 }; // Shedinja
                case 293: return new int[] { 43, 43, 155 }; // Whismur
                case 294: return new int[] { 43, 43, 113 }; // Loudred
                case 295: return new int[] { 43, 43, 113 }; // Exploud
                case 296: return new int[] { 47, 62, 125 }; // Makuhita
                case 297: return new int[] { 47, 62, 125 }; // Hariyama
                case 298: return new int[] { 47, 37, 157 }; // Azurill
                case 299: return new int[] { 5, 42, 159 }; // Nosepass
                case 300: return new int[] { 56, 96, 147 }; // Skitty
                case 301: return new int[] { 56, 96, 147 }; // Delcatty
                case 302: return new int[] { 51, 100, 158 }; // Sableye
                //case 302: return new int[] { 156, 156, 156 }; // Mega Sableye
                case 303: return new int[] { 52, 22, 125 }; // Mawile
                //case 303: return new int[] { 37, 37, 37 }; // Mega Mawile
                case 304: return new int[] { 5, 69, 134 }; // Aron
                case 305: return new int[] { 5, 69, 134 }; // Lairon
                case 306: return new int[] { 5, 69, 134 }; // Aggron
                //case 306: return new int[] { 111, 111, 111 }; // Mega Aggron
                case 307: return new int[] { 74, 74, 140 }; // Meditite
                case 308: return new int[] { 74, 74, 140 }; // Medicham
                //case 308: return new int[] { 74, 74, 74 }; // Mega Medicham
                case 309: return new int[] { 9, 31, 58 }; // Electrike
                case 310: return new int[] { 9, 31, 58 }; // Manectric
                //case 310: return new int[] { 22, 22, 22 }; // Mega Manectric
                case 311: return new int[] { 57, 57, 31 }; // Plusle
                case 312: return new int[] { 58, 58, 10 }; // Minun
                case 313: return new int[] { 35, 68, 158 }; // Volbeat
                case 314: return new int[] { 12, 110, 158 }; // Illumise
                case 315: return new int[] { 30, 38, 102 }; // Roselia
                case 316: return new int[] { 64, 60, 82 }; // Gulpin
                case 317: return new int[] { 64, 60, 82 }; // Swalot
                case 318: return new int[] { 24, 24, 3 }; // Carvanha
                case 319: return new int[] { 24, 24, 3 }; // Sharpedo
                //case 319: return new int[] { 173, 173, 173 }; // Mega Sharpedo
                case 320: return new int[] { 41, 12, 46 }; // Wailmer
                case 321: return new int[] { 41, 12, 46 }; // Wailord
                case 322: return new int[] { 12, 86, 20 }; // Numel
                case 323: return new int[] { 40, 116, 83 }; // Camerupt
                //case 323: return new int[] { 125, 125, 125 }; // Mega Camerupt
                case 324: return new int[] { 73, 70, 75 }; // Torkoal
                case 325: return new int[] { 47, 20, 82 }; // Spoink
                case 326: return new int[] { 47, 20, 82 }; // Grumpig
                case 327: return new int[] { 20, 77, 126 }; // Spinda
                case 328: return new int[] { 52, 71, 125 }; // Trapinch
                case 329: return new int[] { 26, 26, 26 }; // Vibrava
                case 330: return new int[] { 26, 26, 26 }; // Flygon
                case 331: return new int[] { 8, 8, 11 }; // Cacnea
                case 332: return new int[] { 8, 8, 11 }; // Cacturne
                case 333: return new int[] { 30, 30, 13 }; // Swablu
                case 334: return new int[] { 30, 30, 13 }; // Altaria
                //case 334: return new int[] { 182, 182, 182 }; // Mega Altaria
                case 335: return new int[] { 17, 17, 137 }; // Zangoose
                case 336: return new int[] { 61, 61, 151 }; // Seviper
                case 337: return new int[] { 26, 26, 26 }; // Lunatone
                case 338: return new int[] { 26, 26, 26 }; // Solrock
                case 339: return new int[] { 12, 107, 93 }; // Barboach
                case 340: return new int[] { 12, 107, 93 }; // Whiscash
                case 341: return new int[] { 52, 75, 91 }; // Corphish
                case 342: return new int[] { 52, 75, 91 }; // Crawdaunt
                case 343: return new int[] { 26, 26, 26 }; // Baltoy
                case 344: return new int[] { 26, 26, 26 }; // Claydol
                case 345: return new int[] { 21, 21, 114 }; // Lileep
                case 346: return new int[] { 21, 21, 114 }; // Cradily
                case 347: return new int[] { 4, 4, 33 }; // Anorith
                case 348: return new int[] { 4, 4, 33 }; // Armaldo
                case 349: return new int[] { 33, 12, 91 }; // Feebas
                case 350: return new int[] { 63, 172, 56 }; // Milotic
                case 351: return new int[] { 59, 59, 59 }; // Castform - All formes
                case 352: return new int[] { 16, 16, 168 }; // Kecleon
                case 353: return new int[] { 15, 119, 130 }; // Shuppet
                case 354: return new int[] { 15, 119, 130 }; // Banette
                //case 354: return new int[] { 158, 158, 158 }; // Mega Banette
                case 355: return new int[] { 26, 26, 119 }; // Duskull
                case 356: return new int[] { 46, 46, 119 }; // Dusclops
                case 357: return new int[] { 34, 94, 139 }; // Tropius
                case 358: return new int[] { 26, 26, 26 }; // Chimecho
                case 359: return new int[] { 46, 105, 154 }; // Absol
                //case 359: return new int[] { 156, 156, 156 }; // Mega Absol
                case 360: return new int[] { 23, 23, 140 }; // Wynaut
                case 361: return new int[] { 39, 115, 141 }; // Snorunt
                case 362: return new int[] { 39, 115, 141 }; // Glalie
                //case 362: return new int[] { 174, 174, 174 }; // Mega Glalie
                case 363: return new int[] { 47, 115, 12 }; // Spheal
                case 364: return new int[] { 47, 115, 12 }; // Sealeo
                case 365: return new int[] { 47, 115, 12 }; // Walrein
                case 366: return new int[] { 75, 75, 155 }; // Clamperl
                case 367: return new int[] { 33, 33, 41 }; // Huntail
                case 368: return new int[] { 33, 33, 93 }; // Gorebyss
                case 369: return new int[] { 33, 69, 5 }; // Relicanth
                case 370: return new int[] { 33, 33, 93 }; // Luvdisc
                case 371: return new int[] { 69, 69, 125 }; // Bagon
                case 372: return new int[] { 69, 69, 142 }; // Shelgon
                case 373: return new int[] { 22, 22, 153 }; // Salamence
                //case 373: return new int[] { 184, 184, 184 }; // Mega Salamence
                case 374: return new int[] { 29, 29, 135 }; // Beldum
                case 375: return new int[] { 29, 29, 135 }; // Metang
                case 376: return new int[] { 29, 29, 135 }; // Metagross
                //case 376: return new int[] { 181, 181, 181 }; // Mega Metagross
                case 377: return new int[] { 29, 29, 5 }; // Regirock
                case 378: return new int[] { 29, 29, 115 }; // Regice
                case 379: return new int[] { 29, 29, 135 }; // Registeel
                case 380: return new int[] { 26, 26, 26 }; // Latias
                //case 380: return new int[] { 26, 26, 26 }; // Mega Latias
                case 381: return new int[] { 26, 26, 26 }; // Latios
                //case 381: return new int[] { 26, 26, 26 }; // Mega Latios
                case 382: return new int[] { 2, 2, 2 }; // Kyogre
                //case 382: return new int[] { 189, 189, 189 }; // Primal Kyogre
                case 383: return new int[] { 70, 70, 70 }; // Groudon
                //case 383: return new int[] { 190, 190, 190 }; // Primal Groudon
                case 384: return new int[] { 76, 76, 76 }; // Rayquaza
                //case 384: return new int[] { 191, 191, 191 }; // Mega Rayquaza
                case 385: return new int[] { 32, 32, 32 }; // Jirachi
                case 386: return new int[] { 46, 46, 46 }; // Deoxys - All formes
                case 387: return new int[] { 65, 65, 75 }; // Turtwig
                case 388: return new int[] { 65, 65, 75 }; // Grotle
                case 389: return new int[] { 65, 65, 75 }; // Torterra
                case 390: return new int[] { 66, 66, 89 }; // Chimchar
                case 391: return new int[] { 66, 66, 89 }; // Monferno
                case 392: return new int[] { 66, 66, 89 }; // Infernape
                case 393: return new int[] { 67, 67, 128 }; // Piplup
                case 394: return new int[] { 67, 67, 128 }; // Prinplup
                case 395: return new int[] { 67, 67, 128 }; // Empoleon
                case 396: return new int[] { 51, 51, 120 }; // Starly
                case 397: return new int[] { 22, 22, 120 }; // Staravia
                case 398: return new int[] { 22, 22, 120 }; // Staraptor
                case 399: return new int[] { 86, 109, 141 }; // Bidoof
                case 400: return new int[] { 86, 109, 141 }; // Bibarel
                case 401: return new int[] { 61, 61, 50 }; // Kricketot
                case 402: return new int[] { 68, 68, 101 }; // Kricketune
                case 403: return new int[] { 79, 22, 62 }; // Shinx
                case 404: return new int[] { 79, 22, 62 }; // Luxio
                case 405: return new int[] { 79, 22, 62 }; // Luxray
                case 406: return new int[] { 30, 38, 102 }; // Budew
                case 407: return new int[] { 30, 38, 101 }; // Roserade
                case 408: return new int[] { 104, 104, 125 }; // Cranidos
                case 409: return new int[] { 104, 104, 125 }; // Rampardos
                case 410: return new int[] { 5, 5, 43 }; // Shieldon
                case 411: return new int[] { 5, 5, 43 }; // Bastiodon
                case 412: return new int[] { 61, 61, 142 }; // Burmy - All formes
                case 413: return new int[] { 107, 107, 142 }; // Wormadam - All formes
                case 414: return new int[] { 68, 68, 110 }; // Mothim
                case 415: return new int[] { 118, 118, 55 }; // Combee
                case 416: return new int[] { 46, 46, 127 }; // Vespiquen
                case 417: return new int[] { 50, 53, 10 }; // Pachirisu
                case 418: return new int[] { 33, 33, 41 }; // Buizel
                case 419: return new int[] { 33, 33, 41 }; // Floatzel
                case 420: return new int[] { 34, 34, 34 }; // Cherubi
                case 421: return new int[] { 122, 122, 122 }; // Cherrim
                case 422: return new int[] { 60, 114, 159 }; // Shellos
                case 423: return new int[] { 60, 114, 159 }; // Gastrodon
                case 424: return new int[] { 101, 53, 92 }; // Ambipom
                case 425: return new int[] { 106, 84, 138 }; // Drifloon
                case 426: return new int[] { 106, 84, 138 }; // Drifblim
                case 427: return new int[] { 50, 103, 7 }; // Buneary
                case 428: return new int[] { 56, 103, 7 }; // Lopunny
                //case 428: return new int[] { 113, 113, 113 }; // Mega Lopunny
                case 429: return new int[] { 26, 26, 26 }; // Mismagius
                case 430: return new int[] { 15, 105, 153 }; // Honchkrow
                case 431: return new int[] { 7, 20, 51 }; // Glameow
                case 432: return new int[] { 47, 20, 128 }; // Purugly
                case 433: return new int[] { 26, 26, 26 }; // Chingling
                case 434: return new int[] { 1, 106, 51 }; // Stunky
                case 435: return new int[] { 1, 106, 51 }; // Skuntank
                case 436: return new int[] { 26, 85, 134 }; // Bronzor
                case 437: return new int[] { 26, 85, 134 }; // Bronzong
                case 438: return new int[] { 5, 69, 155 }; // Bonsly
                case 439: return new int[] { 43, 111, 101 }; // Mime Jr.
                case 440: return new int[] { 30, 32, 132 }; // Happiny
                case 441: return new int[] { 51, 77, 145 }; // Chatot
                case 442: return new int[] { 46, 46, 151 }; // Spiritomb
                case 443: return new int[] { 8, 8, 24 }; // Gible
                case 444: return new int[] { 8, 8, 24 }; // Gabite
                case 445: return new int[] { 8, 8, 24 }; // Garchomp
                //case 445: return new int[] { 159, 159, 159 }; // Mega Garchomp
                case 446: return new int[] { 53, 47, 82 }; // Munchlax
                case 447: return new int[] { 80, 39, 158 }; // Riolu
                case 448: return new int[] { 80, 39, 154 }; // Lucario
                //case 448: return new int[] { 91, 91, 91 }; // Mega Lucario
                case 449: return new int[] { 45, 45, 159 }; // Hippopotas
                case 450: return new int[] { 45, 45, 159 }; // Hippowdon
                case 451: return new int[] { 4, 97, 51 }; // Skorupi
                case 452: return new int[] { 4, 97, 51 }; // Drapion
                case 453: return new int[] { 107, 87, 143 }; // Croagunk
                case 454: return new int[] { 107, 87, 143 }; // Toxicroak
                case 455: return new int[] { 26, 26, 26 }; // Carnivine
                case 456: return new int[] { 33, 114, 41 }; // Finneon
                case 457: return new int[] { 33, 114, 41 }; // Lumineon
                case 458: return new int[] { 33, 11, 41 }; // Mantyke
                case 459: return new int[] { 117, 117, 43 }; // Snover
                case 460: return new int[] { 117, 117, 43 }; // Abomasnow
                //case 460: return new int[] { 117, 117, 117 }; // Mega Abomasnow
                case 461: return new int[] { 46, 46, 124 }; // Weavile
                case 462: return new int[] { 42, 5, 148 }; // Magnezone
                case 463: return new int[] { 20, 12, 13 }; // Lickilicky
                case 464: return new int[] { 31, 116, 120 }; // Rhyperior
                case 465: return new int[] { 34, 102, 144 }; // Tangrowth
                case 466: return new int[] { 78, 78, 72 }; // Electivire
                case 467: return new int[] { 49, 49, 72 }; // Magmortar
                case 468: return new int[] { 55, 32, 105 }; // Togekiss
                case 469: return new int[] { 3, 110, 119 }; // Yanmega
                case 470: return new int[] { 102, 102, 34 }; // Leafeon
                case 471: return new int[] { 81, 81, 115 }; // Glaceon
                case 472: return new int[] { 52, 8, 90 }; // Gliscor
                case 473: return new int[] { 12, 81, 47 }; // Mamoswine
                case 474: return new int[] { 91, 88, 148 }; // Porygon-Z
                case 475: return new int[] { 80, 80, 154 }; // Gallade
                //case 475: return new int[] { 39, 39, 39 }; // Mega Gallade
                case 476: return new int[] { 5, 42, 159 }; // Probopass
                case 477: return new int[] { 46, 46, 119 }; // Dusknoir
                case 478: return new int[] { 81, 81, 130 }; // Froslass
                case 479: return new int[] { 26, 26, 26 }; // Rotom - All formes
                case 480: return new int[] { 26, 26, 26 }; // Uxie
                case 481: return new int[] { 26, 26, 26 }; // Mesprit
                case 482: return new int[] { 26, 26, 26 }; // Azelf
                case 483: return new int[] { 46, 46, 140 }; // Dialga
                case 484: return new int[] { 46, 46, 140 }; // Palkia
                case 485: return new int[] { 18, 18, 49 }; // Heatran
                case 486: return new int[] { 112, 112, 112 }; // Regigigas
                case 487:
                    switch (forme)
                    {
                        case 1: return new int[] { 26, 26, 26 }; // Giratina - Origin
                        default: return new int[] { 46, 46, 140 }; // Giratina - Altered
                    }
                case 488: return new int[] { 26, 26, 26 }; // Cresselia
                case 489: return new int[] { 93, 93, 93 }; // Phione
                case 490: return new int[] { 93, 93, 93 }; // Manaphy
                case 491: return new int[] { 123, 123, 123 }; // Darkrai
                case 492:
                    switch (forme)
                    {
                        case 1: return new int[] { 32, 32, 32 }; // Shaymin - Sky
                        default: return new int[] { 30, 30, 30 }; // Shaymin - Land
                    }
                case 493: return new int[] { 121, 121, 121 }; // Arceus
                case 494: return new int[] { 162, 162, 162 }; // Victini
                case 495: return new int[] { 65, 65, 126 }; // Snivy
                case 496: return new int[] { 65, 65, 126 }; // Servine
                case 497: return new int[] { 65, 65, 126 }; // Serperior
                case 498: return new int[] { 66, 66, 47 }; // Tepig
                case 499: return new int[] { 66, 66, 47 }; // Pignite
                case 500: return new int[] { 66, 66, 120 }; // Emboar
                case 501: return new int[] { 67, 67, 75 }; // Oshawott
                case 502: return new int[] { 67, 67, 75 }; // Dewott
                case 503: return new int[] { 67, 67, 75 }; // Samurott
                case 504: return new int[] { 50, 51, 148 }; // Patrat
                case 505: return new int[] { 35, 51, 148 }; // Watchog
                case 506: return new int[] { 72, 53, 50 }; // Lillipup
                case 507: return new int[] { 22, 146, 113 }; // Herdier
                case 508: return new int[] { 22, 146, 113 }; // Stoutland
                case 509: return new int[] { 7, 84, 158 }; // Purrloin
                case 510: return new int[] { 7, 84, 158 }; // Liepard
                case 511: return new int[] { 82, 82, 65 }; // Pansage
                case 512: return new int[] { 82, 82, 65 }; // Simisage
                case 513: return new int[] { 82, 82, 66 }; // Pansear
                case 514: return new int[] { 82, 82, 66 }; // Simisear
                case 515: return new int[] { 82, 82, 67 }; // Panpour
                case 516: return new int[] { 82, 82, 67 }; // Simipour
                case 517: return new int[] { 108, 28, 140 }; // Munna
                case 518: return new int[] { 108, 28, 140 }; // Musharna
                case 519: return new int[] { 145, 105, 79 }; // Pidove
                case 520: return new int[] { 145, 105, 79 }; // Tranquill
                case 521: return new int[] { 145, 105, 79 }; // Unfezant
                case 522: return new int[] { 31, 78, 157 }; // Blitzle
                case 523: return new int[] { 31, 78, 157 }; // Zebstrika
                case 524: return new int[] { 5, 133, 159 }; // Roggenrola
                case 525: return new int[] { 5, 133, 159 }; // Boldore
                case 526: return new int[] { 5, 45, 159 }; // Gigalith
                case 527: return new int[] { 109, 103, 86 }; // Woobat
                case 528: return new int[] { 109, 103, 86 }; // Swoobat
                case 529: return new int[] { 146, 159, 104 }; // Drilbur
                case 530: return new int[] { 146, 159, 104 }; // Excadrill
                case 531: return new int[] { 131, 144, 103 }; // Audino
                //case 531: return new int[] { 131, 131, 131 }; // Mega Audino
                case 532: return new int[] { 62, 125, 89 }; // Timburr
                case 533: return new int[] { 62, 125, 89 }; // Gurdurr
                case 534: return new int[] { 62, 125, 89 }; // Conkeldurr
                case 535: return new int[] { 33, 93, 11 }; // Tympole
                case 536: return new int[] { 33, 93, 11 }; // Palpitoad
                case 537: return new int[] { 33, 143, 11 }; // Seismitoad
                case 538: return new int[] { 62, 39, 104 }; // Throh
                case 539: return new int[] { 5, 39, 104 }; // Sawk
                case 540: return new int[] { 68, 34, 142 }; // Sewaddle
                case 541: return new int[] { 102, 34, 142 }; // Swadloon
                case 542: return new int[] { 68, 34, 142 }; // Leavanny
                case 543: return new int[] { 38, 68, 3 }; // Venipede*
                case 544: return new int[] { 38, 68, 3 }; // Whirlipede*
                case 545: return new int[] { 38, 68, 3 }; // Scolipede*
                case 546: return new int[] { 158, 151, 34 }; // Cottonee
                case 547: return new int[] { 158, 151, 34 }; // Whimsicott
                case 548: return new int[] { 34, 20, 102 }; // Petilil
                case 549: return new int[] { 34, 20, 102 }; // Lilligant
                case 550:
                    switch (forme)
                    {
                        case 1: return new int[] { 69, 91, 104 }; // Basculin - Blue
                        default: return new int[] { 120, 91, 104 }; // Basculin - Red
                    }
                case 551: return new int[] { 22, 153, 83 }; // Sandile
                case 552: return new int[] { 22, 153, 83 }; // Krokorok
                case 553: return new int[] { 22, 153, 83 }; // Krookodile
                case 554: return new int[] { 55, 55, 39 }; // Darumaka
                case 555: return new int[] { 125, 125, 161 }; // Darmanitan
                case 556: return new int[] { 11, 34, 114 }; // Maractus
                case 557: return new int[] { 5, 75, 133 }; // Dwebble
                case 558: return new int[] { 5, 75, 133 }; // Crustle
                case 559: return new int[] { 61, 153, 22 }; // Scraggy
                case 560: return new int[] { 61, 153, 22 }; // Scrafty
                case 561: return new int[] { 147, 98, 110 }; // Sigilyph
                case 562: return new int[] { 152, 152, 152 }; // Yamask
                case 563: return new int[] { 152, 152, 152 }; // Cofagrigus
                case 564: return new int[] { 116, 5, 33 }; // Tirtouga
                case 565: return new int[] { 116, 5, 33 }; // Carracosta
                case 566: return new int[] { 129, 129, 129 }; // Archen
                case 567: return new int[] { 129, 129, 129 }; // Archeops
                case 568: return new int[] { 1, 60, 106 }; // Trubbish
                case 569: return new int[] { 1, 133, 106 }; // Garbodor
                case 570: return new int[] { 149, 149, 149 }; // Zorua
                case 571: return new int[] { 149, 149, 149 }; // Zoroark
                case 572: return new int[] { 56, 101, 92 }; // Minccino
                case 573: return new int[] { 56, 101, 92 }; // Cinccino
                case 574: return new int[] { 119, 172, 23 }; // Gothita
                case 575: return new int[] { 119, 172, 23 }; // Gothorita
                case 576: return new int[] { 119, 172, 23 }; // Gothitelle
                case 577: return new int[] { 142, 98, 144 }; // Solosis
                case 578: return new int[] { 142, 98, 144 }; // Duosion
                case 579: return new int[] { 142, 98, 144 }; // Reuniclus
                case 580: return new int[] { 51, 145, 93 }; // Ducklett
                case 581: return new int[] { 51, 145, 93 }; // Swanna
                case 582: return new int[] { 115, 81, 133 }; // Vanillite
                case 583: return new int[] { 115, 81, 133 }; // Vanillish
                case 584: return new int[] { 115, 117, 133 }; // Vanilluxe
                case 585: return new int[] { 34, 157, 32 }; // Deerling - All formes
                case 586: return new int[] { 34, 157, 32 }; // Sawsbuck - All formes
                case 587: return new int[] { 9, 9, 78 }; // Emolga
                case 588: return new int[] { 68, 61, 99 }; // Karrablast
                case 589: return new int[] { 68, 75, 142 }; // Escavalier
                case 590: return new int[] { 27, 27, 144 }; // Foongus
                case 591: return new int[] { 27, 27, 144 }; // Amoonguss
                case 592: return new int[] { 11, 130, 6 }; // Frillish
                case 593: return new int[] { 11, 130, 6 }; // Jellicent
                case 594: return new int[] { 131, 93, 144 }; // Alomomola
                case 595: return new int[] { 14, 127, 68 }; // Joltik
                case 596: return new int[] { 14, 127, 68 }; // Galvantula
                case 597: return new int[] { 160, 160, 160 }; // Ferroseed
                case 598: return new int[] { 160, 160, 107 }; // Ferrothorn
                case 599: return new int[] { 57, 58, 29 }; // Klink
                case 600: return new int[] { 57, 58, 29 }; // Klang
                case 601: return new int[] { 57, 58, 29 }; // Klinklang
                case 602: return new int[] { 26, 26, 26 }; // Tynamo
                case 603: return new int[] { 26, 26, 26 }; // Eelektrik
                case 604: return new int[] { 26, 26, 26 }; // Eelektross
                case 605: return new int[] { 140, 28, 148 }; // Elgyem
                case 606: return new int[] { 140, 28, 148 }; // Beheeyem
                case 607: return new int[] { 18, 49, 151 }; // Litwick
                case 608: return new int[] { 18, 49, 151 }; // Lampent
                case 609: return new int[] { 18, 49, 151 }; // Chandelure
                case 610: return new int[] { 79, 104, 127 }; // Axew
                case 611: return new int[] { 79, 104, 127 }; // Fraxure
                case 612: return new int[] { 79, 104, 127 }; // Haxorus
                case 613: return new int[] { 81, 202, 155 }; // Cubchoo
                case 614: return new int[] { 81, 202, 33 }; // Cubchoo
                case 615: return new int[] { 26, 26, 26 }; // Cryogonal
                case 616: return new int[] { 93, 75, 142 }; // Shelmet
                case 617: return new int[] { 93, 60, 84 }; // Accelgor
                case 618: return new int[] { 9, 7, 8 }; // Stunfisk
                case 619: return new int[] { 39, 144, 120 }; // Mienfoo
                case 620: return new int[] { 39, 144, 120 }; // Mienshao
                case 621: return new int[] { 24, 125, 104 }; // Druddigon
                case 622: return new int[] { 89, 103, 99 }; // Golett
                case 623: return new int[] { 89, 103, 99 }; // Golurk
                case 624: return new int[] { 128, 39, 46 }; // Pawniard
                case 625: return new int[] { 128, 39, 46 }; // Bisharp
                case 626: return new int[] { 120, 157, 43 }; // Bouffalant
                case 627: return new int[] { 51, 125, 55 }; // Rufflet
                case 628: return new int[] { 51, 125, 128 }; // Braviary
                case 629: return new int[] { 145, 142, 133 }; // Vullaby
                case 630: return new int[] { 145, 142, 133 }; // Mandibuzz
                case 631: return new int[] { 82, 18, 73 }; // Heatmor
                case 632: return new int[] { 68, 55, 54 }; // Durant
                case 633: return new int[] { 55, 55, 55 }; // Deino
                case 634: return new int[] { 55, 55, 55 }; // Zweilous
                case 635: return new int[] { 26, 26, 26 }; // Hydreigon
                case 636: return new int[] { 49, 49, 68 }; // Larvesta
                case 637: return new int[] { 49, 49, 68 }; // Volcarona
                case 638: return new int[] { 154, 154, 154 }; // Cobalion
                case 639: return new int[] { 154, 154, 154 }; // Terrakion
                case 640: return new int[] { 154, 154, 154 }; // Virizion
                case 641:
                    switch (forme)
                    {
                        case 1: return new int[] { 144, 144, 144 }; // Tornadus - Therian
                        default: return new int[] { 158, 158, 128 }; // Tornadus - Incarnate
                    }
                case 642:
                    switch (forme)
                    {
                        case 1: return new int[] { 10, 10, 10 }; // Thundurus - Therian
                        default: return new int[] { 158, 158, 128 }; // Thundurus - Incarnate
                    }
                case 643: return new int[] { 163, 163, 163 }; // Reshiram
                case 644: return new int[] { 164, 164, 164 }; // Zekrom
                case 645:
                    switch (forme)
                    {
                        case 1: return new int[] { 22, 22, 22 }; // Landorus - Therian
                        default: return new int[] { 159, 159, 125 }; // Landorus - Incarnate
                    }
                case 646:
                    switch (forme)
                    {
                        case 1: return new int[] { 163, 163, 163 }; // White Kyurem
                        case 2: return new int[] { 164, 164, 164 }; // Black Kyurem
                        default: return new int[] { 46, 46, 46 }; // Kyurem
                    }
                case 647: return new int[] { 154, 154, 154 }; // Keldeo
                case 648: return new int[] { 32, 32, 32 }; // Meloetta
                case 649: return new int[] { 88, 88, 88 }; // Genesect
                case 650: return new int[] { 65, 65, 171 }; // Chespin
                case 651: return new int[] { 65, 65, 171 }; // Quilladin
                case 652: return new int[] { 65, 65, 171 }; // Chesnaught
                case 653: return new int[] { 66, 66, 170 }; // Fennekin
                case 654: return new int[] { 66, 66, 170 }; // Braixen
                case 655: return new int[] { 66, 66, 170 }; // Delphox
                case 656: return new int[] { 67, 67, 168 }; // Froakie
                case 657: return new int[] { 67, 67, 168 }; // Frogadier
                case 658:
                    switch (forme)
                    {
                        case 1: return new int[] { 210, 210, 210 }; // Ash-Greninja
                        default: return new int[] { 67, 67, 168 }; // Greninja
                    }
                case 659: return new int[] { 53, 167, 37 }; // Bunnelby
                case 660: return new int[] { 53, 167, 37 }; // Diggersby
                case 661: return new int[] { 145, 145, 177 }; // Fletchling
                case 662: return new int[] { 49, 49, 177 }; // Fletchinder
                case 663: return new int[] { 49, 49, 177 }; // Talonflame
                case 664: return new int[] { 19, 14, 132 }; // Scatterbug
                case 665: return new int[] { 61, 61, 132 }; // Spewpa
                case 666: return new int[] { 19, 14, 132 }; // Vivillon
                case 667: return new int[] { 79, 127, 153 }; // Litleo
                case 668: return new int[] { 79, 127, 153 }; // Pyroar
                case 669: return new int[] { 166, 166, 180 }; // Flabébé
                case 670: return new int[] { 166, 166, 180 }; // Floette
                case 671: return new int[] { 166, 166, 180 }; // Florges
                case 672: return new int[] { 157, 157, 179 }; // Skiddo
                case 673: return new int[] { 157, 157, 179 }; // Gogoat
                case 674: return new int[] { 89, 104, 113 }; // Pancham
                case 675: return new int[] { 89, 104, 113 }; // Pangoro
                case 676: return new int[] { 169, 169, 169 }; // Furfrou
                case 677: return new int[] { 51, 151, 20 }; // Espurr
                case 678:
                    switch (forme)
                    {
                        case 1: return new int[] { 51, 151, 172 }; // Meowstic♀
                        default: return new int[] { 51, 151, 158 }; // Meowstic♂
                    }
                case 679: return new int[] { 99, 99, 99 }; // Honedge
                case 680: return new int[] { 99, 99, 99 }; // Doublade
                case 681: return new int[] { 176, 176, 176 }; // Aegislash
                case 682: return new int[] { 131, 131, 165 }; // Spritzee
                case 683: return new int[] { 131, 131, 165 }; // Aromatisse
                case 684: return new int[] { 175, 175, 84 }; // Swirlix
                case 685: return new int[] { 175, 175, 84 }; // Slurpuff
                case 686: return new int[] { 126, 21, 151 }; // Inkay
                case 687: return new int[] { 126, 21, 151 }; // Malamar
                case 688: return new int[] { 97, 181, 124 }; // Binacle
                case 689: return new int[] { 97, 181, 124 }; // Barbaracle
                case 690: return new int[] { 38, 143, 91 }; // Skrelp
                case 691: return new int[] { 38, 143, 91 }; // Dragalge
                case 692: return new int[] { 178, 178, 178 }; // Clauncher
                case 693: return new int[] { 178, 178, 178 }; // Clawitzer
                case 694: return new int[] { 87, 8, 94 }; // Helioptile
                case 695: return new int[] { 87, 8, 94 }; // Heliolisk
                case 696: return new int[] { 173, 173, 5 }; // Tyrunt
                case 697: return new int[] { 173, 173, 69 }; // Tyrantrum
                case 698: return new int[] { 174, 174, 117 }; // Amaura
                case 699: return new int[] { 174, 174, 117 }; // Aurorus
                case 700: return new int[] { 56, 56, 182 }; // Sylveon
                case 701: return new int[] { 7, 84, 104 }; // Hawlucha
                case 702: return new int[] { 167, 53, 57 }; // Dedenne
                case 703: return new int[] { 29, 29, 5 }; // Carbink
                case 704: return new int[] { 157, 93, 183 }; // Goomy
                case 705: return new int[] { 157, 93, 183 }; // Sliggoo
                case 706: return new int[] { 157, 93, 183 }; // Goodra
                case 707: return new int[] { 158, 158, 170 }; // Klefki
                case 708: return new int[] { 30, 119, 139 }; // Phantump
                case 709: return new int[] { 30, 119, 139 }; // Trevenant
                case 710: return new int[] { 53, 119, 15 }; // Pumpkaboo
                case 711: return new int[] { 53, 119, 15 }; // Gourgeist
                case 712: return new int[] { 20, 115, 5 }; // Bergmite
                case 713: return new int[] { 20, 115, 5 }; // Avalugg
                case 714: return new int[] { 119, 151, 140 }; // Noibat
                case 715: return new int[] { 119, 151, 140 }; // Noivern
                case 716: return new int[] { 187, 187, 187 }; // Xerneas
                case 717: return new int[] { 186, 186, 186 }; // Yveltal
                case 718:
                    switch (forme)
                    {
                        case 1: return new int[] { 188, 188, 188 }; // Zygarde 10% - Aura Break
                        case 2: return new int[] { 211, 211, 211 }; // Zygarde 10% - Power Construct
                        case 3: return new int[] { 211, 211, 211 }; // Zygarde 50% - Power Construct
                        case 4: return new int[] { 211, 211, 211 }; // Zygarde 100% - Power Construct
                        default: return new int[] { 188, 188, 188 }; // Zygarde 50% - Aura Break
                    }
                case 719: return new int[] { 29, 29, 29 }; // Diancie
                //case 719: return new int[] { 156, 156, 156 }; // Mega Diancie
                case 720: return new int[] { 170, 170, 170 }; // Hoopa Confined
                case 721: return new int[] { 11, 11, 11 }; // Volcanion
                case 722: return new int[] { 65, 65, 203 }; // Rowlet
                case 723: return new int[] { 65, 65, 203 }; // Dartrix
                case 724: return new int[] { 65, 65, 203 }; // Decidueye
                case 725: return new int[] { 66, 66, 22 }; // Litten
                case 726: return new int[] { 66, 66, 22 }; // Torracat
                case 727: return new int[] { 66, 66, 22 }; // Incineroar
                case 728: return new int[] { 67, 67, 204 }; // Popplio
                case 729: return new int[] { 67, 67, 204 }; // Brionne
                case 730: return new int[] { 67, 67, 204 }; // Primarina
                case 731: return new int[] { 51, 92, 51 }; // Pikipek
                case 732: return new int[] { 51, 92, 51 }; // Trumbeak
                case 733: return new int[] { 51, 92, 51 }; // Toucannon
                case 734: return new int[] { 198, 173, 91 }; // Yungoos
                case 735: return new int[] { 198, 173, 91 }; // Gumshoos
                case 736: return new int[] { 68, 68, 68 }; // Grubbin
                case 737: return new int[] { 217, 217, 217 }; // Charjabug
                case 738: return new int[] { 26, 26, 26 }; // Vikavolt
                case 739: return new int[] { 52, 89, 83 }; // Crabrawler
                case 740: return new int[] { 52, 89, 83 }; // Crabominable
                case 741: return new int[] { 216, 216, 216 }; // Oricorio
                case 742: return new int[] { 118, 19, 175 }; // Cutiefly
                case 743: return new int[] { 118, 19, 175 }; // Ribombee
                case 744: return new int[] { 51, 72, 80 }; // Rockruff
                case 745:
                    switch (forme)
                    {
                        case 1: return new int[] { 51, 72, 99 }; // Midnight Form Lycanroc
                        default: return new int[] { 51, 146, 80 }; // Midday Form Lycanroc
                    }
                case 746: return new int[] { 208, 208, 208 }; // Wishiwashi
                case 747: return new int[] { 196, 7, 144 }; // Mareanie
                case 748: return new int[] { 196, 7, 144 }; // Toxapex
                case 749: return new int[] { 20, 192, 39 }; // Mudbray
                case 750: return new int[] { 20, 192, 39 }; // Mudsdale
                case 751: return new int[] { 199, 199, 11 }; // Dewpider
                case 752: return new int[] { 199, 199, 11 }; // Araquanid
                case 753: return new int[] { 102, 102, 126 }; // Fomantis
                case 754: return new int[] { 102, 102, 126 }; // Lurantis
                case 755: return new int[] { 35, 27, 44 }; // Morelull
                case 756: return new int[] { 35, 27, 44 }; // Shiinotic
                case 757: return new int[] { 212, 212, 12 }; // Salandit
                case 758: return new int[] { 212, 212, 12 }; // Salazzle
                case 759: return new int[] { 218, 103, 56 }; // Stufful
                case 760: return new int[] { 218, 103, 127 }; // Bewear
                case 761: return new int[] { 102, 12, 175 }; // Bounsweet
                case 762: return new int[] { 102, 12, 175 }; // Steenee
                case 763: return new int[] { 102, 214, 175 }; // Tsareena
                case 764: return new int[] { 166, 205, 30 }; // Comfey
                case 765: return new int[] { 39, 140, 180 }; // Oranguru
                case 766: return new int[] { 222, 222, 128 }; // Passimian
                case 767: return new int[] { 193, 193, 193 }; // Wimpod
                case 768: return new int[] { 194, 194, 194 }; // Golisopod
                case 769: return new int[] { 195, 195, 8 }; // Sandygast
                case 770: return new int[] { 195, 195, 8 }; // Palossand
                case 771: return new int[] { 215, 215, 109 }; // Pyukumuku
                case 772: return new int[] { 4, 4, 4 }; // Type: Null
                case 773: return new int[] { 225, 225, 225 }; // Silvally
                case 774: return new int[] { 197, 197, 197 }; // Minior
                case 775: return new int[] { 213, 213, 213 }; // Komala
                case 776: return new int[] { 75, 75, 75 }; // Turtonator
                case 777: return new int[] { 160, 31, 5 }; // Togedemaru
                case 778: return new int[] { 209, 209, 209 }; // Mimikyu
                case 779: return new int[] { 219, 173, 147 }; // Bruxish
                case 780: return new int[] { 201, 157, 13 }; // Drampa
                case 781: return new int[] { 200, 200, 200 }; // Dhelmise
                case 782: return new int[] { 171, 43, 142 }; // Jangmo-o
                case 783: return new int[] { 171, 43, 142 }; // Hakamo-o
                case 784: return new int[] { 171, 43, 142 }; // Kommo-o
                case 785: return new int[] { 226, 226, 140 }; // Tapu Koko
                case 786: return new int[] { 227, 227, 140 }; // Tapu Lele
                case 787: return new int[] { 229, 229, 140 }; // Tapu Bulu
                case 788: return new int[] { 228, 228, 140 }; // Tapu Fini
                case 789: return new int[] { 109, 109, 109 }; // Cosmog
                case 790: return new int[] { 5, 5, 5 }; // Cosmoem
                case 791: return new int[] { 230, 230, 230 }; // Solgaleo
                case 792: return new int[] { 231, 231, 231 }; // Lunala
                case 793: return new int[] { 224, 224, 224 }; // Nihilego
                case 794: return new int[] { 224, 224, 224 }; // Buzzwole
                case 795: return new int[] { 224, 224, 224 }; // Pheromosa
                case 796: return new int[] { 224, 224, 224 }; // Xurkitree
                case 797: return new int[] { 224, 224, 224 }; // Celesteela
                case 798: return new int[] { 224, 224, 224 }; // Kartana
                case 799: return new int[] { 224, 224, 224 }; // Guzzlord
                case 800: return new int[] { 232, 232, 232 }; // Necrozma
                case 801: return new int[] { 220, 220, 220 }; // Magearna
                case 802: return new int[] { 101, 101, 101 }; // Marshadow
                default: return new int[] { 0, 0, 0 }; // No pokémon
            }
        }

        public static string getAbil6(int index)
        {
            if (index >= 0 && index < Ability6.Length)
            {
                return Ability6[index];
            }
            else
            {
                return "Any";
            }
        }

        public static string getAbil7(int index)
        {
            if (index >= 0 && index < Ability7.Length)
            {
                return Ability7[index];
            }
            else
            {
                return "Any";
            }
        }

        #endregion Ability

        #region Species

        public static string[] Species6 = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch’d", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr-Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime-Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion" };

        public static string[] Species7 = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch’d", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr-Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime-Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabebe", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Rowlet", "Dartrix", "Decidueye", "Litten", "Torracat", "Incineroar", "Popplio", "Brionne", "Primarina", "Pikipek", "Trumbeak", "Toucannon", "Yungoos", "Gumshoos", "Grubbin", "Charjabug", "Vikavolt", "Crabrawler", "Crabominable", "Oricorio", "Cutiefly", "Ribombee", "Rockruff", "Lycanroc", "Wishiwashi", "Mareanie", "Toxapex", "Mudbray", "Mudsdale", "Dewpider", "Araquanid", "Fomantis", "Lurantis", "Morelull", "Shiinotic", "Salandit", "Salazzle", "Stufful", "Bewear", "Bounsweet", "Steenee", "Tsareena", "Comfey", "Oranguru", "Passimian", "Wimpod", "Golisopod", "Sandygast", "Palossand", "Pyukumuku", "Type: Null", "Silvally", "Minior", "Komala", "Turtonator", "Togedemaru", "Mimikyu", "Bruxish", "Drampa", "Dhelmise", "Jangmo-o", "Hakamo-o", "Kommo-o", "Tapu Koko", "Tapu Lele", "Tapu Bulu", "Tapu Fini", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Necrozma", "Magearna", "Marshadow" };

        public static string getSpeciesName(int species, int lang, bool isEgg)
        {
            string[] allnames;
            if (isEgg)
            {
                species = -1;
            }
            switch (species)
            {
                case 1: allnames = new string[] { "フシギダネ", "Bulbasaur", "Bulbizarre", "Bulbasaur", "Bisasam", "Bulbasaur", "이상해씨", "妙蛙种子" }; break;
                case 2: allnames = new string[] { "フシギソウ", "Ivysaur", "Herbizarre", "Ivysaur", "Bisaknosp", "Ivysaur", "이상해풀", "妙蛙草" }; break;
                case 3: allnames = new string[] { "フシギバナ", "Venusaur", "Florizarre", "Venusaur", "Bisaflor", "Venusaur", "이상해꽃", "妙蛙花" }; break;
                case 4: allnames = new string[] { "ヒトカゲ", "Charmander", "Salamèche", "Charmander", "Glumanda", "Charmander", "파이리", "小火龙" }; break;
                case 5: allnames = new string[] { "リザード", "Charmeleon", "Reptincel", "Charmeleon", "Glutexo", "Charmeleon", "리자드", "火恐龙" }; break;
                case 6: allnames = new string[] { "リザードン", "Charizard", "Dracaufeu", "Charizard", "Glurak", "Charizard", "리자몽", "喷火龙" }; break;
                case 7: allnames = new string[] { "ゼニガメ", "Squirtle", "Carapuce", "Squirtle", "Schiggy", "Squirtle", "꼬부기", "杰尼龟" }; break;
                case 8: allnames = new string[] { "カメール", "Wartortle", "Carabaffe", "Wartortle", "Schillok", "Wartortle", "어니부기", "卡咪龟" }; break;
                case 9: allnames = new string[] { "カメックス", "Blastoise", "Tortank", "Blastoise", "Turtok", "Blastoise", "거북왕", "水箭龟" }; break;
                case 10: allnames = new string[] { "キャタピー", "Caterpie", "Chenipan", "Caterpie", "Raupy", "Caterpie", "캐터피", "绿毛虫" }; break;
                case 11: allnames = new string[] { "トランセル", "Metapod", "Chrysacier", "Metapod", "Safcon", "Metapod", "단데기", "铁甲蛹" }; break;
                case 12: allnames = new string[] { "バタフリー", "Butterfree", "Papilusion", "Butterfree", "Smettbo", "Butterfree", "버터플", "巴大蝶" }; break;
                case 13: allnames = new string[] { "ビードル", "Weedle", "Aspicot", "Weedle", "Hornliu", "Weedle", "뿔충이", "独角虫" }; break;
                case 14: allnames = new string[] { "コクーン", "Kakuna", "Coconfort", "Kakuna", "Kokuna", "Kakuna", "딱충이", "铁壳蛹" }; break;
                case 15: allnames = new string[] { "スピアー", "Beedrill", "Dardargnan", "Beedrill", "Bibor", "Beedrill", "독침붕", "大针蜂" }; break;
                case 16: allnames = new string[] { "ポッポ", "Pidgey", "Roucool", "Pidgey", "Taubsi", "Pidgey", "구구", "波波" }; break;
                case 17: allnames = new string[] { "ピジョン", "Pidgeotto", "Roucoups", "Pidgeotto", "Tauboga", "Pidgeotto", "피죤", "比比鸟" }; break;
                case 18: allnames = new string[] { "ピジョット", "Pidgeot", "Roucarnage", "Pidgeot", "Tauboss", "Pidgeot", "피죤투", "大比鸟" }; break;
                case 19: allnames = new string[] { "コラッタ", "Rattata", "Rattata", "Rattata", "Rattfratz", "Rattata", "꼬렛", "小拉达" }; break;
                case 20: allnames = new string[] { "ラッタ", "Raticate", "Rattatac", "Raticate", "Rattikarl", "Raticate", "레트라", "拉达" }; break;
                case 21: allnames = new string[] { "オニスズメ", "Spearow", "Piafabec", "Spearow", "Habitak", "Spearow", "깨비참", "烈雀" }; break;
                case 22: allnames = new string[] { "オニドリル", "Fearow", "Rapasdepic", "Fearow", "Ibitak", "Fearow", "깨비드릴조", "大嘴雀" }; break;
                case 23: allnames = new string[] { "アーボ", "Ekans", "Abo", "Ekans", "Rettan", "Ekans", "아보", "阿柏蛇" }; break;
                case 24: allnames = new string[] { "アーボック", "Arbok", "Arbok", "Arbok", "Arbok", "Arbok", "아보크", "阿柏怪" }; break;
                case 25: allnames = new string[] { "ピカチュウ", "Pikachu", "Pikachu", "Pikachu", "Pikachu", "Pikachu", "피카츄", "皮卡丘" }; break;
                case 26: allnames = new string[] { "ライチュウ", "Raichu", "Raichu", "Raichu", "Raichu", "Raichu", "라이츄", "雷丘" }; break;
                case 27: allnames = new string[] { "サンド", "Sandshrew", "Sabelette", "Sandshrew", "Sandan", "Sandshrew", "모래두지", "穿山鼠" }; break;
                case 28: allnames = new string[] { "サンドパン", "Sandslash", "Sablaireau", "Sandslash", "Sandamer", "Sandslash", "고지", "穿山王" }; break;
                case 29: allnames = new string[] { "ニドラン♀", "Nidoran♀", "Nidoran♀", "Nidoran♀", "Nidoran♀", "Nidoran♀", "니드런♀", "尼多兰" }; break;
                case 30: allnames = new string[] { "ニドリーナ", "Nidorina", "Nidorina", "Nidorina", "Nidorina", "Nidorina", "니드리나", "尼多娜" }; break;
                case 31: allnames = new string[] { "ニドクイン", "Nidoqueen", "Nidoqueen", "Nidoqueen", "Nidoqueen", "Nidoqueen", "니드퀸", "尼多后" }; break;
                case 32: allnames = new string[] { "ニドラン♂", "Nidoran♂", "Nidoran♂", "Nidoran♂", "Nidoran♂", "Nidoran♂", "니드런♂", "尼多朗" }; break;
                case 33: allnames = new string[] { "ニドリーノ", "Nidorino", "Nidorino", "Nidorino", "Nidorino", "Nidorino", "니드리노", "尼多力诺" }; break;
                case 34: allnames = new string[] { "ニドキング", "Nidoking", "Nidoking", "Nidoking", "Nidoking", "Nidoking", "니드킹", "尼多王" }; break;
                case 35: allnames = new string[] { "ピッピ", "Clefairy", "Mélofée", "Clefairy", "Piepi", "Clefairy", "삐삐", "皮皮" }; break;
                case 36: allnames = new string[] { "ピクシー", "Clefable", "Mélodelfe", "Clefable", "Pixi", "Clefable", "픽시", "皮可西" }; break;
                case 37: allnames = new string[] { "ロコン", "Vulpix", "Goupix", "Vulpix", "Vulpix", "Vulpix", "식스테일", "六尾" }; break;
                case 38: allnames = new string[] { "キュウコン", "Ninetales", "Feunard", "Ninetales", "Vulnona", "Ninetales", "나인테일", "九尾" }; break;
                case 39: allnames = new string[] { "プリン", "Jigglypuff", "Rondoudou", "Jigglypuff", "Pummeluff", "Jigglypuff", "푸린", "胖丁" }; break;
                case 40: allnames = new string[] { "プクリン", "Wigglytuff", "Grodoudou", "Wigglytuff", "Knuddeluff", "Wigglytuff", "푸크린", "胖可丁" }; break;
                case 41: allnames = new string[] { "ズバット", "Zubat", "Nosferapti", "Zubat", "Zubat", "Zubat", "주뱃", "超音蝠" }; break;
                case 42: allnames = new string[] { "ゴルバット", "Golbat", "Nosferalto", "Golbat", "Golbat", "Golbat", "골뱃", "大嘴蝠" }; break;
                case 43: allnames = new string[] { "ナゾノクサ", "Oddish", "Mystherbe", "Oddish", "Myrapla", "Oddish", "뚜벅쵸", "走路草" }; break;
                case 44: allnames = new string[] { "クサイハナ", "Gloom", "Ortide", "Gloom", "Duflor", "Gloom", "냄새꼬", "臭臭花" }; break;
                case 45: allnames = new string[] { "ラフレシア", "Vileplume", "Rafflesia", "Vileplume", "Giflor", "Vileplume", "라플레시아", "霸王花" }; break;
                case 46: allnames = new string[] { "パラス", "Paras", "Paras", "Paras", "Paras", "Paras", "파라스", "派拉斯" }; break;
                case 47: allnames = new string[] { "パラセクト", "Parasect", "Parasect", "Parasect", "Parasek", "Parasect", "파라섹트", "派拉斯特" }; break;
                case 48: allnames = new string[] { "コンパン", "Venonat", "Mimitoss", "Venonat", "Bluzuk", "Venonat", "콘팡", "毛球" }; break;
                case 49: allnames = new string[] { "モルフォン", "Venomoth", "Aéromite", "Venomoth", "Omot", "Venomoth", "도나리", "摩鲁蛾" }; break;
                case 50: allnames = new string[] { "ディグダ", "Diglett", "Taupiqueur", "Diglett", "Digda", "Diglett", "디그다", "地鼠" }; break;
                case 51: allnames = new string[] { "ダグトリオ", "Dugtrio", "Triopikeur", "Dugtrio", "Digdri", "Dugtrio", "닥트리오", "三地鼠" }; break;
                case 52: allnames = new string[] { "ニャース", "Meowth", "Miaouss", "Meowth", "Mauzi", "Meowth", "나옹", "喵喵" }; break;
                case 53: allnames = new string[] { "ペルシアン", "Persian", "Persian", "Persian", "Snobilikat", "Persian", "페르시온", "猫老大" }; break;
                case 54: allnames = new string[] { "コダック", "Psyduck", "Psykokwak", "Psyduck", "Enton", "Psyduck", "고라파덕", "可达鸭" }; break;
                case 55: allnames = new string[] { "ゴルダック", "Golduck", "Akwakwak", "Golduck", "Entoron", "Golduck", "골덕", "哥达鸭" }; break;
                case 56: allnames = new string[] { "マンキー", "Mankey", "Férosinge", "Mankey", "Menki", "Mankey", "망키", "猴怪" }; break;
                case 57: allnames = new string[] { "オコリザル", "Primeape", "Colossinge", "Primeape", "Rasaff", "Primeape", "성원숭", "火暴猴" }; break;
                case 58: allnames = new string[] { "ガーディ", "Growlithe", "Caninos", "Growlithe", "Fukano", "Growlithe", "가디", "卡蒂狗" }; break;
                case 59: allnames = new string[] { "ウインディ", "Arcanine", "Arcanin", "Arcanine", "Arkani", "Arcanine", "윈디", "风速狗" }; break;
                case 60: allnames = new string[] { "ニョロモ", "Poliwag", "Ptitard", "Poliwag", "Quapsel", "Poliwag", "발챙이", "蚊香蝌蚪" }; break;
                case 61: allnames = new string[] { "ニョロゾ", "Poliwhirl", "Têtarte", "Poliwhirl", "Quaputzi", "Poliwhirl", "슈륙챙이", "蚊香君" }; break;
                case 62: allnames = new string[] { "ニョロボン", "Poliwrath", "Tartard", "Poliwrath", "Quappo", "Poliwrath", "강챙이", "蚊香泳士" }; break;
                case 63: allnames = new string[] { "ケーシィ", "Abra", "Abra", "Abra", "Abra", "Abra", "캐이시", "凯西" }; break;
                case 64: allnames = new string[] { "ユンゲラー", "Kadabra", "Kadabra", "Kadabra", "Kadabra", "Kadabra", "윤겔라", "勇基拉" }; break;
                case 65: allnames = new string[] { "フーディン", "Alakazam", "Alakazam", "Alakazam", "Simsala", "Alakazam", "후딘", "胡地" }; break;
                case 66: allnames = new string[] { "ワンリキー", "Machop", "Machoc", "Machop", "Machollo", "Machop", "알통몬", "腕力" }; break;
                case 67: allnames = new string[] { "ゴーリキー", "Machoke", "Machopeur", "Machoke", "Maschock", "Machoke", "근육몬", "豪力" }; break;
                case 68: allnames = new string[] { "カイリキー", "Machamp", "Mackogneur", "Machamp", "Machomei", "Machamp", "괴력몬", "怪力" }; break;
                case 69: allnames = new string[] { "マダツボミ", "Bellsprout", "Chétiflor", "Bellsprout", "Knofensa", "Bellsprout", "모다피", "喇叭芽" }; break;
                case 70: allnames = new string[] { "ウツドン", "Weepinbell", "Boustiflor", "Weepinbell", "Ultrigaria", "Weepinbell", "우츠동", "口呆花" }; break;
                case 71: allnames = new string[] { "ウツボット", "Victreebel", "Empiflor", "Victreebel", "Sarzenia", "Victreebel", "우츠보트", "大食花" }; break;
                case 72: allnames = new string[] { "メノクラゲ", "Tentacool", "Tentacool", "Tentacool", "Tentacha", "Tentacool", "왕눈해", "玛瑙水母" }; break;
                case 73: allnames = new string[] { "ドククラゲ", "Tentacruel", "Tentacruel", "Tentacruel", "Tentoxa", "Tentacruel", "독파리", "毒刺水母" }; break;
                case 74: allnames = new string[] { "イシツブテ", "Geodude", "Racaillou", "Geodude", "Kleinstein", "Geodude", "꼬마돌", "小拳石" }; break;
                case 75: allnames = new string[] { "ゴローン", "Graveler", "Gravalanch", "Graveler", "Georok", "Graveler", "데구리", "隆隆石" }; break;
                case 76: allnames = new string[] { "ゴローニャ", "Golem", "Grolem", "Golem", "Geowaz", "Golem", "딱구리", "隆隆岩" }; break;
                case 77: allnames = new string[] { "ポニータ", "Ponyta", "Ponyta", "Ponyta", "Ponita", "Ponyta", "포니타", "小火马" }; break;
                case 78: allnames = new string[] { "ギャロップ", "Rapidash", "Galopa", "Rapidash", "Gallopa", "Rapidash", "날쌩마", "烈焰马" }; break;
                case 79: allnames = new string[] { "ヤドン", "Slowpoke", "Ramoloss", "Slowpoke", "Flegmon", "Slowpoke", "야돈", "呆呆兽" }; break;
                case 80: allnames = new string[] { "ヤドラン", "Slowbro", "Flagadoss", "Slowbro", "Lahmus", "Slowbro", "야도란", "呆壳兽" }; break;
                case 81: allnames = new string[] { "コイル", "Magnemite", "Magnéti", "Magnemite", "Magnetilo", "Magnemite", "코일", "小磁怪" }; break;
                case 82: allnames = new string[] { "レアコイル", "Magneton", "Magnéton", "Magneton", "Magneton", "Magneton", "레어코일", "三合一磁怪" }; break;
                case 83: allnames = new string[] { "カモネギ", "Farfetch’d", "Canarticho", "Farfetch’d", "Porenta", "Farfetch’d", "파오리", "大葱鸭" }; break;
                case 84: allnames = new string[] { "ドードー", "Doduo", "Doduo", "Doduo", "Dodu", "Doduo", "두두", "嘟嘟" }; break;
                case 85: allnames = new string[] { "ドードリオ", "Dodrio", "Dodrio", "Dodrio", "Dodri", "Dodrio", "두트리오", "嘟嘟利" }; break;
                case 86: allnames = new string[] { "パウワウ", "Seel", "Otaria", "Seel", "Jurob", "Seel", "쥬쥬", "小海狮" }; break;
                case 87: allnames = new string[] { "ジュゴン", "Dewgong", "Lamantine", "Dewgong", "Jugong", "Dewgong", "쥬레곤", "白海狮" }; break;
                case 88: allnames = new string[] { "ベトベター", "Grimer", "Tadmorv", "Grimer", "Sleima", "Grimer", "질퍽이", "臭泥" }; break;
                case 89: allnames = new string[] { "ベトベトン", "Muk", "Grotadmorv", "Muk", "Sleimok", "Muk", "질뻐기", "臭臭泥" }; break;
                case 90: allnames = new string[] { "シェルダー", "Shellder", "Kokiyas", "Shellder", "Muschas", "Shellder", "셀러", "大舌贝" }; break;
                case 91: allnames = new string[] { "パルシェン", "Cloyster", "Crustabri", "Cloyster", "Austos", "Cloyster", "파르셀", "刺甲贝" }; break;
                case 92: allnames = new string[] { "ゴース", "Gastly", "Fantominus", "Gastly", "Nebulak", "Gastly", "고오스", "鬼斯" }; break;
                case 93: allnames = new string[] { "ゴースト", "Haunter", "Spectrum", "Haunter", "Alpollo", "Haunter", "고우스트", "鬼斯通" }; break;
                case 94: allnames = new string[] { "ゲンガー", "Gengar", "Ectoplasma", "Gengar", "Gengar", "Gengar", "팬텀", "耿鬼" }; break;
                case 95: allnames = new string[] { "イワーク", "Onix", "Onix", "Onix", "Onix", "Onix", "롱스톤", "大岩蛇" }; break;
                case 96: allnames = new string[] { "スリープ", "Drowzee", "Soporifik", "Drowzee", "Traumato", "Drowzee", "슬리프", "催眠貘" }; break;
                case 97: allnames = new string[] { "スリーパー", "Hypno", "Hypnomade", "Hypno", "Hypno", "Hypno", "슬리퍼", "引梦貘人" }; break;
                case 98: allnames = new string[] { "クラブ", "Krabby", "Krabby", "Krabby", "Krabby", "Krabby", "크랩", "大钳蟹" }; break;
                case 99: allnames = new string[] { "キングラー", "Kingler", "Krabboss", "Kingler", "Kingler", "Kingler", "킹크랩", "巨钳蟹" }; break;
                case 100: allnames = new string[] { "ビリリダマ", "Voltorb", "Voltorbe", "Voltorb", "Voltobal", "Voltorb", "찌리리공", "霹雳电球" }; break;
                case 101: allnames = new string[] { "マルマイン", "Electrode", "Électrode", "Electrode", "Lektrobal", "Electrode", "붐볼", "顽皮雷弹" }; break;
                case 102: allnames = new string[] { "タマタマ", "Exeggcute", "Noeunoeuf", "Exeggcute", "Owei", "Exeggcute", "아라리", "蛋蛋" }; break;
                case 103: allnames = new string[] { "ナッシー", "Exeggutor", "Noadkoko", "Exeggutor", "Kokowei", "Exeggutor", "나시", "椰蛋树" }; break;
                case 104: allnames = new string[] { "カラカラ", "Cubone", "Osselait", "Cubone", "Tragosso", "Cubone", "탕구리", "卡拉卡拉" }; break;
                case 105: allnames = new string[] { "ガラガラ", "Marowak", "Ossatueur", "Marowak", "Knogga", "Marowak", "텅구리", "嘎啦嘎啦" }; break;
                case 106: allnames = new string[] { "サワムラー", "Hitmonlee", "Kicklee", "Hitmonlee", "Kicklee", "Hitmonlee", "시라소몬", "飞腿郎" }; break;
                case 107: allnames = new string[] { "エビワラー", "Hitmonchan", "Tygnon", "Hitmonchan", "Nockchan", "Hitmonchan", "홍수몬", "快拳郎" }; break;
                case 108: allnames = new string[] { "ベロリンガ", "Lickitung", "Excelangue", "Lickitung", "Schlurp", "Lickitung", "내루미", "大舌头" }; break;
                case 109: allnames = new string[] { "ドガース", "Koffing", "Smogo", "Koffing", "Smogon", "Koffing", "또가스", "瓦斯弹" }; break;
                case 110: allnames = new string[] { "マタドガス", "Weezing", "Smogogo", "Weezing", "Smogmog", "Weezing", "또도가스", "双弹瓦斯" }; break;
                case 111: allnames = new string[] { "サイホーン", "Rhyhorn", "Rhinocorne", "Rhyhorn", "Rihorn", "Rhyhorn", "뿔카노", "独角犀牛" }; break;
                case 112: allnames = new string[] { "サイドン", "Rhydon", "Rhinoféros", "Rhydon", "Rizeros", "Rhydon", "코뿌리", "钻角犀兽" }; break;
                case 113: allnames = new string[] { "ラッキー", "Chansey", "Leveinard", "Chansey", "Chaneira", "Chansey", "럭키", "吉利蛋" }; break;
                case 114: allnames = new string[] { "モンジャラ", "Tangela", "Saquedeneu", "Tangela", "Tangela", "Tangela", "덩쿠리", "蔓藤怪" }; break;
                case 115: allnames = new string[] { "ガルーラ", "Kangaskhan", "Kangourex", "Kangaskhan", "Kangama", "Kangaskhan", "캥카", "袋兽" }; break;
                case 116: allnames = new string[] { "タッツー", "Horsea", "Hypotrempe", "Horsea", "Seeper", "Horsea", "쏘드라", "墨海马" }; break;
                case 117: allnames = new string[] { "シードラ", "Seadra", "Hypocéan", "Seadra", "Seemon", "Seadra", "시드라", "海刺龙" }; break;
                case 118: allnames = new string[] { "トサキント", "Goldeen", "Poissirène", "Goldeen", "Goldini", "Goldeen", "콘치", "角金鱼" }; break;
                case 119: allnames = new string[] { "アズマオウ", "Seaking", "Poissoroy", "Seaking", "Golking", "Seaking", "왕콘치", "金鱼王" }; break;
                case 120: allnames = new string[] { "ヒトデマン", "Staryu", "Stari", "Staryu", "Sterndu", "Staryu", "별가사리", "海星星" }; break;
                case 121: allnames = new string[] { "スターミー", "Starmie", "Staross", "Starmie", "Starmie", "Starmie", "아쿠스타", "宝石海星" }; break;
                case 122: allnames = new string[] { "バリヤード", "Mr. Mime", "M. Mime", "Mr. Mime", "Pantimos", "Mr. Mime", "마임맨", "魔墙人偶" }; break;
                case 123: allnames = new string[] { "ストライク", "Scyther", "Insécateur", "Scyther", "Sichlor", "Scyther", "스라크", "飞天螳螂" }; break;
                case 124: allnames = new string[] { "ルージュラ", "Jynx", "Lippoutou", "Jynx", "Rossana", "Jynx", "루주라", "迷唇姐" }; break;
                case 125: allnames = new string[] { "エレブー", "Electabuzz", "Élektek", "Electabuzz", "Elektek", "Electabuzz", "에레브", "电击兽" }; break;
                case 126: allnames = new string[] { "ブーバー", "Magmar", "Magmar", "Magmar", "Magmar", "Magmar", "마그마", "鸭嘴火兽" }; break;
                case 127: allnames = new string[] { "カイロス", "Pinsir", "Scarabrute", "Pinsir", "Pinsir", "Pinsir", "쁘사이저", "凯罗斯" }; break;
                case 128: allnames = new string[] { "ケンタロス", "Tauros", "Tauros", "Tauros", "Tauros", "Tauros", "켄타로스", "肯泰罗" }; break;
                case 129: allnames = new string[] { "コイキング", "Magikarp", "Magicarpe", "Magikarp", "Karpador", "Magikarp", "잉어킹", "鲤鱼王" }; break;
                case 130: allnames = new string[] { "ギャラドス", "Gyarados", "Léviator", "Gyarados", "Garados", "Gyarados", "갸라도스", "暴鲤龙" }; break;
                case 131: allnames = new string[] { "ラプラス", "Lapras", "Lokhlass", "Lapras", "Lapras", "Lapras", "라프라스", "拉普拉斯" }; break;
                case 132: allnames = new string[] { "メタモン", "Ditto", "Métamorph", "Ditto", "Ditto", "Ditto", "메타몽", "百变怪" }; break;
                case 133: allnames = new string[] { "イーブイ", "Eevee", "Évoli", "Eevee", "Evoli", "Eevee", "이브이", "伊布" }; break;
                case 134: allnames = new string[] { "シャワーズ", "Vaporeon", "Aquali", "Vaporeon", "Aquana", "Vaporeon", "샤미드", "水伊布" }; break;
                case 135: allnames = new string[] { "サンダース", "Jolteon", "Voltali", "Jolteon", "Blitza", "Jolteon", "쥬피썬더", "雷伊布" }; break;
                case 136: allnames = new string[] { "ブースター", "Flareon", "Pyroli", "Flareon", "Flamara", "Flareon", "부스터", "火伊布" }; break;
                case 137: allnames = new string[] { "ポリゴン", "Porygon", "Porygon", "Porygon", "Porygon", "Porygon", "폴리곤", "多边兽" }; break;
                case 138: allnames = new string[] { "オムナイト", "Omanyte", "Amonita", "Omanyte", "Amonitas", "Omanyte", "암나이트", "菊石兽" }; break;
                case 139: allnames = new string[] { "オムスター", "Omastar", "Amonistar", "Omastar", "Amoroso", "Omastar", "암스타", "多刺菊石兽" }; break;
                case 140: allnames = new string[] { "カブト", "Kabuto", "Kabuto", "Kabuto", "Kabuto", "Kabuto", "투구", "化石盔" }; break;
                case 141: allnames = new string[] { "カブトプス", "Kabutops", "Kabutops", "Kabutops", "Kabutops", "Kabutops", "투구푸스", "镰刀盔" }; break;
                case 142: allnames = new string[] { "プテラ", "Aerodactyl", "Ptéra", "Aerodactyl", "Aerodactyl", "Aerodactyl", "프테라", "化石翼龙" }; break;
                case 143: allnames = new string[] { "カビゴン", "Snorlax", "Ronflex", "Snorlax", "Relaxo", "Snorlax", "잠만보", "卡比兽" }; break;
                case 144: allnames = new string[] { "フリーザー", "Articuno", "Artikodin", "Articuno", "Arktos", "Articuno", "프리져", "急冻鸟" }; break;
                case 145: allnames = new string[] { "サンダー", "Zapdos", "Électhor", "Zapdos", "Zapdos", "Zapdos", "썬더", "闪电鸟" }; break;
                case 146: allnames = new string[] { "ファイヤー", "Moltres", "Sulfura", "Moltres", "Lavados", "Moltres", "파이어", "火焰鸟" }; break;
                case 147: allnames = new string[] { "ミニリュウ", "Dratini", "Minidraco", "Dratini", "Dratini", "Dratini", "미뇽", "迷你龙" }; break;
                case 148: allnames = new string[] { "ハクリュー", "Dragonair", "Draco", "Dragonair", "Dragonir", "Dragonair", "신뇽", "哈克龙" }; break;
                case 149: allnames = new string[] { "カイリュー", "Dragonite", "Dracolosse", "Dragonite", "Dragoran", "Dragonite", "망나뇽", "快龙" }; break;
                case 150: allnames = new string[] { "ミュウツー", "Mewtwo", "Mewtwo", "Mewtwo", "Mewtu", "Mewtwo", "뮤츠", "超梦" }; break;
                case 151: allnames = new string[] { "ミュウ", "Mew", "Mew", "Mew", "Mew", "Mew", "뮤", "梦幻" }; break;
                case 152: allnames = new string[] { "チコリータ", "Chikorita", "Germignon", "Chikorita", "Endivie", "Chikorita", "치코리타", "菊草叶" }; break;
                case 153: allnames = new string[] { "ベイリーフ", "Bayleef", "Macronium", "Bayleef", "Lorblatt", "Bayleef", "베이리프", "月桂叶" }; break;
                case 154: allnames = new string[] { "メガニウム", "Meganium", "Méganium", "Meganium", "Meganie", "Meganium", "메가니움", "大竺葵" }; break;
                case 155: allnames = new string[] { "ヒノアラシ", "Cyndaquil", "Héricendre", "Cyndaquil", "Feurigel", "Cyndaquil", "브케인", "火球鼠" }; break;
                case 156: allnames = new string[] { "マグマラシ", "Quilava", "Feurisson", "Quilava", "Igelavar", "Quilava", "마그케인", "火岩鼠" }; break;
                case 157: allnames = new string[] { "バクフーン", "Typhlosion", "Typhlosion", "Typhlosion", "Tornupto", "Typhlosion", "블레이범", "火暴兽" }; break;
                case 158: allnames = new string[] { "ワニノコ", "Totodile", "Kaiminus", "Totodile", "Karnimani", "Totodile", "리아코", "小锯鳄" }; break;
                case 159: allnames = new string[] { "アリゲイツ", "Croconaw", "Crocrodil", "Croconaw", "Tyracroc", "Croconaw", "엘리게이", "蓝鳄" }; break;
                case 160: allnames = new string[] { "オーダイル", "Feraligatr", "Aligatueur", "Feraligatr", "Impergator", "Feraligatr", "장크로다일", "大力鳄" }; break;
                case 161: allnames = new string[] { "オタチ", "Sentret", "Fouinette", "Sentret", "Wiesor", "Sentret", "꼬리선", "尾立" }; break;
                case 162: allnames = new string[] { "オオタチ", "Furret", "Fouinar", "Furret", "Wiesenior", "Furret", "다꼬리", "大尾立" }; break;
                case 163: allnames = new string[] { "ホーホー", "Hoothoot", "Hoothoot", "Hoothoot", "Hoothoot", "Hoothoot", "부우부", "咕咕" }; break;
                case 164: allnames = new string[] { "ヨルノズク", "Noctowl", "Noarfang", "Noctowl", "Noctuh", "Noctowl", "야부엉", "猫头夜鹰" }; break;
                case 165: allnames = new string[] { "レディバ", "Ledyba", "Coxy", "Ledyba", "Ledyba", "Ledyba", "레디바", "芭瓢虫" }; break;
                case 166: allnames = new string[] { "レディアン", "Ledian", "Coxyclaque", "Ledian", "Ledian", "Ledian", "레디안", "安瓢虫" }; break;
                case 167: allnames = new string[] { "イトマル", "Spinarak", "Mimigal", "Spinarak", "Webarak", "Spinarak", "페이검", "圆丝蛛" }; break;
                case 168: allnames = new string[] { "アリアドス", "Ariados", "Migalos", "Ariados", "Ariados", "Ariados", "아리아도스", "阿利多斯" }; break;
                case 169: allnames = new string[] { "クロバット", "Crobat", "Nostenfer", "Crobat", "Iksbat", "Crobat", "크로뱃", "叉字蝠" }; break;
                case 170: allnames = new string[] { "チョンチー", "Chinchou", "Loupio", "Chinchou", "Lampi", "Chinchou", "초라기", "灯笼鱼" }; break;
                case 171: allnames = new string[] { "ランターン", "Lanturn", "Lanturn", "Lanturn", "Lanturn", "Lanturn", "랜턴", "电灯怪" }; break;
                case 172: allnames = new string[] { "ピチュー", "Pichu", "Pichu", "Pichu", "Pichu", "Pichu", "피츄", "皮丘" }; break;
                case 173: allnames = new string[] { "ピィ", "Cleffa", "Mélo", "Cleffa", "Pii", "Cleffa", "삐", "皮宝宝" }; break;
                case 174: allnames = new string[] { "ププリン", "Igglybuff", "Toudoudou", "Igglybuff", "Fluffeluff", "Igglybuff", "푸푸린", "宝宝丁" }; break;
                case 175: allnames = new string[] { "トゲピー", "Togepi", "Togepi", "Togepi", "Togepi", "Togepi", "토게피", "波克比" }; break;
                case 176: allnames = new string[] { "トゲチック", "Togetic", "Togetic", "Togetic", "Togetic", "Togetic", "토게틱", "波克基古" }; break;
                case 177: allnames = new string[] { "ネイティ", "Natu", "Natu", "Natu", "Natu", "Natu", "네이티", "天然雀" }; break;
                case 178: allnames = new string[] { "ネイティオ", "Xatu", "Xatu", "Xatu", "Xatu", "Xatu", "네이티오", "天然鸟" }; break;
                case 179: allnames = new string[] { "メリープ", "Mareep", "Wattouat", "Mareep", "Voltilamm", "Mareep", "메리프", "咩利羊" }; break;
                case 180: allnames = new string[] { "モココ", "Flaaffy", "Lainergie", "Flaaffy", "Waaty", "Flaaffy", "보송송", "茸茸羊" }; break;
                case 181: allnames = new string[] { "デンリュウ", "Ampharos", "Pharamp", "Ampharos", "Ampharos", "Ampharos", "전룡", "电龙" }; break;
                case 182: allnames = new string[] { "キレイハナ", "Bellossom", "Joliflor", "Bellossom", "Blubella", "Bellossom", "아르코", "美丽花" }; break;
                case 183: allnames = new string[] { "マリル", "Marill", "Marill", "Marill", "Marill", "Marill", "마릴", "玛力露" }; break;
                case 184: allnames = new string[] { "マリルリ", "Azumarill", "Azumarill", "Azumarill", "Azumarill", "Azumarill", "마릴리", "玛力露丽" }; break;
                case 185: allnames = new string[] { "ウソッキー", "Sudowoodo", "Simularbre", "Sudowoodo", "Mogelbaum", "Sudowoodo", "꼬지모", "树才怪" }; break;
                case 186: allnames = new string[] { "ニョロトノ", "Politoed", "Tarpaud", "Politoed", "Quaxo", "Politoed", "왕구리", "蚊香蛙皇" }; break;
                case 187: allnames = new string[] { "ハネッコ", "Hoppip", "Granivol", "Hoppip", "Hoppspross", "Hoppip", "통통코", "毽子草" }; break;
                case 188: allnames = new string[] { "ポポッコ", "Skiploom", "Floravol", "Skiploom", "Hubelupf", "Skiploom", "두코", "毽子花" }; break;
                case 189: allnames = new string[] { "ワタッコ", "Jumpluff", "Cotovol", "Jumpluff", "Papungha", "Jumpluff", "솜솜코", "毽子棉" }; break;
                case 190: allnames = new string[] { "エイパム", "Aipom", "Capumain", "Aipom", "Griffel", "Aipom", "에이팜", "长尾怪手" }; break;
                case 191: allnames = new string[] { "ヒマナッツ", "Sunkern", "Tournegrin", "Sunkern", "Sonnkern", "Sunkern", "해너츠", "向日种子" }; break;
                case 192: allnames = new string[] { "キマワリ", "Sunflora", "Héliatronc", "Sunflora", "Sonnflora", "Sunflora", "해루미", "向日花怪" }; break;
                case 193: allnames = new string[] { "ヤンヤンマ", "Yanma", "Yanma", "Yanma", "Yanma", "Yanma", "왕자리", "蜻蜻蜓" }; break;
                case 194: allnames = new string[] { "ウパー", "Wooper", "Axoloto", "Wooper", "Felino", "Wooper", "우파", "乌波" }; break;
                case 195: allnames = new string[] { "ヌオー", "Quagsire", "Maraiste", "Quagsire", "Morlord", "Quagsire", "누오", "沼王" }; break;
                case 196: allnames = new string[] { "エーフィ", "Espeon", "Mentali", "Espeon", "Psiana", "Espeon", "에브이", "太阳伊布" }; break;
                case 197: allnames = new string[] { "ブラッキー", "Umbreon", "Noctali", "Umbreon", "Nachtara", "Umbreon", "블래키", "月亮伊布" }; break;
                case 198: allnames = new string[] { "ヤミカラス", "Murkrow", "Cornèbre", "Murkrow", "Kramurx", "Murkrow", "니로우", "黑暗鸦" }; break;
                case 199: allnames = new string[] { "ヤドキング", "Slowking", "Roigada", "Slowking", "Laschoking", "Slowking", "야도킹", "呆呆王" }; break;
                case 200: allnames = new string[] { "ムウマ", "Misdreavus", "Feuforêve", "Misdreavus", "Traunfugil", "Misdreavus", "무우마", "梦妖" }; break;
                case 201: allnames = new string[] { "アンノーン", "Unown", "Zarbi", "Unown", "Icognito", "Unown", "안농", "未知图腾" }; break;
                case 202: allnames = new string[] { "ソーナンス", "Wobbuffet", "Qulbutoké", "Wobbuffet", "Woingenau", "Wobbuffet", "마자용", "果然翁" }; break;
                case 203: allnames = new string[] { "キリンリキ", "Girafarig", "Girafarig", "Girafarig", "Girafarig", "Girafarig", "키링키", "麒麟奇" }; break;
                case 204: allnames = new string[] { "クヌギダマ", "Pineco", "Pomdepik", "Pineco", "Tannza", "Pineco", "피콘", "榛果球" }; break;
                case 205: allnames = new string[] { "フォレトス", "Forretress", "Foretress", "Forretress", "Forstellka", "Forretress", "쏘콘", "佛烈托斯" }; break;
                case 206: allnames = new string[] { "ノコッチ", "Dunsparce", "Insolourdo", "Dunsparce", "Dummisel", "Dunsparce", "노고치", "土龙弟弟" }; break;
                case 207: allnames = new string[] { "グライガー", "Gligar", "Scorplane", "Gligar", "Skorgla", "Gligar", "글라이거", "天蝎" }; break;
                case 208: allnames = new string[] { "ハガネール", "Steelix", "Steelix", "Steelix", "Stahlos", "Steelix", "강철톤", "大钢蛇" }; break;
                case 209: allnames = new string[] { "ブルー", "Snubbull", "Snubbull", "Snubbull", "Snubbull", "Snubbull", "블루", "布鲁" }; break;
                case 210: allnames = new string[] { "グランブル", "Granbull", "Granbull", "Granbull", "Granbull", "Granbull", "그랑블루", "布鲁皇" }; break;
                case 211: allnames = new string[] { "ハリーセン", "Qwilfish", "Qwilfish", "Qwilfish", "Baldorfish", "Qwilfish", "침바루", "千针鱼" }; break;
                case 212: allnames = new string[] { "ハッサム", "Scizor", "Cizayox", "Scizor", "Scherox", "Scizor", "핫삼", "巨钳螳螂" }; break;
                case 213: allnames = new string[] { "ツボツボ", "Shuckle", "Caratroc", "Shuckle", "Pottrott", "Shuckle", "단단지", "壶壶" }; break;
                case 214: allnames = new string[] { "ヘラクロス", "Heracross", "Scarhino", "Heracross", "Skaraborn", "Heracross", "헤라크로스", "赫拉克罗斯" }; break;
                case 215: allnames = new string[] { "ニューラ", "Sneasel", "Farfuret", "Sneasel", "Sniebel", "Sneasel", "포푸니", "狃拉" }; break;
                case 216: allnames = new string[] { "ヒメグマ", "Teddiursa", "Teddiursa", "Teddiursa", "Teddiursa", "Teddiursa", "깜지곰", "熊宝宝" }; break;
                case 217: allnames = new string[] { "リングマ", "Ursaring", "Ursaring", "Ursaring", "Ursaring", "Ursaring", "링곰", "圈圈熊" }; break;
                case 218: allnames = new string[] { "マグマッグ", "Slugma", "Limagma", "Slugma", "Schneckmag", "Slugma", "마그마그", "熔岩虫" }; break;
                case 219: allnames = new string[] { "マグカルゴ", "Magcargo", "Volcaropod", "Magcargo", "Magcargo", "Magcargo", "마그카르고", "熔岩蜗牛" }; break;
                case 220: allnames = new string[] { "ウリムー", "Swinub", "Marcacrin", "Swinub", "Quiekel", "Swinub", "꾸꾸리", "小山猪" }; break;
                case 221: allnames = new string[] { "イノムー", "Piloswine", "Cochignon", "Piloswine", "Keifel", "Piloswine", "메꾸리", "长毛猪" }; break;
                case 222: allnames = new string[] { "サニーゴ", "Corsola", "Corayon", "Corsola", "Corasonn", "Corsola", "코산호", "太阳珊瑚" }; break;
                case 223: allnames = new string[] { "テッポウオ", "Remoraid", "Rémoraid", "Remoraid", "Remoraid", "Remoraid", "총어", "铁炮鱼" }; break;
                case 224: allnames = new string[] { "オクタン", "Octillery", "Octillery", "Octillery", "Octillery", "Octillery", "대포무노", "章鱼桶" }; break;
                case 225: allnames = new string[] { "デリバード", "Delibird", "Cadoizo", "Delibird", "Botogel", "Delibird", "딜리버드", "信使鸟" }; break;
                case 226: allnames = new string[] { "マンタイン", "Mantine", "Démanta", "Mantine", "Mantax", "Mantine", "만타인", "巨翅飞鱼" }; break;
                case 227: allnames = new string[] { "エアームド", "Skarmory", "Airmure", "Skarmory", "Panzaeron", "Skarmory", "무장조", "盔甲鸟" }; break;
                case 228: allnames = new string[] { "デルビル", "Houndour", "Malosse", "Houndour", "Hunduster", "Houndour", "델빌", "戴鲁比" }; break;
                case 229: allnames = new string[] { "ヘルガー", "Houndoom", "Démolosse", "Houndoom", "Hundemon", "Houndoom", "헬가", "黑鲁加" }; break;
                case 230: allnames = new string[] { "キングドラ", "Kingdra", "Hyporoi", "Kingdra", "Seedraking", "Kingdra", "킹드라", "刺龙王" }; break;
                case 231: allnames = new string[] { "ゴマゾウ", "Phanpy", "Phanpy", "Phanpy", "Phanpy", "Phanpy", "코코리", "小小象" }; break;
                case 232: allnames = new string[] { "ドンファン", "Donphan", "Donphan", "Donphan", "Donphan", "Donphan", "코리갑", "顿甲" }; break;
                case 233: allnames = new string[] { "ポリゴン２", "Porygon2", "Porygon2", "Porygon2", "Porygon2", "Porygon2", "폴리곤2", "多边兽Ⅱ" }; break;
                case 234: allnames = new string[] { "オドシシ", "Stantler", "Cerfrousse", "Stantler", "Damhirplex", "Stantler", "노라키", "惊角鹿" }; break;
                case 235: allnames = new string[] { "ドーブル", "Smeargle", "Queulorior", "Smeargle", "Farbeagle", "Smeargle", "루브도", "图图犬" }; break;
                case 236: allnames = new string[] { "バルキー", "Tyrogue", "Debugant", "Tyrogue", "Rabauz", "Tyrogue", "배루키", "无畏小子" }; break;
                case 237: allnames = new string[] { "カポエラー", "Hitmontop", "Kapoera", "Hitmontop", "Kapoera", "Hitmontop", "카포에라", "战舞郎" }; break;
                case 238: allnames = new string[] { "ムチュール", "Smoochum", "Lippouti", "Smoochum", "Kussilla", "Smoochum", "뽀뽀라", "迷唇娃" }; break;
                case 239: allnames = new string[] { "エレキッド", "Elekid", "Élekid", "Elekid", "Elekid", "Elekid", "에레키드", "电击怪" }; break;
                case 240: allnames = new string[] { "ブビィ", "Magby", "Magby", "Magby", "Magby", "Magby", "마그비", "鸭嘴宝宝" }; break;
                case 241: allnames = new string[] { "ミルタンク", "Miltank", "Écrémeuh", "Miltank", "Miltank", "Miltank", "밀탱크", "大奶罐" }; break;
                case 242: allnames = new string[] { "ハピナス", "Blissey", "Leuphorie", "Blissey", "Heiteira", "Blissey", "해피너스", "幸福蛋" }; break;
                case 243: allnames = new string[] { "ライコウ", "Raikou", "Raikou", "Raikou", "Raikou", "Raikou", "라이코", "雷公" }; break;
                case 244: allnames = new string[] { "エンテイ", "Entei", "Entei", "Entei", "Entei", "Entei", "앤테이", "炎帝" }; break;
                case 245: allnames = new string[] { "スイクン", "Suicune", "Suicune", "Suicune", "Suicune", "Suicune", "스이쿤", "水君" }; break;
                case 246: allnames = new string[] { "ヨーギラス", "Larvitar", "Embrylex", "Larvitar", "Larvitar", "Larvitar", "애버라스", "幼基拉斯" }; break;
                case 247: allnames = new string[] { "サナギラス", "Pupitar", "Ymphect", "Pupitar", "Pupitar", "Pupitar", "데기라스", "沙基拉斯" }; break;
                case 248: allnames = new string[] { "バンギラス", "Tyranitar", "Tyranocif", "Tyranitar", "Despotar", "Tyranitar", "마기라스", "班基拉斯" }; break;
                case 249: allnames = new string[] { "ルギア", "Lugia", "Lugia", "Lugia", "Lugia", "Lugia", "루기아", "洛奇亚" }; break;
                case 250: allnames = new string[] { "ホウオウ", "Ho-Oh", "Ho-Oh", "Ho-Oh", "Ho-Oh", "Ho-Oh", "칠색조", "凤王" }; break;
                case 251: allnames = new string[] { "セレビィ", "Celebi", "Celebi", "Celebi", "Celebi", "Celebi", "세레비", "时拉比" }; break;
                case 252: allnames = new string[] { "キモリ", "Treecko", "Arcko", "Treecko", "Geckarbor", "Treecko", "나무지기", "木守宫" }; break;
                case 253: allnames = new string[] { "ジュプトル", "Grovyle", "Massko", "Grovyle", "Reptain", "Grovyle", "나무돌이", "森林蜥蜴" }; break;
                case 254: allnames = new string[] { "ジュカイン", "Sceptile", "Jungko", "Sceptile", "Gewaldro", "Sceptile", "나무킹", "蜥蜴王" }; break;
                case 255: allnames = new string[] { "アチャモ", "Torchic", "Poussifeu", "Torchic", "Flemmli", "Torchic", "아차모", "火稚鸡" }; break;
                case 256: allnames = new string[] { "ワカシャモ", "Combusken", "Galifeu", "Combusken", "Jungglut", "Combusken", "영치코", "力壮鸡" }; break;
                case 257: allnames = new string[] { "バシャーモ", "Blaziken", "Braségali", "Blaziken", "Lohgock", "Blaziken", "번치코", "火焰鸡" }; break;
                case 258: allnames = new string[] { "ミズゴロウ", "Mudkip", "Gobou", "Mudkip", "Hydropi", "Mudkip", "물짱이", "水跃鱼" }; break;
                case 259: allnames = new string[] { "ヌマクロー", "Marshtomp", "Flobio", "Marshtomp", "Moorabbel", "Marshtomp", "늪짱이", "沼跃鱼" }; break;
                case 260: allnames = new string[] { "ラグラージ", "Swampert", "Laggron", "Swampert", "Sumpex", "Swampert", "대짱이", "巨沼怪" }; break;
                case 261: allnames = new string[] { "ポチエナ", "Poochyena", "Medhyèna", "Poochyena", "Fiffyen", "Poochyena", "포챠나", "土狼犬" }; break;
                case 262: allnames = new string[] { "グラエナ", "Mightyena", "Grahyèna", "Mightyena", "Magnayen", "Mightyena", "그라에나", "大狼犬" }; break;
                case 263: allnames = new string[] { "ジグザグマ", "Zigzagoon", "Zigzaton", "Zigzagoon", "Zigzachs", "Zigzagoon", "지그제구리", "蛇纹熊" }; break;
                case 264: allnames = new string[] { "マッスグマ", "Linoone", "Linéon", "Linoone", "Geradaks", "Linoone", "직구리", "直冲熊" }; break;
                case 265: allnames = new string[] { "ケムッソ", "Wurmple", "Chenipotte", "Wurmple", "Waumpel", "Wurmple", "개무소", "刺尾虫" }; break;
                case 266: allnames = new string[] { "カラサリス", "Silcoon", "Armulys", "Silcoon", "Schaloko", "Silcoon", "실쿤", "甲壳茧" }; break;
                case 267: allnames = new string[] { "アゲハント", "Beautifly", "Charmillon", "Beautifly", "Papinella", "Beautifly", "뷰티플라이", "狩猎凤蝶" }; break;
                case 268: allnames = new string[] { "マユルド", "Cascoon", "Blindalys", "Cascoon", "Panekon", "Cascoon", "카스쿤", "盾甲茧" }; break;
                case 269: allnames = new string[] { "ドクケイル", "Dustox", "Papinox", "Dustox", "Pudox", "Dustox", "독케일", "毒粉蛾" }; break;
                case 270: allnames = new string[] { "ハスボー", "Lotad", "Nénupiot", "Lotad", "Loturzel", "Lotad", "연꽃몬", "莲叶童子" }; break;
                case 271: allnames = new string[] { "ハスブレロ", "Lombre", "Lombre", "Lombre", "Lombrero", "Lombre", "로토스", "莲帽小童" }; break;
                case 272: allnames = new string[] { "ルンパッパ", "Ludicolo", "Ludicolo", "Ludicolo", "Kappalores", "Ludicolo", "로파파", "乐天河童" }; break;
                case 273: allnames = new string[] { "タネボー", "Seedot", "Grainipiot", "Seedot", "Samurzel", "Seedot", "도토링", "橡实果" }; break;
                case 274: allnames = new string[] { "コノハナ", "Nuzleaf", "Pifeuil", "Nuzleaf", "Blanas", "Nuzleaf", "잎새코", "长鼻叶" }; break;
                case 275: allnames = new string[] { "ダーテング", "Shiftry", "Tengalice", "Shiftry", "Tengulist", "Shiftry", "다탱구", "狡猾天狗" }; break;
                case 276: allnames = new string[] { "スバメ", "Taillow", "Nirondelle", "Taillow", "Schwalbini", "Taillow", "테일로", "傲骨燕" }; break;
                case 277: allnames = new string[] { "オオスバメ", "Swellow", "Hélédelle", "Swellow", "Schwalboss", "Swellow", "스왈로", "大王燕" }; break;
                case 278: allnames = new string[] { "キャモメ", "Wingull", "Goélise", "Wingull", "Wingull", "Wingull", "갈모매", "长翅鸥" }; break;
                case 279: allnames = new string[] { "ペリッパー", "Pelipper", "Bekipan", "Pelipper", "Pelipper", "Pelipper", "패리퍼", "大嘴鸥" }; break;
                case 280: allnames = new string[] { "ラルトス", "Ralts", "Tarsal", "Ralts", "Trasla", "Ralts", "랄토스", "拉鲁拉丝" }; break;
                case 281: allnames = new string[] { "キルリア", "Kirlia", "Kirlia", "Kirlia", "Kirlia", "Kirlia", "킬리아", "奇鲁莉安" }; break;
                case 282: allnames = new string[] { "サーナイト", "Gardevoir", "Gardevoir", "Gardevoir", "Guardevoir", "Gardevoir", "가디안", "沙奈朵" }; break;
                case 283: allnames = new string[] { "アメタマ", "Surskit", "Arakdo", "Surskit", "Gehweiher", "Surskit", "비구술", "溜溜糖球" }; break;
                case 284: allnames = new string[] { "アメモース", "Masquerain", "Maskadra", "Masquerain", "Maskeregen", "Masquerain", "비나방", "雨翅蛾" }; break;
                case 285: allnames = new string[] { "キノココ", "Shroomish", "Balignon", "Shroomish", "Knilz", "Shroomish", "버섯꼬", "蘑蘑菇" }; break;
                case 286: allnames = new string[] { "キノガッサ", "Breloom", "Chapignon", "Breloom", "Kapilz", "Breloom", "버섯모", "斗笠菇" }; break;
                case 287: allnames = new string[] { "ナマケロ", "Slakoth", "Parecool", "Slakoth", "Bummelz", "Slakoth", "게을로", "懒人獭" }; break;
                case 288: allnames = new string[] { "ヤルキモノ", "Vigoroth", "Vigoroth", "Vigoroth", "Muntier", "Vigoroth", "발바로", "过动猿" }; break;
                case 289: allnames = new string[] { "ケッキング", "Slaking", "Monaflèmit", "Slaking", "Letarking", "Slaking", "게을킹", "请假王" }; break;
                case 290: allnames = new string[] { "ツチニン", "Nincada", "Ningale", "Nincada", "Nincada", "Nincada", "토중몬", "土居忍士" }; break;
                case 291: allnames = new string[] { "テッカニン", "Ninjask", "Ninjask", "Ninjask", "Ninjask", "Ninjask", "아이스크", "铁面忍者" }; break;
                case 292: allnames = new string[] { "ヌケニン", "Shedinja", "Munja", "Shedinja", "Ninjatom", "Shedinja", "껍질몬", "脱壳忍者" }; break;
                case 293: allnames = new string[] { "ゴニョニョ", "Whismur", "Chuchmur", "Whismur", "Flurmel", "Whismur", "소곤룡", "咕妞妞" }; break;
                case 294: allnames = new string[] { "ドゴーム", "Loudred", "Ramboum", "Loudred", "Krakeelo", "Loudred", "노공룡", "吼爆弹" }; break;
                case 295: allnames = new string[] { "バクオング", "Exploud", "Brouhabam", "Exploud", "Krawumms", "Exploud", "폭음룡", "爆音怪" }; break;
                case 296: allnames = new string[] { "マクノシタ", "Makuhita", "Makuhita", "Makuhita", "Makuhita", "Makuhita", "마크탕", "幕下力士" }; break;
                case 297: allnames = new string[] { "ハリテヤマ", "Hariyama", "Hariyama", "Hariyama", "Hariyama", "Hariyama", "하리뭉", "铁掌力士" }; break;
                case 298: allnames = new string[] { "ルリリ", "Azurill", "Azurill", "Azurill", "Azurill", "Azurill", "루리리", "露力丽" }; break;
                case 299: allnames = new string[] { "ノズパス", "Nosepass", "Tarinor", "Nosepass", "Nasgnet", "Nosepass", "코코파스", "朝北鼻" }; break;
                case 300: allnames = new string[] { "エネコ", "Skitty", "Skitty", "Skitty", "Eneco", "Skitty", "에나비", "向尾喵" }; break;
                case 301: allnames = new string[] { "エネコロロ", "Delcatty", "Delcatty", "Delcatty", "Enekoro", "Delcatty", "델케티", "优雅猫" }; break;
                case 302: allnames = new string[] { "ヤミラミ", "Sableye", "Ténéfix", "Sableye", "Zobiris", "Sableye", "깜까미", "勾魂眼" }; break;
                case 303: allnames = new string[] { "クチート", "Mawile", "Mysdibule", "Mawile", "Flunkifer", "Mawile", "입치트", "大嘴娃" }; break;
                case 304: allnames = new string[] { "ココドラ", "Aron", "Galekid", "Aron", "Stollunior", "Aron", "가보리", "可可多拉" }; break;
                case 305: allnames = new string[] { "コドラ", "Lairon", "Galegon", "Lairon", "Stollrak", "Lairon", "갱도라", "可多拉" }; break;
                case 306: allnames = new string[] { "ボスゴドラ", "Aggron", "Galeking", "Aggron", "Stolloss", "Aggron", "보스로라", "波士可多拉" }; break;
                case 307: allnames = new string[] { "アサナン", "Meditite", "Méditikka", "Meditite", "Meditie", "Meditite", "요가랑", "玛沙那" }; break;
                case 308: allnames = new string[] { "チャーレム", "Medicham", "Charmina", "Medicham", "Meditalis", "Medicham", "요가램", "恰雷姆" }; break;
                case 309: allnames = new string[] { "ラクライ", "Electrike", "Dynavolt", "Electrike", "Frizelbliz", "Electrike", "썬더라이", "落雷兽" }; break;
                case 310: allnames = new string[] { "ライボルト", "Manectric", "Élecsprint", "Manectric", "Voltenso", "Manectric", "썬더볼트", "雷电兽" }; break;
                case 311: allnames = new string[] { "プラスル", "Plusle", "Posipi", "Plusle", "Plusle", "Plusle", "플러시", "正电拍拍" }; break;
                case 312: allnames = new string[] { "マイナン", "Minun", "Négapi", "Minun", "Minun", "Minun", "마이농", "负电拍拍" }; break;
                case 313: allnames = new string[] { "バルビート", "Volbeat", "Muciole", "Volbeat", "Volbeat", "Volbeat", "볼비트", "电萤虫" }; break;
                case 314: allnames = new string[] { "イルミーゼ", "Illumise", "Lumivole", "Illumise", "Illumise", "Illumise", "네오비트", "甜甜萤" }; break;
                case 315: allnames = new string[] { "ロゼリア", "Roselia", "Rosélia", "Roselia", "Roselia", "Roselia", "로젤리아", "毒蔷薇" }; break;
                case 316: allnames = new string[] { "ゴクリン", "Gulpin", "Gloupti", "Gulpin", "Schluppuck", "Gulpin", "꼴깍몬", "溶食兽" }; break;
                case 317: allnames = new string[] { "マルノーム", "Swalot", "Avaltout", "Swalot", "Schlukwech", "Swalot", "꿀꺽몬", "吞食兽" }; break;
                case 318: allnames = new string[] { "キバニア", "Carvanha", "Carvanha", "Carvanha", "Kanivanha", "Carvanha", "샤프니아", "利牙鱼" }; break;
                case 319: allnames = new string[] { "サメハダー", "Sharpedo", "Sharpedo", "Sharpedo", "Tohaido", "Sharpedo", "샤크니아", "巨牙鲨" }; break;
                case 320: allnames = new string[] { "ホエルコ", "Wailmer", "Wailmer", "Wailmer", "Wailmer", "Wailmer", "고래왕자", "吼吼鲸" }; break;
                case 321: allnames = new string[] { "ホエルオー", "Wailord", "Wailord", "Wailord", "Wailord", "Wailord", "고래왕", "吼鲸王" }; break;
                case 322: allnames = new string[] { "ドンメル", "Numel", "Chamallot", "Numel", "Camaub", "Numel", "둔타", "呆火驼" }; break;
                case 323: allnames = new string[] { "バクーダ", "Camerupt", "Camérupt", "Camerupt", "Camerupt", "Camerupt", "폭타", "喷火驼" }; break;
                case 324: allnames = new string[] { "コータス", "Torkoal", "Chartor", "Torkoal", "Qurtel", "Torkoal", "코터스", "煤炭龟" }; break;
                case 325: allnames = new string[] { "バネブー", "Spoink", "Spoink", "Spoink", "Spoink", "Spoink", "피그점프", "跳跳猪" }; break;
                case 326: allnames = new string[] { "ブーピッグ", "Grumpig", "Groret", "Grumpig", "Groink", "Grumpig", "피그킹", "噗噗猪" }; break;
                case 327: allnames = new string[] { "パッチール", "Spinda", "Spinda", "Spinda", "Pandir", "Spinda", "얼루기", "晃晃斑" }; break;
                case 328: allnames = new string[] { "ナックラー", "Trapinch", "Kraknoix", "Trapinch", "Knacklion", "Trapinch", "톱치", "大颚蚁" }; break;
                case 329: allnames = new string[] { "ビブラーバ", "Vibrava", "Vibraninf", "Vibrava", "Vibrava", "Vibrava", "비브라바", "超音波幼虫" }; break;
                case 330: allnames = new string[] { "フライゴン", "Flygon", "Libégon", "Flygon", "Libelldra", "Flygon", "플라이곤", "沙漠蜻蜓" }; break;
                case 331: allnames = new string[] { "サボネア", "Cacnea", "Cacnea", "Cacnea", "Tuska", "Cacnea", "선인왕", "刺球仙人掌" }; break;
                case 332: allnames = new string[] { "ノクタス", "Cacturne", "Cacturne", "Cacturne", "Noktuska", "Cacturne", "밤선인", "梦歌仙人掌" }; break;
                case 333: allnames = new string[] { "チルット", "Swablu", "Tylton", "Swablu", "Wablu", "Swablu", "파비코", "青绵鸟" }; break;
                case 334: allnames = new string[] { "チルタリス", "Altaria", "Altaria", "Altaria", "Altaria", "Altaria", "파비코리", "七夕青鸟" }; break;
                case 335: allnames = new string[] { "ザングース", "Zangoose", "Mangriff", "Zangoose", "Sengo", "Zangoose", "쟝고", "猫鼬斩" }; break;
                case 336: allnames = new string[] { "ハブネーク", "Seviper", "Séviper", "Seviper", "Vipitis", "Seviper", "세비퍼", "饭匙蛇" }; break;
                case 337: allnames = new string[] { "ルナトーン", "Lunatone", "Séléroc", "Lunatone", "Lunastein", "Lunatone", "루나톤", "月石" }; break;
                case 338: allnames = new string[] { "ソルロック", "Solrock", "Solaroc", "Solrock", "Sonnfel", "Solrock", "솔록", "太阳岩" }; break;
                case 339: allnames = new string[] { "ドジョッチ", "Barboach", "Barloche", "Barboach", "Schmerbe", "Barboach", "미꾸리", "泥泥鳅" }; break;
                case 340: allnames = new string[] { "ナマズン", "Whiscash", "Barbicha", "Whiscash", "Welsar", "Whiscash", "메깅", "鲶鱼王" }; break;
                case 341: allnames = new string[] { "ヘイガニ", "Corphish", "Écrapince", "Corphish", "Krebscorps", "Corphish", "가재군", "龙虾小兵" }; break;
                case 342: allnames = new string[] { "シザリガー", "Crawdaunt", "Colhomard", "Crawdaunt", "Krebutack", "Crawdaunt", "가재장군", "铁螯龙虾" }; break;
                case 343: allnames = new string[] { "ヤジロン", "Baltoy", "Balbuto", "Baltoy", "Puppance", "Baltoy", "오뚝군", "天秤偶" }; break;
                case 344: allnames = new string[] { "ネンドール", "Claydol", "Kaorine", "Claydol", "Lepumentas", "Claydol", "점토도리", "念力土偶" }; break;
                case 345: allnames = new string[] { "リリーラ", "Lileep", "Lilia", "Lileep", "Liliep", "Lileep", "릴링", "触手百合" }; break;
                case 346: allnames = new string[] { "ユレイドル", "Cradily", "Vacilys", "Cradily", "Wielie", "Cradily", "릴리요", "摇篮百合" }; break;
                case 347: allnames = new string[] { "アノプス", "Anorith", "Anorith", "Anorith", "Anorith", "Anorith", "아노딥스", "太古羽虫" }; break;
                case 348: allnames = new string[] { "アーマルド", "Armaldo", "Armaldo", "Armaldo", "Armaldo", "Armaldo", "아말도", "太古盔甲" }; break;
                case 349: allnames = new string[] { "ヒンバス", "Feebas", "Barpau", "Feebas", "Barschwa", "Feebas", "빈티나", "丑丑鱼" }; break;
                case 350: allnames = new string[] { "ミロカロス", "Milotic", "Milobellus", "Milotic", "Milotic", "Milotic", "밀로틱", "美纳斯" }; break;
                case 351: allnames = new string[] { "ポワルン", "Castform", "Morphéo", "Castform", "Formeo", "Castform", "캐스퐁", "飘浮泡泡" }; break;
                case 352: allnames = new string[] { "カクレオン", "Kecleon", "Kecleon", "Kecleon", "Kecleon", "Kecleon", "켈리몬", "变隐龙" }; break;
                case 353: allnames = new string[] { "カゲボウズ", "Shuppet", "Polichombr", "Shuppet", "Shuppet", "Shuppet", "어둠대신", "怨影娃娃" }; break;
                case 354: allnames = new string[] { "ジュペッタ", "Banette", "Branette", "Banette", "Banette", "Banette", "다크펫", "诅咒娃娃" }; break;
                case 355: allnames = new string[] { "ヨマワル", "Duskull", "Skelénox", "Duskull", "Zwirrlicht", "Duskull", "해골몽", "夜巡灵" }; break;
                case 356: allnames = new string[] { "サマヨール", "Dusclops", "Téraclope", "Dusclops", "Zwirrklop", "Dusclops", "미라몽", "彷徨夜灵" }; break;
                case 357: allnames = new string[] { "トロピウス", "Tropius", "Tropius", "Tropius", "Tropius", "Tropius", "트로피우스", "热带龙" }; break;
                case 358: allnames = new string[] { "チリーン", "Chimecho", "Éoko", "Chimecho", "Palimpalim", "Chimecho", "치렁", "风铃铃" }; break;
                case 359: allnames = new string[] { "アブソル", "Absol", "Absol", "Absol", "Absol", "Absol", "앱솔", "阿勃梭鲁" }; break;
                case 360: allnames = new string[] { "ソーナノ", "Wynaut", "Okéoké", "Wynaut", "Isso", "Wynaut", "마자", "小果然" }; break;
                case 361: allnames = new string[] { "ユキワラシ", "Snorunt", "Stalgamin", "Snorunt", "Schneppke", "Snorunt", "눈꼬마", "雪童子" }; break;
                case 362: allnames = new string[] { "オニゴーリ", "Glalie", "Oniglali", "Glalie", "Firnontor", "Glalie", "얼음귀신", "冰鬼护" }; break;
                case 363: allnames = new string[] { "タマザラシ", "Spheal", "Obalie", "Spheal", "Seemops", "Spheal", "대굴레오", "海豹球" }; break;
                case 364: allnames = new string[] { "トドグラー", "Sealeo", "Phogleur", "Sealeo", "Seejong", "Sealeo", "씨레오", "海魔狮" }; break;
                case 365: allnames = new string[] { "トドゼルガ", "Walrein", "Kaimorse", "Walrein", "Walraisa", "Walrein", "씨카이저", "帝牙海狮" }; break;
                case 366: allnames = new string[] { "パールル", "Clamperl", "Coquiperl", "Clamperl", "Perlu", "Clamperl", "진주몽", "珍珠贝" }; break;
                case 367: allnames = new string[] { "ハンテール", "Huntail", "Serpang", "Huntail", "Aalabyss", "Huntail", "헌테일", "猎斑鱼" }; break;
                case 368: allnames = new string[] { "サクラビス", "Gorebyss", "Rosabyss", "Gorebyss", "Saganabyss", "Gorebyss", "분홍장이", "樱花鱼" }; break;
                case 369: allnames = new string[] { "ジーランス", "Relicanth", "Relicanth", "Relicanth", "Relicanth", "Relicanth", "시라칸", "古空棘鱼" }; break;
                case 370: allnames = new string[] { "ラブカス", "Luvdisc", "Lovdisc", "Luvdisc", "Liebiskus", "Luvdisc", "사랑동이", "爱心鱼" }; break;
                case 371: allnames = new string[] { "タツベイ", "Bagon", "Draby", "Bagon", "Kindwurm", "Bagon", "아공이", "宝贝龙" }; break;
                case 372: allnames = new string[] { "コモルー", "Shelgon", "Drackhaus", "Shelgon", "Draschel", "Shelgon", "쉘곤", "甲壳龙" }; break;
                case 373: allnames = new string[] { "ボーマンダ", "Salamence", "Drattak", "Salamence", "Brutalanda", "Salamence", "보만다", "暴飞龙" }; break;
                case 374: allnames = new string[] { "ダンバル", "Beldum", "Terhal", "Beldum", "Tanhel", "Beldum", "메탕", "铁哑铃" }; break;
                case 375: allnames = new string[] { "メタング", "Metang", "Métang", "Metang", "Metang", "Metang", "메탕구", "金属怪" }; break;
                case 376: allnames = new string[] { "メタグロス", "Metagross", "Métalosse", "Metagross", "Metagross", "Metagross", "메타그로스", "巨金怪" }; break;
                case 377: allnames = new string[] { "レジロック", "Regirock", "Regirock", "Regirock", "Regirock", "Regirock", "레지락", "雷吉洛克" }; break;
                case 378: allnames = new string[] { "レジアイス", "Regice", "Regice", "Regice", "Regice", "Regice", "레지아이스", "雷吉艾斯" }; break;
                case 379: allnames = new string[] { "レジスチル", "Registeel", "Registeel", "Registeel", "Registeel", "Registeel", "레지스틸", "雷吉斯奇鲁" }; break;
                case 380: allnames = new string[] { "ラティアス", "Latias", "Latias", "Latias", "Latias", "Latias", "라티아스", "拉帝亚斯" }; break;
                case 381: allnames = new string[] { "ラティオス", "Latios", "Latios", "Latios", "Latios", "Latios", "라티오스", "拉帝欧斯" }; break;
                case 382: allnames = new string[] { "カイオーガ", "Kyogre", "Kyogre", "Kyogre", "Kyogre", "Kyogre", "가이오가", "盖欧卡" }; break;
                case 383: allnames = new string[] { "グラードン", "Groudon", "Groudon", "Groudon", "Groudon", "Groudon", "그란돈", "固拉多" }; break;
                case 384: allnames = new string[] { "レックウザ", "Rayquaza", "Rayquaza", "Rayquaza", "Rayquaza", "Rayquaza", "레쿠쟈", "烈空坐" }; break;
                case 385: allnames = new string[] { "ジラーチ", "Jirachi", "Jirachi", "Jirachi", "Jirachi", "Jirachi", "지라치", "基拉祈" }; break;
                case 386: allnames = new string[] { "デオキシス", "Deoxys", "Deoxys", "Deoxys", "Deoxys", "Deoxys", "테오키스", "代欧奇希斯" }; break;
                case 387: allnames = new string[] { "ナエトル", "Turtwig", "Tortipouss", "Turtwig", "Chelast", "Turtwig", "모부기", "草苗龟" }; break;
                case 388: allnames = new string[] { "ハヤシガメ", "Grotle", "Boskara", "Grotle", "Chelcarain", "Grotle", "수풀부기", "树林龟" }; break;
                case 389: allnames = new string[] { "ドダイトス", "Torterra", "Torterra", "Torterra", "Chelterrar", "Torterra", "토대부기", "土台龟" }; break;
                case 390: allnames = new string[] { "ヒコザル", "Chimchar", "Ouisticram", "Chimchar", "Panflam", "Chimchar", "불꽃숭이", "小火焰猴" }; break;
                case 391: allnames = new string[] { "モウカザル", "Monferno", "Chimpenfeu", "Monferno", "Panpyro", "Monferno", "파이숭이", "猛火猴" }; break;
                case 392: allnames = new string[] { "ゴウカザル", "Infernape", "Simiabraz", "Infernape", "Panferno", "Infernape", "초염몽", "烈焰猴" }; break;
                case 393: allnames = new string[] { "ポッチャマ", "Piplup", "Tiplouf", "Piplup", "Plinfa", "Piplup", "팽도리", "波加曼" }; break;
                case 394: allnames = new string[] { "ポッタイシ", "Prinplup", "Prinplouf", "Prinplup", "Pliprin", "Prinplup", "팽태자", "波皇子" }; break;
                case 395: allnames = new string[] { "エンペルト", "Empoleon", "Pingoléon", "Empoleon", "Impoleon", "Empoleon", "엠페르트", "帝王拿波" }; break;
                case 396: allnames = new string[] { "ムックル", "Starly", "Étourmi", "Starly", "Staralili", "Starly", "찌르꼬", "姆克儿" }; break;
                case 397: allnames = new string[] { "ムクバード", "Staravia", "Étourvol", "Staravia", "Staravia", "Staravia", "찌르버드", "姆克鸟" }; break;
                case 398: allnames = new string[] { "ムクホーク", "Staraptor", "Étouraptor", "Staraptor", "Staraptor", "Staraptor", "찌르호크", "姆克鹰" }; break;
                case 399: allnames = new string[] { "ビッパ", "Bidoof", "Keunotor", "Bidoof", "Bidiza", "Bidoof", "비버니", "大牙狸" }; break;
                case 400: allnames = new string[] { "ビーダル", "Bibarel", "Castorno", "Bibarel", "Bidifas", "Bibarel", "비버통", "大尾狸" }; break;
                case 401: allnames = new string[] { "コロボーシ", "Kricketot", "Crikzik", "Kricketot", "Zirpurze", "Kricketot", "귀뚤뚜기", "圆法师" }; break;
                case 402: allnames = new string[] { "コロトック", "Kricketune", "Mélokrik", "Kricketune", "Zirpeise", "Kricketune", "귀뚤톡크", "音箱蟀" }; break;
                case 403: allnames = new string[] { "コリンク", "Shinx", "Lixy", "Shinx", "Sheinux", "Shinx", "꼬링크", "小猫怪" }; break;
                case 404: allnames = new string[] { "ルクシオ", "Luxio", "Luxio", "Luxio", "Luxio", "Luxio", "럭시오", "勒克猫" }; break;
                case 405: allnames = new string[] { "レントラー", "Luxray", "Luxray", "Luxray", "Luxtra", "Luxray", "렌트라", "伦琴猫" }; break;
                case 406: allnames = new string[] { "スボミー", "Budew", "Rozbouton", "Budew", "Knospi", "Budew", "꼬몽울", "含羞苞" }; break;
                case 407: allnames = new string[] { "ロズレイド", "Roserade", "Roserade", "Roserade", "Roserade", "Roserade", "로즈레이드", "罗丝雷朵" }; break;
                case 408: allnames = new string[] { "ズガイドス", "Cranidos", "Kranidos", "Cranidos", "Koknodon", "Cranidos", "두개도스", "头盖龙" }; break;
                case 409: allnames = new string[] { "ラムパルド", "Rampardos", "Charkos", "Rampardos", "Rameidon", "Rampardos", "램펄드", "战槌龙" }; break;
                case 410: allnames = new string[] { "タテトプス", "Shieldon", "Dinoclier", "Shieldon", "Schilterus", "Shieldon", "방패톱스", "盾甲龙" }; break;
                case 411: allnames = new string[] { "トリデプス", "Bastiodon", "Bastiodon", "Bastiodon", "Bollterus", "Bastiodon", "바리톱스", "护城龙" }; break;
                case 412: allnames = new string[] { "ミノムッチ", "Burmy", "Cheniti", "Burmy", "Burmy", "Burmy", "도롱충이", "结草儿" }; break;
                case 413: allnames = new string[] { "ミノマダム", "Wormadam", "Cheniselle", "Wormadam", "Burmadame", "Wormadam", "도롱마담", "结草贵妇" }; break;
                case 414: allnames = new string[] { "ガーメイル", "Mothim", "Papilord", "Mothim", "Moterpel", "Mothim", "나메일", "绅士蛾" }; break;
                case 415: allnames = new string[] { "ミツハニー", "Combee", "Apitrini", "Combee", "Wadribie", "Combee", "세꿀버리", "三蜜蜂" }; break;
                case 416: allnames = new string[] { "ビークイン", "Vespiquen", "Apireine", "Vespiquen", "Honweisel", "Vespiquen", "비퀸", "蜂女王" }; break;
                case 417: allnames = new string[] { "パチリス", "Pachirisu", "Pachirisu", "Pachirisu", "Pachirisu", "Pachirisu", "파치리스", "帕奇利兹" }; break;
                case 418: allnames = new string[] { "ブイゼル", "Buizel", "Mustébouée", "Buizel", "Bamelin", "Buizel", "브이젤", "泳圈鼬" }; break;
                case 419: allnames = new string[] { "フローゼル", "Floatzel", "Mustéflott", "Floatzel", "Bojelin", "Floatzel", "플로젤", "浮潜鼬" }; break;
                case 420: allnames = new string[] { "チェリンボ", "Cherubi", "Ceribou", "Cherubi", "Kikugi", "Cherubi", "체리버", "樱花宝" }; break;
                case 421: allnames = new string[] { "チェリム", "Cherrim", "Ceriflor", "Cherrim", "Kinoso", "Cherrim", "체리꼬", "樱花儿" }; break;
                case 422: allnames = new string[] { "カラナクシ", "Shellos", "Sancoki", "Shellos", "Schalellos", "Shellos", "깝질무", "无壳海兔" }; break;
                case 423: allnames = new string[] { "トリトドン", "Gastrodon", "Tritosor", "Gastrodon", "Gastrodon", "Gastrodon", "트리토돈", "海兔兽" }; break;
                case 424: allnames = new string[] { "エテボース", "Ambipom", "Capidextre", "Ambipom", "Ambidiffel", "Ambipom", "겟핸보숭", "双尾怪手" }; break;
                case 425: allnames = new string[] { "フワンテ", "Drifloon", "Baudrive", "Drifloon", "Driftlon", "Drifloon", "흔들풍손", "飘飘球" }; break;
                case 426: allnames = new string[] { "フワライド", "Drifblim", "Grodrive", "Drifblim", "Drifzepeli", "Drifblim", "둥실라이드", "随风球" }; break;
                case 427: allnames = new string[] { "ミミロル", "Buneary", "Laporeille", "Buneary", "Haspiror", "Buneary", "이어롤", "卷卷耳" }; break;
                case 428: allnames = new string[] { "ミミロップ", "Lopunny", "Lockpin", "Lopunny", "Schlapor", "Lopunny", "이어롭", "长耳兔" }; break;
                case 429: allnames = new string[] { "ムウマージ", "Mismagius", "Magirêve", "Mismagius", "Traunmagil", "Mismagius", "무우마직", "梦妖魔" }; break;
                case 430: allnames = new string[] { "ドンカラス", "Honchkrow", "Corboss", "Honchkrow", "Kramshef", "Honchkrow", "돈크로우", "乌鸦头头" }; break;
                case 431: allnames = new string[] { "ニャルマー", "Glameow", "Chaglam", "Glameow", "Charmian", "Glameow", "나옹마", "魅力喵" }; break;
                case 432: allnames = new string[] { "ブニャット", "Purugly", "Chaffreux", "Purugly", "Shnurgarst", "Purugly", "몬냥이", "东施喵" }; break;
                case 433: allnames = new string[] { "リーシャン", "Chingling", "Korillon", "Chingling", "Klingplim", "Chingling", "랑딸랑", "铃铛响" }; break;
                case 434: allnames = new string[] { "スカンプー", "Stunky", "Moufouette", "Stunky", "Skunkapuh", "Stunky", "스컹뿡", "臭鼬噗" }; break;
                case 435: allnames = new string[] { "スカタンク", "Skuntank", "Moufflair", "Skuntank", "Skuntank", "Skuntank", "스컹탱크", "坦克臭鼬" }; break;
                case 436: allnames = new string[] { "ドーミラー", "Bronzor", "Archéomire", "Bronzor", "Bronzel", "Bronzor", "동미러", "铜镜怪" }; break;
                case 437: allnames = new string[] { "ドータクン", "Bronzong", "Archéodong", "Bronzong", "Bronzong", "Bronzong", "동탁군", "青铜钟" }; break;
                case 438: allnames = new string[] { "ウソハチ", "Bonsly", "Manzaï", "Bonsly", "Mobai", "Bonsly", "꼬지지", "盆才怪" }; break;
                case 439: allnames = new string[] { "マネネ", "Mime Jr.", "Mime Jr.", "Mime Jr.", "Pantimimi", "Mime Jr.", "흉내내", "魔尼尼" }; break;
                case 440: allnames = new string[] { "ピンプク", "Happiny", "Ptiravi", "Happiny", "Wonneira", "Happiny", "핑복", "小福蛋" }; break;
                case 441: allnames = new string[] { "ペラップ", "Chatot", "Pijako", "Chatot", "Plaudagei", "Chatot", "페라페", "聒噪鸟" }; break;
                case 442: allnames = new string[] { "ミカルゲ", "Spiritomb", "Spiritomb", "Spiritomb", "Kryppuk", "Spiritomb", "화강돌", "花岩怪" }; break;
                case 443: allnames = new string[] { "フカマル", "Gible", "Griknot", "Gible", "Kaumalat", "Gible", "딥상어동", "圆陆鲨" }; break;
                case 444: allnames = new string[] { "ガバイト", "Gabite", "Carmache", "Gabite", "Knarksel", "Gabite", "한바이트", "尖牙陆鲨" }; break;
                case 445: allnames = new string[] { "ガブリアス", "Garchomp", "Carchacrok", "Garchomp", "Knakrack", "Garchomp", "한카리아스", "烈咬陆鲨" }; break;
                case 446: allnames = new string[] { "ゴンベ", "Munchlax", "Goinfrex", "Munchlax", "Mampfaxo", "Munchlax", "먹고자", "小卡比兽" }; break;
                case 447: allnames = new string[] { "リオル", "Riolu", "Riolu", "Riolu", "Riolu", "Riolu", "리오르", "利欧路" }; break;
                case 448: allnames = new string[] { "ルカリオ", "Lucario", "Lucario", "Lucario", "Lucario", "Lucario", "루카리오", "路卡利欧" }; break;
                case 449: allnames = new string[] { "ヒポポタス", "Hippopotas", "Hippopotas", "Hippopotas", "Hippopotas", "Hippopotas", "히포포타스", "沙河马" }; break;
                case 450: allnames = new string[] { "カバルドン", "Hippowdon", "Hippodocus", "Hippowdon", "Hippoterus", "Hippowdon", "하마돈", "河马兽" }; break;
                case 451: allnames = new string[] { "スコルピ", "Skorupi", "Rapion", "Skorupi", "Pionskora", "Skorupi", "스콜피", "钳尾蝎" }; break;
                case 452: allnames = new string[] { "ドラピオン", "Drapion", "Drascore", "Drapion", "Piondragi", "Drapion", "드래피온", "龙王蝎" }; break;
                case 453: allnames = new string[] { "グレッグル", "Croagunk", "Cradopaud", "Croagunk", "Glibunkel", "Croagunk", "삐딱구리", "不良蛙" }; break;
                case 454: allnames = new string[] { "ドクロッグ", "Toxicroak", "Coatox", "Toxicroak", "Toxiquak", "Toxicroak", "독개굴", "毒骷蛙" }; break;
                case 455: allnames = new string[] { "マスキッパ", "Carnivine", "Vortente", "Carnivine", "Venuflibis", "Carnivine", "무스틈니", "尖牙笼" }; break;
                case 456: allnames = new string[] { "ケイコウオ", "Finneon", "Écayon", "Finneon", "Finneon", "Finneon", "형광어", "荧光鱼" }; break;
                case 457: allnames = new string[] { "ネオラント", "Lumineon", "Luminéon", "Lumineon", "Lumineon", "Lumineon", "네오라이트", "霓虹鱼" }; break;
                case 458: allnames = new string[] { "タマンタ", "Mantyke", "Babimanta", "Mantyke", "Mantirps", "Mantyke", "타만타", "小球飞鱼" }; break;
                case 459: allnames = new string[] { "ユキカブリ", "Snover", "Blizzi", "Snover", "Shnebedeck", "Snover", "눈쓰개", "雪笠怪" }; break;
                case 460: allnames = new string[] { "ユキノオー", "Abomasnow", "Blizzaroi", "Abomasnow", "Rexblisar", "Abomasnow", "눈설왕", "暴雪王" }; break;
                case 461: allnames = new string[] { "マニューラ", "Weavile", "Dimoret", "Weavile", "Snibunna", "Weavile", "포푸니라", "玛狃拉" }; break;
                case 462: allnames = new string[] { "ジバコイル", "Magnezone", "Magnézone", "Magnezone", "Magnezone", "Magnezone", "자포코일", "自爆磁怪" }; break;
                case 463: allnames = new string[] { "ベロベルト", "Lickilicky", "Coudlangue", "Lickilicky", "Schlurplek", "Lickilicky", "내룸벨트", "大舌舔" }; break;
                case 464: allnames = new string[] { "ドサイドン", "Rhyperior", "Rhinastoc", "Rhyperior", "Rihornior", "Rhyperior", "거대코뿌리", "超甲狂犀" }; break;
                case 465: allnames = new string[] { "モジャンボ", "Tangrowth", "Bouldeneu", "Tangrowth", "Tangoloss", "Tangrowth", "덩쿠림보", "巨蔓藤" }; break;
                case 466: allnames = new string[] { "エレキブル", "Electivire", "Élekable", "Electivire", "Elevoltek", "Electivire", "에레키블", "电击魔兽" }; break;
                case 467: allnames = new string[] { "ブーバーン", "Magmortar", "Maganon", "Magmortar", "Magbrant", "Magmortar", "마그마번", "鸭嘴炎兽" }; break;
                case 468: allnames = new string[] { "トゲキッス", "Togekiss", "Togekiss", "Togekiss", "Togekiss", "Togekiss", "토게키스", "波克基斯" }; break;
                case 469: allnames = new string[] { "メガヤンマ", "Yanmega", "Yanmega", "Yanmega", "Yanmega", "Yanmega", "메가자리", "远古巨蜓" }; break;
                case 470: allnames = new string[] { "リーフィア", "Leafeon", "Phyllali", "Leafeon", "Folipurba", "Leafeon", "리피아", "叶伊布" }; break;
                case 471: allnames = new string[] { "グレイシア", "Glaceon", "Givrali", "Glaceon", "Glaziola", "Glaceon", "글레이시아", "冰伊布" }; break;
                case 472: allnames = new string[] { "グライオン", "Gliscor", "Scorvol", "Gliscor", "Skorgro", "Gliscor", "글라이온", "天蝎王" }; break;
                case 473: allnames = new string[] { "マンムー", "Mamoswine", "Mammochon", "Mamoswine", "Mamutel", "Mamoswine", "맘모꾸리", "象牙猪" }; break;
                case 474: allnames = new string[] { "ポリゴンＺ", "Porygon-Z", "Porygon-Z", "Porygon-Z", "Porygon-Z", "Porygon-Z", "폴리곤Z", "多边兽Ｚ" }; break;
                case 475: allnames = new string[] { "エルレイド", "Gallade", "Gallame", "Gallade", "Galagladi", "Gallade", "엘레이드", "艾路雷朵" }; break;
                case 476: allnames = new string[] { "ダイノーズ", "Probopass", "Tarinorme", "Probopass", "Voluminas", "Probopass", "대코파스", "大朝北鼻" }; break;
                case 477: allnames = new string[] { "ヨノワール", "Dusknoir", "Noctunoir", "Dusknoir", "Zwirrfinst", "Dusknoir", "야느와르몽", "黑夜魔灵" }; break;
                case 478: allnames = new string[] { "ユキメノコ", "Froslass", "Momartik", "Froslass", "Frosdedje", "Froslass", "눈여아", "雪妖女" }; break;
                case 479: allnames = new string[] { "ロトム", "Rotom", "Motisma", "Rotom", "Rotom", "Rotom", "로토무", "洛托姆" }; break;
                case 480: allnames = new string[] { "ユクシー", "Uxie", "Créhelf", "Uxie", "Selfe", "Uxie", "유크시", "由克希" }; break;
                case 481: allnames = new string[] { "エムリット", "Mesprit", "Créfollet", "Mesprit", "Vesprit", "Mesprit", "엠라이트", "艾姆利多" }; break;
                case 482: allnames = new string[] { "アグノム", "Azelf", "Créfadet", "Azelf", "Tobutz", "Azelf", "아그놈", "亚克诺姆" }; break;
                case 483: allnames = new string[] { "ディアルガ", "Dialga", "Dialga", "Dialga", "Dialga", "Dialga", "디아루가", "帝牙卢卡" }; break;
                case 484: allnames = new string[] { "パルキア", "Palkia", "Palkia", "Palkia", "Palkia", "Palkia", "펄기아", "帕路奇亚" }; break;
                case 485: allnames = new string[] { "ヒードラン", "Heatran", "Heatran", "Heatran", "Heatran", "Heatran", "히드런", "席多蓝恩" }; break;
                case 486: allnames = new string[] { "レジギガス", "Regigigas", "Regigigas", "Regigigas", "Regigigas", "Regigigas", "레지기가스", "雷吉奇卡斯" }; break;
                case 487: allnames = new string[] { "ギラティナ", "Giratina", "Giratina", "Giratina", "Giratina", "Giratina", "기라티나", "骑拉帝纳" }; break;
                case 488: allnames = new string[] { "クレセリア", "Cresselia", "Cresselia", "Cresselia", "Cresselia", "Cresselia", "크레세리아", "克雷色利亚" }; break;
                case 489: allnames = new string[] { "フィオネ", "Phione", "Phione", "Phione", "Phione", "Phione", "피오네", "霏欧纳" }; break;
                case 490: allnames = new string[] { "マナフィ", "Manaphy", "Manaphy", "Manaphy", "Manaphy", "Manaphy", "마나피", "玛纳霏" }; break;
                case 491: allnames = new string[] { "ダークライ", "Darkrai", "Darkrai", "Darkrai", "Darkrai", "Darkrai", "다크라이", "达克莱伊" }; break;
                case 492: allnames = new string[] { "シェイミ", "Shaymin", "Shaymin", "Shaymin", "Shaymin", "Shaymin", "쉐이미", "谢米" }; break;
                case 493: allnames = new string[] { "アルセウス", "Arceus", "Arceus", "Arceus", "Arceus", "Arceus", "아르세우스", "阿尔宙斯" }; break;
                case 494: allnames = new string[] { "ビクティニ", "Victini", "Victini", "Victini", "Victini", "Victini", "비크티니", "比克提尼" }; break;
                case 495: allnames = new string[] { "ツタージャ", "Snivy", "Vipélierre", "Snivy", "Serpifeu", "Snivy", "주리비얀", "藤藤蛇" }; break;
                case 496: allnames = new string[] { "ジャノビー", "Servine", "Lianaja", "Servine", "Efoserp", "Servine", "샤비", "青藤蛇" }; break;
                case 497: allnames = new string[] { "ジャローダ", "Serperior", "Majaspic", "Serperior", "Serpiroyal", "Serperior", "샤로다", "君主蛇" }; break;
                case 498: allnames = new string[] { "ポカブ", "Tepig", "Gruikui", "Tepig", "Floink", "Tepig", "뚜꾸리", "暖暖猪" }; break;
                case 499: allnames = new string[] { "チャオブー", "Pignite", "Grotichon", "Pignite", "Ferkokel", "Pignite", "차오꿀", "炒炒猪" }; break;
                case 500: allnames = new string[] { "エンブオー", "Emboar", "Roitiflam", "Emboar", "Flambirex", "Emboar", "염무왕", "炎武王" }; break;
                case 501: allnames = new string[] { "ミジュマル", "Oshawott", "Moustillon", "Oshawott", "Ottaro", "Oshawott", "수댕이", "水水獭" }; break;
                case 502: allnames = new string[] { "フタチマル", "Dewott", "Mateloutre", "Dewott", "Zwottronin", "Dewott", "쌍검자비", "双刃丸" }; break;
                case 503: allnames = new string[] { "ダイケンキ", "Samurott", "Clamiral", "Samurott", "Admurai", "Samurott", "대검귀", "大剑鬼" }; break;
                case 504: allnames = new string[] { "ミネズミ", "Patrat", "Ratentif", "Patrat", "Nagelotz", "Patrat", "보르쥐", "探探鼠" }; break;
                case 505: allnames = new string[] { "ミルホッグ", "Watchog", "Miradar", "Watchog", "Kukmarda", "Watchog", "보르그", "步哨鼠" }; break;
                case 506: allnames = new string[] { "ヨーテリー", "Lillipup", "Ponchiot", "Lillipup", "Yorkleff", "Lillipup", "요테리", "小约克" }; break;
                case 507: allnames = new string[] { "ハーデリア", "Herdier", "Ponchien", "Herdier", "Terribark", "Herdier", "하데리어", "哈约克" }; break;
                case 508: allnames = new string[] { "ムーランド", "Stoutland", "Mastouffe", "Stoutland", "Bissbark", "Stoutland", "바랜드", "长毛狗" }; break;
                case 509: allnames = new string[] { "チョロネコ", "Purrloin", "Chacripan", "Purrloin", "Felilou", "Purrloin", "쌔비냥", "扒手猫" }; break;
                case 510: allnames = new string[] { "レパルダス", "Liepard", "Léopardus", "Liepard", "Kleoparda", "Liepard", "레파르다스", "酷豹" }; break;
                case 511: allnames = new string[] { "ヤナップ", "Pansage", "Feuillajou", "Pansage", "Vegimak", "Pansage", "야나프", "花椰猴" }; break;
                case 512: allnames = new string[] { "ヤナッキー", "Simisage", "Feuiloutan", "Simisage", "Vegichita", "Simisage", "야나키", "花椰猿" }; break;
                case 513: allnames = new string[] { "バオップ", "Pansear", "Flamajou", "Pansear", "Grillmak", "Pansear", "바오프", "爆香猴" }; break;
                case 514: allnames = new string[] { "バオッキー", "Simisear", "Flamoutan", "Simisear", "Grillchita", "Simisear", "바오키", "爆香猿" }; break;
                case 515: allnames = new string[] { "ヒヤップ", "Panpour", "Flotajou", "Panpour", "Sodamak", "Panpour", "앗차프", "冷水猴" }; break;
                case 516: allnames = new string[] { "ヒヤッキー", "Simipour", "Flotoutan", "Simipour", "Sodachita", "Simipour", "앗차키", "冷水猿" }; break;
                case 517: allnames = new string[] { "ムンナ", "Munna", "Munna", "Munna", "Somniam", "Munna", "몽나", "食梦梦" }; break;
                case 518: allnames = new string[] { "ムシャーナ", "Musharna", "Mushana", "Musharna", "Somnivora", "Musharna", "몽얌나", "梦梦蚀" }; break;
                case 519: allnames = new string[] { "マメパト", "Pidove", "Poichigeon", "Pidove", "Dusselgurr", "Pidove", "콩둘기", "豆豆鸽" }; break;
                case 520: allnames = new string[] { "ハトーボー", "Tranquill", "Colombeau", "Tranquill", "Navitaub", "Tranquill", "유토브", "咕咕鸽" }; break;
                case 521: allnames = new string[] { "ケンホロウ", "Unfezant", "Déflaisan", "Unfezant", "Fasasnob", "Unfezant", "켄호로우", "高傲雉鸡" }; break;
                case 522: allnames = new string[] { "シママ", "Blitzle", "Zébibron", "Blitzle", "Elezeba", "Blitzle", "줄뮤마", "斑斑马" }; break;
                case 523: allnames = new string[] { "ゼブライカ", "Zebstrika", "Zéblitz", "Zebstrika", "Zebritz", "Zebstrika", "제브라이카", "雷电斑马" }; break;
                case 524: allnames = new string[] { "ダンゴロ", "Roggenrola", "Nodulithe", "Roggenrola", "Kiesling", "Roggenrola", "단굴", "石丸子" }; break;
                case 525: allnames = new string[] { "ガントル", "Boldore", "Géolithe", "Boldore", "Sedimantur", "Boldore", "암트르", "地幔岩" }; break;
                case 526: allnames = new string[] { "ギガイアス", "Gigalith", "Gigalithe", "Gigalith", "Brockoloss", "Gigalith", "기가이어스", "庞岩怪" }; break;
                case 527: allnames = new string[] { "コロモリ", "Woobat", "Chovsourir", "Woobat", "Fleknoil", "Woobat", "또르박쥐", "滚滚蝙蝠" }; break;
                case 528: allnames = new string[] { "ココロモリ", "Swoobat", "Rhinolove", "Swoobat", "Fletiamo", "Swoobat", "맘박쥐", "心蝙蝠" }; break;
                case 529: allnames = new string[] { "モグリュー", "Drilbur", "Rototaupe", "Drilbur", "Rotomurf", "Drilbur", "두더류", "螺钉地鼠" }; break;
                case 530: allnames = new string[] { "ドリュウズ", "Excadrill", "Minotaupe", "Excadrill", "Stalobor", "Excadrill", "몰드류", "龙头地鼠" }; break;
                case 531: allnames = new string[] { "タブンネ", "Audino", "Nanméouïe", "Audino", "Ohrdoch", "Audino", "다부니", "差不多娃娃" }; break;
                case 532: allnames = new string[] { "ドッコラー", "Timburr", "Charpenti", "Timburr", "Praktibalk", "Timburr", "으랏차", "搬运小匠" }; break;
                case 533: allnames = new string[] { "ドテッコツ", "Gurdurr", "Ouvrifier", "Gurdurr", "Strepoli", "Gurdurr", "토쇠골", "铁骨土人" }; break;
                case 534: allnames = new string[] { "ローブシン", "Conkeldurr", "Bétochef", "Conkeldurr", "Meistagrif", "Conkeldurr", "노보청", "修建老匠" }; break;
                case 535: allnames = new string[] { "オタマロ", "Tympole", "Tritonde", "Tympole", "Schallquap", "Tympole", "동챙이", "圆蝌蚪" }; break;
                case 536: allnames = new string[] { "ガマガル", "Palpitoad", "Batracné", "Palpitoad", "Mebrana", "Palpitoad", "두까비", "蓝蟾蜍" }; break;
                case 537: allnames = new string[] { "ガマゲロゲ", "Seismitoad", "Crapustule", "Seismitoad", "Branawarz", "Seismitoad", "두빅굴", "蟾蜍王" }; break;
                case 538: allnames = new string[] { "ナゲキ", "Throh", "Judokrak", "Throh", "Jiutesto", "Throh", "던지미", "投摔鬼" }; break;
                case 539: allnames = new string[] { "ダゲキ", "Sawk", "Karaclée", "Sawk", "Karadonis", "Sawk", "타격귀", "打击鬼" }; break;
                case 540: allnames = new string[] { "クルミル", "Sewaddle", "Larveyette", "Sewaddle", "Strawickl", "Sewaddle", "두르보", "虫宝包" }; break;
                case 541: allnames = new string[] { "クルマユ", "Swadloon", "Couverdure", "Swadloon", "Folikon", "Swadloon", "두르쿤", "宝包茧" }; break;
                case 542: allnames = new string[] { "ハハコモリ", "Leavanny", "Manternel", "Leavanny", "Matrifol", "Leavanny", "모아머", "保姆虫" }; break;
                case 543: allnames = new string[] { "フシデ", "Venipede", "Venipatte", "Venipede", "Toxiped", "Venipede", "마디네", "百足蜈蚣" }; break;
                case 544: allnames = new string[] { "ホイーガ", "Whirlipede", "Scobolide", "Whirlipede", "Rollum", "Whirlipede", "휠구", "车轮球" }; break;
                case 545: allnames = new string[] { "ペンドラー", "Scolipede", "Brutapode", "Scolipede", "Cerapendra", "Scolipede", "펜드라", "蜈蚣王" }; break;
                case 546: allnames = new string[] { "モンメン", "Cottonee", "Doudouvet", "Cottonee", "Waumboll", "Cottonee", "소미안", "木棉球" }; break;
                case 547: allnames = new string[] { "エルフーン", "Whimsicott", "Farfaduvet", "Whimsicott", "Elfun", "Whimsicott", "엘풍", "风妖精" }; break;
                case 548: allnames = new string[] { "チュリネ", "Petilil", "Chlorobule", "Petilil", "Lilminip", "Petilil", "치릴리", "百合根娃娃" }; break;
                case 549: allnames = new string[] { "ドレディア", "Lilligant", "Fragilady", "Lilligant", "Dressella", "Lilligant", "드레디어", "裙儿小姐" }; break;
                case 550: allnames = new string[] { "バスラオ", "Basculin", "Bargantua", "Basculin", "Barschuft", "Basculin", "배쓰나이", "野蛮鲈鱼" }; break;
                case 551: allnames = new string[] { "メグロコ", "Sandile", "Mascaïman", "Sandile", "Ganovil", "Sandile", "깜눈크", "黑眼鳄" }; break;
                case 552: allnames = new string[] { "ワルビル", "Krokorok", "Escroco", "Krokorok", "Rokkaiman", "Krokorok", "악비르", "混混鳄" }; break;
                case 553: allnames = new string[] { "ワルビアル", "Krookodile", "Crocorible", "Krookodile", "Rabigator", "Krookodile", "악비아르", "流氓鳄" }; break;
                case 554: allnames = new string[] { "ダルマッカ", "Darumaka", "Darumarond", "Darumaka", "Flampion", "Darumaka", "달막화", "火红不倒翁" }; break;
                case 555: allnames = new string[] { "ヒヒダルマ", "Darmanitan", "Darumacho", "Darmanitan", "Flampivian", "Darmanitan", "불비달마", "达摩狒狒" }; break;
                case 556: allnames = new string[] { "マラカッチ", "Maractus", "Maracachi", "Maractus", "Maracamba", "Maractus", "마라카치", "沙铃仙人掌" }; break;
                case 557: allnames = new string[] { "イシズマイ", "Dwebble", "Crabicoque", "Dwebble", "Lithomith", "Dwebble", "돌살이", "石居蟹" }; break;
                case 558: allnames = new string[] { "イワパレス", "Crustle", "Crabaraque", "Crustle", "Castellith", "Crustle", "암팰리스", "岩殿居蟹" }; break;
                case 559: allnames = new string[] { "ズルッグ", "Scraggy", "Baggiguane", "Scraggy", "Zurrokex", "Scraggy", "곤율랭", "滑滑小子" }; break;
                case 560: allnames = new string[] { "ズルズキン", "Scrafty", "Baggaïd", "Scrafty", "Irokex", "Scrafty", "곤율거니", "头巾混混" }; break;
                case 561: allnames = new string[] { "シンボラー", "Sigilyph", "Cryptéro", "Sigilyph", "Symvolara", "Sigilyph", "심보러", "象征鸟" }; break;
                case 562: allnames = new string[] { "デスマス", "Yamask", "Tutafeh", "Yamask", "Makabaja", "Yamask", "데스마스", "哭哭面具" }; break;
                case 563: allnames = new string[] { "デスカーン", "Cofagrigus", "Tutankafer", "Cofagrigus", "Echnatoll", "Cofagrigus", "데스니칸", "死神棺" }; break;
                case 564: allnames = new string[] { "プロトーガ", "Tirtouga", "Carapagos", "Tirtouga", "Galapaflos", "Tirtouga", "프로토가", "原盖海龟" }; break;
                case 565: allnames = new string[] { "アバゴーラ", "Carracosta", "Mégapagos", "Carracosta", "Karippas", "Carracosta", "늑골라", "肋骨海龟" }; break;
                case 566: allnames = new string[] { "アーケン", "Archen", "Arkéapti", "Archen", "Flapteryx", "Archen", "아켄", "始祖小鸟" }; break;
                case 567: allnames = new string[] { "アーケオス", "Archeops", "Aéroptéryx", "Archeops", "Aeropteryx", "Archeops", "아케오스", "始祖大鸟" }; break;
                case 568: allnames = new string[] { "ヤブクロン", "Trubbish", "Miamiasme", "Trubbish", "Unratütox", "Trubbish", "깨봉이", "破破袋" }; break;
                case 569: allnames = new string[] { "ダストダス", "Garbodor", "Miasmax", "Garbodor", "Deponitox", "Garbodor", "더스트나", "灰尘山" }; break;
                case 570: allnames = new string[] { "ゾロア", "Zorua", "Zorua", "Zorua", "Zorua", "Zorua", "조로아", "索罗亚" }; break;
                case 571: allnames = new string[] { "ゾロアーク", "Zoroark", "Zoroark", "Zoroark", "Zoroark", "Zoroark", "조로아크", "索罗亚克" }; break;
                case 572: allnames = new string[] { "チラーミィ", "Minccino", "Chinchidou", "Minccino", "Picochilla", "Minccino", "치라미", "泡沫栗鼠" }; break;
                case 573: allnames = new string[] { "チラチーノ", "Cinccino", "Pashmilla", "Cinccino", "Chillabell", "Cinccino", "치라치노", "奇诺栗鼠" }; break;
                case 574: allnames = new string[] { "ゴチム", "Gothita", "Scrutella", "Gothita", "Mollimorba", "Gothita", "고디탱", "哥德宝宝" }; break;
                case 575: allnames = new string[] { "ゴチミル", "Gothorita", "Mesmérella", "Gothorita", "Hypnomorba", "Gothorita", "고디보미", "哥德小童" }; break;
                case 576: allnames = new string[] { "ゴチルゼル", "Gothitelle", "Sidérella", "Gothitelle", "Morbitesse", "Gothitelle", "고디모아젤", "哥德小姐" }; break;
                case 577: allnames = new string[] { "ユニラン", "Solosis", "Nucléos", "Solosis", "Monozyto", "Solosis", "유니란", "单卵细胞球" }; break;
                case 578: allnames = new string[] { "ダブラン", "Duosion", "Méios", "Duosion", "Mitodos", "Duosion", "듀란", "双卵细胞球" }; break;
                case 579: allnames = new string[] { "ランクルス", "Reuniclus", "Symbios", "Reuniclus", "Zytomega", "Reuniclus", "란쿨루스", "人造细胞卵" }; break;
                case 580: allnames = new string[] { "コアルヒー", "Ducklett", "Couaneton", "Ducklett", "Piccolente", "Ducklett", "꼬지보리", "鸭宝宝" }; break;
                case 581: allnames = new string[] { "スワンナ", "Swanna", "Lakmécygne", "Swanna", "Swaroness", "Swanna", "스완나", "舞天鹅" }; break;
                case 582: allnames = new string[] { "バニプッチ", "Vanillite", "Sorbébé", "Vanillite", "Gelatini", "Vanillite", "바닐프티", "迷你冰" }; break;
                case 583: allnames = new string[] { "バニリッチ", "Vanillish", "Sorboul", "Vanillish", "Gelatroppo", "Vanillish", "바닐리치", "多多冰" }; break;
                case 584: allnames = new string[] { "バイバニラ", "Vanilluxe", "Sorbouboul", "Vanilluxe", "Gelatwino", "Vanilluxe", "배바닐라", "双倍多多冰" }; break;
                case 585: allnames = new string[] { "シキジカ", "Deerling", "Vivaldaim", "Deerling", "Sesokitz", "Deerling", "사철록", "四季鹿" }; break;
                case 586: allnames = new string[] { "メブキジカ", "Sawsbuck", "Haydaim", "Sawsbuck", "Kronjuwild", "Sawsbuck", "바라철록", "萌芽鹿" }; break;
                case 587: allnames = new string[] { "エモンガ", "Emolga", "Emolga", "Emolga", "Emolga", "Emolga", "에몽가", "电飞鼠" }; break;
                case 588: allnames = new string[] { "カブルモ", "Karrablast", "Carabing", "Karrablast", "Laukaps", "Karrablast", "딱정곤", "盖盖虫" }; break;
                case 589: allnames = new string[] { "シュバルゴ", "Escavalier", "Lançargot", "Escavalier", "Cavalanzas", "Escavalier", "슈바르고", "骑士蜗牛" }; break;
                case 590: allnames = new string[] { "タマゲタケ", "Foongus", "Trompignon", "Foongus", "Tarnpignon", "Foongus", "깜놀버슬", "哎呀球菇" }; break;
                case 591: allnames = new string[] { "モロバレル", "Amoonguss", "Gaulet", "Amoonguss", "Hutsassa", "Amoonguss", "뽀록나", "败露球菇" }; break;
                case 592: allnames = new string[] { "プルリル", "Frillish", "Viskuse", "Frillish", "Quabbel", "Frillish", "탱그릴", "轻飘飘" }; break;
                case 593: allnames = new string[] { "ブルンゲル", "Jellicent", "Moyade", "Jellicent", "Apoquallyp", "Jellicent", "탱탱겔", "胖嘟嘟" }; break;
                case 594: allnames = new string[] { "ママンボウ", "Alomomola", "Mamanbo", "Alomomola", "Mamolida", "Alomomola", "맘복치", "保姆曼波" }; break;
                case 595: allnames = new string[] { "バチュル", "Joltik", "Statitik", "Joltik", "Wattzapf", "Joltik", "파쪼옥", "电电虫" }; break;
                case 596: allnames = new string[] { "デンチュラ", "Galvantula", "Mygavolt", "Galvantula", "Voltula", "Galvantula", "전툴라", "电蜘蛛" }; break;
                case 597: allnames = new string[] { "テッシード", "Ferroseed", "Grindur", "Ferroseed", "Kastadur", "Ferroseed", "철시드", "种子铁球" }; break;
                case 598: allnames = new string[] { "ナットレイ", "Ferrothorn", "Noacier", "Ferrothorn", "Tentantel", "Ferrothorn", "너트령", "坚果哑铃" }; break;
                case 599: allnames = new string[] { "ギアル", "Klink", "Tic", "Klink", "Klikk", "Klink", "기어르", "齿轮儿" }; break;
                case 600: allnames = new string[] { "ギギアル", "Klang", "Clic", "Klang", "Kliklak", "Klang", "기기어르", "齿轮组" }; break;
                case 601: allnames = new string[] { "ギギギアル", "Klinklang", "Cliticlic", "Klinklang", "Klikdiklak", "Klinklang", "기기기어르", "齿轮怪" }; break;
                case 602: allnames = new string[] { "シビシラス", "Tynamo", "Anchwatt", "Tynamo", "Zapplardin", "Tynamo", "저리어", "麻麻小鱼" }; break;
                case 603: allnames = new string[] { "シビビール", "Eelektrik", "Lampéroie", "Eelektrik", "Zapplalek", "Eelektrik", "저리릴", "麻麻鳗" }; break;
                case 604: allnames = new string[] { "シビルドン", "Eelektross", "Ohmassacre", "Eelektross", "Zapplarang", "Eelektross", "저리더프", "麻麻鳗鱼王" }; break;
                case 605: allnames = new string[] { "リグレー", "Elgyem", "Lewsor", "Elgyem", "Pygraulon", "Elgyem", "리그레", "小灰怪" }; break;
                case 606: allnames = new string[] { "オーベム", "Beheeyem", "Neitram", "Beheeyem", "Megalon", "Beheeyem", "벰크", "大宇怪" }; break;
                case 607: allnames = new string[] { "ヒトモシ", "Litwick", "Funécire", "Litwick", "Lichtel", "Litwick", "불켜미", "烛光灵" }; break;
                case 608: allnames = new string[] { "ランプラー", "Lampent", "Mélancolux", "Lampent", "Laternecto", "Lampent", "램프라", "灯火幽灵" }; break;
                case 609: allnames = new string[] { "シャンデラ", "Chandelure", "Lugulabre", "Chandelure", "Skelabra", "Chandelure", "샹델라", "水晶灯火灵" }; break;
                case 610: allnames = new string[] { "キバゴ", "Axew", "Coupenotte", "Axew", "Milza", "Axew", "터검니", "牙牙" }; break;
                case 611: allnames = new string[] { "オノンド", "Fraxure", "Incisache", "Fraxure", "Sharfax", "Fraxure", "액슨도", "斧牙龙" }; break;
                case 612: allnames = new string[] { "オノノクス", "Haxorus", "Tranchodon", "Haxorus", "Maxax", "Haxorus", "액스라이즈", "双斧战龙" }; break;
                case 613: allnames = new string[] { "クマシュン", "Cubchoo", "Polarhume", "Cubchoo", "Petznief", "Cubchoo", "코고미", "喷嚏熊" }; break;
                case 614: allnames = new string[] { "ツンベアー", "Beartic", "Polagriffe", "Beartic", "Siberio", "Beartic", "툰베어", "冻原熊" }; break;
                case 615: allnames = new string[] { "フリージオ", "Cryogonal", "Hexagel", "Cryogonal", "Frigometri", "Cryogonal", "프리지오", "几何雪花" }; break;
                case 616: allnames = new string[] { "チョボマキ", "Shelmet", "Escargaume", "Shelmet", "Schnuthelm", "Shelmet", "쪼마리", "小嘴蜗" }; break;
                case 617: allnames = new string[] { "アギルダー", "Accelgor", "Limaspeed", "Accelgor", "Hydragil", "Accelgor", "어지리더", "敏捷虫" }; break;
                case 618: allnames = new string[] { "マッギョ", "Stunfisk", "Limonde", "Stunfisk", "Flunschlik", "Stunfisk", "메더", "泥巴鱼" }; break;
                case 619: allnames = new string[] { "コジョフー", "Mienfoo", "Kungfouine", "Mienfoo", "Lin-Fu", "Mienfoo", "비조푸", "功夫鼬" }; break;
                case 620: allnames = new string[] { "コジョンド", "Mienshao", "Shaofouine", "Mienshao", "Wie-Shu", "Mienshao", "비조도", "师父鼬" }; break;
                case 621: allnames = new string[] { "クリムガン", "Druddigon", "Drakkarmin", "Druddigon", "Shardrago", "Druddigon", "크리만", "赤面龙" }; break;
                case 622: allnames = new string[] { "ゴビット", "Golett", "Gringolem", "Golett", "Golbit", "Golett", "골비람", "泥偶小人" }; break;
                case 623: allnames = new string[] { "ゴルーグ", "Golurk", "Golemastoc", "Golurk", "Golgantes", "Golurk", "골루그", "泥偶巨人" }; break;
                case 624: allnames = new string[] { "コマタナ", "Pawniard", "Scalpion", "Pawniard", "Gladiantri", "Pawniard", "자망칼", "驹刀小兵" }; break;
                case 625: allnames = new string[] { "キリキザン", "Bisharp", "Scalproie", "Bisharp", "Caesurio", "Bisharp", "절각참", "劈斩司令" }; break;
                case 626: allnames = new string[] { "バッフロン", "Bouffalant", "Frison", "Bouffalant", "Bisofank", "Bouffalant", "버프론", "爆炸头水牛" }; break;
                case 627: allnames = new string[] { "ワシボン", "Rufflet", "Furaiglon", "Rufflet", "Geronimatz", "Rufflet", "수리둥보", "毛头小鹰" }; break;
                case 628: allnames = new string[] { "ウォーグル", "Braviary", "Gueriaigle", "Braviary", "Washakwil", "Braviary", "워글", "勇士雄鹰" }; break;
                case 629: allnames = new string[] { "バルチャイ", "Vullaby", "Vostourno", "Vullaby", "Skallyk", "Vullaby", "벌차이", "秃鹰丫头" }; break;
                case 630: allnames = new string[] { "バルジーナ", "Mandibuzz", "Vaututrice", "Mandibuzz", "Grypheldis", "Mandibuzz", "버랜지나", "秃鹰娜" }; break;
                case 631: allnames = new string[] { "クイタラン", "Heatmor", "Aflamanoir", "Heatmor", "Furnifraß", "Heatmor", "앤티골", "熔蚁兽" }; break;
                case 632: allnames = new string[] { "アイアント", "Durant", "Fermite", "Durant", "Fermicula", "Durant", "아이앤트", "铁蚁" }; break;
                case 633: allnames = new string[] { "モノズ", "Deino", "Solochi", "Deino", "Kapuno", "Deino", "모노두", "单首龙" }; break;
                case 634: allnames = new string[] { "ジヘッド", "Zweilous", "Diamat", "Zweilous", "Duodino", "Zweilous", "디헤드", "双首暴龙" }; break;
                case 635: allnames = new string[] { "サザンドラ", "Hydreigon", "Trioxhydre", "Hydreigon", "Trikephalo", "Hydreigon", "삼삼드래", "三首恶龙" }; break;
                case 636: allnames = new string[] { "メラルバ", "Larvesta", "Pyronille", "Larvesta", "Ignivor", "Larvesta", "활화르바", "燃烧虫" }; break;
                case 637: allnames = new string[] { "ウルガモス", "Volcarona", "Pyrax", "Volcarona", "Ramoth", "Volcarona", "불카모스", "火神蛾" }; break;
                case 638: allnames = new string[] { "コバルオン", "Cobalion", "Cobaltium", "Cobalion", "Kobalium", "Cobalion", "코바르온", "勾帕路翁" }; break;
                case 639: allnames = new string[] { "テラキオン", "Terrakion", "Terrakium", "Terrakion", "Terrakium", "Terrakion", "테라키온", "代拉基翁" }; break;
                case 640: allnames = new string[] { "ビリジオン", "Virizion", "Viridium", "Virizion", "Viridium", "Virizion", "비리디온", "毕力吉翁" }; break;
                case 641: allnames = new string[] { "トルネロス", "Tornadus", "Boréas", "Tornadus", "Boreos", "Tornadus", "토네로스", "龙卷云" }; break;
                case 642: allnames = new string[] { "ボルトロス", "Thundurus", "Fulguris", "Thundurus", "Voltolos", "Thundurus", "볼트로스", "雷电云" }; break;
                case 643: allnames = new string[] { "レシラム", "Reshiram", "Reshiram", "Reshiram", "Reshiram", "Reshiram", "레시라무", "莱希拉姆" }; break;
                case 644: allnames = new string[] { "ゼクロム", "Zekrom", "Zekrom", "Zekrom", "Zekrom", "Zekrom", "제크로무", "捷克罗姆" }; break;
                case 645: allnames = new string[] { "ランドロス", "Landorus", "Démétéros", "Landorus", "Demeteros", "Landorus", "랜드로스", "土地云" }; break;
                case 646: allnames = new string[] { "キュレム", "Kyurem", "Kyurem", "Kyurem", "Kyurem", "Kyurem", "큐레무", "酋雷姆" }; break;
                case 647: allnames = new string[] { "ケルディオ", "Keldeo", "Keldeo", "Keldeo", "Keldeo", "Keldeo", "케르디오", "凯路迪欧" }; break;
                case 648: allnames = new string[] { "メロエッタ", "Meloetta", "Meloetta", "Meloetta", "Meloetta", "Meloetta", "메로엣타", "美洛耶塔" }; break;
                case 649: allnames = new string[] { "ゲノセクト", "Genesect", "Genesect", "Genesect", "Genesect", "Genesect", "게노세크트", "盖诺赛克特" }; break;
                case 650: allnames = new string[] { "ハリマロン", "Chespin", "Marisson", "Chespin", "Igamaro", "Chespin", "도치마론", "哈力栗" }; break;
                case 651: allnames = new string[] { "ハリボーグ", "Quilladin", "Boguérisse", "Quilladin", "Igastarnish", "Quilladin", "도치보구", "胖胖哈力" }; break;
                case 652: allnames = new string[] { "ブリガロン", "Chesnaught", "Blindépique", "Chesnaught", "Brigaron", "Chesnaught", "브리가론", "布里卡隆" }; break;
                case 653: allnames = new string[] { "フォッコ", "Fennekin", "Feunnec", "Fennekin", "Fynx", "Fennekin", "푸호꼬", "火狐狸" }; break;
                case 654: allnames = new string[] { "テールナー", "Braixen", "Roussil", "Braixen", "Rutena", "Braixen", "테르나", "长尾火狐" }; break;
                case 655: allnames = new string[] { "マフォクシー", "Delphox", "Goupelin", "Delphox", "Fennexis", "Delphox", "마폭시", "妖火红狐" }; break;
                case 656: allnames = new string[] { "ケロマツ", "Froakie", "Grenousse", "Froakie", "Froxy", "Froakie", "개구마르", "呱呱泡蛙" }; break;
                case 657: allnames = new string[] { "ゲコガシラ", "Frogadier", "Croâporal", "Frogadier", "Amphizel", "Frogadier", "개굴반장", "呱头蛙" }; break;
                case 658: allnames = new string[] { "ゲッコウガ", "Greninja", "Amphinobi", "Greninja", "Quajutsu", "Greninja", "개굴닌자", "甲贺忍蛙" }; break;
                case 659: allnames = new string[] { "ホルビー", "Bunnelby", "Sapereau", "Bunnelby", "Scoppel", "Bunnelby", "파르빗", "掘掘兔" }; break;
                case 660: allnames = new string[] { "ホルード", "Diggersby", "Excavarenne", "Diggersby", "Grebbit", "Diggersby", "파르토", "掘地兔" }; break;
                case 661: allnames = new string[] { "ヤヤコマ", "Fletchling", "Passerouge", "Fletchling", "Dartiri", "Fletchling", "화살꼬빈", "小箭雀" }; break;
                case 662: allnames = new string[] { "ヒノヤコマ", "Fletchinder", "Braisillon", "Fletchinder", "Dartignis", "Fletchinder", "불화살빈", "火箭雀" }; break;
                case 663: allnames = new string[] { "ファイアロー", "Talonflame", "Flambusard", "Talonflame", "Fiaro", "Talonflame", "파이어로", "烈箭鹰" }; break;
                case 664: allnames = new string[] { "コフキムシ", "Scatterbug", "Lépidonille", "Scatterbug", "Purmel", "Scatterbug", "분이벌레", "粉蝶虫" }; break;
                case 665: allnames = new string[] { "コフーライ", "Spewpa", "Pérégrain", "Spewpa", "Puponcho", "Spewpa", "분떠도리", "粉蝶蛹" }; break;
                case 666: allnames = new string[] { "ビビヨン", "Vivillon", "Prismillon", "Vivillon", "Vivillon", "Vivillon", "비비용", "彩粉蝶" }; break;
                case 667: allnames = new string[] { "シシコ", "Litleo", "Hélionceau", "Litleo", "Leufeo", "Litleo", "레오꼬", "小狮狮" }; break;
                case 668: allnames = new string[] { "カエンジシ", "Pyroar", "Némélios", "Pyroar", "Pyroleo", "Pyroar", "화염레오", "火炎狮" }; break;
                case 669: allnames = new string[] { "フラベベ", "Flabébé", "Flabébé", "Flabébé", "Flabébé", "Flabébé", "플라베베", "花蓓蓓" }; break;
                case 670: allnames = new string[] { "フラエッテ", "Floette", "Floette", "Floette", "Floette", "Floette", "플라엣테", "花叶蒂" }; break;
                case 671: allnames = new string[] { "フラージェス", "Florges", "Florges", "Florges", "Florges", "Florges", "플라제스", "花洁夫人" }; break;
                case 672: allnames = new string[] { "メェークル", "Skiddo", "Cabriolaine", "Skiddo", "Mähikel", "Skiddo", "메이클", "坐骑小羊" }; break;
                case 673: allnames = new string[] { "ゴーゴート", "Gogoat", "Chevroum", "Gogoat", "Chevrumm", "Gogoat", "고고트", "坐骑山羊" }; break;
                case 674: allnames = new string[] { "ヤンチャム", "Pancham", "Pandespiègle", "Pancham", "Pam-Pam", "Pancham", "판짱", "顽皮熊猫" }; break;
                case 675: allnames = new string[] { "ゴロンダ", "Pangoro", "Pandarbare", "Pangoro", "Pandagro", "Pangoro", "부란다", "流氓熊猫" }; break;
                case 676: allnames = new string[] { "トリミアン", "Furfrou", "Couafarel", "Furfrou", "Coiffwaff", "Furfrou", "트리미앙", "多丽米亚" }; break;
                case 677: allnames = new string[] { "ニャスパー", "Espurr", "Psystigri", "Espurr", "Psiau", "Espurr", "냐스퍼", "妙喵" }; break;
                case 678: allnames = new string[] { "ニャオニクス", "Meowstic", "Mistigrix", "Meowstic", "Psiaugon", "Meowstic", "냐오닉스", "超能妙喵" }; break;
                case 679: allnames = new string[] { "ヒトツキ", "Honedge", "Monorpale", "Honedge", "Gramokles", "Honedge", "단칼빙", "独剑鞘" }; break;
                case 680: allnames = new string[] { "ニダンギル", "Doublade", "Dimoclès", "Doublade", "Duokles", "Doublade", "쌍검킬", "双剑鞘" }; break;
                case 681: allnames = new string[] { "ギルガルド", "Aegislash", "Exagide", "Aegislash", "Durengard", "Aegislash", "킬가르도", "坚盾剑怪" }; break;
                case 682: allnames = new string[] { "シュシュプ", "Spritzee", "Fluvetin", "Spritzee", "Parfi", "Spritzee", "슈쁘", "粉香香" }; break;
                case 683: allnames = new string[] { "フレフワン", "Aromatisse", "Cocotine", "Aromatisse", "Parfinesse", "Aromatisse", "프레프티르", "芳香精" }; break;
                case 684: allnames = new string[] { "ペロッパフ", "Swirlix", "Sucroquin", "Swirlix", "Flauschling", "Swirlix", "나룸퍼프", "绵绵泡芙" }; break;
                case 685: allnames = new string[] { "ペロリーム", "Slurpuff", "Cupcanaille", "Slurpuff", "Sabbaione", "Slurpuff", "나루림", "胖甜妮" }; break;
                case 686: allnames = new string[] { "マーイーカ", "Inkay", "Sepiatop", "Inkay", "Iscalar", "Inkay", "오케이징", "好啦鱿" }; break;
                case 687: allnames = new string[] { "カラマネロ", "Malamar", "Sepiatroce", "Malamar", "Calamanero", "Malamar", "칼라마네로", "乌贼王" }; break;
                case 688: allnames = new string[] { "カメテテ", "Binacle", "Opermine", "Binacle", "Bithora", "Binacle", "거북손손", "龟脚脚" }; break;
                case 689: allnames = new string[] { "ガメノデス", "Barbaracle", "Golgopathe", "Barbaracle", "Thanathora", "Barbaracle", "거북손데스", "龟足巨铠" }; break;
                case 690: allnames = new string[] { "クズモー", "Skrelp", "Venalgue", "Skrelp", "Algitt", "Skrelp", "수레기", "垃垃藻" }; break;
                case 691: allnames = new string[] { "ドラミドロ", "Dragalge", "Kravarech", "Dragalge", "Tandrak", "Dragalge", "드래캄", "毒藻龙" }; break;
                case 692: allnames = new string[] { "ウデッポウ", "Clauncher", "Flingouste", "Clauncher", "Scampisto", "Clauncher", "완철포", "铁臂枪虾" }; break;
                case 693: allnames = new string[] { "ブロスター", "Clawitzer", "Gamblast", "Clawitzer", "Wummer", "Clawitzer", "블로스터", "钢炮臂虾" }; break;
                case 694: allnames = new string[] { "エリキテル", "Helioptile", "Galvaran", "Helioptile", "Eguana", "Helioptile", "목도리키텔", "伞电蜥" }; break;
                case 695: allnames = new string[] { "エレザード", "Heliolisk", "Iguolta", "Heliolisk", "Elezard", "Heliolisk", "일레도리자드", "光电伞蜥" }; break;
                case 696: allnames = new string[] { "チゴラス", "Tyrunt", "Ptyranidur", "Tyrunt", "Balgoras", "Tyrunt", "티고라스", "宝宝暴龙" }; break;
                case 697: allnames = new string[] { "ガチゴラス", "Tyrantrum", "Rexillius", "Tyrantrum", "Monargoras", "Tyrantrum", "견고라스", "怪颚龙" }; break;
                case 698: allnames = new string[] { "アマルス", "Amaura", "Amagara", "Amaura", "Amarino", "Amaura", "아마루스", "冰雪龙" }; break;
                case 699: allnames = new string[] { "アマルルガ", "Aurorus", "Dragmara", "Aurorus", "Amagarga", "Aurorus", "아마루르가", "冰雪巨龙" }; break;
                case 700: allnames = new string[] { "ニンフィア", "Sylveon", "Nymphali", "Sylveon", "Feelinara", "Sylveon", "님피아", "仙子伊布" }; break;
                case 701: allnames = new string[] { "ルチャブル", "Hawlucha", "Brutalibré", "Hawlucha", "Resladero", "Hawlucha", "루차불", "摔角鹰人" }; break;
                case 702: allnames = new string[] { "デデンネ", "Dedenne", "Dedenne", "Dedenne", "Dedenne", "Dedenne", "데덴네", "咚咚鼠" }; break;
                case 703: allnames = new string[] { "メレシー", "Carbink", "Strassie", "Carbink", "Rocara", "Carbink", "멜리시", "小碎钻" }; break;
                case 704: allnames = new string[] { "ヌメラ", "Goomy", "Mucuscule", "Goomy", "Viscora", "Goomy", "미끄메라", "黏黏宝" }; break;
                case 705: allnames = new string[] { "ヌメイル", "Sliggoo", "Colimucus", "Sliggoo", "Viscargot", "Sliggoo", "미끄네일", "黏美儿" }; break;
                case 706: allnames = new string[] { "ヌメルゴン", "Goodra", "Muplodocus", "Goodra", "Viscogon", "Goodra", "미끄래곤", "黏美龙" }; break;
                case 707: allnames = new string[] { "クレッフィ", "Klefki", "Trousselin", "Klefki", "Clavion", "Klefki", "클레피", "钥圈儿" }; break;
                case 708: allnames = new string[] { "ボクレー", "Phantump", "Brocélôme", "Phantump", "Paragoni", "Phantump", "나목령", "小木灵" }; break;
                case 709: allnames = new string[] { "オーロット", "Trevenant", "Desséliande", "Trevenant", "Trombork", "Trevenant", "대로트", "朽木妖" }; break;
                case 710: allnames = new string[] { "バケッチャ", "Pumpkaboo", "Pitrouille", "Pumpkaboo", "Irrbis", "Pumpkaboo", "호바귀", "南瓜精" }; break;
                case 711: allnames = new string[] { "パンプジン", "Gourgeist", "Banshitrouye", "Gourgeist", "Pumpdjinn", "Gourgeist", "펌킨인", "南瓜怪人" }; break;
                case 712: allnames = new string[] { "カチコール", "Bergmite", "Grelaçon", "Bergmite", "Arktip", "Bergmite", "꽁어름", "冰宝" }; break;
                case 713: allnames = new string[] { "クレベース", "Avalugg", "Séracrawl", "Avalugg", "Arktilas", "Avalugg", "크레베이스", "冰岩怪" }; break;
                case 714: allnames = new string[] { "オンバット", "Noibat", "Sonistrelle", "Noibat", "eF-eM", "Noibat", "음뱃", "嗡蝠" }; break;
                case 715: allnames = new string[] { "オンバーン", "Noivern", "Bruyverne", "Noivern", "UHaFnir", "Noivern", "음번", "音波龙" }; break;
                case 716: allnames = new string[] { "ゼルネアス", "Xerneas", "Xerneas", "Xerneas", "Xerneas", "Xerneas", "제르네아스", "哲尔尼亚斯" }; break;
                case 717: allnames = new string[] { "イベルタル", "Yveltal", "Yveltal", "Yveltal", "Yveltal", "Yveltal", "이벨타르", "伊裴尔塔尔" }; break;
                case 718: allnames = new string[] { "ジガルデ", "Zygarde", "Zygarde", "Zygarde", "Zygarde", "Zygarde", "지가르데", "基格尔德" }; break;
                case 719: allnames = new string[] { "ディアンシー", "Diancie", "Diancie", "Diancie", "Diancie", "Diancie", "디안시", "蒂安希" }; break;
                case 720: allnames = new string[] { "フーパ", "Hoopa", "Hoopa", "Hoopa", "Hoopa", "Hoopa", "후파", "胡帕" }; break;
                case 721: allnames = new string[] { "ボルケニオン", "Volcanion", "Volcanion", "Volcanion", "Volcanion", "Volcanion", "볼케니온", "波尔凯尼恩" }; break;
                case 722: allnames = new string[] { "モクロー", "Rowlet", "Brindibou", "Rowlet", "Bauz", "Rowlet", "나몰빼미", "木木枭" }; break;
                case 723: allnames = new string[] { "フクスロー", "Dartrix", "Efflèche", "Dartrix", "Arboretoss", "Dartrix", "빼미스로우", "投羽枭" }; break;
                case 724: allnames = new string[] { "ジュナイパー", "Decidueye", "Archéduc", "Decidueye", "Silvarro", "Decidueye", "모크나이퍼", "狙射树枭" }; break;
                case 725: allnames = new string[] { "ニャビー", "Litten", "Flamiaou", "Litten", "Flamiau", "Litten", "냐오불", "火斑喵" }; break;
                case 726: allnames = new string[] { "ニャヒート", "Torracat", "Matoufeu", "Torracat", "Miezunder", "Torracat", "냐오히트", "炎热喵" }; break;
                case 727: allnames = new string[] { "ガオガエン", "Incineroar", "Félinferno", "Incineroar", "Fuegro", "Incineroar", "어흥염", "炽焰咆哮虎" }; break;
                case 728: allnames = new string[] { "アシマリ", "Popplio", "Otaquin", "Popplio", "Robball", "Popplio", "누리공", "球球海狮" }; break;
                case 729: allnames = new string[] { "オシャマリ", "Brionne", "Otarlette", "Brionne", "Marikeck", "Brionne", "키요공", "花漾海狮" }; break;
                case 730: allnames = new string[] { "アシレーヌ", "Primarina", "Oratoria", "Primarina", "Primarene", "Primarina", "누리레느", "西狮海壬" }; break;
                case 731: allnames = new string[] { "ツツケラ", "Pikipek", "Picassaut", "Pikipek", "Peppeck", "Pikipek", "콕코구리", "小笃儿" }; break;
                case 732: allnames = new string[] { "ケララッパ", "Trumbeak", "Piclairon", "Trumbeak", "Trompeck", "Trumbeak", "크라파", "喇叭啄鸟" }; break;
                case 733: allnames = new string[] { "ドデカバシ", "Toucannon", "Bazoucan", "Toucannon", "Tukanon", "Toucannon", "왕큰부리", "铳嘴大鸟" }; break;
                case 734: allnames = new string[] { "ヤングース", "Yungoos", "Manglouton", "Yungoos", "Mangunior", "Yungoos", "영구스", "猫鼬少" }; break;
                case 735: allnames = new string[] { "デカグース", "Gumshoos", "Argouste", "Gumshoos", "Manguspektor", "Gumshoos", "형사구스", "猫鼬探长" }; break;
                case 736: allnames = new string[] { "アゴジムシ", "Grubbin", "Larvibule", "Grubbin", "Mabula", "Grubbin", "턱지충이", "强颚鸡母虫" }; break;
                case 737: allnames = new string[] { "デンヂムシ", "Charjabug", "Chrysapile", "Charjabug", "Akkup", "Charjabug", "전지충이", "虫电宝" }; break;
                case 738: allnames = new string[] { "クワガノン", "Vikavolt", "Lucanon", "Vikavolt", "Donarion", "Vikavolt", "투구뿌논", "锹农炮虫" }; break;
                case 739: allnames = new string[] { "マケンカニ", "Crabrawler", "Crabagarre", "Crabrawler", "Krabbox", "Crabrawler", "오기지게", "好胜蟹" }; break;
                case 740: allnames = new string[] { "ケケンカニ", "Crabominable", "Crabominable", "Crabominable", "Krawell", "Crabominable", "모단단게", "好胜毛蟹" }; break;
                case 741: allnames = new string[] { "オドリドリ", "Oricorio", "Plumeline", "Oricorio", "Choreogel", "Oricorio", "춤추새", "花舞鸟" }; break;
                case 742: allnames = new string[] { "アブリー", "Cutiefly", "Bombydou", "Cutiefly", "Wommel", "Cutiefly", "에블리", "萌虻" }; break;
                case 743: allnames = new string[] { "アブリボン", "Ribombee", "Rubombelle", "Ribombee", "Bandelby", "Ribombee", "에리본", "蝶结萌虻" }; break;
                case 744: allnames = new string[] { "イワンコ", "Rockruff", "Rocabot", "Rockruff", "Wuffels", "Rockruff", "암멍이", "岩狗狗" }; break;
                case 745: allnames = new string[] { "ルガルガン", "Lycanroc", "Lougaroc", "Lycanroc", "Wolwerock", "Lycanroc", "루가루암", "鬃岩狼人" }; break;
                case 746: allnames = new string[] { "ヨワシ", "Wishiwashi", "Froussardine", "Wishiwashi", "Lusardin", "Wishiwashi", "약어리", "弱丁鱼" }; break;
                case 747: allnames = new string[] { "ヒドイデ", "Mareanie", "Vorastérie", "Mareanie", "Garstella", "Mareanie", "시마사리", "好坏星" }; break;
                case 748: allnames = new string[] { "ドヒドイデ", "Toxapex", "Prédastérie", "Toxapex", "Aggrostella", "Toxapex", "더시마사리", "超坏星" }; break;
                case 749: allnames = new string[] { "ドロバンコ", "Mudbray", "Tiboudet", "Mudbray", "Pampuli", "Mudbray", "머드나기", "泥驴仔" }; break;
                case 750: allnames = new string[] { "バンバドロ", "Mudsdale", "Bourrinos", "Mudsdale", "Pampross", "Mudsdale", "만마드", "重泥挽马" }; break;
                case 751: allnames = new string[] { "シズクモ", "Dewpider", "Araqua", "Dewpider", "Araqua", "Dewpider", "물거미", "滴蛛" }; break;
                case 752: allnames = new string[] { "オニシズクモ", "Araquanid", "Tarenbulle", "Araquanid", "Aranestro", "Araquanid", "깨비물거미", "滴蛛霸" }; break;
                case 753: allnames = new string[] { "カリキリ", "Fomantis", "Mimantis", "Fomantis", "Imantis", "Fomantis", "짜랑랑", "伪螳草" }; break;
                case 754: allnames = new string[] { "ラランテス", "Lurantis", "Floramantis", "Lurantis", "Mantidea", "Lurantis", "라란티스", "兰螳花" }; break;
                case 755: allnames = new string[] { "ネマシュ", "Morelull", "Spododo", "Morelull", "Bubungus", "Morelull", "자마슈", "睡睡菇" }; break;
                case 756: allnames = new string[] { "マシェード", "Shiinotic", "Lampignon", "Shiinotic", "Lamellux", "Shiinotic", "마셰이드", "灯罩夜菇" }; break;
                case 757: allnames = new string[] { "ヤトウモリ", "Salandit", "Tritox", "Salandit", "Molunk", "Salandit", "야도뇽", "夜盗火蜥" }; break;
                case 758: allnames = new string[] { "エンニュート", "Salazzle", "Malamandre", "Salazzle", "Amfira", "Salazzle", "염뉴트", "焰后蜥" }; break;
                case 759: allnames = new string[] { "ヌイコグマ", "Stufful", "Nounourson", "Stufful", "Velursi", "Stufful", "포곰곰", "童偶熊" }; break;
                case 760: allnames = new string[] { "キテルグマ", "Bewear", "Chelours", "Bewear", "Kosturso", "Bewear", "이븐곰", "穿着熊" }; break;
                case 761: allnames = new string[] { "アマカジ", "Bounsweet", "Croquine", "Bounsweet", "Frubberl", "Bounsweet", "달콤아", "甜竹竹" }; break;
                case 762: allnames = new string[] { "アママイコ", "Steenee", "Candine", "Steenee", "Frubaila", "Steenee", "달무리나", "甜舞妮" }; break;
                case 763: allnames = new string[] { "アマージョ", "Tsareena", "Sucreine", "Tsareena", "Fruyal", "Tsareena", "달코퀸", "甜冷美后" }; break;
                case 764: allnames = new string[] { "キュワワー", "Comfey", "Guérilande", "Comfey", "Curelei", "Comfey", "큐아링", "花疗环环" }; break;
                case 765: allnames = new string[] { "ヤレユータン", "Oranguru", "Gouroutan", "Oranguru", "Kommandutan", "Oranguru", "하랑우탄", "智挥猩" }; break;
                case 766: allnames = new string[] { "ナゲツケサル", "Passimian", "Quartermac", "Passimian", "Quartermak", "Passimian", "내던숭이", "投掷猴" }; break;
                case 767: allnames = new string[] { "コソクムシ", "Wimpod", "Sovkipou", "Wimpod", "Reißlaus", "Wimpod", "꼬시레", "胆小虫" }; break;
                case 768: allnames = new string[] { "グソクムシャ", "Golisopod", "Sarmuraï", "Golisopod", "Tectass", "Golisopod", "갑주무사", "具甲武者" }; break;
                case 769: allnames = new string[] { "スナバァ", "Sandygast", "Bacabouh", "Sandygast", "Sankabuh", "Sandygast", "모래꿍", "沙丘娃" }; break;
                case 770: allnames = new string[] { "シロデスナ", "Palossand", "Trépassable", "Palossand", "Colossand", "Palossand", "모래성이당", "噬沙堡爷" }; break;
                case 771: allnames = new string[] { "ナマコブシ", "Pyukumuku", "Concombaffe", "Pyukumuku", "Gufa", "Pyukumuku", "해무기", "拳海参" }; break;
                case 772: allnames = new string[] { "タイプ：ヌル", "Type: Null", "Type:0", "Tipo Zero", "Typ:Null", "Código Cero", "타입:널", "属性：空" }; break;
                case 773: allnames = new string[] { "シルヴァディ", "Silvally", "Silvallié", "Silvally", "Amigento", "Silvally", "실버디", "银伴战兽" }; break;
                case 774: allnames = new string[] { "メテノ", "Minior", "Météno", "Minior", "Meteno", "Minior", "메테노", "小陨星" }; break;
                case 775: allnames = new string[] { "ネッコアラ", "Komala", "Dodoala", "Komala", "Koalelu", "Komala", "자말라", "树枕尾熊" }; break;
                case 776: allnames = new string[] { "バクガメス", "Turtonator", "Boumata", "Turtonator", "Tortunator", "Turtonator", "폭거북스", "爆焰龟兽" }; break;
                case 777: allnames = new string[] { "トゲデマル", "Togedemaru", "Togedemaru", "Togedemaru", "Togedemaru", "Togedemaru", "토게데마루", "托戈德玛尔" }; break;
                case 778: allnames = new string[] { "ミミッキュ", "Mimikyu", "Mimiqui", "Mimikyu", "Mimigma", "Mimikyu", "따라큐", "谜拟Ｑ" }; break;
                case 779: allnames = new string[] { "ハギギシリ", "Bruxish", "Denticrisse", "Bruxish", "Knirfish", "Bruxish", "치갈기", "磨牙彩皮鱼" }; break;
                case 780: allnames = new string[] { "ジジーロン", "Drampa", "Draïeul", "Drampa", "Sen-Long", "Drampa", "할비롱", "老翁龙" }; break;
                case 781: allnames = new string[] { "ダダリン", "Dhelmise", "Sinistrail", "Dhelmise", "Moruda", "Dhelmise", "타타륜", "破破舵轮" }; break;
                case 782: allnames = new string[] { "ジャラコ", "Jangmo-o", "Bébécaille", "Jangmo-o", "Miniras", "Jangmo-o", "짜랑꼬", "心鳞宝" }; break;
                case 783: allnames = new string[] { "ジャランゴ", "Hakamo-o", "Écaïd", "Hakamo-o", "Mediras", "Hakamo-o", "짜랑고우", "鳞甲龙" }; break;
                case 784: allnames = new string[] { "ジャラランガ", "Kommo-o", "Ékaïser", "Kommo-o", "Grandiras", "Kommo-o", "짜랑고우거", "杖尾鳞甲龙" }; break;
                case 785: allnames = new string[] { "カプ・コケコ", "Tapu Koko", "Tokorico", "Tapu Koko", "Kapu-Riki", "Tapu Koko", "카푸꼬꼬꼭", "卡璞・鸣鸣" }; break;
                case 786: allnames = new string[] { "カプ・テテフ", "Tapu Lele", "Tokopiyon", "Tapu Lele", "Kapu-Fala", "Tapu Lele", "카푸나비나", "卡璞・蝶蝶" }; break;
                case 787: allnames = new string[] { "カプ・ブルル", "Tapu Bulu", "Tokotoro", "Tapu Bulu", "Kapu-Toro", "Tapu Bulu", "카푸브루루", "卡璞・哞哞" }; break;
                case 788: allnames = new string[] { "カプ・レヒレ", "Tapu Fini", "Tokopisco", "Tapu Fini", "Kapu-Kime", "Tapu Fini", "카푸느지느", "卡璞・鳍鳍" }; break;
                case 789: allnames = new string[] { "コスモッグ", "Cosmog", "Cosmog", "Cosmog", "Cosmog", "Cosmog", "코스모그", "科斯莫古" }; break;
                case 790: allnames = new string[] { "コスモウム", "Cosmoem", "Cosmovum", "Cosmoem", "Cosmovum", "Cosmoem", "코스모움", "科斯莫姆" }; break;
                case 791: allnames = new string[] { "ソルガレオ", "Solgaleo", "Solgaleo", "Solgaleo", "Solgaleo", "Solgaleo", "솔가레오", "索尔迦雷欧" }; break;
                case 792: allnames = new string[] { "ルナアーラ", "Lunala", "Lunala", "Lunala", "Lunala", "Lunala", "루나아라", "露奈雅拉" }; break;
                case 793: allnames = new string[] { "ウツロイド", "Nihilego", "Zéroïd", "Nihilego", "Anego", "Nihilego", "텅비드", "虚吾伊德" }; break;
                case 794: allnames = new string[] { "マッシブーン", "Buzzwole", "Mouscoto", "Buzzwole", "Masskito", "Buzzwole", "매시붕", "爆肌蚊" }; break;
                case 795: allnames = new string[] { "フェローチェ", "Pheromosa", "Cancrelove", "Pheromosa", "Schabelle", "Pheromosa", "페로코체", "费洛美螂" }; break;
                case 796: allnames = new string[] { "デンジュモク", "Xurkitree", "Câblifère", "Xurkitree", "Voltriant", "Xurkitree", "전수목", "电束木" }; break;
                case 797: allnames = new string[] { "テッカグヤ", "Celesteela", "Bamboiselle", "Celesteela", "Kaguron", "Celesteela", "철화구야", "铁火辉夜" }; break;
                case 798: allnames = new string[] { "カミツルギ", "Kartana", "Katagami", "Kartana", "Katagami", "Kartana", "종이신도", "纸御剑" }; break;
                case 799: allnames = new string[] { "アクジキング", "Guzzlord", "Engloutyran", "Guzzlord", "Schlingking", "Guzzlord", "악식킹", "恶食大王" }; break;
                case 800: allnames = new string[] { "ネクロズマ", "Necrozma", "Necrozma", "Necrozma", "Necrozma", "Necrozma", "네크로즈마", "奈克洛兹玛" }; break;
                case 801: allnames = new string[] { "マギアナ", "Magearna", "Magearna", "Magearna", "Magearna", "Magearna", "마기아나", "玛机雅娜" }; break;
                case 802: allnames = new string[] { "マーシャドー", "Marshadow", "Marshadow", "Marshadow", "Marshadow", "Marshadow", "마샤도", "玛夏多" }; break;
                default: allnames = new string[] { "タマゴ", "Egg", "Œuf", "Uovo", "Ei", "Huevo", "알", "蛋" }; break;
            }
            switch (lang)
            {
                case 0x01: return allnames[0]; // JPN
                case 0x02: return allnames[1]; // ENG
                case 0x03: return allnames[2]; // FRE
                case 0x04: return allnames[3]; // ITA
                case 0x05: return allnames[4]; // GER
                case 0x07: return allnames[5]; // SPA
                case 0x08: return allnames[6]; // KOR
                case 0x09: return allnames[7]; // CHS
                case 0x0A: return allnames[7]; // CHT
                default: return allnames[1]; // ENG
            }
        }

        #endregion Species

        #region Moves

        public static string[] Moves6 = { "[None]", "Pound", "Karate Chop", "Double Slap", "Comet Punch", "Mega Punch", "Pay Day", "Fire Punch", "Ice Punch", "Thunder Punch", "Scratch", "Vice Grip", "Guillotine", "Razor Wind", "Swords Dance", "Cut", "Gust", "Wing Attack", "Whirlwind", "Fly", "Bind", "Slam", "Vine Whip", "Stomp", "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack", "Headbutt", "Horn Attack", "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take Down", "Thrash", "Double-Edge", "Tail Whip", "Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite", "Growl", "Roar", "Sing", "Supersonic", "Sonic Boom", "Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump", "Surf", "Ice Beam", "Blizzard", "Psybeam", "Bubble Beam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck", "Submission", "Low Kick", "Counter", "Seismic Toss", "Strength", "Absorb", "Mega Drain", "Leech Seed", "Growth", "Razor Leaf", "Solar Beam", "Poison Powder", "Stun Spore", "Sleep Powder", "Petal Dance", "String Shot", "Dragon Rage", "Fire Spin", "Thunder Shock", "Thunderbolt", "Thunder Wave", "Thunder", "Rock Throw", "Earthquake", "Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate", "Agility", "Quick Attack", "Rage", "Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover", "Harden", "Minimize", "Smokescreen", "Confuse Ray", "Withdraw", "Defense Curl", "Barrier", "Light Screen", "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move", "Self-Destruct", "Egg Bomb", "Lick", "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift", "Skull Bash", "Spike Cannon", "Constrict", "Amnesia", "Kinesis", "Soft-Boiled", "High Jump Kick", "Glare", "Dream Eater", "Poison Gas", "Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash", "Psywave", "Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest", "Rock Slide", "Hyper Fang", "Sharpen", "Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute", "Struggle", "Sketch", "Triple Kick", "Thief", "Spider Web", "Mind Reader", "Nightmare", "Flame Wheel", "Snore", "Curse", "Flail", "Conversion 2", "Aeroblast", "Cotton Spore", "Reversal", "Spite", "Powder Snow", "Protect", "Mach Punch", "Scary Face", "Feint Attack", "Sweet Kiss", "Belly Drum", "Sludge Bomb", "Mud-Slap", "Octazooka", "Spikes", "Zap Cannon", "Foresight", "Destiny Bond", "Perish Song", "Icy Wind", "Detect", "Bone Rush", "Lock-On", "Outrage", "Sandstorm", "Giga Drain", "Endure", "Charm", "Rollout", "False Swipe", "Swagger", "Milk Drink", "Spark", "Fury Cutter", "Steel Wing", "Mean Look", "Attract", "Sleep Talk", "Heal Bell", "Return", "Present", "Frustration", "Safeguard", "Pain Split", "Sacred Fire", "Magnitude", "Dynamic Punch", "Megahorn", "Dragon Breath", "Baton Pass", "Encore", "Pursuit", "Rapid Spin", "Sweet Scent", "Iron Tail", "Metal Claw", "Vital Throw", "Morning Sun", "Synthesis", "Moonlight", "Hidden Power", "Cross Chop", "Twister", "Rain Dance", "Sunny Day", "Crunch", "Mirror Coat", "Psych Up", "Extreme Speed", "Ancient Power", "Shadow Ball", "Future Sight", "Rock Smash", "Whirlpool", "Beat Up", "Fake Out", "Uproar", "Stockpile", "Spit Up", "Swallow", "Heat Wave", "Hail", "Torment", "Flatter", "Will-O-Wisp", "Memento", "Facade", "Focus Punch", "Smelling Salts", "Follow Me", "Nature Power", "Charge", "Taunt", "Helping Hand", "Trick", "Role Play", "Wish", "Assist", "Ingrain", "Superpower", "Magic Coat", "Recycle", "Revenge", "Brick Break", "Yawn", "Knock Off", "Endeavor", "Eruption", "Skill Swap", "Imprison", "Refresh", "Grudge", "Snatch", "Secret Power", "Dive", "Arm Thrust", "Camouflage", "Tail Glow", "Luster Purge", "Mist Ball", "Feather Dance", "Teeter Dance", "Blaze Kick", "Mud Sport", "Ice Ball", "Needle Arm", "Slack Off", "Hyper Voice", "Poison Fang", "Crush Claw", "Blast Burn", "Hydro Cannon", "Meteor Mash", "Astonish", "Weather Ball", "Aromatherapy", "Fake Tears", "Air Cutter", "Overheat", "Odor Sleuth", "Rock Tomb", "Silver Wind", "Metal Sound", "Grass Whistle", "Tickle", "Cosmic Power", "Water Spout", "Signal Beam", "Shadow Punch", "Extrasensory", "Sky Uppercut", "Sand Tomb", "Sheer Cold", "Muddy Water", "Bullet Seed", "Aerial Ace", "Icicle Spear", "Iron Defense", "Block", "Howl", "Dragon Claw", "Frenzy Plant", "Bulk Up", "Bounce", "Mud Shot", "Poison Tail", "Covet", "Volt Tackle", "Magical Leaf", "Water Sport", "Calm Mind", "Leaf Blade", "Dragon Dance", "Rock Blast", "Shock Wave", "Water Pulse", "Doom Desire", "Psycho Boost", "Roost", "Gravity", "Miracle Eye", "Wake-Up Slap", "Hammer Arm", "Gyro Ball", "Healing Wish", "Brine", "Natural Gift", "Feint", "Pluck", "Tailwind", "Acupressure", "Metal Burst", "U-turn", "Close Combat", "Payback", "Assurance", "Embargo", "Fling", "Psycho Shift", "Trump Card", "Heal Block", "Wring Out", "Power Trick", "Gastro Acid", "Lucky Chant", "Me First", "Copycat", "Power Swap", "Guard Swap", "Punishment", "Last Resort", "Worry Seed", "Sucker Punch", "Toxic Spikes", "Heart Swap", "Aqua Ring", "Magnet Rise", "Flare Blitz", "Force Palm", "Aura Sphere", "Rock Polish", "Poison Jab", "Dark Pulse", "Night Slash", "Aqua Tail", "Seed Bomb", "Air Slash", "X-Scissor", "Bug Buzz", "Dragon Pulse", "Dragon Rush", "Power Gem", "Drain Punch", "Vacuum Wave", "Focus Blast", "Energy Ball", "Brave Bird", "Earth Power", "Switcheroo", "Giga Impact", "Nasty Plot", "Bullet Punch", "Avalanche", "Ice Shard", "Shadow Claw", "Thunder Fang", "Ice Fang", "Fire Fang", "Shadow Sneak", "Mud Bomb", "Psycho Cut", "Zen Headbutt", "Mirror Shot", "Flash Cannon", "Rock Climb", "Defog", "Trick Room", "Draco Meteor", "Discharge", "Lava Plume", "Leaf Storm", "Power Whip", "Rock Wrecker", "Cross Poison", "Gunk Shot", "Iron Head", "Magnet Bomb", "Stone Edge", "Captivate", "Stealth Rock", "Grass Knot", "Chatter", "Judgment", "Bug Bite", "Charge Beam", "Wood Hammer", "Aqua Jet", "Attack Order", "Defend Order", "Heal Order", "Head Smash", "Double Hit", "Roar of Time", "Spacial Rend", "Lunar Dance", "Crush Grip", "Magma Storm", "Dark Void", "Seed Flare", "Ominous Wind", "Shadow Force", "Hone Claws", "Wide Guard", "Guard Split", "Power Split", "Wonder Room", "Psyshock", "Venoshock", "Autotomize", "Rage Powder", "Telekinesis", "Magic Room", "Smack Down", "Storm Throw", "Flame Burst", "Sludge Wave", "Quiver Dance", "Heavy Slam", "Synchronoise", "Electro Ball", "Soak", "Flame Charge", "Coil", "Low Sweep", "Acid Spray", "Foul Play", "Simple Beam", "Entrainment", "After You", "Round", "Echoed Voice", "Chip Away", "Clear Smog", "Stored Power", "Quick Guard", "Ally Switch", "Scald", "Shell Smash", "Heal Pulse", "Hex", "Sky Drop", "Shift Gear", "Circle Throw", "Incinerate", "Quash", "Acrobatics", "Reflect Type", "Retaliate", "Final Gambit", "Bestow", "Inferno", "Water Pledge", "Fire Pledge", "Grass Pledge", "Volt Switch", "Struggle Bug", "Bulldoze", "Frost Breath", "Dragon Tail", "Work Up", "Electroweb", "Wild Charge", "Drill Run", "Dual Chop", "Heart Stamp", "Horn Leech", "Sacred Sword", "Razor Shell", "Heat Crash", "Leaf Tornado", "Steamroller", "Cotton Guard", "Night Daze", "Psystrike", "Tail Slap", "Hurricane", "Head Charge", "Gear Grind", "Searing Shot", "Techno Blast", "Relic Song", "Secret Sword", "Glaciate", "Bolt Strike", "Blue Flare", "Fiery Dance", "Freeze Shock", "Ice Burn", "Snarl", "Icicle Crash", "V-create", "Fusion Flare", "Fusion Bolt", "Flying Press", "Mat Block", "Belch", "Rototiller", "Sticky Web", "Fell Stinger", "Phantom Force", "Trick-or-Treat", "Noble Roar", "Ion Deluge", "Parabolic Charge", "Forest’s Curse", "Petal Blizzard", "Freeze-Dry", "Disarming Voice", "Parting Shot", "Topsy-Turvy", "Draining Kiss", "Crafty Shield", "Flower Shield", "Grassy Terrain", "Misty Terrain", "Electrify", "Play Rough", "Fairy Wind", "Moonblast", "Boomburst", "Fairy Lock", "King’s Shield", "Play Nice", "Confide", "Diamond Storm", "Steam Eruption", "Hyperspace Hole", "Water Shuriken", "Mystical Fire", "Spiky Shield", "Aromatic Mist", "Eerie Impulse", "Venom Drench", "Powder", "Geomancy", "Magnetic Flux", "Happy Hour", "Electric Terrain", "Dazzling Gleam", "Celebrate", "Hold Hands", "Baby-Doll Eyes", "Nuzzle", "Hold Back", "Infestation", "Power-Up Punch", "Oblivion Wing", "Thousand Arrows", "Thousand Waves", "Land’s Wrath", "Light of Ruin", "Origin Pulse", "Precipice Blades", "Dragon Ascent", "Hyperspace Fury" };

        public static string[] Moves7 = { "[None]", "Pound", "Karate Chop", "Double Slap", "Comet Punch", "Mega Punch", "Pay Day", "Fire Punch", "Ice Punch", "Thunder Punch", "Scratch", "Vice Grip", "Guillotine", "Razor Wind", "Swords Dance", "Cut", "Gust", "Wing Attack", "Whirlwind", "Fly", "Bind", "Slam", "Vine Whip", "Stomp", "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack", "Headbutt", "Horn Attack", "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take Down", "Thrash", "Double-Edge", "Tail Whip", "Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite", "Growl", "Roar", "Sing", "Supersonic", "Sonic Boom", "Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump", "Surf", "Ice Beam", "Blizzard", "Psybeam", "Bubble Beam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck", "Submission", "Low Kick", "Counter", "Seismic Toss", "Strength", "Absorb", "Mega Drain", "Leech Seed", "Growth", "Razor Leaf", "Solar Beam", "Poison Powder", "Stun Spore", "Sleep Powder", "Petal Dance", "String Shot", "Dragon Rage", "Fire Spin", "Thunder Shock", "Thunderbolt", "Thunder Wave", "Thunder", "Rock Throw", "Earthquake", "Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate", "Agility", "Quick Attack", "Rage", "Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover", "Harden", "Minimize", "Smokescreen", "Confuse Ray", "Withdraw", "Defense Curl", "Barrier", "Light Screen", "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move", "Self-Destruct", "Egg Bomb", "Lick", "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift", "Skull Bash", "Spike Cannon", "Constrict", "Amnesia", "Kinesis", "Soft-Boiled", "High Jump Kick", "Glare", "Dream Eater", "Poison Gas", "Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash", "Psywave", "Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest", "Rock Slide", "Hyper Fang", "Sharpen", "Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute", "Struggle", "Sketch", "Triple Kick", "Thief", "Spider Web", "Mind Reader", "Nightmare", "Flame Wheel", "Snore", "Curse", "Flail", "Conversion 2", "Aeroblast", "Cotton Spore", "Reversal", "Spite", "Powder Snow", "Protect", "Mach Punch", "Scary Face", "Feint Attack", "Sweet Kiss", "Belly Drum", "Sludge Bomb", "Mud-Slap", "Octazooka", "Spikes", "Zap Cannon", "Foresight", "Destiny Bond", "Perish Song", "Icy Wind", "Detect", "Bone Rush", "Lock-On", "Outrage", "Sandstorm", "Giga Drain", "Endure", "Charm", "Rollout", "False Swipe", "Swagger", "Milk Drink", "Spark", "Fury Cutter", "Steel Wing", "Mean Look", "Attract", "Sleep Talk", "Heal Bell", "Return", "Present", "Frustration", "Safeguard", "Pain Split", "Sacred Fire", "Magnitude", "Dynamic Punch", "Megahorn", "Dragon Breath", "Baton Pass", "Encore", "Pursuit", "Rapid Spin", "Sweet Scent", "Iron Tail", "Metal Claw", "Vital Throw", "Morning Sun", "Synthesis", "Moonlight", "Hidden Power", "Cross Chop", "Twister", "Rain Dance", "Sunny Day", "Crunch", "Mirror Coat", "Psych Up", "Extreme Speed", "Ancient Power", "Shadow Ball", "Future Sight", "Rock Smash", "Whirlpool", "Beat Up", "Fake Out", "Uproar", "Stockpile", "Spit Up", "Swallow", "Heat Wave", "Hail", "Torment", "Flatter", "Will-O-Wisp", "Memento", "Facade", "Focus Punch", "Smelling Salts", "Follow Me", "Nature Power", "Charge", "Taunt", "Helping Hand", "Trick", "Role Play", "Wish", "Assist", "Ingrain", "Superpower", "Magic Coat", "Recycle", "Revenge", "Brick Break", "Yawn", "Knock Off", "Endeavor", "Eruption", "Skill Swap", "Imprison", "Refresh", "Grudge", "Snatch", "Secret Power", "Dive", "Arm Thrust", "Camouflage", "Tail Glow", "Luster Purge", "Mist Ball", "Feather Dance", "Teeter Dance", "Blaze Kick", "Mud Sport", "Ice Ball", "Needle Arm", "Slack Off", "Hyper Voice", "Poison Fang", "Crush Claw", "Blast Burn", "Hydro Cannon", "Meteor Mash", "Astonish", "Weather Ball", "Aromatherapy", "Fake Tears", "Air Cutter", "Overheat", "Odor Sleuth", "Rock Tomb", "Silver Wind", "Metal Sound", "Grass Whistle", "Tickle", "Cosmic Power", "Water Spout", "Signal Beam", "Shadow Punch", "Extrasensory", "Sky Uppercut", "Sand Tomb", "Sheer Cold", "Muddy Water", "Bullet Seed", "Aerial Ace", "Icicle Spear", "Iron Defense", "Block", "Howl", "Dragon Claw", "Frenzy Plant", "Bulk Up", "Bounce", "Mud Shot", "Poison Tail", "Covet", "Volt Tackle", "Magical Leaf", "Water Sport", "Calm Mind", "Leaf Blade", "Dragon Dance", "Rock Blast", "Shock Wave", "Water Pulse", "Doom Desire", "Psycho Boost", "Roost", "Gravity", "Miracle Eye", "Wake-Up Slap", "Hammer Arm", "Gyro Ball", "Healing Wish", "Brine", "Natural Gift", "Feint", "Pluck", "Tailwind", "Acupressure", "Metal Burst", "U-turn", "Close Combat", "Payback", "Assurance", "Embargo", "Fling", "Psycho Shift", "Trump Card", "Heal Block", "Wring Out", "Power Trick", "Gastro Acid", "Lucky Chant", "Me First", "Copycat", "Power Swap", "Guard Swap", "Punishment", "Last Resort", "Worry Seed", "Sucker Punch", "Toxic Spikes", "Heart Swap", "Aqua Ring", "Magnet Rise", "Flare Blitz", "Force Palm", "Aura Sphere", "Rock Polish", "Poison Jab", "Dark Pulse", "Night Slash", "Aqua Tail", "Seed Bomb", "Air Slash", "X-Scissor", "Bug Buzz", "Dragon Pulse", "Dragon Rush", "Power Gem", "Drain Punch", "Vacuum Wave", "Focus Blast", "Energy Ball", "Brave Bird", "Earth Power", "Switcheroo", "Giga Impact", "Nasty Plot", "Bullet Punch", "Avalanche", "Ice Shard", "Shadow Claw", "Thunder Fang", "Ice Fang", "Fire Fang", "Shadow Sneak", "Mud Bomb", "Psycho Cut", "Zen Headbutt", "Mirror Shot", "Flash Cannon", "Rock Climb", "Defog", "Trick Room", "Draco Meteor", "Discharge", "Lava Plume", "Leaf Storm", "Power Whip", "Rock Wrecker", "Cross Poison", "Gunk Shot", "Iron Head", "Magnet Bomb", "Stone Edge", "Captivate", "Stealth Rock", "Grass Knot", "Chatter", "Judgment", "Bug Bite", "Charge Beam", "Wood Hammer", "Aqua Jet", "Attack Order", "Defend Order", "Heal Order", "Head Smash", "Double Hit", "Roar of Time", "Spacial Rend", "Lunar Dance", "Crush Grip", "Magma Storm", "Dark Void", "Seed Flare", "Ominous Wind", "Shadow Force", "Hone Claws", "Wide Guard", "Guard Split", "Power Split", "Wonder Room", "Psyshock", "Venoshock", "Autotomize", "Rage Powder", "Telekinesis", "Magic Room", "Smack Down", "Storm Throw", "Flame Burst", "Sludge Wave", "Quiver Dance", "Heavy Slam", "Synchronoise", "Electro Ball", "Soak", "Flame Charge", "Coil", "Low Sweep", "Acid Spray", "Foul Play", "Simple Beam", "Entrainment", "After You", "Round", "Echoed Voice", "Chip Away", "Clear Smog", "Stored Power", "Quick Guard", "Ally Switch", "Scald", "Shell Smash", "Heal Pulse", "Hex", "Sky Drop", "Shift Gear", "Circle Throw", "Incinerate", "Quash", "Acrobatics", "Reflect Type", "Retaliate", "Final Gambit", "Bestow", "Inferno", "Water Pledge", "Fire Pledge", "Grass Pledge", "Volt Switch", "Struggle Bug", "Bulldoze", "Frost Breath", "Dragon Tail", "Work Up", "Electroweb", "Wild Charge", "Drill Run", "Dual Chop", "Heart Stamp", "Horn Leech", "Sacred Sword", "Razor Shell", "Heat Crash", "Leaf Tornado", "Steamroller", "Cotton Guard", "Night Daze", "Psystrike", "Tail Slap", "Hurricane", "Head Charge", "Gear Grind", "Searing Shot", "Techno Blast", "Relic Song", "Secret Sword", "Glaciate", "Bolt Strike", "Blue Flare", "Fiery Dance", "Freeze Shock", "Ice Burn", "Snarl", "Icicle Crash", "V-create", "Fusion Flare", "Fusion Bolt", "Flying Press", "Mat Block", "Belch", "Rototiller", "Sticky Web", "Fell Stinger", "Phantom Force", "Trick-or-Treat", "Noble Roar", "Ion Deluge", "Parabolic Charge", "Forest’s Curse", "Petal Blizzard", "Freeze-Dry", "Disarming Voice", "Parting Shot", "Topsy-Turvy", "Draining Kiss", "Crafty Shield", "Flower Shield", "Grassy Terrain", "Misty Terrain", "Electrify", "Play Rough", "Fairy Wind", "Moonblast", "Boomburst", "Fairy Lock", "King’s Shield", "Play Nice", "Confide", "Diamond Storm", "Steam Eruption", "Hyperspace Hole", "Water Shuriken", "Mystical Fire", "Spiky Shield", "Aromatic Mist", "Eerie Impulse", "Venom Drench", "Powder", "Geomancy", "Magnetic Flux", "Happy Hour", "Electric Terrain", "Dazzling Gleam", "Celebrate", "Hold Hands", "Baby-Doll Eyes", "Nuzzle", "Hold Back", "Infestation", "Power-Up Punch", "Oblivion Wing", "Thousand Arrows", "Thousand Waves", "Land’s Wrath", "Light of Ruin", "Origin Pulse", "Precipice Blades", "Dragon Ascent", "Hyperspace Fury", "Breakneck Blitz", "Breakneck Blitz", "All-Out Pummeling", "All-Out Pummeling", "Supersonic Skystrike", "Supersonic Skystrike", "Acid Downpour", "Acid Downpour", "Tectonic Rage", "Tectonic Rage", "Continental Crush", "Continental Crush", "Savage Spin-Out", "Savage Spin-Out", "Never-Ending Nightmare", "Never-Ending Nightmare", "Corkscrew Crash", "Corkscrew Crash", "Inferno Overdrive", "Inferno Overdrive", "Hydro Vortex", "Hydro Vortex", "Bloom Doom", "Bloom Doom", "Gigavolt Havoc", "Gigavolt Havoc", "Shattered Psyche", "Shattered Psyche", "Subzero Slammer", "Subzero Slammer", "Devastating Drake", "Devastating Drake", "Black Hole Eclipse", "Black Hole Eclipse", "Twinkle Tackle", "Twinkle Tackle", "Catastropika", "Shore Up", "First Impression", "Baneful Bunker", "Spirit Shackle", "Darkest Lariat", "Sparkling Aria", "Ice Hammer", "Floral Healing", "High Horsepower", "Strength Sap", "Solar Blade", "Leafage", "Spotlight", "Toxic Thread", "Laser Focus", "Gear Up", "Throat Chop", "Pollen Puff", "Anchor Shot", "Psychic Terrain", "Lunge", "Fire Lash", "Power Trip", "Burn Up", "Speed Swap", "Smart Strike", "Purify", "Revelation Dance", "Core Enforcer", "Trop Kick", "Instruct", "Beak Blast", "Clanging Scales", "Dragon Hammer", "Brutal Swing", "Aurora Veil", "Sinister Arrow Raid", "Malicious Moonsault", "Oceanic Operetta", "Guardian of Alola", "Soul-Stealing 7-Star Strike", "Stoked Sparksurfer", "Pulverizing Pancake", "Extreme Evoboost", "Genesis Supernova", "Shell Trap", "Fleur Cannon", "Psychic Fangs", "Stomping Tantrum", "Shadow Bone", "Accelerock", "Liquidation", "Prismatic Laser", "Spectral Thief", "Sunsteel Strike", "Moongeist Beam", "Tearful Look", "Zing Zap", "Nature’s Madness", "Multi-Attack", "10,000,000 Volt Thunderbolt" };

        #endregion Moves

        #region Languages

        public static string[] Lang6 = { "JPN", "ENG", "FRE", "ITA", "GER", "SPA", "KOR" };

        public static string[] Lang7 = { "JPN", "ENG", "FRE", "ITA", "GER", "SPA", "KOR", "CHS", "CHT" };

        #endregion Languages

        #region Hidden Power

        public static string[] HPName = { "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel", "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark", };

        public static Color[] HPColor = { Color.FromArgb(192, 48, 40), Color.FromArgb(168, 144, 240), Color.FromArgb(160, 64, 160), Color.FromArgb(224, 192, 104), Color.FromArgb(184, 160, 56), Color.FromArgb(168, 184, 32), Color.FromArgb(112, 88, 152), Color.FromArgb(184, 184, 208), Color.FromArgb(240, 128, 48), Color.FromArgb(104, 144, 240), Color.FromArgb(120, 200, 80), Color.FromArgb(248, 208, 48), Color.FromArgb(248, 88, 136), Color.FromArgb(152, 216, 216), Color.FromArgb(112, 56, 248), Color.FromArgb(112, 88, 72) };

        public static string getHPName(int index)
        {
            if (index >= 0 && index < HPName.Length)
            {
                return HPName[index];
            }
            else
            {
                return "Any";
            }
        }

        #endregion Hidden Power

        #region Experience

        public static int getExpGroup(int species)
        {
            switch (species)
            {
                case 1: return 3; // Bulbasaur
                case 2: return 3; // Ivysaur
                case 3: return 3; // Venusaur
                case 4: return 3; // Charmander
                case 5: return 3; // Charmeleon
                case 6: return 3; // Charizard
                case 7: return 3; // Squirtle
                case 8: return 3; // Wartortle
                case 9: return 3; // Blastoise
                case 10: return 2; // Caterpie
                case 11: return 2; // Metapod
                case 12: return 2; // Butterfree
                case 13: return 2; // Weedle
                case 14: return 2; // Kakuna
                case 15: return 2; // Beedrill
                case 16: return 3; // Pidgey
                case 17: return 3; // Pidgeotto
                case 18: return 3; // Pidgeot
                case 19: return 2; // Rattata
                case 20: return 2; // Raticate
                case 21: return 2; // Spearow
                case 22: return 2; // Fearow
                case 23: return 2; // Ekans
                case 24: return 2; // Arbok
                case 25: return 2; // Pikachu
                case 26: return 2; // Raichu
                case 27: return 2; // Sandshrew
                case 28: return 2; // Sandslash
                case 29: return 3; // Nidoran♀
                case 30: return 3; // Nidorina
                case 31: return 3; // Nidoqueen
                case 32: return 3; // Nidoran♂
                case 33: return 3; // Nidorino
                case 34: return 3; // Nidoking
                case 35: return 1; // Clefairy
                case 36: return 1; // Clefable
                case 37: return 2; // Vulpix
                case 38: return 2; // Ninetales
                case 39: return 1; // Jigglypuff
                case 40: return 1; // Wigglytuff
                case 41: return 2; // Zubat
                case 42: return 2; // Golbat
                case 43: return 3; // Oddish
                case 44: return 3; // Gloom
                case 45: return 3; // Vileplume
                case 46: return 2; // Paras
                case 47: return 2; // Parasect
                case 48: return 2; // Venonat
                case 49: return 2; // Venomoth
                case 50: return 2; // Diglett
                case 51: return 2; // Dugtrio
                case 52: return 2; // Meowth
                case 53: return 2; // Persian
                case 54: return 2; // Psyduck
                case 55: return 2; // Golduck
                case 56: return 2; // Mankey
                case 57: return 2; // Primeape
                case 58: return 4; // Growlithe
                case 59: return 4; // Arcanine
                case 60: return 3; // Poliwag
                case 61: return 3; // Poliwhirl
                case 62: return 3; // Poliwrath
                case 63: return 3; // Abra
                case 64: return 3; // Kadabra
                case 65: return 3; // Alakazam
                case 66: return 3; // Machop
                case 67: return 3; // Machoke
                case 68: return 3; // Machamp
                case 69: return 3; // Bellsprout
                case 70: return 3; // Weepinbell
                case 71: return 3; // Victreebel
                case 72: return 4; // Tentacool
                case 73: return 4; // Tentacruel
                case 74: return 3; // Geodude
                case 75: return 3; // Graveler
                case 76: return 3; // Golem
                case 77: return 2; // Ponyta
                case 78: return 2; // Rapidash
                case 79: return 2; // Slowpoke
                case 80: return 2; // Slowbro
                case 81: return 2; // Magnemite
                case 82: return 2; // Magneton
                case 83: return 2; // Farfetch'd
                case 84: return 2; // Doduo
                case 85: return 2; // Dodrio
                case 86: return 2; // Seel
                case 87: return 2; // Dewgong
                case 88: return 2; // Grimer
                case 89: return 2; // Muk
                case 90: return 4; // Shellder
                case 91: return 4; // Cloyster
                case 92: return 3; // Gastly
                case 93: return 3; // Haunter
                case 94: return 3; // Gengar
                case 95: return 2; // Onix
                case 96: return 2; // Drowzee
                case 97: return 2; // Hypno
                case 98: return 2; // Krabby
                case 99: return 2; // Kingler
                case 100: return 2; // Voltorb
                case 101: return 2; // Electrode
                case 102: return 4; // Exeggcute
                case 103: return 4; // Exeggutor
                case 104: return 2; // Cubone
                case 105: return 2; // Marowak
                case 106: return 2; // Hitmonlee
                case 107: return 2; // Hitmonchan
                case 108: return 2; // Lickitung
                case 109: return 2; // Koffing
                case 110: return 2; // Weezing
                case 111: return 4; // Rhyhorn
                case 112: return 4; // Rhydon
                case 113: return 1; // Chansey
                case 114: return 2; // Tangela
                case 115: return 2; // Kangaskhan
                case 116: return 2; // Horsea
                case 117: return 2; // Seadra
                case 118: return 2; // Goldeen
                case 119: return 2; // Seaking
                case 120: return 4; // Staryu
                case 121: return 4; // Starmie
                case 122: return 2; // Mr. Mime
                case 123: return 2; // Scyther
                case 124: return 2; // Jynx
                case 125: return 2; // Electabuzz
                case 126: return 2; // Magmar
                case 127: return 4; // Pinsir
                case 128: return 4; // Tauros
                case 129: return 4; // Magikarp
                case 130: return 4; // Gyarados
                case 131: return 4; // Lapras
                case 132: return 2; // Ditto
                case 133: return 2; // Eevee
                case 134: return 2; // Vaporeon
                case 135: return 2; // Jolteon
                case 136: return 2; // Flareon
                case 137: return 2; // Porygon
                case 138: return 2; // Omanyte
                case 139: return 2; // Omastar
                case 140: return 2; // Kabuto
                case 141: return 2; // Kabutops
                case 142: return 4; // Aerodactyl
                case 143: return 4; // Snorlax
                case 144: return 4; // Articuno
                case 145: return 4; // Zapdos
                case 146: return 4; // Moltres
                case 147: return 4; // Dratini
                case 148: return 4; // Dragonair
                case 149: return 4; // Dragonite
                case 150: return 4; // Mewtwo
                case 151: return 3; // Mew
                case 152: return 3; // Chikorita
                case 153: return 3; // Bayleef
                case 154: return 3; // Meganium
                case 155: return 3; // Cyndaquil
                case 156: return 3; // Quilava
                case 157: return 3; // Typhlosion
                case 158: return 3; // Totodile
                case 159: return 3; // Croconaw
                case 160: return 3; // Feraligatr
                case 161: return 2; // Sentret
                case 162: return 2; // Furret
                case 163: return 2; // Hoothoot
                case 164: return 2; // Noctowl
                case 165: return 1; // Ledyba
                case 166: return 1; // Ledian
                case 167: return 1; // Spinarak
                case 168: return 1; // Ariados
                case 169: return 2; // Crobat
                case 170: return 4; // Chinchou
                case 171: return 4; // Lanturn
                case 172: return 2; // Pichu
                case 173: return 1; // Cleffa
                case 174: return 1; // Igglybuff
                case 175: return 1; // Togepi
                case 176: return 1; // Togetic
                case 177: return 2; // Natu
                case 178: return 2; // Xatu
                case 179: return 3; // Mareep
                case 180: return 3; // Flaaffy
                case 181: return 3; // Ampharos
                case 182: return 3; // Bellossom
                case 183: return 1; // Marill
                case 184: return 1; // Azumarill
                case 185: return 2; // Sudowoodo
                case 186: return 3; // Politoed
                case 187: return 3; // Hoppip
                case 188: return 3; // Skiploom
                case 189: return 3; // Jumpluff
                case 190: return 1; // Aipom
                case 191: return 3; // Sunkern
                case 192: return 3; // Sunflora
                case 193: return 2; // Yanma
                case 194: return 2; // Wooper
                case 195: return 2; // Quagsire
                case 196: return 2; // Espeon
                case 197: return 2; // Umbreon
                case 198: return 3; // Murkrow
                case 199: return 2; // Slowking
                case 200: return 1; // Misdreavus
                case 201: return 2; // Unown
                case 202: return 2; // Wobbuffet
                case 203: return 2; // Girafarig
                case 204: return 2; // Pineco
                case 205: return 2; // Forretress
                case 206: return 2; // Dunsparce
                case 207: return 3; // Gligar
                case 208: return 2; // Steelix
                case 209: return 1; // Snubbull
                case 210: return 1; // Granbull
                case 211: return 2; // Qwilfish
                case 212: return 2; // Scizor
                case 213: return 3; // Shuckle
                case 214: return 4; // Heracross
                case 215: return 3; // Sneasel
                case 216: return 2; // Teddiursa
                case 217: return 2; // Ursaring
                case 218: return 2; // Slugma
                case 219: return 2; // Magcargo
                case 220: return 4; // Swinub
                case 221: return 4; // Piloswine
                case 222: return 1; // Corsola
                case 223: return 2; // Remoraid
                case 224: return 2; // Octillery
                case 225: return 1; // Delibird
                case 226: return 4; // Mantine
                case 227: return 4; // Skarmory
                case 228: return 4; // Houndour
                case 229: return 4; // Houndoom
                case 230: return 2; // Kingdra
                case 231: return 2; // Phanpy
                case 232: return 2; // Donphan
                case 233: return 2; // Porygon2
                case 234: return 4; // Stantler
                case 235: return 1; // Smeargle
                case 236: return 2; // Tyrogue
                case 237: return 2; // Hitmontop
                case 238: return 2; // Smoochum
                case 239: return 2; // Elekid
                case 240: return 2; // Magby
                case 241: return 4; // Miltank
                case 242: return 1; // Blissey
                case 243: return 4; // Raikou
                case 244: return 4; // Entei
                case 245: return 4; // Suicune
                case 246: return 4; // Larvitar
                case 247: return 4; // Pupitar
                case 248: return 4; // Tyranitar
                case 249: return 4; // Lugia
                case 250: return 4; // Ho-Oh
                case 251: return 3; // Celebi
                case 252: return 3; // Treecko
                case 253: return 3; // Grovyle
                case 254: return 3; // Sceptile
                case 255: return 3; // Torchic
                case 256: return 3; // Combusken
                case 257: return 3; // Blaziken
                case 258: return 3; // Mudkip
                case 259: return 3; // Marshtomp
                case 260: return 3; // Swampert
                case 261: return 2; // Poochyena
                case 262: return 2; // Mightyena
                case 263: return 2; // Zigzagoon
                case 264: return 2; // Linoone
                case 265: return 2; // Wurmple
                case 266: return 2; // Silcoon
                case 267: return 2; // Beautifly
                case 268: return 2; // Cascoon
                case 269: return 2; // Dustox
                case 270: return 3; // Lotad
                case 271: return 3; // Lombre
                case 272: return 3; // Ludicolo
                case 273: return 3; // Seedot
                case 274: return 3; // Nuzleaf
                case 275: return 3; // Shiftry
                case 276: return 3; // Taillow
                case 277: return 3; // Swellow
                case 278: return 2; // Wingull
                case 279: return 2; // Pelipper
                case 280: return 4; // Ralts
                case 281: return 4; // Kirlia
                case 282: return 4; // Gardevoir
                case 283: return 2; // Surskit
                case 284: return 2; // Masquerain
                case 285: return 5; // Shroomish
                case 286: return 5; // Breloom
                case 287: return 4; // Slakoth
                case 288: return 4; // Vigoroth
                case 289: return 4; // Slaking
                case 290: return 0; // Nincada
                case 291: return 0; // Ninjask
                case 292: return 0; // Shedinja
                case 293: return 3; // Whismur
                case 294: return 3; // Loudred
                case 295: return 3; // Exploud
                case 296: return 5; // Makuhita
                case 297: return 5; // Hariyama
                case 298: return 1; // Azurill
                case 299: return 2; // Nosepass
                case 300: return 1; // Skitty
                case 301: return 1; // Delcatty
                case 302: return 3; // Sableye
                case 303: return 1; // Mawile
                case 304: return 4; // Aron
                case 305: return 4; // Lairon
                case 306: return 4; // Aggron
                case 307: return 2; // Meditite
                case 308: return 2; // Medicham
                case 309: return 4; // Electrike
                case 310: return 4; // Manectric
                case 311: return 2; // Plusle
                case 312: return 2; // Minun
                case 313: return 0; // Volbeat
                case 314: return 5; // Illumise
                case 315: return 3; // Roselia
                case 316: return 5; // Gulpin
                case 317: return 5; // Swalot
                case 318: return 4; // Carvanha
                case 319: return 4; // Sharpedo
                case 320: return 5; // Wailmer
                case 321: return 5; // Wailord
                case 322: return 2; // Numel
                case 323: return 2; // Camerupt
                case 324: return 2; // Torkoal
                case 325: return 1; // Spoink
                case 326: return 1; // Grumpig
                case 327: return 1; // Spinda
                case 328: return 3; // Trapinch
                case 329: return 3; // Vibrava
                case 330: return 3; // Flygon
                case 331: return 3; // Cacnea
                case 332: return 3; // Cacturne
                case 333: return 0; // Swablu
                case 334: return 0; // Altaria
                case 335: return 0; // Zangoose
                case 336: return 5; // Seviper
                case 337: return 1; // Lunatone
                case 338: return 1; // Solrock
                case 339: return 2; // Barboach
                case 340: return 2; // Whiscash
                case 341: return 5; // Corphish
                case 342: return 5; // Crawdaunt
                case 343: return 2; // Baltoy
                case 344: return 2; // Claydol
                case 345: return 0; // Lileep
                case 346: return 0; // Cradily
                case 347: return 0; // Anorith
                case 348: return 0; // Armaldo
                case 349: return 0; // Feebas
                case 350: return 0; // Milotic
                case 351: return 2; // Castform
                case 352: return 3; // Kecleon
                case 353: return 1; // Shuppet
                case 354: return 1; // Banette
                case 355: return 1; // Duskull
                case 356: return 1; // Dusclops
                case 357: return 4; // Tropius
                case 358: return 1; // Chimecho
                case 359: return 3; // Absol
                case 360: return 2; // Wynaut
                case 361: return 2; // Snorunt
                case 362: return 2; // Glalie
                case 363: return 3; // Spheal
                case 364: return 3; // Sealeo
                case 365: return 3; // Walrein
                case 366: return 0; // Clamperl
                case 367: return 0; // Huntail
                case 368: return 0; // Gorebyss
                case 369: return 4; // Relicanth
                case 370: return 1; // Luvdisc
                case 371: return 4; // Bagon
                case 372: return 4; // Shelgon
                case 373: return 4; // Salamence
                case 374: return 4; // Beldum
                case 375: return 4; // Metang
                case 376: return 4; // Metagross
                case 377: return 4; // Regirock
                case 378: return 4; // Regice
                case 379: return 4; // Registeel
                case 380: return 4; // Latias
                case 381: return 4; // Latios
                case 382: return 4; // Kyogre
                case 383: return 4; // Groudon
                case 384: return 4; // Rayquaza
                case 385: return 4; // Jirachi
                case 386: return 4; // Deoxys
                case 387: return 3; // Turtwig
                case 388: return 3; // Grotle
                case 389: return 3; // Torterra
                case 390: return 3; // Chimchar
                case 391: return 3; // Monferno
                case 392: return 3; // Infernape
                case 393: return 3; // Piplup
                case 394: return 3; // Prinplup
                case 395: return 3; // Empoleon
                case 396: return 3; // Starly
                case 397: return 3; // Staravia
                case 398: return 3; // Staraptor
                case 399: return 2; // Bidoof
                case 400: return 2; // Bibarel
                case 401: return 3; // Kricketot
                case 402: return 3; // Kricketune
                case 403: return 3; // Shinx
                case 404: return 3; // Luxio
                case 405: return 3; // Luxray
                case 406: return 3; // Budew
                case 407: return 3; // Roserade
                case 408: return 0; // Cranidos
                case 409: return 0; // Rampardos
                case 410: return 0; // Shieldon
                case 411: return 0; // Bastiodon
                case 412: return 2; // Burmy
                case 413: return 2; // Wormadam
                case 414: return 2; // Mothim
                case 415: return 3; // Combee
                case 416: return 3; // Vespiquen
                case 417: return 2; // Pachirisu
                case 418: return 2; // Buizel
                case 419: return 2; // Floatzel
                case 420: return 2; // Cherubi
                case 421: return 2; // Cherrim
                case 422: return 2; // Shellos
                case 423: return 2; // Gastrodon
                case 424: return 1; // Ambipom
                case 425: return 5; // Drifloon
                case 426: return 5; // Drifblim
                case 427: return 2; // Buneary
                case 428: return 2; // Lopunny
                case 429: return 1; // Mismagius
                case 430: return 3; // Honchkrow
                case 431: return 1; // Glameow
                case 432: return 1; // Purugly
                case 433: return 1; // Chingling
                case 434: return 2; // Stunky
                case 435: return 2; // Skuntank
                case 436: return 2; // Bronzor
                case 437: return 2; // Bronzong
                case 438: return 2; // Bonsly
                case 439: return 2; // Mime Jr.
                case 440: return 1; // Happiny
                case 441: return 3; // Chatot
                case 442: return 2; // Spiritomb
                case 443: return 4; // Gible
                case 444: return 4; // Gabite
                case 445: return 4; // Garchomp
                case 446: return 4; // Munchlax
                case 447: return 3; // Riolu
                case 448: return 3; // Lucario
                case 449: return 4; // Hippopotas
                case 450: return 4; // Hippowdon
                case 451: return 4; // Skorupi
                case 452: return 4; // Drapion
                case 453: return 2; // Croagunk
                case 454: return 2; // Toxicroak
                case 455: return 4; // Carnivine
                case 456: return 0; // Finneon
                case 457: return 0; // Lumineon
                case 458: return 4; // Mantyke
                case 459: return 4; // Snover
                case 460: return 4; // Abomasnow
                case 461: return 3; // Weavile
                case 462: return 2; // Magnezone
                case 463: return 2; // Lickilicky
                case 464: return 4; // Rhyperior
                case 465: return 2; // Tangrowth
                case 466: return 2; // Electivire
                case 467: return 2; // Magmortar
                case 468: return 1; // Togekiss
                case 469: return 2; // Yanmega
                case 470: return 2; // Leafeon
                case 471: return 2; // Glaceon
                case 472: return 3; // Gliscor
                case 473: return 4; // Mamoswine
                case 474: return 2; // Porygon-Z
                case 475: return 4; // Gallade
                case 476: return 2; // Probopass
                case 477: return 1; // Dusknoir
                case 478: return 2; // Froslass
                case 479: return 2; // Rotom
                case 480: return 4; // Uxie
                case 481: return 4; // Mesprit
                case 482: return 4; // Azelf
                case 483: return 4; // Dialga
                case 484: return 4; // Palkia
                case 485: return 4; // Heatran
                case 486: return 4; // Regigigas
                case 487: return 4; // Giratina
                case 488: return 4; // Cresselia
                case 489: return 4; // Phione
                case 490: return 4; // Manaphy
                case 491: return 4; // Darkrai
                case 492: return 3; // Shaymin
                case 493: return 4; // Arceus
                case 494: return 4; // Victini
                case 495: return 3; // Snivy
                case 496: return 3; // Servine
                case 497: return 3; // Serperior
                case 498: return 3; // Tepig
                case 499: return 3; // Pignite
                case 500: return 3; // Emboar
                case 501: return 3; // Oshawott
                case 502: return 3; // Dewott
                case 503: return 3; // Samurott
                case 504: return 2; // Patrat
                case 505: return 2; // Watchog
                case 506: return 3; // Lillipup
                case 507: return 3; // Herdier
                case 508: return 3; // Stoutland
                case 509: return 2; // Purrloin
                case 510: return 2; // Liepard
                case 511: return 2; // Pansage
                case 512: return 2; // Simisage
                case 513: return 2; // Pansear
                case 514: return 2; // Simisear
                case 515: return 2; // Panpour
                case 516: return 2; // Simipour
                case 517: return 1; // Munna
                case 518: return 1; // Musharna
                case 519: return 3; // Pidove
                case 520: return 3; // Tranquill
                case 521: return 3; // Unfezant
                case 522: return 2; // Blitzle
                case 523: return 2; // Zebstrika
                case 524: return 3; // Roggenrola
                case 525: return 3; // Boldore
                case 526: return 3; // Gigalith
                case 527: return 2; // Woobat
                case 528: return 2; // Swoobat
                case 529: return 2; // Drilbur
                case 530: return 2; // Excadrill
                case 531: return 1; // Audino
                case 532: return 3; // Timburr
                case 533: return 3; // Gurdurr
                case 534: return 3; // Conkeldurr
                case 535: return 3; // Tympole
                case 536: return 3; // Palpitoad
                case 537: return 3; // Seismitoad
                case 538: return 2; // Throh
                case 539: return 2; // Sawk
                case 540: return 3; // Sewaddle
                case 541: return 3; // Swadloon
                case 542: return 3; // Leavanny
                case 543: return 3; // Venipede
                case 544: return 3; // Whirlipede
                case 545: return 3; // Scolipede
                case 546: return 2; // Cottonee
                case 547: return 2; // Whimsicott
                case 548: return 2; // Petilil
                case 549: return 2; // Lilligant
                case 550: return 2; // Basculin
                case 551: return 3; // Sandile
                case 552: return 3; // Krokorok
                case 553: return 3; // Krookodile
                case 554: return 3; // Darumaka
                case 555: return 3; // Darmanitan
                case 556: return 2; // Maractus
                case 557: return 2; // Dwebble
                case 558: return 2; // Crustle
                case 559: return 2; // Scraggy
                case 560: return 2; // Scrafty
                case 561: return 2; // Sigilyph
                case 562: return 2; // Yamask
                case 563: return 2; // Cofagrigus
                case 564: return 2; // Tirtouga
                case 565: return 2; // Carracosta
                case 566: return 2; // Archen
                case 567: return 2; // Archeops
                case 568: return 2; // Trubbish
                case 569: return 2; // Garbodor
                case 570: return 3; // Zorua
                case 571: return 3; // Zoroark
                case 572: return 1; // Minccino
                case 573: return 1; // Cinccino
                case 574: return 3; // Gothita
                case 575: return 3; // Gothorita
                case 576: return 3; // Gothitelle
                case 577: return 3; // Solosis
                case 578: return 3; // Duosion
                case 579: return 3; // Reuniclus
                case 580: return 2; // Ducklett
                case 581: return 2; // Swanna
                case 582: return 4; // Vanillite
                case 583: return 4; // Vanillish
                case 584: return 4; // Vanilluxe
                case 585: return 2; // Deerling
                case 586: return 2; // Sawsbuck
                case 587: return 2; // Emolga
                case 588: return 2; // Karrablast
                case 589: return 2; // Escavalier
                case 590: return 2; // Foongus
                case 591: return 2; // Amoonguss
                case 592: return 2; // Frillish
                case 593: return 2; // Jellicent
                case 594: return 1; // Alomomola
                case 595: return 2; // Joltik
                case 596: return 2; // Galvantula
                case 597: return 2; // Ferroseed
                case 598: return 2; // Ferrothorn
                case 599: return 3; // Klink
                case 600: return 3; // Klang
                case 601: return 3; // Klinklang
                case 602: return 4; // Tynamo
                case 603: return 4; // Eelektrik
                case 604: return 4; // Eelektross
                case 605: return 2; // Elgyem
                case 606: return 2; // Beheeyem
                case 607: return 3; // Litwick
                case 608: return 3; // Lampent
                case 609: return 3; // Chandelure
                case 610: return 4; // Axew
                case 611: return 4; // Fraxure
                case 612: return 4; // Haxorus
                case 613: return 2; // Cubchoo
                case 614: return 2; // Beartic
                case 615: return 2; // Cryogonal
                case 616: return 2; // Shelmet
                case 617: return 2; // Accelgor
                case 618: return 2; // Stunfisk
                case 619: return 3; // Mienfoo
                case 620: return 3; // Mienshao
                case 621: return 2; // Druddigon
                case 622: return 2; // Golett
                case 623: return 2; // Golurk
                case 624: return 2; // Pawniard
                case 625: return 2; // Bisharp
                case 626: return 2; // Bouffalant
                case 627: return 4; // Rufflet
                case 628: return 4; // Braviary
                case 629: return 4; // Vullaby
                case 630: return 4; // Mandibuzz
                case 631: return 2; // Heatmor
                case 632: return 2; // Durant
                case 633: return 4; // Deino
                case 634: return 4; // Zweilous
                case 635: return 4; // Hydreigon
                case 636: return 4; // Larvesta
                case 637: return 4; // Volcarona
                case 638: return 4; // Cobalion
                case 639: return 4; // Terrakion
                case 640: return 4; // Virizion
                case 641: return 4; // Tornadus
                case 642: return 4; // Thundurus
                case 643: return 4; // Reshiram
                case 644: return 4; // Zekrom
                case 645: return 4; // Landorus
                case 646: return 4; // Kyurem
                case 647: return 4; // Keldeo
                case 648: return 4; // Meloetta
                case 649: return 4; // Genesect
                case 650: return 3; // Chespin
                case 651: return 3; // Quilladin
                case 652: return 3; // Chesnaught
                case 653: return 3; // Fennekin
                case 654: return 3; // Braixen
                case 655: return 3; // Delphox
                case 656: return 3; // Froakie
                case 657: return 3; // Frogadier
                case 658: return 3; // Greninja
                case 659: return 2; // Bunnelby
                case 660: return 2; // Diggersby
                case 661: return 3; // Fletchling
                case 662: return 3; // Fletchinder
                case 663: return 3; // Talonflame
                case 664: return 2; // Scatterbug
                case 665: return 2; // Spewpa
                case 666: return 2; // Vivillon
                case 667: return 3; // Litleo
                case 668: return 3; // Pyroar
                case 669: return 2; // Flabébé
                case 670: return 2; // Floette
                case 671: return 2; // Florges
                case 672: return 2; // Skiddo
                case 673: return 2; // Gogoat
                case 674: return 2; // Pancham
                case 675: return 2; // Pangoro
                case 676: return 2; // Furfrou
                case 677: return 2; // Espurr
                case 678: return 2; // Meowstic
                case 679: return 2; // Honedge
                case 680: return 2; // Doublade
                case 681: return 2; // Aegislash
                case 682: return 2; // Spritzee
                case 683: return 2; // Aromatisse
                case 684: return 2; // Swirlix
                case 685: return 2; // Slurpuff
                case 686: return 2; // Inkay
                case 687: return 2; // Malamar
                case 688: return 2; // Binacle
                case 689: return 2; // Barbaracle
                case 690: return 2; // Skrelp
                case 691: return 2; // Dragalge
                case 692: return 4; // Clauncher
                case 693: return 4; // Clawitzer
                case 694: return 2; // Helioptile
                case 695: return 2; // Heliolisk
                case 696: return 2; // Tyrunt
                case 697: return 2; // Tyrantrum
                case 698: return 2; // Amaura
                case 699: return 2; // Aurorus
                case 700: return 2; // Sylveon
                case 701: return 2; // Hawlucha
                case 702: return 2; // Dedenne
                case 703: return 4; // Carbink
                case 704: return 4; // Goomy
                case 705: return 4; // Sliggoo
                case 706: return 4; // Goodra
                case 707: return 1; // Klefki
                case 708: return 2; // Phantump
                case 709: return 2; // Trevenant
                case 710: return 2; // Pumpkaboo
                case 711: return 2; // Gourgeist
                case 712: return 2; // Bergmite
                case 713: return 2; // Avalugg
                case 714: return 2; // Noibat
                case 715: return 2; // Noivern
                case 716: return 4; // Xerneas
                case 717: return 4; // Yveltal
                case 718: return 4; // Zygarde
                case 719: return 4; // Diancie
                case 720: return 4; // Hoopa
                case 721: return 4; // Volcanion
                case 722: return 3; // Rowlet
                case 723: return 3; // Dartrix
                case 724: return 3; // Decidueye
                case 725: return 3; // Litten
                case 726: return 3; // Torracat
                case 727: return 3; // Incineroar
                case 728: return 3; // Popplio
                case 729: return 3; // Brionne
                case 730: return 3; // Primarina
                case 731: return 2; // Pikipek
                case 732: return 2; // Trumbeak
                case 733: return 2; // Toucannon
                case 734: return 2; // Yungoos
                case 735: return 2; // Gumshoos
                case 736: return 2; // Grubbin
                case 737: return 2; // Charjabug
                case 738: return 2; // Vikavolt
                case 739: return 2; // Crabrawler
                case 740: return 2; // Crabominable
                case 741: return 2; // Oricorio
                case 742: return 2; // Cutiefly
                case 743: return 2; // Ribombee
                case 744: return 2; // Rockruff
                case 745: return 2; // Lycanroc
                case 746: return 1; // Wishiwashi
                case 747: return 2; // Mareanie
                case 748: return 2; // Toxapex
                case 749: return 2; // Mudbray
                case 750: return 2; // Mudsdale
                case 751: return 2; // Dewpider
                case 752: return 2; // Araquanid
                case 753: return 2; // Fomantis
                case 754: return 2; // Lurantis
                case 755: return 2; // Morelull
                case 756: return 2; // Shiinotic
                case 757: return 2; // Salandit
                case 758: return 2; // Salazzle
                case 759: return 2; // Stufful
                case 760: return 2; // Bewear
                case 761: return 3; // Bounsweet
                case 762: return 3; // Steenee
                case 763: return 3; // Tsareena
                case 764: return 1; // Comfey
                case 765: return 4; // Oranguru
                case 766: return 4; // Passimian
                case 767: return 2; // Wimpod
                case 768: return 2; // Golisopod
                case 769: return 2; // Sandygast
                case 770: return 2; // Palossand
                case 771: return 1; // Pyukumuku
                case 772: return 4; // Type: Null
                case 773: return 4; // Silvally
                case 774: return 3; // Minior
                case 775: return 4; // Komala
                case 776: return 2; // Turtonator
                case 777: return 2; // Togedemaru
                case 778: return 2; // Mimikyu
                case 779: return 2; // Bruxish
                case 780: return 2; // Drampa
                case 781: return 2; // Dhelmise
                case 782: return 4; // Jangmo-o
                case 783: return 4; // Hakamo-o
                case 784: return 4; // Kommo-o
                case 785: return 4; // Tapu Koko
                case 786: return 4; // Tapu Lele
                case 787: return 4; // Tapu Bulu
                case 788: return 4; // Tapu Fini
                case 789: return 4; // Cosmog
                case 790: return 4; // Cosmoem
                case 791: return 4; // Solgaleo
                case 792: return 4; // Lunala
                case 793: return 4; // Nihilego
                case 794: return 4; // Buzzwole
                case 795: return 4; // Pheromosa
                case 796: return 4; // Xurkitree
                case 797: return 4; // Celesteela
                case 798: return 4; // Kartana
                case 799: return 4; // Guzzlord
                case 800: return 4; // Necrozma
                case 801: return 4; // Magearna
                case 802: return 4; // Marshadow
                default: return -1; // Error
            }
        }

        public static uint[] getExpLevel(int level)
        {
            switch (level)
            {
                case 1: return new uint[] { 0, 0, 0, 0, 0, 0 };
                case 2: return new uint[] { 15, 6, 8, 9, 10, 4 };
                case 3: return new uint[] { 52, 21, 27, 57, 33, 13 };
                case 4: return new uint[] { 122, 51, 64, 96, 80, 32 };
                case 5: return new uint[] { 237, 100, 125, 135, 156, 65 };
                case 6: return new uint[] { 406, 172, 216, 179, 270, 112 };
                case 7: return new uint[] { 637, 274, 343, 236, 428, 178 };
                case 8: return new uint[] { 942, 409, 512, 314, 640, 276 };
                case 9: return new uint[] { 1326, 583, 729, 419, 911, 393 };
                case 10: return new uint[] { 1800, 800, 1000, 560, 1250, 540 };
                case 11: return new uint[] { 2369, 1064, 1331, 742, 1663, 745 };
                case 12: return new uint[] { 3041, 1382, 1728, 973, 2160, 967 };
                case 13: return new uint[] { 3822, 1757, 2197, 1261, 2746, 1230 };
                case 14: return new uint[] { 4719, 2195, 2744, 1612, 3430, 1591 };
                case 15: return new uint[] { 5737, 2700, 3375, 2035, 4218, 1957 };
                case 16: return new uint[] { 6881, 3276, 4096, 2535, 5120, 2457 };
                case 17: return new uint[] { 8155, 3930, 4913, 3120, 6141, 3046 };
                case 18: return new uint[] { 9564, 4665, 5832, 3798, 7290, 3732 };
                case 19: return new uint[] { 11111, 5487, 6859, 4575, 8573, 4526 };
                case 20: return new uint[] { 12800, 6400, 8000, 5460, 10000, 5440 };
                case 21: return new uint[] { 14632, 7408, 9261, 6458, 11576, 6482 };
                case 22: return new uint[] { 16610, 8518, 10648, 7577, 13310, 7666 };
                case 23: return new uint[] { 18737, 9733, 12167, 8825, 15208, 9003 };
                case 24: return new uint[] { 21012, 11059, 13824, 10208, 17280, 10506 };
                case 25: return new uint[] { 23437, 12500, 15625, 11735, 19531, 12187 };
                case 26: return new uint[] { 26012, 14060, 17576, 13411, 21970, 14060 };
                case 27: return new uint[] { 28737, 15746, 19683, 15244, 24603, 16140 };
                case 28: return new uint[] { 31610, 17561, 21952, 17242, 27440, 18439 };
                case 29: return new uint[] { 34632, 19511, 24389, 19411, 30486, 20974 };
                case 30: return new uint[] { 37800, 21600, 27000, 21760, 33750, 23760 };
                case 31: return new uint[] { 41111, 23832, 29791, 24294, 37238, 26811 };
                case 32: return new uint[] { 44564, 26214, 32768, 27021, 40960, 30146 };
                case 33: return new uint[] { 48155, 28749, 35937, 29949, 44921, 33780 };
                case 34: return new uint[] { 51881, 31443, 39304, 33084, 49130, 37731 };
                case 35: return new uint[] { 55737, 34300, 42875, 36435, 53593, 42017 };
                case 36: return new uint[] { 59719, 37324, 46656, 40007, 58320, 46656 };
                case 37: return new uint[] { 63822, 40522, 50653, 43808, 63316, 50653 };
                case 38: return new uint[] { 68041, 43897, 54872, 47846, 68590, 55969 };
                case 39: return new uint[] { 72369, 47455, 59319, 52127, 74148, 60505 };
                case 40: return new uint[] { 76800, 51200, 64000, 56660, 80000, 66560 };
                case 41: return new uint[] { 81326, 55136, 68921, 61450, 86151, 71677 };
                case 42: return new uint[] { 85942, 59270, 74088, 66505, 92610, 78533 };
                case 43: return new uint[] { 90637, 63605, 79507, 71833, 99383, 84277 };
                case 44: return new uint[] { 95406, 68147, 85184, 77440, 106480, 91998 };
                case 45: return new uint[] { 100237, 72900, 91125, 83335, 113906, 98415 };
                case 46: return new uint[] { 105122, 77868, 97336, 89523, 121670, 107069 };
                case 47: return new uint[] { 110052, 83058, 103823, 96012, 129778, 114205 };
                case 48: return new uint[] { 115015, 88473, 110592, 102810, 138240, 123863 };
                case 49: return new uint[] { 120001, 94119, 117649, 109923, 147061, 131766 };
                case 50: return new uint[] { 125000, 100000, 125000, 117360, 156250, 142500 };
                case 51: return new uint[] { 131324, 106120, 132651, 125126, 165813, 151222 };
                case 52: return new uint[] { 137795, 112486, 140608, 133229, 175760, 163105 };
                case 53: return new uint[] { 144410, 119101, 148877, 141677, 186096, 172697 };
                case 54: return new uint[] { 151165, 125971, 157464, 150476, 196830, 185807 };
                case 55: return new uint[] { 158056, 133100, 166375, 159635, 207968, 196322 };
                case 56: return new uint[] { 165079, 140492, 175616, 169159, 219520, 210739 };
                case 57: return new uint[] { 172229, 148154, 185193, 179056, 231491, 222231 };
                case 58: return new uint[] { 179503, 156089, 195112, 189334, 243890, 238036 };
                case 59: return new uint[] { 186894, 164303, 205379, 199999, 256723, 250562 };
                case 60: return new uint[] { 194400, 172800, 216000, 211060, 270000, 267840 };
                case 61: return new uint[] { 202013, 181584, 226981, 222522, 283726, 281456 };
                case 62: return new uint[] { 209728, 190662, 238328, 234393, 297910, 300293 };
                case 63: return new uint[] { 217540, 200037, 250047, 246681, 312558, 315059 };
                case 64: return new uint[] { 225443, 209715, 262144, 259392, 327680, 335544 };
                case 65: return new uint[] { 233431, 219700, 274625, 272535, 343281, 351520 };
                case 66: return new uint[] { 241496, 229996, 287496, 286115, 359370, 373744 };
                case 67: return new uint[] { 249633, 240610, 300763, 300140, 375953, 390991 };
                case 68: return new uint[] { 257834, 251545, 314432, 314618, 393040, 415050 };
                case 69: return new uint[] { 267406, 262807, 328509, 329555, 410636, 433631 };
                case 70: return new uint[] { 276458, 274400, 343000, 344960, 428750, 459620 };
                case 71: return new uint[] { 286328, 286328, 357911, 360838, 447388, 479600 };
                case 72: return new uint[] { 296358, 298598, 373248, 377197, 466560, 507617 };
                case 73: return new uint[] { 305767, 311213, 389017, 394045, 486271, 529063 };
                case 74: return new uint[] { 316074, 324179, 405224, 411388, 506530, 559209 };
                case 75: return new uint[] { 326531, 337500, 421875, 429235, 527343, 582187 };
                case 76: return new uint[] { 336255, 351180, 438976, 447591, 548720, 614566 };
                case 77: return new uint[] { 346965, 365226, 456533, 466464, 570666, 639146 };
                case 78: return new uint[] { 357812, 379641, 474552, 485862, 593190, 673863 };
                case 79: return new uint[] { 367807, 394431, 493039, 505791, 616298, 700115 };
                case 80: return new uint[] { 378880, 409600, 512000, 526260, 640000, 737280 };
                case 81: return new uint[] { 390077, 425152, 531441, 547274, 664301, 765275 };
                case 82: return new uint[] { 400293, 441094, 551368, 568841, 689210, 804997 };
                case 83: return new uint[] { 411686, 457429, 571787, 590969, 714733, 834809 };
                case 84: return new uint[] { 423190, 474163, 592704, 613664, 740880, 877201 };
                case 85: return new uint[] { 433572, 491300, 614125, 636935, 767656, 908905 };
                case 86: return new uint[] { 445239, 508844, 636056, 660787, 795070, 954084 };
                case 87: return new uint[] { 457001, 526802, 658503, 685228, 823128, 987754 };
                case 88: return new uint[] { 467489, 545177, 681472, 710266, 851840, 1035837 };
                case 89: return new uint[] { 479378, 563975, 704969, 735907, 881211, 1071552 };
                case 90: return new uint[] { 491346, 583200, 729000, 762160, 911250, 1122660 };
                case 91: return new uint[] { 501878, 602856, 753571, 789030, 941963, 1160499 };
                case 92: return new uint[] { 513934, 622950, 778688, 816525, 973360, 1214753 };
                case 93: return new uint[] { 526049, 643485, 804357, 844653, 1005446, 1254796 };
                case 94: return new uint[] { 536557, 664467, 830584, 873420, 1038230, 1312322 };
                case 95: return new uint[] { 548720, 685900, 857375, 902835, 1071718, 1354652 };
                case 96: return new uint[] { 560922, 707788, 884736, 932903, 1105920, 1415577 };
                case 97: return new uint[] { 571333, 730138, 912673, 963632, 1140841, 1460276 };
                case 98: return new uint[] { 583539, 752953, 941192, 995030, 1176490, 1524731 };
                case 99: return new uint[] { 591882, 776239, 970299, 1027103, 1212873, 1571884 };
                case 100: return new uint[] { 600000, 800000, 1000000, 1059860, 1250000, 1640000 };
                default: return new uint[] { 600000, 800000, 1000000, 1059860, 1250000, 1640000 };
            }
        }

        public static int getLevel(int species, int exp)
        {
            if (species > 0)
            {
                int expgroup = getExpGroup(species);
                uint currentexp;
                int lvl;
                for (lvl = 1; lvl <= 100; lvl++)
                {
                    currentexp = getExpLevel(lvl)[expgroup];
                    if (currentexp > exp)
                    {
                        lvl--;
                        break;
                    }
                    else if (currentexp == exp)
                    {
                        break;
                    }
                }
                return lvl;
            }
            else
            {
                return 1;
            }
        }

        public static uint getExp(int species, int lvl)
        {
            if (species > 0)
            {
                return getExpLevel(lvl)[getExpGroup(species)];
            }
            else
            {
                return 0;
            }
        }

        #endregion Experience

        #region Nature

        public static string[] natureList = { "Hardy", "Lonely", "Brave", "Adamant", "Naughty", "Bold", "Docile", "Relaxed", "Impish", "Lax", "Timid", "Hasty", "Serious", "Jolly", "Naive", "Modest", "Mild", "Quiet", "Bashful", "Rash", "Calm", "Gentle", "Sassy", "Careful", "Quirky" };

        public static string getNature(int index)
        {
            if (index >= 0 && index < natureList.Length)
            {
                return natureList[index];
            }
            else
            {
                return "Any";
            }
        }

        #endregion Nature

        #region Gender

        public static string getGender(int index)
        {
            switch (index)
            {
                case 0: return "Male";
                case 1: return "Female";
                case 2: return "Genderless";
                default: return "Any";
            }
        }

        #endregion Gender

        #region Buttons

        public static uint keyA = 0xFFE;
        public static uint keyB = 0xFFD;
        public static uint keyX = 0xBFF;
        public static uint keyY = 0x7FF;
        public static uint keyR = 0xEFF;
        public static uint keyL = 0xDFF;
        public static uint keySTART = 0xFF7;
        public static uint keySELECT = 0xFFB;
        public static uint DpadUP = 0xFBF;
        public static uint DpadDOWN = 0xF7F;
        public static uint DpadLEFT = 0xFDF;
        public static uint DpadRIGHT = 0xFEF;
        public static uint runUP = 0xFBD;
        public static uint runDOWN = 0xF7D;
        public static uint runLEFT = 0xFDD;
        public static uint runRIGHT = 0xFED;
        public static uint softReset = 0xCF7;
        public static uint nokey = 0xFFF;
        public static uint notouch = 0x02000000;
        public static uint nostick = 0x00800800;

        #endregion Buttons

        #region Box Position

        // Gen 6
        public static uint[] pokeposX6 = { 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180 };
        public static uint[] pokeposY6 = { 60, 60, 60, 60, 60, 60, 90, 90, 90, 90, 90, 90, 120, 120, 120, 120, 120, 120, 150, 150, 150, 150, 150, 150, 180, 180, 180, 180, 180, 180 };
        public static uint[] boxposX6 = { 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260 };
        public static uint[] boxposY6 = { 24, 24, 24, 24, 24, 24, 24, 24, 72, 72, 72, 72, 72, 72, 72, 72, 120, 120, 120, 120, 120, 120, 120, 120, 168, 168, 168, 168, 168, 168, 168 };

        // Gen 7
        public static uint[] pokeposX7 = { 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180 };
        public static uint[] pokeposY7 = { 70, 70, 70, 70, 70, 70, 100, 100, 100, 100, 100, 100, 130, 130, 130, 130, 130, 130, 160, 160, 160, 160, 160, 160, 190, 190, 190, 190, 190, 190 };
        public static uint[] boxposX7 = { 33, 69, 105, 141, 177, 213, 249, 285, 33, 69, 105, 141, 177, 213, 249, 285, 33, 69, 105, 141, 177, 213, 249, 285, 33, 69, 105, 141, 177, 213, 249, 285 };
        public static uint[] boxposY7 = { 36, 36, 36, 36, 36, 36, 36, 36, 84, 84, 84, 84, 84, 84, 84, 84, 132, 132, 132, 132, 132, 132, 132, 132, 180, 180, 180, 180, 180, 180, 180, 180 };

        #endregion Box Position

        #region Bots

        public static string[] SoftResetModes6 = { "Regular", "Mirage Spot", "Event", "Groudon/Kyogre", "Walk", "Palkia/Dialga/Giratina", "Tornadus/Thundurus/Landorus" };

        public static string[] SoftResetModes7 = { "Event", "Type:Null", "Tapus", "Solgaleo/Lunala", "Wild Pokemon", "Ultra Beast/Necrozma" };

        public static string[] BreedingModes6 = { "Simple", "Filter", "ESV/TSV" };

        public static string[] BreedingModes7 = { "Simple", "Filter", "ESV/TSV", "Accept/Reject" };

        #endregion Bots
    }

}