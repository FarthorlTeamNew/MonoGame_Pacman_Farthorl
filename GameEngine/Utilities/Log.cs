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
        private static Dictionary<LogEnumerable, List<string>> logs;

        static Log()
        {
            logs = new Dictionary<LogEnumerable, List<string>>();
        }

        public static void AddToLog(string input, LogEnumerable inLog)
        {
            input = DateTime.Now + " : " + input;

            if (logs.Keys.Contains(inLog))
            {
                logs[inLog].Add(input);

            }
            else
            {
                List<string> list = new List<string>();
                list.Add(input);
                logs.Add(inLog, list);
            }

            if (logs.Sum(l => l.Value.Count) >= 300)
            {
                SaveLoggedLogs();
            }
        }

        public static async void SaveLogOnExist()
        {
            await SaveLoggedLogs();
        }

        private static async Task SaveLoggedLogs()
        {
            var currentDirectory = Directory.GetCurrentDirectory() + @"\DataFiles\Logs\";
            foreach (var log in logs)
            {
                try
                {
                    var file = currentDirectory + log.Key + ".log";

                    if (!File.Exists(file))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(file))
                        {
                            foreach (var value in logs[log.Key])
                            {
                                sw.WriteLine(value);
                            }
                        }
                        logs.Clear();
                    }
                    else
                    {
                        File.Delete(file);
                        using (StreamWriter sw = File.CreateText(file))
                        {
                            foreach (var value in logs[log.Key])
                            {
                                sw.WriteLine(value);
                            }
                        }
                        logs.Clear();
                    }
                }
                catch (Exception)
                {

                    throw new FileLoadException($"The logs cannot be saved in to the log file {log.Key}!");
                }

            }
        }
    }
}
