using System;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace ntrbase
{
    static class Program
    {

        public static ScriptEngine pyEngine;
        public static NTR ntrClient;
		public static ScriptHelper scriptHelper;
		public static ScriptScope globalScope;
		public static MainForm gCmdWindow;

        [STAThread]
        static void Main()
        {
            pyEngine = Python.CreateEngine();
            ntrClient = new NTR();
			scriptHelper = new ScriptHelper();

			globalScope = pyEngine.CreateScope();
			globalScope.SetVariable("nc", scriptHelper);
			

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			gCmdWindow = new MainForm();
            Application.Run(gCmdWindow);
        }
    }
}
