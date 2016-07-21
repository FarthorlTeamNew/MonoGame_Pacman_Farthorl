using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Globals
{
    public class GameTexture
    {

        public static Texture2D mainMenu;
        public static Texture2D playButton;
        public static Texture2D exitButton;
        public static Texture2D pacmanOpenSprite;
        public static Texture2D apple;
        public static Texture2D banana;
        public static Texture2D brezel;
        public static Texture2D cherry;
        public static Texture2D peach;
        public static Texture2D pear;
        public static Texture2D strawberry;


        public static void LoadTextures(Game game)
        {
            mainMenu = game.Content.Load<Texture2D>("MenuImages/MainMenu");
            playButton = game.Content.Load<Texture2D>("MenuImages/PlayGame");
            exitButton = game.Content.Load<Texture2D>("MenuImages/Exit");
            apple = game.Content.Load<Texture2D>("FruitImages/Apple");
            banana = game.Content.Load<Texture2D>("FruitImages/Banana");
            brezel = game.Content.Load<Texture2D>("FruitImages/Brezel");
            cherry = game.Content.Load<Texture2D>("FruitImages/Cherry");
            peach = game.Content.Load<Texture2D>("FruitImages/Peach");
            pear = game.Content.Load<Texture2D>("FruitImages/Pear");
            strawberry = game.Content.Load<Texture2D>("FruitImages/Strawberry");
            
        }
    }
}