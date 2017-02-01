using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using PKHeX.Core;
using ntrbase.Helpers;

namespace ntrbase.Sub_forms
{
    public partial class Edit_Trainer : Form
    {
        private Task<bool> RAMreader;

        private Control[] Ctrls = new Control[] { };

        public Edit_Trainer()
        {
            InitializeComponent();
            Ctrls = new Control[] { TB_Name, Write_Name, Num_TID, Write_TID, Num_SID, Write_SID, Num_Money, Write_Money, Num_Miles, Write_Miles, Num_FestivalCoins, Num_FestivalCoins, Num_TotalFC,  Write_TotalFC, Num_Miles, Write_Miles, Num_BP, Write_BP, LB_Lang, Write_Lang, Num_Hour, Num_Min, Num_Sec, Write_Time, ReloadFields };
        }

        private void Edit_Trainer_Load(object sender, EventArgs e)
        {
            if (Program.gCmdWindow.SAV.Generation == 6)
            {
                Fill6();
            }
            else
            {
                Fill7();
            }
        }

        private void SetControls(bool state)
        {
            foreach (Control c in Ctrls)
            {
                Delg.SetEnabled(c, state);
            }
        }

        private async void Fill6()
        {
            SetControls(false);
            Delg.SetText(TB_Name, await waitName());
            Delg.SetValue(Num_TID, await waitTID());
            Delg.SetValue(Num_SID, await waitSID());
            Delg.SetValue(Num_Money, await waitMoney());
            Delg.SetValue(Num_Miles, await waitMiles());
            Delg.SetValue(Num_BP, await waitBP());
            byte[] time = await waitTime();
            Delg.SetValue(Num_Hour, BitConverter.ToUInt16(time, 0));
            Delg.SetValue(Num_Min, time[2]);
            Delg.SetValue(Num_Sec, time[3]);
            Delg.SetEnabled(ReloadFields, true);
        }

        private async void Fill7()
        {
            SetControls(false);
            TB_EggSeed.Clear();
            Delg.SetText(TB_Name, await waitName());
            Delg.SetValue(Num_TID, await waitTID());
            Delg.SetValue(Num_SID, await waitSID());
            Delg.SetValue(Num_Money, await waitMoney());
            Delg.SetValue(Num_FestivalCoins, await waitFestivalCoins());
            Delg.SetValue(Num_TotalFC, await waitTotalFC());
            Delg.SetValue(Num_BP, await waitBP());
            byte[] time = await waitTime();
            Delg.SetValue(Num_Hour, BitConverter.ToUInt16(time, 0));
            Delg.SetValue(Num_Min, time[2]);
            Delg.SetValue(Num_Sec, time[3]);
            Delg.SetText(TB_EggSeed, await waitEggSeed());
            Delg.SetText(TB_RNGSeed, await waitRNGSeed());
            Delg.SetEnabled(ReloadFields, true);
        }

        private async Task<string> waitName()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.nameOff, 0x1A);
            if (await RAMreader)
            {
                Delg.SetEnabled(TB_Name, true);
                Delg.SetEnabled(Write_Name, true);
                return Util.TrimFromZero(Encoding.Unicode.GetString(Program.helper.lastmultiread));
            }
            else
            {
                return null;
            }
        }

        private async Task<ushort> waitTID()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.tidOff, 0x02);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_TID, true);
                Delg.SetEnabled(Write_TID, true);
                return BitConverter.ToUInt16(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<ushort> waitSID()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.sidOff, 0x02);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_SID, true);
                Delg.SetEnabled(Write_SID, true);
                return BitConverter.ToUInt16(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<uint> waitMoney()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.moneyOff, 0x04);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_Money, true);
                Delg.SetEnabled(Write_Money, true);
                return BitConverter.ToUInt32(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<uint> waitMiles()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.milesOff, 0x04);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_Miles, true);
                Delg.SetEnabled(Write_Miles, true);
                return BitConverter.ToUInt32(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<uint> waitFestivalCoins()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.festivalcoinsOff, 0x04);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_FestivalCoins, true);
                Delg.SetEnabled(Write_FestivalCoins, true);
                return BitConverter.ToUInt32(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<uint> waitTotalFC()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.totalfcOff, 0x04);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_TotalFC, true);
                Delg.SetEnabled(Write_TotalFC, true);
                return BitConverter.ToUInt32(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<uint> waitBP()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.bpOff, 0x04);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_BP, true);
                Delg.SetEnabled(Write_BP, true);
                return BitConverter.ToUInt32(Program.helper.lastmultiread, 0);
            }
            else
            {
                return 0;
            }
        }

        private async Task<byte[]> waitTime()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.timeOff, 0x04);
            if (await RAMreader)
            {
                Delg.SetEnabled(Num_Hour, true);
                Delg.SetEnabled(Num_Min, true);
                Delg.SetEnabled(Num_Sec, true);
                Delg.SetEnabled(Write_Time, true);
                return Program.helper.lastmultiread;
            }
            else
            {
                return new byte[] { 0, 0, 0, 0 };
            }
        }

        private async Task<string> waitEggSeed()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.eggseedOff, 0x10);
            if (await RAMreader)
            {
                return BitConverter.ToString(Program.helper.lastmultiread.Reverse().ToArray()).Replace("-", "");
            }
            else
            {
                return null;
            }
        }

        private async Task<string> waitRNGSeed()
        {
            RAMreader = Program.helper.waitNTRmultiread(LookupTable.rngseedOff, 0x04);
            if (await RAMreader)
            {;
                return BitConverter.ToUInt32(Program.helper.lastmultiread, 0).ToString("X8");
            }
            else
            {
                return null;
            }
        }

        private void ReloadFields_Click(object sender, EventArgs e)
        {
            if (Program.gCmdWindow.SAV.Generation == 6)
            {
                Fill6();
            }
            else
            {
                Fill7();
            }
        }
    }
}
