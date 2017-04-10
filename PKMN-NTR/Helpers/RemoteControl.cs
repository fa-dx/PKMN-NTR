﻿using System;
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

        // Button Handler
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
                buttonByte = BitConverter.GetBytes(LookupTable.nokey);
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
            buttonByte = BitConverter.GetBytes(LookupTable.nokey);
            Program.scriptHelper.write(buttonsOff, buttonByte, hid_pid);
        }

        public async Task<bool> waitSoftReset()
        {
            // Get and send hex coordinates
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
                return false;
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
                    return false;
                else // Return sucess
                    return true;
            }
        }

        // Touch Screen Handler
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
                buttonByte = BitConverter.GetBytes(LookupTable.notouch);
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

        public async Task<bool> waitholdtouch(decimal Xcoord, decimal Ycoord)
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
                return true;
        }

        public async Task<bool> waitfreetouch()
        {
            // Get and send hex coordinates
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(LookupTable.notouch);
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
                return true;
        }

        public async void quicktouch(decimal Xcoord, decimal Ycoord, int time)
        {
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(LookupTable.notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
        }

        public async void holdtouch(decimal Xcoord, decimal Ycoord)
        {
            byte[] buttonByte = BitConverter.GetBytes(gethexcoord(Xcoord, Ycoord));
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(100);
        }

        public async void freetouch()
        {
            byte[] buttonByte = BitConverter.GetBytes(LookupTable.notouch);
            Program.scriptHelper.write(touchscrOff, buttonByte, hid_pid);
            await Task.Delay(100);
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
            // Get and send hex coordinates
            WriteLastLog("");
            byte[] buttonByte = BitConverter.GetBytes(getstickhex(Xvalue, Yvalue));
            Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
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
                buttonByte = BitConverter.GetBytes(LookupTable.nostick);
                Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
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

        public async void quickstick(int Xvalue, int Yvalue, int time)
        {
            byte[] buttonByte = BitConverter.GetBytes(getstickhex(Xvalue, Yvalue));
            Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
            await Task.Delay(time);
            buttonByte = BitConverter.GetBytes(LookupTable.nostick);
            Program.scriptHelper.write(stickOff, buttonByte, hid_pid);
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
                return -2; // No data received
            else if (validator.Species != 0)
            {
                Program.gCmdWindow.dumpedPKHeX.Data = validator.Data;
                Program.gCmdWindow.updateTabs();
                return validator.PID;
            }
            else // Empty slot
                return -1;
        }

        public async Task<long> waitPartyRead(uint partyOff, int slot)
        {
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
                return -2; // No data received
            else if (validator.Species != 0)
            {
                Program.gCmdWindow.dumpedPKHeX.Data = validator.Data;
                Program.gCmdWindow.updateTabs();
                return validator.PID;
            }
            else // Empty slot
                return -1;
        }

        public async Task<bool> memoryinrange(uint address, uint value, uint range)
        {
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
                    return true;
                else
                    return false;
            }
            else // No data received
                return false;
        }

        public async Task<bool> timememoryinrange(uint address, uint value, uint range, int tick, int maxtime)
        {
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
                        return true;
                    else
                    {
                        await Task.Delay(tick);
                        time += tick;
                    }
                } // If no data received or not in range, try again
            }
            return false;
        }

        // Memory Write handler
        public async Task<bool> waitNTRwrite(uint address, uint data, int pid)
        {
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
                return true;
            else
                return false;
        }
    }
}
