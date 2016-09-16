using ntrbase.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ntrbase
{

    public partial class MainForm : Form
    {
        public string moneyoff;
        public string milesoff;
        public string bpoff;
        public int boff;
        public string boffs;
        public string pid;
        public string game;
        public string d1off;
        public string d2off;
        public string itemsoff;
        public bool firstcheck = false;
        public byte[] pkx;
        public byte[] items;
        public string selectedPkx;
        public int numofItems;
        public int test = 2;

        public string[] itemList = { "None", "Master Ball", "Ultra Ball", "Great Ball", "Poke Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Potion", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Paralyze Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Full Heal", "Revive", "Max Revive", "Fresh Water", "Soda Pop", "Lemonade", "Moomoo Milk", "Energy Powder", "Energy Root", "Heal Powder", "Revival Herb", "Ether", "Max Ether", "Elixir", "Max Elixir", "Lava Cookie", "Berry Juice", "Sacred Ash", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "PP Up", "Zinc", "PP Max", "Old Gateau", "Guard Spec.", "Dire Hit", "X Attack", "X Defense", "X Speed", "X Accuracy", "X Sp. Atk", "X Sp. Def", "Poke Doll", "Fluffy Tail", "Blue Flute", "Yellow Flute", "Red Flute", "Black Flute", "White Flute", "Shoal Salt", "Shoal Shell", "Red Shard", "Blue Shard", "Yellow Shard", "Green Shard", "Super Repel", "Max Repel", "Escape Rope", "Repel", "Sun Stone", "Moon Stone", "Fire Stone", "Thunder Stone", "Water Stone", "Leaf Stone", "Tiny Mushroom", "Big Mushroom", "Pearl", "Big Pearl", "Stardust", "Star Piece", "Nugget", "Heart Scale", "Honey", "Growth Mulch", "Damp Mulch", "Stable Mulch", "Gooey Mulch", "Root Fossil", "Claw Fossil", "Helix Fossil", "Dome Fossil", "Old Amber", "Armor Fossil", "Skull Fossil", "Rare Bone", "Shiny Stone", "Dusk Stone", "Dawn Stone", "Oval Stone", "Odd Keystone", "Griseous Orb", "???", "???", "???", "Douse Drive", "Shock Drive", "Burn Drive", "Chill Drive", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Sweet Heart", "Adamant Orb", "Lustrous Orb", "Greet Mail", "Favored Mail", "RSVP Mail", "Thanks Mail", "Inquiry Mail", "Like Mail", "Reply Mail", "Bridge Mail S", "Bridge Mail D", "Bridge Mail T", "Bridge Mail V", "Bridge Mail M", "Cheri Berry", "Chesto Berry", "Pecha Berry", "Rawst Berry", "Aspear Berry", "Leppa Berry", "Oran Berry", "Persim Berry", "Lum Berry", "Sitrus Berry", "Figy Berry", "Wiki Berry", "Mago Berry", "Aguav Berry", "Iapapa Berry", "Razz Berry", "Bluk Berry", "Nanab Berry", "Wepear Berry", "Pinap Berry", "Pomeg Berry", "Kelpsy Berry", "Qualot Berry", "Hondew Berry", "Grepa Berry", "Tamato Berry", "Cornn Berry", "Magost Berry", "Rabuta Berry", "Nomel Berry", "Spelon Berry", "Pamtre Berry", "Watmel Berry", "Durin Berry", "Belue Berry", "Occa Berry", "Passho Berry", "Wacan Berry", "Rindo Berry", "Yache Berry", "Chople Berry", "Kebai Berry", "Shuca Berry", "Coba Berry", "Payapa Berry", "Tanga Berry", "Charti Berry", "Kasib Berry", "Haban Berry", "Colbur Berry", "Babiri Berry", "Chilan Berry", "Liechi Berry", "Ganlon Berry", "Salac Berry", "Petaya Berry", "Apicot Berry", "Lansat Berry", "Starf Berry", "Enigma Berry", "Micle Berry", "Custap Berry", "Jaboca Berry", "Rowap Berry", "Bright Powder", "White Herb", "Macho Brace", "Exp. Share", "Quick Claw", "Soothe Bell", "Mental Herb", "Choice Band", "King's Rock", "Silver Powder", "Amulet Coin", "Cleanse Tag", "Soul Dew", "Deep Sea Tooth", "Deep Sea Scale", "Smoke Ball", "Everstone", "Focus Band", "Lucky Egg", "Scope Lens", "Metal Coat", "Leftovers", "Dragon Scale", "Light Ball", "Soft Sand", "Hard Stone", "Miracle Seed", "Black Glasses", "Black Belt", "Magnet", "Mystic Water", "Sharp Beak", "Poison Barb", "Never-Melt Ice", "Spell Tag", "Twisted Spoon", "Charcoal", "Dragon Fang", "Silk Scarf", "Up-Grade", "Shell Bell", "Sea Incense", "Lax Incense", "Lucky Punch", "Metal Powder", "Thick Club", "Stick", "Red Scarf", "Blue Scarf", "Pink Scarf", "Green Scarf", "Yellow Scarf", "Wide Lens", "Muscle Band", "Wise Glasses", "Expert Belt", "Light Clay", "Life Orb", "Power Herb", "Toxic Orb", "Flame Orb", "Quick Powder", "Focus Sash", "Zoom Lens", "Metronome", "Iron Ball", "Lagging Tail", "Destiny Knot", "Black Sludge", "Icy Rock", "Smooth Rock", "Heat Rock", "Damp Rock", "Grip Claw", "Choice Scarf", "Sticky Barb", "Power Bracer", "Power Belt", "Power Lens", "Power Band", "Power Anklet", "Power Weight", "Shed Shell", "Big Root", "Choice Specs", "Flame Plate", "Splash Plate", "Zap Plate", "Meadow Plate", "Icicle Plate", "Fist Plate", "Toxic Plate", "Earth Plate", "Sky Plate", "Mind Plate", "Insect Plate", "Stone Plate", "Spooky Plate", "Draco Plate", "Dread Plate", "Iron Plate", "Odd Incense", "Rock Incense", "Full Incense", "Wave Incense", "Rose Incense", "Luck Incense", "Pure Incense", "Protector", "Electrizer", "Magmarizer", "Dubious Disc", "Reaper Cloth", "Razor Claw", "Razor Fang", "Hone Claws", "Dragon Claw", "Psyshock", "Calm Mind", "Roar", "Toxic", "Hail", "Bulk Up", "Venoshock", "Hidden Power", "Sunny Day", "Taunt", "Ice Beam", "Blizzard", "Hyper Beam", "Light Screen", "Protect", "Rain Dance", "Roost", "Safeguard", "Frustration", "Solar Beam", "Smack Down", "Thunderbolt", "Thunder", "Earthquake", "Return", "Dig", "Psychic", "Shadow Ball", "Brick Break", "Double Team", "Reflect", "Sludge Wave", "Flamethrower", "Sludge Bomb", "Sandstorm", "Fire Blast", "Rock Tomb", "Aerial Ace", "Torment", "Facade", "Flame Charge", "Rest", "Attract", "Thief", "Low Sweep", "Round", "Echoed Voice", "Overheat", "Steel Wing", "Focus Blast", "Energy Ball", "False Swipe", "Scald", "Fling", "Charge Beam", "Sky Drop", "Incinerate", "Quash", "Will-O-Wisp", "Acrobatics", "Embargo", "Explosion", "Shadow Claw", "Payback", "Retaliate", "Giga Impact", "Rock Polish", "Flash", "Stone Edge", "Volt Switch", "Thunder Wave", "Gyro Ball", "Swords Dance", "Struggle Bug", "Psych Up", "Bulldoze", "Frost Breath", "Rock Slide", "X-Scissor", "Dragon Tail", "Infestation", "Poison Jab", "Dream Eater", "Grass Knot", "Swagger", "Sleep Talk", "U-turn", "Substitute", "Flash Cannon", "Trick Room", "Cut", "Fly", "Surf", "Strength", "Waterfall", "Rock Smash", "???", "???", "Explorer Kit", "Loot Sack", "Rule Book", "Poke Radar", "Point Card", "Journal", "Seal Case", "Fashion Case", "Seal Bag", "Pal Pad", "Works key", "Old Charm", "Galactic Key", "Red Chain", "Town Map", "Vs. Seeker", "Coin Case", "Old Rod", "Good Rod", "Super Rod", "Sprayduck", "Poffin Case", "Bike", "Suite Key", "Oak's Letter", "Lunar Wing", "Member Card", "Azure Flute", "S.S. Ticket", "Contest Pass", "Magma Stone", "Parcel", "Coupon 1", "Coupon 2", "Coupon 3", "Storage Key", "Secret Potion", "Vs. Recorder", "Gracidea", "Secret Key", "Apricorn Box", "Unown Report", "Berry Pots", "Dowsing Machine", "Blue Card", "Slowpoke Tail", "Clear Bell", "Card Key", "Basement Key", "Squirt Bottle", "Red Scale", "Lost Item", "Pass", "Machine Part", "Silver Wing", "Rainbow Wing", "Mystery Egg", "Red Apricorn", "Blue Apricorn", "Yellow Apricorn", "Green Apricorn", "Pink Apricorn", "White Apricorn", "Black Apricorn", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Park Ball", "Photo Album", "GB Sounds", "Tidal Bell", "Rage Candy Bar", "Data Card 01", "Data Card 02", "Data Card 03", "Data Card 04", "Data Card 05", "Data Card 06", "Data Card 07", "Data Card 08", "Data Card 09", "Data Card 10", "Data Card 11", "Data Card 12", "Data Card 13", "Data Card 14", "Data Card 15", "Data Card 16", "Data Card 17", "Data Card 18", "Data Card 19", "Data Card 20", "Data Card 21", "Data Card 22", "Data Card 23", "Data Card 24", "Data Card 25", "Data Card 26", "Data Card 27", "Jade Orb", "Lock Capsule", "Red Orb", "Blue Orb", "Enigma Stone", "Prism Scale", "Eviolite", "Float Stone", "Rocky Helmet", "Air Balloon", "Red Card", "Ring Target", "Binding Band", "Absorb Bulb", "Cell Battery", "Eject Button", "Fire Gem", "Water Gem", "Electric Gem", "Grass Gem", "Ice Gem", "Fighting Gem", "Poison Gem", "Ground Gem", "Flying Gem", "Psychic Gem", "Bug Gem", "Rock Gem", "Ghost Gem", "Dragon Gem", "Dark Gem", "Steel Gem", "Normal Gem", "Health Wing", "Muscle Wing", "Resist Wing", "Genius Wing", "Clever Wing", "Swift Wing", "Pretty Wing", "Cover Fossil", "Plume Fossil", "Libery Pass", "Pass Orb", "Dream Ball", "Poke Toy", "Prop Case", "Dragon Skull", "Balm Mushroom", "Big Nugget", "Pearl String", "Comet Shard", "Relic Copper", "Relic Silver", "Relic Gold", "Relic Vase", "Relic Band", "Relic Statue", "Relic Crown", "Casteliacone", "Dire Hit 2", "X Speed 2", "X Sp. Atk 2", "X Sp. Def 2", "X Defense 2", "X Attack 2", "X Accuracy 2", "X Speed 3", "X Sp. Atk 3", "X Sp. Def 3", "X Defense 3", "X Attack 3", "X Accuracy 3", "X Speed 6", "X Sp. Atk 6", "X Sp. Def 6", "X Defense 6", "X Attack 6", "X Accuracy 6", "Ability Urge", "Item Drop", "Item Urge", "Reset Urge", "Dire Hit 3", "Light Stone", "Dark Stone", "Wild Charge", "Secret Power", "Snarl", "Xtransceiver(Male)", "???", "Gram 1", "Gram 2", "Gram 3", "Xtransceiver(Female)", "Medal Box", "DNA Splicers(Fuses)", "DNA Splicers(Seperates)", "Permit", "Oval Charm", "Shiny Charm", "Plasma Card", "Grubby Hanky", "Colress Machine", "Dropped Item (Xtransceiver Male)", "Dropped Item (Xtransceiver Female)", "Reveal Glass", "Weakness Policy", "Assault Vest", "Holo Caster", "Prof's Letter", "Roller Skates", "Pixie Plate", "Ability Capsule", "Whipped Dream", "Sachet", "Luminous Moss", "Snowball", "Safety Goggles", "Poke Flute", "Rich Mulch", "Surprise Mulch", "Boost Mulch", "Amaze Mulch", "Gengarite", "Gardevoirite", "Ampharosite", "Venusaurite", "Charizardite X", "Blastoisinite", "Mewtwonite X", "Mewtwonite Y", "Blazikenite", "Medichamite", "Houndoominite", "Aggronite", "Banettite", "Tyranitarite", "Scizorite", "Pinsirite", "Aerodactylite", "Lucarionite", "Abomasite", "Kangaskhanite", "Gyaradosite", "Absolite", "Charizardite Y", "Alakazite", "Heracronite", "Mawilite", "Manectite", "Garchompite", "Latiasite", "Latiosite", "Roseli Berry", "Kee Berry", "Maranga Berry", "Sprinklotad", "Nature Power", "Dark Pulse", "Power-Up Punch", "Dazzling Gleam", "Confide", "Power Plant Pass", "Mega Ring", "Intruiging Stone", "Common Stone", "Discount Coupon", "Elevator Key", "TMV Pass", "Honor of Kalos", "Adventure Rules", "Strange Souvenir", "Lens Case", "Travel Trunk (Silver)", "Travel Trunk (Gold)", "Lumiose Galette", "Shalour Sable", "Jaw Fossil", "Sail Fossil", "Looker Ticket", "Bike", "Holo Caster", "Fairy Gem", "Mega Charm", "Mega Glove", "Mach Bike", "Acro Bike", "Wailmer Pail", "Devon Parts", "Soot Sack", "Basement Key", "Pokeblock Kit", "Letter", "Eon Ticket", "Scanner", "Go-Goggles", "Meteorite (originally found)", "Key to Room 1", "Key to Room 2", "Key to Room 4", "Key to Room 6", "Storage Key", "Devon Scope", "S.S. Ticket", "Dive", "Devon Scuba Gear", "Contest Costume (Male)", "Contest Costume (Female)", "Magma Suit", "Aqua Suit", "Pair of Tickets", "Mega Bracelet", "Mega Pendant", "Mega Glasses", "Mega Anchor", "Mega Stickpin", "Mega Tiara", "Mega Anklet", "Meteorite (faint glow)", "Swampertite", "Sceptilite", "Sablenite", "Altarianite", "Galladite", "Audinite", "Metagrossite", "Sharpedonite", "Slowbronite", "Steelixite", "Pidgeotite", "Glalitite", "Diancite", "Prison Bottle", "Mega Cuff", "Cameruptite", "Lopunnite", "Salamencite", "Beedrillite", "Meteorite (1)", "Meteorite (2)", "Key Stone", "Meteorite Shard", "Eon Flute" };


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

		void runCmd(String cmd)
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

		private void MainForm_Load(object sender, EventArgs e)
        {
            items1.SelectedIndex = 0;
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

            dataGridView1.Columns.Add(itemItem);
            dataGridView1.Columns.Add(itemAmount);

            foreach (string t in itemList)
                itemItem.Items.Add(t);
            host.Text = Settings.Default.IP;
            runCmd("import sys;sys.path.append('.\\python\\Lib')");
			runCmd("for n in [n for n in dir(nc) if not n.startswith('_')]: globals()[n] = getattr(nc,n)    ");
			runCmd("repr([n for n in dir(nc) if not n.startswith('_')])");
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
            runCmd("disconnect()");
        }



        public void connectCheck()
        {

            if (txtLog.Text.Contains("Server connected"))
            {
                buttonConnect.Text = "Connected";
                runCmd("listprocess()");
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                pokeMoney.Enabled = true;
                pokeMiles.Enabled = true;
                pokeBP.Enabled = true;
                moneyNum.Enabled = true;
                milesNum.Enabled = true;
                bpNum.Enabled = true;
                slot.Enabled = true;
                box.Enabled = true;
                selectPkx.Enabled = true;
                slotDump.Enabled = true;
                boxDump.Enabled = true;
                namePkx.Enabled = true;
                dumpPkx.Enabled = true;
                dumpBoxes.Enabled = true;
                radioBoxes.Enabled = true;
                radioDaycare.Enabled = true;
                Settings.Default.IP = host.Text;
                Settings.Default.Save();
            }
        }

        public void getGame()
        {

                if (txtLog.Text.Contains("kujira-1"))
                {
                    string log = txtLog.Text;
                    string pname = ", pname: kujira-1";
                    string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                    pid = "0x" + splitlog.Substring(0, 2);
                    moneyoff = "0x8C6A6AC";
                    milesoff = "0x8C82BA0";
                    bpoff = "0x8C6A6E0";
                    boff = 147349960;
                    boffs = "0x8C861C8";
                    d1off = "0x8C7FF4C";
                    d2off = "0x8C8003C";
                    itemsoff = "0x8C6EC70"; //UPDATE
                    dumpMoney();
                }

                if (txtLog.Text.Contains("kujira-2"))
                {
                    string log = txtLog.Text;
                    string pname = ", pname: kujira-2";
                    string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                    pid = "0x" + splitlog.Substring(0, 2);
                    moneyoff = "0x8C6A6AC";
                    milesoff = "0x8C82BA0";
                    bpoff = "0x8C6A6E0";
                    boff = 147349960;
                    boffs = "0x8C861C8";
                    d1off = "0x8C7FF4C";
                    d2off = "0x8C8003C";
                    itemsoff = "0x8C6EC70"; //UPDATE
                    dumpMoney();
            }

                if (txtLog.Text.Contains("sango-1"))
                {
                    string log = txtLog.Text;
                    string pname = ", pname:  sango-1";
                    string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                    pid = "0x" + splitlog.Substring(0, 2);
                    moneyoff = "0x8C71DC0";
                    milesoff = "0x8C8B36C";
                    bpoff = "0x8C71DE8";
                    boff = 147448116;
                    boffs = "0x8C9E134";
                    d1off = "0x8C88370";
                    d2off = "0x8C88460";
                    itemsoff = "0x8C6EC70";
                    dumpMoney();
            }

                if (txtLog.Text.Contains("sango-2"))
                {
                    string log = txtLog.Text;
                    string pname = ", pname:  sango-2";
                    string splitlog = log.Substring(log.IndexOf(pname) - 2, log.Length - log.IndexOf(pname));
                    pid = "0x" + splitlog.Substring(0, 2);
                    moneyoff = "0x8C71DC0";
                    milesoff = "0x8C8B36C";
                    bpoff = "0x8C71DE8";
                    boff = 147448116;
                    boffs = "0x8C9E134";
                    d1off = "0x8C88370";
                    d2off = "0x8C88460";
                    itemsoff = "0x8C6EC70";
                    dumpMoney();
            }
        }

        public void dumpItems()
        {
            string dumpItems = "data(" + itemsoff + ", 0x640, filename='items.temp', pid=" + pid + ")";
            runCmd(dumpItems);
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
            if (File.Exists(dumpedItems))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedItems, FileMode.Open)))
                {
                    const int itemsLength = 1600;
                    byte[] items = reader.ReadBytes(itemsLength);
                    string itemsstring = BitConverter.ToString(items).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length/(Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    int numofItems = Convert.ToInt32(numofItemsRounded);
                    dataGridView1.Rows.Add(numofItems);




                    //Read the item
                    byte[] item1 = items.Take(2).ToArray();
                    int items1Item = BitConverter.ToInt16(item1, 0);
                    items1.SelectedIndex = items1Item;

                    byte[] item2 = items.Skip(4).Take(2).ToArray();
                    int items2Item = BitConverter.ToInt16(item2, 0);
                    items2.SelectedIndex = items2Item;


                    //Read how many of the item there is
                    byte[] item1amnt = items.Skip(2).Take(2).ToArray();
                    int items1Amount = BitConverter.ToInt16(item1amnt, 0);
                    itemsNum1.Value = items1Amount;

                    byte[] item2amnt = items.Skip(6).Take(2).ToArray();
                    int items2Amount = BitConverter.ToInt16(item2amnt, 0);
                    itemsNum2.Value = items2Amount;
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

        public void movePkx()
        {
            if (txtLog.Text.Contains(".pkx successfully"))
            {
                txtLog.Clear();
                string pkmfrom = @Application.StartupPath + "\\" + namePkx.Text + ".pkx";
                string pkmto = @Application.StartupPath + "\\Pokemon\\" + namePkx.Text + ".pkx";
                System.IO.FileInfo folder = new System.IO.FileInfo(@Application.StartupPath + "\\Pokemon\\");
                folder.Directory.Create();
                if (File.Exists(pkmto))
                {
                        MessageBox.Show("That file already exists, please select a different filename.", "File Already Exists");
                        File.Delete(pkmfrom);
                }
                else
                if (!File.Exists(pkmto))
                {
                        File.Move(pkmfrom, pkmto);
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
                    dumpItems();
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

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            runCmd("connect('" + host.Text + "',8000)");
            Delay.Add(connectCheck, 1);
            Delay.Add(getGame, 2);
        }


        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
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
            slot.Enabled = false;
            box.Enabled = false;
            pokePkm.Enabled = false;
            selectPkx.Enabled = false;
            slotDump.Enabled = false;
            boxDump.Enabled = false;
            namePkx.Enabled = false;
            dumpPkx.Enabled = false;
            dumpBoxes.Enabled = false;
            radioBoxes.Enabled = false;
            radioDaycare.Enabled = false;
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            isMoneyDumped();
            isMilesDumped();
            isBPDumped();
            isItemsDumped();
            movePkx();
        }

        private void pokeMoney_Click(object sender, EventArgs e)
        {
            byte[] moneybyte = BitConverter.GetBytes(Convert.ToInt32(moneyNum.Value));
            string moneyr = ", 0x";
            string money = BitConverter.ToString(moneybyte).Replace("-", moneyr);
            string pokeMoney = "write(" + moneyoff + ", (0x" + money + "), pid=" + pid + ")";
            runCmd(pokeMoney);
        }

        private void pokeMiles_Click(object sender, EventArgs e)
        {
            byte[] milesbyte = BitConverter.GetBytes(Convert.ToInt32(milesNum.Value));
            string milesr = ", 0x";
            string miles = BitConverter.ToString(milesbyte).Replace("-", milesr);
            string pokeMiles = "write(" + milesoff + ", (0x" + miles + "), pid=" + pid + ")";
            runCmd(pokeMiles);
        }

        private void pokeBP_Click(object sender, EventArgs e)
        {
            byte[] bpbyte = BitConverter.GetBytes(Convert.ToInt32(bpNum.Value));
            string bpr = ", 0x";
            string bp = BitConverter.ToString(bpbyte).Replace("-", bpr);
            string pokeBP = "write(" + bpoff + ", (0x" + bp + "), pid=" + pid + ")";
            runCmd(pokeBP);
        }

        public void selectPkx_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectPkxDialog = new OpenFileDialog();
            selectPkxDialog.Title = "Select a PKX file";
            selectPkxDialog.Filter = "PKX files|*.pk6;*.pkx|All Files (*.*)|*.*";
            string path = @Application.StartupPath + "\\Pokemon";
            selectPkxDialog.InitialDirectory = path;
            if (selectPkxDialog.ShowDialog() == DialogResult.OK)
            {
                selectedPkx = selectPkxDialog.FileName;
                pokePkm.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pkxr = ", 0x";
            byte[] pkxb = File.ReadAllBytes(selectedPkx);
            string pkx = BitConverter.ToString(pkxb).Replace("-", pkxr);
            int ss = (Decimal.ToInt32(box.Value)* 30 - 30) + Decimal.ToInt32(slot.Value) - 1;
            int ssOff = boff + (ss * 232);
            string ssH = ssOff.ToString("X");
            if (pkx.Length == 1388)
            {
                string ssr = "0x";
                string ssS = ssr + ssH;
                string pokePkx = "write(0x" + ssH + ", (0x" + pkx + "), pid=" + pid + ")";
                runCmd(pokePkx);
                txtLog.Clear();
            }
            else
            {
                MessageBox.Show("Please make sure you are using a valid PKX file.", "Incorrect File Size");
                txtLog.Clear();
            }
        }

        private void dumpPkx_Click(object sender, EventArgs e)
        {
            int ssd = (Decimal.ToInt32(boxDump.Value)* 30 - 30) + Decimal.ToInt32(slotDump.Value) - 1;
            int ssdOff = boff + (ssd * 232);
            string ssdH = ssdOff.ToString("X");

            string dumpPkx = "data(0x" + ssdH + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";
            string dumpDay1 = "data(" + d1off + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";

            if (radioBoxes.Checked == true)
            {
                runCmd(dumpPkx);
            }
            if (radioDaycare.Checked == true)
            {
                runCmd(dumpDay1);
            }


            txtLog.Clear();
        }

        private void dumpBoxes_Click(object sender, EventArgs e)
        {
            string dumpBoxes = "data(" + boffs + ", 0x34AD0, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";

            string dumpDay2 = "data(" + d2off + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";

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
            label8.Text = "Box:";
            label7.Text = "Slot:";
            label9.Text = "Filename:";
            boxDump.Visible = true;
            slotDump.Visible = true;
            dumpBoxes.Visible = true;
            namePkx.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label9.Location = new System.Drawing.Point(96, 16);
            namePkx.Location = new System.Drawing.Point(98, 35);
            namePkx.Size = new System.Drawing.Size(82, 23);
            dumpPkx.Size = new System.Drawing.Size(86, 23);
            dumpBoxes.Size = new System.Drawing.Size(105, 23);
            dumpBoxes.Location = new System.Drawing.Point(98, 61);
            dumpPkx.Location = new System.Drawing.Point(6, 61);
            dumpPkx.Text = "Dump";
            dumpBoxes.Text = "Dump All Boxes";

        }

        private void radioDaycare_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;
            boxDump.Visible = false;
            slotDump.Visible = false;
            namePkx.Visible = true;
            dumpBoxes.Visible = true;
            dumpPkx.Location = new System.Drawing.Point(6, 61);
            namePkx.Location = new System.Drawing.Point(6, 35);
            label9.Location = new System.Drawing.Point(6, 16);
            dumpPkx.Size = new System.Drawing.Size(95, 23);
            dumpBoxes.Size = new System.Drawing.Size(95, 23);
            dumpBoxes.Location = new System.Drawing.Point(108, 61);
            namePkx.Size = new System.Drawing.Size(197, 23);
            dumpPkx.Text = "Dump Slot 1";
            dumpBoxes.Text = "Dump Slot 2";
        }

        private void items1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int item1 = items1.SelectedIndex;
            string item1s = item1.ToString("X");

            if (items1.SelectedIndex == 0)
            {
                itemsNum1.Enabled = false;
            }

            if (items1.SelectedIndex != 0)
            {
                itemsNum1.Enabled = true;
            }
        }

    }
}
