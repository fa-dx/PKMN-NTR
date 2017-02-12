using PKHeX.Core;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    public static class Bot
    {
        public enum ErrorMessage { Finished, UserStop, ReadError, WriteError, ButtonError, TouchError, StickError, NotInPSS, FestivalPlaza, GeneralError };

        public static void Report(string message)
        {
            Program.gCmdWindow.addtoLog(message);
        }

        public static bool isLegal(PKM poke)
        {
            if (poke.GenNumber >= 6)
            {
                LegalityAnalysis Legal = new LegalityAnalysis(poke);
                return Legal.Valid;
            }
            else
            {
                return true;
            }
        }

        public static uint getBoxOff(uint startOff, NumericUpDown boxSource, NumericUpDown slotSource)
        {
            return startOff + (uint)(boxSource.Value - 1) * 30 * 232 + (uint)(slotSource.Value - 1) * 232;
        }

        public static int getIndex(NumericUpDown ctrl)
        {
            return (int)ctrl.Value - 1;
        }

        public static void showResult(string source, ErrorMessage message)
        {
            switch (message)
            {
                case ErrorMessage.Finished:
                    MessageBox.Show("Bot finished sucessfully.", source, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ErrorMessage.UserStop:
                    MessageBox.Show("Bot stopped by the user.", source, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ErrorMessage.ReadError:
                    MessageBox.Show("A error ocurred while reading data from the 3DS RAM.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorMessage.WriteError:
                    MessageBox.Show("A error ocurred while writting data to the 3DS RAM.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorMessage.ButtonError:
                    MessageBox.Show("A error ocurred while sending Button commands to the 3DS.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorMessage.TouchError:
                    MessageBox.Show("A error ocurred while sending Touch Screen commands to the 3DS.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorMessage.StickError:
                    MessageBox.Show("A error ocurred while sending Control Stick commands to the 3DS.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorMessage.NotInPSS:
                    MessageBox.Show("Please go to the PSS menu and try again.", source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case ErrorMessage.FestivalPlaza:
                    MessageBox.Show("Bot finished due level-up in Festival Plaza.", source, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ErrorMessage.GeneralError:
                    MessageBox.Show("A error has ocurred, see log for detals.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("An unknown error has ocurred, please keep the log and report this error.", source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
