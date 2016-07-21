using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pac.Resources
{
    public class GameTexture
    {
        public static Texture2D menuSprite;
        public static Texture2D startScreenSprite;
        public static Texture2D instructionSprite;
        public static Texture2D pacmanOpenSprite;
        public static Texture2D pacmanCloseSprite;
        public static Texture2D ghostSprite;
        public static Texture2D levelBackgroundSprite;
        public static Texture2D wallSprite;
        public static Texture2D pathSprite;
        public static Texture2D pelletSprite;
        public static Texture2D powerupSprite;
        public static Texture2D gameOverSprite;
        public static Texture2D levelCompleteSprite;
        public static Texture2D pauseSprite;
        public static Texture2D creditsSprite;

        public static SpriteFont spriteFont;
        
        public static void loadTextures(Game game)
        {
            menuSprite = game.Content.Load<Texture2D>("Scene/menu");
            startScreenSprite = game.Content.Load<Texture2D>("Scene/start_screen");
            instructionSprite = game.Content.Load<Texture2D>("Scene/instructions");
            pacmanOpenSprite = game.Content.Load<Texture2D>("Sprite/pacman");
            pacmanCloseSprite = game.Content.Load<Texture2D>("Sprite/pacman1");
            levelBackgroundSprite = game.Content.Load<Texture2D>("Scene/background");
            wallSprite = game.Content.Load<Texture2D>("Sprite/wall");
            pathSprite = game.Content.Load<Texture2D>("Sprite/path");
            pelletSprite = game.Content.Load<Texture2D>("Sprite/pellet");
            powerupSprite = game.Content.Load<Texture2D>("Sprite/powerup");
            ghostSprite = game.Content.Load<Texture2D>("Sprite/ghosts");
            gameOverSprite = game.Content.Load<Texture2D>("Misc/gameover");
            levelCompleteSprite = game.Content.Load<Texture2D>("Misc/levelcomplete");
            pauseSprite = game.Content.Load<Texture2D>("Scene/pause");
            creditsSprite = game.Content.Load<Texture2D>("Scene/credits");

          //  spriteFont = game.Content.Load<SpriteFont>("Font/SpriteFont1");
        }
    }
}
