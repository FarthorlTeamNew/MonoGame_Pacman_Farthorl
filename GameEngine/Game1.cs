using System;
using GameEngine.Animators;
using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameEngine
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        public PacMan pacMan;
        private PacmanAnimator pacmanAnimator;
        private PacmanInputHandler inputHandler;
        private Matrix levelMatrix;
        private List<Fruit> fruitList;
        private bool isRunning = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.pacMan = new PacMan(this.GraphicsDevice, new Rectangle(0, 0, 32, 32));
            this.pacmanAnimator = new PacmanAnimator(this.pacMan);
            this.inputHandler = new PacmanInputHandler(this.pacMan);
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new Matrix(GraphicsDevice);
            this.fruitList = new List<Fruit>();
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            levelMatrix.LoadLevelMatrix(this.GraphicsDevice);
            Fruit.InicializeFruits(GraphicsDevice);
            fruitList.AddRange(Fruit.GetFruitList());
            // TODO: use this.Content to load your game content here

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }

            //// TODO: Add your update logic here
            if (isRunning)
            {
                var pacmanMovement = this.inputHandler.Move(gameTime);
                this.pacmanAnimator.UpdateAnimation(gameTime, pacmanMovement);
                this.pacMan.UpdateBoundingBox();
                base.Update(gameTime);

                this.Window.Title = $"Scores: {this.pacMan.Scores}   Left points:{this.levelMatrix.GetLeftPoints()}  HEALTH:{this.pacMan.Health}";
            }


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);
            if (this.pacMan.Health > 0)
            {
                this.spriteBatch.Begin();
                this.levelMatrix.Draw(this.spriteBatch, pacMan, fruitList);
                Fruit.Draw(this.spriteBatch, pacMan);
                this.pacmanAnimator.Draw(this.spriteBatch);
                if (this.levelMatrix.GetLeftPoints() == 0)
                {
                    var texture = Content.Load<Texture2D>("PacManWin_image");
                    this.spriteBatch.Draw(texture, new Vector2(250, 100));
                    isRunning = false;
               
                }
                this.spriteBatch.End();
            }
            else
            {

            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}