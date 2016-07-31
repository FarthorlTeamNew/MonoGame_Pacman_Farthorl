using System.Collections.Generic;
using GameEngine.Animators;
using GameEngine.Animators.GhostAnimators;
using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Interfaces;
using GameEngine.Menu;
using GameEngine.Models;
using GameEngine.Models.LevelObjects;
using GameEngine.Models.LevelObjects.Ghosts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    public class GameInitializer
    {
        public Sound sound;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private PacMan pacMan;
        private Blinky blinky;
        private Clyde clyde;
        private Inky inky;
        private Pinky pinky;
        private List<Animator> animationObjects;
        private List<IMovable> movableObjects;
        private Matrix levelMatrix;
        private List<LevelObject> fruitList;
        private KeyPress keyPress;
        private KeyboardState oldState;
        private bool isLevelCompleated;
        GameState currentGameState = GameState.MainMenu;
        CButton butPlay;
        CButton butExit;

        public void Initialize(Game game)
        {
            this.movableObjects = new List<IMovable>();
            this.animationObjects = new List<Animator>();
            this.sound = new Sound(game);
            GameTexture.LoadTextures(game);

            this.pacMan = new PacMan(GameTexture.pacmanAndGhost, 0, 0, new Rectangle(0, 0, 32, 32));
            this.blinky = new Blinky(GameTexture.pacmanAndGhost, 4 * Global.quad_Width, 4 * Global.quad_Width, new Rectangle(0, 0, 32, 32));
            this.clyde = new Clyde(GameTexture.pacmanAndGhost, 64, 64, new Rectangle(0, 0, 32, 32));
            this.inky = new Inky(GameTexture.pacmanAndGhost, 512, 0, new Rectangle(0, 0, 32, 32));
            this.pinky = new Pinky(GameTexture.pacmanAndGhost, 576, 0, new Rectangle(0, 0, 32, 32));

            this.animationObjects.Add(new PacmanAnimator(this.pacMan));
            this.animationObjects.Add(new BlinkyAnimator(this.blinky));
            this.animationObjects.Add(new ClydeAnimator(this.clyde));
            this.animationObjects.Add(new InkyAnimator(this.inky));
            this.animationObjects.Add(new PinkyAnimator(this.pinky));
            
            this.levelMatrix = new Matrix();
            this.fruitList = new List<LevelObject>();
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.keyPress = new KeyPress();
            this.oldState = Keyboard.GetState();
            this.isLevelCompleated = false;
        }
    }
}
