using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarthorlPacMan.States
{
    public class ExtractAllLevels
    {
        private const string LevelFolder = @"DataFiles\Levels";
        private Dictionary<string, string> levels;

        public ExtractAllLevels()
        {
            this.levels = new Dictionary<string, string>();
        }

        public Dictionary<string, string> ExctractLevels()
        {
            if (!Directory.Exists(LevelFolder))
            {
                throw new DirectoryNotFoundException("Invalid path of level directory!");
            }
            DirectoryInfo directory = new DirectoryInfo(LevelFolder);
            FileInfo[] files = directory.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                var levelName = file.Name.Substring(0, file.Name.Length - 4);
                if (!this.levels.ContainsKey(levelName))
                {
                    this.levels.Add(levelName, LevelFolder + $@"\{file.Name}");
                }
            }

            return this.levels;
        }
    }
}
