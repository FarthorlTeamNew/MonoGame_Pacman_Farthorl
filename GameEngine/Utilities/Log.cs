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
        private static DateTime dateTimeStamp;

        static Log()
        {
            logs = new Dictionary<LogEnumerable, List<string>>();
            dateTimeStamp = new DateTime();
        }

        public static void AddToLog(string input, LogEnumerable inLog)
        {
            input = dateTimeStamp.Date + " : " + input;

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

            if (logs.Keys.Count >= 10)
            {
                SaveLoggedLogs();
            }
        }

        private static void SaveLoggedLogs()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            foreach (var log in logs)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(currentDirectory + @"\DataFile\" + log.Key + ".log"))
                    {
                        foreach (var item in logs[log.Key])
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
                catch (Exception)
                {

                    throw new FileLoadException($"The logs cannot be saved in to the log file {log.Key}!");
                }

            }

            logs.Clear();
        }
    }
}
