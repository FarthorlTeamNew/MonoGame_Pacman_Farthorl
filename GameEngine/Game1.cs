using System;
using GameEngine.Animators;
using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameEngine.Menu;

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
        private bool isRunning = false;

        GameState currentGameState = GameState.MainMenu;
        CButton butPlay;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.IsMouseVisible = true;
            this.butPlay = new CButton(this.Content.Load<Texture2D>("MenuImages/PlayGame"), this.graphics.GraphicsDevice);

            this.butPlay.SetPosition(new Vector2(300, 166));
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

            MouseState mouse = Mouse.GetState();

            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    if (this.butPlay.isClicked == true)
                    {
                        this.currentGameState = GameState.Playing;
                        isRunning = true;
                    }
                    this.butPlay.Update(mouse);
                    break;
                case GameState.Options:
                    break;
                case GameState.Playing:
                    break;
            }
            if (isRunning)
            {
                var pacmanMovement = this.inputHandler.Move(gameTime);
                this.pacmanAnimator.UpdateAnimation(gameTime, pacmanMovement);
                this.pacMan.UpdateBoundingBox();
                base.Update(gameTime);

                this.Window.Title = $"Scores: {this.pacMan.Scores}   Left points:{this.levelMatrix.LeftPoints}  HEALTH:{this.pacMan.Health}";
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            this.spriteBatch.Begin();
            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    this.spriteBatch.Draw(this.Content.Load<Texture2D>("MenuImages/MainMenu"), new Rectangle(0, 0, Global.GLOBAL_WIDTH, Global.GLOBAL_HEIGHT), Color.White);
                    this.butPlay.Draw(this.spriteBatch);
                    break;
                case GameState.Options:
                    break;
                case GameState.Playing:
                    break;
            }
            this.spriteBatch.End();

            if (this.pacMan.Health > 0)
            {
                if (this.butPlay.isClicked)
                {
                    this.spriteBatch.Begin();
                    this.levelMatrix.Draw(this.spriteBatch, pacMan, fruitList);
                    Fruit.Draw(this.spriteBatch, pacMan);
                    this.pacmanAnimator.Draw(this.spriteBatch);
                    if (this.levelMatrix.LeftPoints == 0)
                    {
                        var texture = Content.Load<Texture2D>("PacManWin_image");
                        this.spriteBatch.Draw(texture, new Vector2(250, 100));
                        isRunning = false;

                    }
                    this.spriteBatch.End();
                }               
            }
            else
            {

            }
            base.Draw(gameTime);
        }
    }
}