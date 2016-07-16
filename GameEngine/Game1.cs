using GameEngine.Animators;
using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public PacMan pacMan;
        private PacmanAnimator pacmanAnimator;
        private PacmanInputHandler inputHandler;
        private InitializeMatrix levelMatrix;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.pacMan = new PacMan(this.GraphicsDevice, new Rectangle(0, 0, 32, 32));
            this.pacmanAnimator = new PacmanAnimator(this.pacMan);
            this.inputHandler = new PacmanInputHandler(this.pacMan);
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new InitializeMatrix(GraphicsDevice);
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.graphics.ApplyChanges();

            
            graphics.ApplyChanges();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            levelMatrix.LoadLevelMatrix(this.GraphicsDevice);
            Fruit.InicializeFruits(GraphicsDevice);
            // TODO: use this.Content to load your game content here

        }

        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }

            //// TODO: Add your update logic here
            var pacmanMovement = this.inputHandler.Move(gameTime);
            this.pacmanAnimator.UpdateAnimation(gameTime, pacmanMovement);
            this.pacMan.UpdateBoundingBox();
            base.Update(gameTime);

            this.Window.Title = $"Scores: {this.pacMan.Scores}   Left points:{this.levelMatrix.GetLeftPoints()}";
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);
            if (this.pacMan.Health != 0)
            {
                this.spriteBatch.Begin();
                this.levelMatrix.Draw(this.spriteBatch, pacMan);
                Fruit.Draw(this.spriteBatch, pacMan);
                this.pacmanAnimator.Draw(this.spriteBatch);
                this.spriteBatch.End();
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}