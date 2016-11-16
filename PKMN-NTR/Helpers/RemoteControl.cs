using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntrbase.Helpers
{
    class RemoteControl
    {
        // Class variables
        int timeout = 10; // Max timeout in seconds

        // Offsets for remote controls
        public uint buttonsOff = 0x10df20;
        public uint touchscrOff = 0x10df24;
        public int hid_pid = 0x10;

        // Constant values for remote control
        public static readonly uint nokey = 0xFFF;
        public static readonly uint notouch = 0x02000000;

        private void WriteLastLog(string str)
        {
            Program.gCmdWindow.lastlog = str;
        }

        private bool CompareLastLog(string str)
        {
            return Program.gCmdWindow.lastlog.Contains(str);
        }

        public uint gethexcoord(decimal Xvalue, decimal Yvalue)
        {
            uint hexX = Convert.ToUInt32(Math.Round(Xvalue * 0xFFF / 319));
            uint hexY = Convert.ToUInt32(Math.Round(Yvalue * 0xFFF / 239));
            return 0x01000000 + hexY * 0x1000 + hexX;
        }

        public async Task<bool> waitbutton(uint key)
        {
            // Get and send hex coordinates
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(key);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount >= timeout * 10) // If not response, return timeout
                return false;
            else
            { // Free the buttons
                WriteLastLog("");
                buttonByte = BitConverter.GetBytes(nokey);
                Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
                for (readcount = 0; readcount < timeout * 10; readcount++)
                { // Timeout 2
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount >= timeout * 10) // If not response, return timeout
                    return false;
                else // Return sucess
                    return true;
            }
        }

        public async void quickbuton(uint key, int time)
        {
            byte[] buttonByte = BitConverter.GetBytes(key);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(nokey);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
        }

        public async Task<bool> waittouch(decimal Xcoord, decimal Ycoord)
        {
            // Get and send hex coordinates
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                {
                    break;
                }
            }
            if (readcount >= timeout * 10) // If no response, return timeout
                return false;
            else
            { // Free the touch screen
                WriteLastLog("");
                buttonByte = BitConverter.GetBytes(notouch);
                Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
                for (readcount = 0; readcount < timeout * 10; readcount++)
                { // Timeout 2
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount >= timeout * 10) // If not response in two seconds, return timeout
                    return false;
                else // Return sucess
                    return true;
            }
        }

        public async void quicktouch(decimal Xcoord, decimal Ycoord, int time)
        {
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
        }

    }
}
