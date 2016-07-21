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
using GameEngine.Models;

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
        private List<LevelObject> fruitList;
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
            GameTexture.LoadTextures(this);
            this.pacMan = new PacMan(new Rectangle(0, 0, 32, 32), 0, 0);
            this.pacmanAnimator = new PacmanAnimator(this.pacMan);
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new Matrix();
            this.fruitList = new List<LevelObject>();
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.IsMouseVisible = true;
            this.butPlay = new CButton(GameTexture.playButton, this.graphics.GraphicsDevice);
            this.butPlay.SetPosition(new Vector2(300, 166));
            this.butExit = new CButton(GameTexture.exitButton, this.graphics.GraphicsDevice);
            this.butExit.SetPosition(new Vector2(300, 200));
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
            this.pacmanInputHandler = new PacmanInputHandler(this.pacMan, levelMatrix);
            Fruit.InitializeFruits(GraphicsDevice, levelMatrix);
            this.fruitList.AddRange(Fruit.GetFruitList());
            this.fruitList.AddRange(Fruit.GetGhostKillerList());
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
                    if (this.butPlay.isClicked)
                    {
                        //graphics.IsFullScreen = true; // set this to enable full screen
                        //this.graphics.ApplyChanges();
                        this.currentGameState = GameState.Playing;
                        this.isRunning = true;
                    }
            
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
                levelMatrix.Update(pacMan);
                Fruit.CheckCollisions(pacMan);
                base.Update(gameTime);
            }

            this.Window.Title = $"Scores: {this.pacMan.Scores}   Left points:{this.levelMatrix.LeftPoints}  HEALTH:{this.pacMan.Health}";
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            this.spriteBatch.Begin();
            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    this.spriteBatch.Draw(GameTexture.mainMenu, new Rectangle(0, 0, Global.GLOBAL_WIDTH, Global.GLOBAL_HEIGHT), Color.White);
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
                    this.levelMatrix.Draw(this.spriteBatch);
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
            this.pacmanInputHandler.Reset();
            this.levelMatrix = new Matrix();
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
            Fruit.InitializeFruits(GraphicsDevice, levelMatrix);
            this.fruitList.Clear();
            this.fruitList.AddRange(Fruit.GetFruitList());
            this.fruitList.AddRange(Fruit.GetGhostKillerList());
            this.levelMatrix.RemovePoints(fruitList);
            Fruit.Draw(this.spriteBatch, pacMan);
        }
    }
}