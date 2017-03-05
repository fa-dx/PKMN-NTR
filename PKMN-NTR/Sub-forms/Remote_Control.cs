using ntrbase.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Sub_forms
{
    public partial class Remote_Control : Form
    {
        public Remote_Control()
        {
            InitializeComponent();
        }

        // Manual button presses
        private void sendButton(uint command)
        {
            Program.helper.quickbuton(command, 200);
        }

        private void manualA_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyA);
        }

        private void manualB_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyB);
        }

        private void manualX_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyX);
        }

        private void manualY_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyY);
        }

        private void manualDUp_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadUP);
        }

        private void ManualDDown_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadDOWN);
        }

        private void manualDLeft_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadLEFT);
        }

        private void manualDRight_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadRIGHT);
        }

        private void manualStart_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keySTART);
        }

        private void manualSelect_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keySELECT);
        }

        private void manualL_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyL);
        }

        private void manualR_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyR);
        }

        private async void manualSR_Click(object sender, EventArgs e)
        {
            DialogResult dialogr = MessageBox.Show("Are you sure that you want to send a soft-reset command? The application will automatically disconnect from the game afterwards.", "Remote Control", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogr == DialogResult.Yes)
            {
                sendButton(LookupTable.softReset);
                await Task.Delay(1000);
                Program.gCmdWindow.PerformDisconnect();
            }
        }

        // Send manual touch command
        private void manualTouch_Click(object sender, EventArgs e)
        {
            Program.helper.quicktouch(touchX.Value, touchY.Value, 200);
        }

        // Send Control Stick command
        private void StickSend_Click(object sender, EventArgs e)
        {
            Program.helper.quickstick(StickX.Value, StickY.Value, 500);
        }

        // Control Stick controls
        private void StickY_Scroll(object sender, EventArgs e)
        {
            StickNumY.Value = StickY.Value;
        }

        private void StickX_Scroll(object sender, EventArgs e)
        {
            StickNumX.Value = StickX.Value;
        }

        private void StickNumY_ValueChanged(object sender, EventArgs e)
        {
            StickY.Value = (int)StickNumY.Value;
        }

        private void StickNumX_ValueChanged(object sender, EventArgs e)
        {
            StickX.Value = (int)StickNumX.Value;
        }

        private void Remote_Control_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.gCmdWindow.Tool_Finish();
        }
    }
}
