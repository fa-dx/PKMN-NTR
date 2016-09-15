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
            public string oppoff;
            public bool firstcheck = false;
            public byte[] pkx;
            public string selectedPkx;

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

		private void CmdWindow_Load(object sender, EventArgs e)
        {
            host.Text = Settings.Default.IP;
            runCmd("import sys;sys.path.append('.\\python\\Lib')");
			runCmd("for n in [n for n in dir(nc) if not n.startswith('_')]: globals()[n] = getattr(nc,n)    ");
			runCmd("repr([n for n in dir(nc) if not n.startswith('_')])");
		}

		private void CmdWindow_FormClosed(object sender, FormClosedEventArgs e)
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
                pokePkm.Enabled = true;
                selectPkx.Enabled = true;
                slotDump.Enabled = true;
                boxDump.Enabled = true;
                namePkx.Enabled = true;
                dumpPkx.Enabled = true;
                dumpBoxes.Enabled = true;
                radioBoxes.Enabled = true;
                radioDaycare.Enabled = true;
                radioOpponent.Enabled = true;
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
                    oppoff = "0x81FEBA0";
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
                    oppoff = "0x81FEBA0";
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
                    oppoff = "0x81FEEC8";
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
                    oppoff = "0x81FEEC8";
                    dumpMoney();
            }
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
                    firstcheck = true;
                    txtLog.Clear();
                    RMTemp();
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
            radioOpponent.Enabled = false;
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            isMoneyDumped();
            isMilesDumped();
            isBPDumped();
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
            string dumpOpp = "data(" + oppoff + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";
            string dumpDay1 = "data(" + d1off + ", 0xE8, filename='" + namePkx.Text + ".pkx', pid=" + pid + ")";

            if (radioBoxes.Checked == true)
            {
                runCmd(dumpPkx);
            }
            if (radioOpponent.Checked == true)
            {
                runCmd(dumpOpp);
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

        private void radioOpponent_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            dumpBoxes.Visible = false;
            label9.Visible = true;
            namePkx.Visible = true;
            label9.Location = new System.Drawing.Point(6, 16);
            namePkx.Location = new System.Drawing.Point(6, 35);
            namePkx.Size = new System.Drawing.Size(197, 23);
            dumpPkx.Size = new System.Drawing.Size(197, 23);
            dumpBoxes.Location = new System.Drawing.Point(98, 61);
            dumpPkx.Location = new System.Drawing.Point(6, 61);
            dumpPkx.Text = "Dump";
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
    }
}
