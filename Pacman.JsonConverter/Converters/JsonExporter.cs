namespace Pacman.JsonConverter.Converters
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class JsonExporter
    {
        private const string DirectoryPath = "../../JsonFiles/";

        public static void ExportToJsonFile<TEntity>(IEnumerable<TEntity> entities, string fileName)
                                                                                    where TEntity : class
        {
            var json = JsonConvert.SerializeObject(entities, Formatting.Indented);

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            File.WriteAllText(string.Concat(DirectoryPath, fileName, ".json"), json);
        }
    }
}