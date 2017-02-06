using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntrbase.Bot
{
    class Bot
    {
        public static void Report(string message)
        {
            Program.gCmdWindow.addtoLog(message);
        }
    }
}
