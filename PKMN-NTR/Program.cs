using pkmn_ntr.Helpers;
using System;
using System.Windows.Forms;

namespace pkmn_ntr
{
    static class Program
    {
        public static NTR ntrClient;
        public static ScriptHelper scriptHelper;
        public static MainForm gCmdWindow;
        public static RemoteControl helper;

        [STAThread]
        static void Main()
        {
            ntrClient = new NTR();
            scriptHelper = new ScriptHelper();
            helper = new RemoteControl();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gCmdWindow = new MainForm();
            Application.Run(gCmdWindow);
        }
    }
}
