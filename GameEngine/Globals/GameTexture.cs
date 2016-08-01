namespace GameEngine.Globals
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameTexture
    {
        public static Texture2D mainMenu;
        public static Texture2D playButton;
        public static Texture2D exitButton;
        public static Texture2D pacmanOpenSprite;
        public static Texture2D pacmanAndGhost;
        public static Texture2D brick;
        public static Texture2D point;
        public static Texture2D ghostKiller;
        public static List<Texture2D> fruitTexturesList;

        public static void LoadTextures(Game game)
        {
            mainMenu = game.Content.Load<Texture2D>("MenuImages/MainMenu");
            playButton = game.Content.Load<Texture2D>("MenuImages/PlayGame");
            exitButton = game.Content.Load<Texture2D>("MenuImages/Exit");

            List<string> allFruits = new List<string>();
            fruitTexturesList = new List<Texture2D>();
            allFruits = ExtractAllFruitImagePaths();
            foreach (var fruitTexturePath in allFruits)
            {
                fruitTexturesList.Add(game.Content.Load<Texture2D>(fruitTexturePath));
            }
            
            pacmanAndGhost = game.Content.Load<Texture2D>("PacManSprite_sheets");
            brick = game.Content.Load<Texture2D>("brick.png");
            point = game.Content.Load<Texture2D>("Point");
            ghostKiller = game.Content.Load<Texture2D>("GhostKiller");
        }

        private static List<string> ExtractAllFruitImagePaths()
        {
            const string fruitImagesFolder = @"Content/FruitImages";
            List<string> fruits = new List<string>();
            if (!Directory.Exists(fruitImagesFolder))
            {
                throw new DirectoryNotFoundException("Invalid path of level directory!");
            }
            DirectoryInfo directory = new DirectoryInfo(fruitImagesFolder);
            FileInfo[] files = directory.GetFiles("*.png");
            foreach (FileInfo file in files)
            {
                fruits.Add($@"FruitImages/{file.Name.Substring(0, file.Name.Length - 4)}");
            }
            return fruits;
        }
    }
}