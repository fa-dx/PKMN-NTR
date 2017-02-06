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
