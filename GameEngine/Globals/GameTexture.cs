namespace GameEngine.Globals
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameTexture
    {
        public static Texture2D MainMenu;
        public static Texture2D PlayButton;
        public static Texture2D HardPlayGame;
        public static Texture2D OptionsButton;
        public static Texture2D Instruction;
        public static Texture2D ExitButton;
        public static SpriteFont Font;
        public static Texture2D PacmanOpenSprite;
        public static Texture2D PacmanAndGhost;
        public static Texture2D Brick;
        public static Texture2D Point;
        public static Texture2D GhostKiller;
        public static Texture2D PacmanLose;
        public static Texture2D WinPic;
        public static Texture2D LosePic;
        public static List<Texture2D> FruitTexturesList;

        public static void LoadTextures(Game game)
        {
            MainMenu = game.Content.Load<Texture2D>("MenuImages/MainMenu");
            PlayButton = game.Content.Load<Texture2D>("MenuImages/PlayGame");
            HardPlayGame = game.Content.Load<Texture2D>("MenuImages/PlayGame");
            OptionsButton = game.Content.Load<Texture2D>("MenuImages/instructionbutton");
            Instruction = game.Content.Load<Texture2D>("MenuImages/instructions");
            ExitButton = game.Content.Load<Texture2D>("MenuImages/Exit");
            Font = game.Content.Load<SpriteFont>("ScoresFont");
            WinPic = game.Content.Load<Texture2D>("PacManWin_image");
            LosePic = game.Content.Load<Texture2D>("PacManLose");

            PacmanAndGhost = game.Content.Load<Texture2D>("PacManSprite_sheets");
            Brick = game.Content.Load<Texture2D>("brick.png");
            Point = game.Content.Load<Texture2D>("Point");
            GhostKiller = game.Content.Load<Texture2D>("GhostKiller");

            List<string> allFruits = new List<string>();
            FruitTexturesList = new List<Texture2D>();
            allFruits = ExtractAllFruitImagePaths();

            foreach (var fruitTexturePath in allFruits)
            {
                FruitTexturesList.Add(game.Content.Load<Texture2D>(fruitTexturePath));
            }
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