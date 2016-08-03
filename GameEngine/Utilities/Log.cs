using System.Threading.Tasks;

namespace GameEngine.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Enums;

    public static class Log
    {

        public static async void AddToLog(string input, LogEnumerable inLog)
        {
            input = DateTime.Now + " : " + input;

            await SaveLoggedLogs(input, inLog);

        }

        private static async Task SaveLoggedLogs(string input, LogEnumerable inLog)
        {
            var currentDirectory = Directory.GetCurrentDirectory() + @"\DataFiles\Logs\";

            try
            {
                var file = currentDirectory + inLog + ".log";

                if (!File.Exists(file))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(file))
                    {
                        sw.WriteLine(input);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(input);
                    }

                }
            }
            catch (Exception)
            {

                throw new FileLoadException($"The logs cannot be saved in to the log file {inLog}!");
            }
        }
    }
}
