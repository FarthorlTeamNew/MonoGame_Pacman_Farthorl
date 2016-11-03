using System;

namespace GameEngine.Handlers
{
    using System.IO;
    public static class Log
    {
        private static string logDirectory = Directory.GetCurrentDirectory() + @"\DataFiles\Logs\";

        public static void AddToLog(string input, LogsEnumerable logInToFile)
        {
            var file = logDirectory + logInToFile + ".txt";

            using (StreamWriter writer = File.AppendText(file))
            {
                string recordLine = DateTime.Now + ":" + input;
                writer.WriteLine(recordLine);
            }


        }
    }
}
