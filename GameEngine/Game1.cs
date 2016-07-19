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
        private PacMan pacMan;
        private PacmanAnimator pacmanAnimator;
        private PacmanInputHandler pacmanInputHandler;
        private Matrix levelMatrix;
        private List<Fruit> fruitList;
        private bool isRunning;
        GameState currentGameState = GameState.MainMenu;
        CButton butPlay;
        CButton butExit;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.pacMan = new PacMan(this.GraphicsDevice, new Rectangle(0, 0, 32, 32));
            this.pacmanAnimator = new PacmanAnimator(this.pacMan);
            this.pacmanInputHandler = new PacmanInputHandler(this.pacMan);
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new Matrix();
            this.fruitList = new List<Fruit>();
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.IsMouseVisible = true;
            this.butPlay = new CButton(this.Content.Load<Texture2D>("MenuImages/PlayGame"), this.graphics.GraphicsDevice);
            this.butPlay.SetPosition(new Vector2(300, 166));
            this.butExit = new CButton(this.Content.Load<Texture2D>("MenuImages/Exit"), this.graphics.GraphicsDevice);
            this.butExit.SetPosition(new Vector2(300, 200));
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
            Fruit.InicializeFruits(GraphicsDevice);
            this.fruitList.AddRange(Fruit.GetFruitList());
            this.levelMatrix.RemovePoints(fruitList);
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

            switch (this.currentGameState)
            {

                case GameState.MainMenu:
                    MouseState mouse = Mouse.GetState();
                    if (this.butPlay.isClicked) this.currentGameState = GameState.Playing; this.isRunning = true;
                    if (this.butExit.isClicked) this.currentGameState = GameState.Exit;
                    this.butPlay.Update(mouse); this.butExit.Update(mouse);
                    break;
                case GameState.Options:
                    break;
                case GameState.Playing:
                    break;
                    case GameState.Exit:
                    break;
            }

            if (isRunning)
            {
                var pacmanMovement = this.pacmanInputHandler.Move(gameTime);
                this.pacmanAnimator.UpdateAnimation(gameTime, pacmanMovement);
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
                    this.butExit.Draw(this.spriteBatch);
                    break;
                case GameState.Options:
                    break;
                case GameState.Playing:
                    break;
                    case GameState.Exit:
                    Environment.Exit(0);
                    break;
               
            }
            this.spriteBatch.End();

            if (this.butPlay.isClicked)
            {
                if (this.pacMan.Health > 0)
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
                        if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        {
                            this.Reset();
                        }
                        else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            this.Exit();
                            using (var game = new Game1())
                                game.Run();
                        }
                    }
                    this.spriteBatch.End();
                }
            }
            else
            {

            }
            base.Draw(gameTime);
        }

        private void Reset()
        {
            isRunning = true;
            this.pacMan.X = 0;
            this.pacMan.Y = 0;
            this.pacMan.Scores = 0;
            this.pacMan.Health = 50;
            this.pacmanAnimator.CurrentDirection = "WalkRight";
            levelMatrix.InitializeMatrix(this.GraphicsDevice);
            Fruit.InicializeFruits(GraphicsDevice);
            this.fruitList = new List<Fruit>();
            this.fruitList.AddRange(Fruit.GetFruitList());
            this.levelMatrix.RemovePoints(fruitList);
            //Fruit.Draw(this.spriteBatch, pacMan);  Do we need this
        }
    }
}