using System;
using System.Threading.Tasks;

namespace ntrbase.Helpers
{
    class RemoteControl
    {
        // Class variables
        private int timeout = 10; // Max timeout in seconds
        public uint lastRead = 0; // Last read from RAM
        public int pid = 0;
        PKHeX validator = new PKHeX();

        // Offsets for remote controls
        private uint buttonsOff = 0x10df20;
        private uint touchscrOff = 0x10df24;
        private uint stickOff = 0x10df28;
        private int hid_pid = 0x10;
        public const int BOXSIZE = 30;
        public const int POKEBYTES = 232;

        // Log Handler
        private void WriteLastLog(string str)
        {
            Program.gCmdWindow.lastlog = str;
        }

        private bool CompareLastLog(string str)
        {
            return Program.gCmdWindow.lastlog.Contains(str);
        }

        private void Report(string log)
        {
            Program.gCmdWindow.BeginInvoke(Program.gCmdWindow.delAddLog, log);
        }

        // Button Handler
        public async Task<bool> waitbutton(uint key)
        {
            Report("NTR: Send button command 0x" + key.ToString("X3"));
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
            {
                Report("NTR: Button press failed");
                return false;
            }
            else
            { // Free the buttons
                WriteLastLog("");
                buttonByte = BitConverter.GetBytes(LookupTable.nokey);
                Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
                for (readcount = 0; readcount < timeout * 10; readcount++)
                { // Timeout 2
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount >= timeout * 10) // If not response, return timeout
                {
                    Report("NTR: Button release failed");
                    return false;
                }
                else // Return sucess
                {
                    Report("NTR: Button command sent correctly");
                    return true;
                }
            }
        }

        public async void quickbuton(uint key, int time)
        {
            Report("NTR: Send button command 0x" + key.ToString("X3") + " during " + time + " ms");
            byte[] buttonByte = BitConverter.GetBytes(key);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(LookupTable.nokey);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            Report("NTR: Button command sent, no feedback provided");
        }

        public async Task<bool> waitSoftReset()
        {
            // Get and send hex coordinates
            Report("NTR: Send soft-reset command 0xCF7");
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(0xCF7);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount >= timeout * 10) // If not response, return timeout
            {
                Report("NTR: Button press failed");
                return false;
            }
            else
            { // Free the buttons
                WriteLastLog("");
                buttonByte = BitConverter.GetBytes(LookupTable.nokey);
                Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
                for (readcount = 0; readcount < timeout * 10; readcount++)
                { // Timeout 2
                    await Task.Delay(100);
                    if (CompareLastLog("finished") || CompareLastLog("patching smdh"))
                        break;
                }
                if (readcount >= timeout * 10) // If not response, return timeout
                {
                    Report("NTR: Button release failed");
                    return false;
                }
                else // Return sucess
                {
                    Report("NTR: Soft-reset command sent correctly");
                    return true;
                }
            }
        }

        // Touch Screen Handler
        public async Task<bool> waittouch(decimal Xcoord, decimal Ycoord)
        {
            // Get and send hex coordinates
            Report("NTR: Touch the screen at " + Xcoord.ToString("F0") + "," + Ycoord.ToString("F0"));
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount >= timeout * 10) // If no response, return timeout
            {
                Report("NTR: Touch screen press failed");
                return false;
            }
            else
            { // Free the touch screen
                WriteLastLog("");
                buttonByte = BitConverter.GetBytes(LookupTable.notouch);
                Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
                for (readcount = 0; readcount < timeout * 10; readcount++)
                { // Timeout 2
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount >= timeout * 10) // If not response in two seconds, return timeout
                {
                    Report("NTR: Touch screen release failed");
                    return false;
                }
                else // Return sucess
                {
                    Report("NTR: Touch screen command sent correctly");
                    return true;
                }
            }
        }

        public async Task<bool> waitholdtouch(decimal Xcoord, decimal Ycoord)
        {
            // Get and send hex coordinates
            Report("NTR: Touch the screen and hold at " + Xcoord.ToString("F0") + "," + Ycoord.ToString("F0"));
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount >= timeout * 10) // If no response, return timeout
            {
                Report("NTR: Touch screen press failed");
                return false;
            }
            else
            {
                Report("NTR: Touch screen command sent correctly");
                return true;
            }
        }

        public async Task<bool> waitfreetouch()
        {
            // Get and send hex coordinates
            Report("NTR: Free the touch screen");
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(LookupTable.notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount >= timeout * 10) // If no response, return timeout
            {
                Report("NTR: Touch screen release failed");
                return false;
            }
            else
            {
                Report("NTR: Touch screen command sent correctly");
                return true;
            }
        }

        public async void quicktouch(decimal Xcoord, decimal Ycoord, int time)
        {
            Report("NTR: Touch the screen at " + Xcoord.ToString("F0") + "," + Ycoord.ToString("F0") + " during " + time + " ms");
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(LookupTable.notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            Report("NTR: Touch screen command sent, no feedback provided");
        }

        public async void holdtouch(decimal Xcoord, decimal Ycoord)
        {
            Report("NTR: Touch the screen and hold at " + Xcoord.ToString("F0") + "," + Ycoord.ToString("F0"));
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(100);
            Report("NTR: Touch screen command sent, no feedback provided");
        }

        public async void freetouch()
        {
            Report("NTR: Free the touch screen");
            byte[] buttonByte = BitConverter.GetBytes(LookupTable.notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(100);
            Report("NTR: Touch screen command sent, no feedback provided");
        }

        private uint gethexcoord(decimal Xvalue, decimal Yvalue)
        {
            uint hexX = Convert.ToUInt32(Math.Round(Xvalue * 0xFFF / 319));
            uint hexY = Convert.ToUInt32(Math.Round(Yvalue * 0xFFF / 239));
            return 0x01000000 + hexY * 0x1000 + hexX;
        }

        // Control Stick Handler
        public async Task<bool> waitsitck(int Xvalue, int Yvalue)
        {
            Report("NTR: Move Control Stick to " + Xvalue.ToString("D3") + "," + Yvalue.ToString("D3"));
            // Get and send hex coordinates
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(getstickhex(Xvalue, Yvalue));
            Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            { // Timeout 1
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount >= timeout * 10) // If no response, return timeout
            {
                Report("NTR: Control Stick move failed");
                return false;
            }
            else
            { // Free the touch screen
                WriteLastLog("");
                buttonByte = BitConverter.GetBytes(LookupTable.nostick);
                Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
                for (readcount = 0; readcount < timeout * 10; readcount++)
                { // Timeout 2
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount >= timeout * 10) // If not response in two seconds, return timeout
                {
                    Report("NTR: Control Stick release failed");
                    return false;
                }
                else // Return sucess
                {
                    Report("NTR: Control Stick command sent correctly");
                    return true;
                }
            }
        }

        public async void quickstick(int Xvalue, int Yvalue, int time)
        {
            Report("NTR: Move Control Stick to " + Xvalue.ToString("D3") + "," + Yvalue.ToString("D3") + " during" + time + " ms");
            byte[] buttonByte = BitConverter.GetBytes(getstickhex(Xvalue, Yvalue));
            Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(LookupTable.nostick);
            Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
            Report("NTR: Control Stick command sent, no feedback provided");
        }

        private uint getstickhex(int Xvalue, int Yvalue)
        {
            uint hexX = Convert.ToUInt32((Xvalue + 100) * 0xFFF / 200);
            uint hexY = Convert.ToUInt32((Yvalue + 100) * 0xFFF / 200);
            if (hexX >= 0x1000) hexX = 0xFFF;
            if (hexY >= 0x1000) hexY = 0xFFF;
            return 0x01000000 + hexY * 0x1000 + hexX;
        }

        // Memory Read Handler
        private void handleMemoryRead(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            lastRead = BitConverter.ToUInt32(args.data, 0);
            Program.gCmdWindow.HandleRAMread(lastRead);
        }

        public async Task<bool> waitNTRread(uint address)
        {
            Report("NTR: Read data at address 0x" + address.ToString("X8"));
            lastRead = 0;
            WriteLastLog("");
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
            Program.gCmdWindow.addwaitingForData(Program.scriptHelper.data(address, 0x04, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount == timeout * 10)
            {
                Report("NTR: Read failed");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void handlePokeRead(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            validator.Data = PKHeX.decryptArray(args.data);
        }

        public async Task<long> waitPokeRead(int box, int slot)
        {
            try
            {
                Report("NTR: Read pokémon data at box " + (box + 1) + ", slot " + (slot + 1));
                uint dumpOff = Program.gCmdWindow.boxOff + (Convert.ToUInt32(box * BOXSIZE + slot) * POKEBYTES);
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePokeRead, null);
                Program.gCmdWindow.updateDumpBoxes(box, slot);
                Program.gCmdWindow.addwaitingForData(Program.scriptHelper.data(dumpOff, POKEBYTES, pid), myArgs);
                int readcount = 0;
                for (readcount = 0; readcount < timeout * 10; readcount++)
                {
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount == timeout * 10)
                {
                    Report("NTR: Read failed");
                    return -2; // No data received
                }
                else if (validator.Species != 0 && validator.Species <= Program.gCmdWindow.MAXSPECIES)
                {
                    lastRead = (uint)validator.Species;
                    Program.gCmdWindow.dumpedPKHeX.Data = validator.Data;
                    Program.gCmdWindow.updateTabs();
                    Report("NTR: Read sucessful - PID 0x" + validator.PID.ToString("X8"));
                    return validator.PID;
                }
                else // Empty slot
                {
                    Report("NTR: Empty pokémon data");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Report("NTR: Read failed with exception:");
                Report(ex.Message);
                return -2; // No data received
            }
        }

        public async Task<long> waitPokeRead(uint offset)
        {
            try
            {
                Report("NTR: Read pokémon data at offset 0x" + offset.ToString("X8"));
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePokeRead, null);
                Program.gCmdWindow.addwaitingForData(Program.scriptHelper.data(offset, POKEBYTES, pid), myArgs);
                int readcount = 0;
                for (readcount = 0; readcount < timeout * 10; readcount++)
                {
                    await Task.Delay(100);
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount == timeout * 10)
                {
                    Report("NTR: Read failed");
                    return -2; // No data received
                }
                else if (validator.Species != 0 && validator.Species <= Program.gCmdWindow.MAXSPECIES)
                {
                    lastRead = (uint)validator.Species;
                    Program.gCmdWindow.dumpedPKHeX.Data = validator.Data;
                    Program.gCmdWindow.updateTabs();
                    Report("NTR: Read sucessful - PID 0x" + validator.PID.ToString("X8"));
                    return validator.PID;
                }
                else // Empty slot
                {
                    Report("NTR: Empty pokémon data");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Report("NTR: Read failed with exception:");
                Report(ex.Message);
                return -2; // No data received
            }
        }

        public async Task<long> waitPartyRead(uint partyOff, int slot)
        {
            Report("NTR: Read pokémon data at party slot " + (slot + 1));
            uint dumpOff = Program.gCmdWindow.partyOff + Convert.ToUInt32(slot * 484);
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePokeRead, null);
            Program.gCmdWindow.addwaitingForData(Program.scriptHelper.data(dumpOff, POKEBYTES, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount == timeout * 10)
            {
                Report("NTR: Read failed");
                return -2; // No data received
            }
            else if (validator.Species != 0 && validator.Species <= Program.gCmdWindow.MAXSPECIES)
            {
                lastRead = (uint)validator.Species;
                Program.gCmdWindow.dumpedPKHeX.Data = validator.Data;
                Program.gCmdWindow.updateTabs();
                Report("NTR: Read sucessful - PID 0x" + validator.PID.ToString("X8"));
                return validator.PID;
            }
            else // Empty slot
            {
                Report("NTR: Empty pokémon data");
                return -1;
            }
        }

        public async Task<bool> memoryinrange(uint address, uint value, uint range)
        {
            Report("NTR: Read data at address 0x" + address.ToString("X8"));
            Report("NTR: Expected value 0x" + value.ToString("X8") + " to 0x" + (value + range - 1).ToString("X8"));
            lastRead = 0;
            WriteLastLog("");
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
            Program.gCmdWindow.addwaitingForData(Program.scriptHelper.data(address, 0x04, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount < timeout * 10)
            { // Data received

                if (lastRead >= value && lastRead < value + range)
                {
                    Report("NTR: Value in range: YES");
                    return true;
                }
                else
                {
                    Report("NTR: Value in range: NO");
                    return false;
                }
            }
            else // No data received
            {
                Report("NTR: Read failed");
                return false;
            }
        }

        public async Task<bool> timememoryinrange(uint address, uint value, uint range, int tick, int maxtime)
        {
            Report("NTR: Read data at address 0x" + address.ToString("X8") + " during " + maxtime + " ms");
            Report("NTR: Expected value 0x" + value.ToString("X8") + " to 0x" + (value + range - 1).ToString("X8"));
            int time = 0;
            while (time < maxtime)
            { // Ask for data
                lastRead = 0;
                WriteLastLog("");
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
                Program.gCmdWindow.addwaitingForData(Program.scriptHelper.data(address, 0x04, pid), myArgs);
                // Wait for data
                int readcount = 0;
                for (readcount = 0; readcount < timeout * 10; readcount++)
                {
                    await Task.Delay(100);
                    time += 100;
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount < timeout * 10)
                { // Data received
                    if (lastRead >= value && lastRead < value + range)
                    {
                        Report("NTR: Value in range: YES");
                        return true;
                    }
                    else
                    {
                        Report("NTR: Value in range: No");
                        await Task.Delay(tick);
                        time += tick;
                    }
                } // If no data received or not in range, try again
                else
                {
                    Report("NTR: Read failed");
                }
            }
            Report("NTR: Read failed or outside of range");
            return false;
        }

        // Memory Write handler
        public async Task<bool> waitNTRwrite(uint address, uint data, int pid)
        {
            Report("NTR: Write value 0x" + data.ToString("X8") + " at address 0x" + address.ToString("X8"));
            byte[] command = BitConverter.GetBytes(data);
            Program.scriptHelper.write(address, command, pid);
            int waittimeout;
            for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
            {
                WriteLastLog("");
                await Task.Delay(100);
                if (CompareLastLog("finished"))
                    break;
            }
            if (waittimeout < timeout)
            {
                Report("NTR: Write sucessful");
                return true;
            }
            else
            {
                Report("NTR: Write failed");
                return false;
            }
        }
    }
}
