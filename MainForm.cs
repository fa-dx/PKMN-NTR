using ntrbase.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ntrbase
{



    public partial class MainForm : Form
    {
        public int tradedumpcount = 0;
        public string tradeoffrg;
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
        public string medsoff;
        public string keysoff;
        public string tmsoff;
        public string bersoff;
        public bool firstcheck = false;
        public byte[] pkx;
        public int additem = 0;
        private byte[] items2;
        public byte[] items
        {
            get { return items2; }
            set { items2 = value; }
        }
        private byte[] itemData = new byte[1600];
        private byte[] keyData = new byte[384];
        private byte[] tmData = new byte[432];
        private byte[] medData = new byte[256];
        private byte[] berryData = new byte[288];
        public byte[] data;
        public byte[] keys;
        public byte[] tms;
        public byte[] meds;
        public byte[] bers;
        public byte[] writeitems;
        public string selectedPkx;
        private int numofItems2;
        public int numofItems
        {
            get { return numofItems2; }
            set { numofItems2 = value; }
        }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
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
                tradeoffrg = "0x8500000";
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
                tradeoffrg = "0x8500000";
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
                tradeoffrg = "0x8520000";
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
                tradeoffrg = "0x8520000";
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
            string dumpRealtradeoff = "data(" + tradeoffrg + ", 0xFFFF, filename='gettradeoff.temp', pid=" + pid + ")";
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
                    byte[] items = reader.ReadBytes(itemsLength);
                    items2 = items;
                    string itemsstring = BitConverter.ToString(items).Replace("-", "");
                    string[] itemssplit = itemsstring.Split(new[] { "00000000" }, StringSplitOptions.None);
                    decimal numofItemsdec = itemssplit[0].Length/(Decimal)8;
                    decimal numofItemsRounded = Math.Ceiling(numofItemsdec);
                    int numofItems = Convert.ToInt32(numofItemsRounded);
                    numofItems2 = numofItems;
                    if (numofItems == 0)
                    {

                    }
                    if (numofItems != 0)
                    {
                        dataGridView1.Rows.Add(numofItems);
                    }
                    for (int i = 0; i < numofItems; i++)
                    {
                    uint itemsfinal = BitConverter.ToUInt16(items, i*4);
                    uint amountfinal = BitConverter.ToUInt16(items, (i*4)+2);
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
                    dataGridView2.Rows.Add(numofKeys);
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
                    dataGridView3.Rows.Add(numofTMs);
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
                    dataGridView4.Rows.Add(numofMeds);
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
                    dataGridView5.Rows.Add(numofBers);
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

                        foreach (int occurence in occurences)
                        {
                            int realoffsetint = 142606336 + occurence + 637;
                            string realoppoffset = "0x" + realoffsetint.ToString("X");
                            string dumpOpp = "data(" + realoppoffset + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";
                            runCmd(dumpOpp);
                        }
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
                            string dumpOpp = "data(" + realoppoffset + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";
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
                using (BinaryReader reader = new BinaryReader(File.Open(dumpedtradeOff, FileMode.Open)))
                {
                        byte[] relativePattern = { 0xC4, 0x03, 0x00, 0x00, 0x44, 0x55, 0x00, 0x00, 0x40, 0x10 };
                        byte[] dumptradeBytes = reader.ReadBytes(131070);
                        List<int> occurences = findOccurences(dumptradeBytes, relativePattern);


                             if (moneyoff == "0x8C6A6AC")
                        {

                        foreach (int occurence in occurences)
                        {
                            int realtradeoffsetint = 139460608 + occurence + 4777;
                            string realtradeoffset = "0x" + realtradeoffsetint.ToString("X");
                            string dumpTrade = "data(" + realtradeoffset + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";
                            runCmd(dumpTrade);
                        }
                        }

                            if (moneyoff == "0x8C71DC0")
                        {

                        foreach (int occurence in occurences)
                        {
                            int realtradeoffsetint = 139591680 + occurence + 4777;
                            string realtradeoffset = "0x" + realtradeoffsetint.ToString("X");
                            string dumpTrade = "data(" + realtradeoffset + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";
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
            if (txtLog.Text.Contains(namePkx.Text + ".pkx successfully"))
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
                    dumpName();
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
            radioOpponent.Enabled = false;
            radioTrade.Enabled = true;
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
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            isMoneyDumped();
            isMilesDumped();
            isBPDumped();
            isTIDDumped();
            isSIDDumped();
            isHrDumped();
            isMinDumped();
            isSecDumped();
            isNameDumped();
            isKeysDumped();
            isTMsDumped();
            isMedsDumped();
            isBersDumped();
            istradeDumped();
            isoppDumped();
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
                var size = new FileInfo(selectedPkx).Length;
                {
                    if (size != 232)
                    {
                        pokePkm.Enabled = false;
                        MessageBox.Show("Please make sure you are using a valid PKX file.", "Incorrect File Size");
                    }
                    else
                    {
                        pokePkm.Enabled = true;
                    }

                                            
                }

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
            if (radioOpponent.Checked == true)
            {
                dumprealoppOff();
            }
            if (radioTrade.Checked == true)
            {
                dumprealtradeOff();
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
            namePkx.Size = new System.Drawing.Size(105, 20);
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

        private void radioOpponent_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;
            boxDump.Visible = false;
            slotDump.Visible = false;
            namePkx.Visible = true;
            dumpBoxes.Visible = false;
            dumpPkx.Location = new System.Drawing.Point(6, 61);
            namePkx.Location = new System.Drawing.Point(6, 35);
            label9.Location = new System.Drawing.Point(6, 16);
            dumpPkx.Size = new System.Drawing.Size(197, 23);
            namePkx.Size = new System.Drawing.Size(197, 23);
            dumpPkx.Text = "Dump";
        }


        private void pokeBoxName_Click(object sender, EventArgs e)
        {

        }

        private void pokeName_Click(object sender, EventArgs e)
        {
            if (playerName.Text.Length < 12)
            {
                string nameS = playerName.Text.PadRight(12, '\0');
                byte[] namebyte = Encoding.Unicode.GetBytes(nameS);
                string namer = ", 0x";
                string name = BitConverter.ToString(namebyte).Replace("-", namer);
                string pokeName = "write(" + nameoff + ", (0x" + name + "), pid=" + pid + ")";
                runCmd(pokeName);
            }

            if (playerName.Text.Length == 12)
            {
                string nameS = playerName.Text;
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
            byte[] tidbyte = BitConverter.GetBytes(Convert.ToInt32(TIDNum.Value));
            string tidr = ", 0x";
            string tid = BitConverter.ToString(tidbyte).Replace("-", tidr);
            string pokeTID = "write(" + tidoff + ", (0x" + tid + "), pid=" + pid + ")";
            runCmd(pokeTID);
        }

        private void pokeTime_Click(object sender, EventArgs e)
        {
            byte[] hrbyte = BitConverter.GetBytes(Convert.ToInt32(hourNum.Value));
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


        public void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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
            namePkx.Visible = true;
            dumpBoxes.Visible = false;
            dumpPkx.Location = new System.Drawing.Point(6, 61);
            namePkx.Location = new System.Drawing.Point(6, 35);
            label9.Location = new System.Drawing.Point(6, 16);
            dumpPkx.Size = new System.Drawing.Size(197, 23);
            namePkx.Size = new System.Drawing.Size(197, 23);
            dumpPkx.Text = "Dump";
        }

        private void pokeSID_Click(object sender, EventArgs e)
        {
            byte[] sidbyte = BitConverter.GetBytes(Convert.ToInt32(SIDNum.Value));
            string sidr = ", 0x";
            string sid = BitConverter.ToString(sidbyte).Replace("-", sidr);
            string pokeSID = "write(" + sidoff + ", (0x" + sid + "), pid=" + pid + ")";
            runCmd(pokeSID);
        }
    }
}
