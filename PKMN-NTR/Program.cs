using System;
using System.Windows.Forms;


namespace ntrbase
{
    static class Program
    {
        public static NTR ntrClient;
		public static ScriptHelper scriptHelper;
		public static MainForm gCmdWindow;

        [STAThread]
        static void Main()
        {
            ntrClient = new NTR();
			scriptHelper = new ScriptHelper();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			gCmdWindow = new MainForm();
            Application.Run(gCmdWindow);
        }
    }
}
