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
        public static Sound sound;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private PacMan pacMan;
        private bool isLevelCompleated;
        private PacmanAnimator pacmanAnimator;
        private PacmanInputHandler pacmanInputHandler;
        private Matrix levelMatrix;
        private List<LevelObject> fruitList;
        private KeyPress keyPress;
        private KeyboardState oldState;
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
            sound = new Sound(this);
            GameTexture.LoadTextures(this);
            this.pacMan = new PacMan(new Rectangle(0, 0, 32, 32), 0, 0);
            this.pacmanAnimator = new PacmanAnimator(this.pacMan);
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new Matrix();
            this.fruitList = new List<LevelObject>();
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.graphics.ApplyChanges();
            keyPress = new KeyPress();
            oldState = Keyboard.GetState();
            isLevelCompleated = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sound = new Sound(this);
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
            this.levelMatrix.RemovePoints(fruitList);
            sound.Begin();
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (keyPress.IsPressedKey(Keys.Escape, oldState))
            {
                if (currentGameState == GameState.Playing)
                {
                    currentGameState = GameState.MainMenu;
                    Reset();
                }
                else if(currentGameState == GameState.MainMenu)
                {
                    Exit();
                    return;
                }
            }

            switch (this.currentGameState)
            {

                case GameState.MainMenu:
                    MouseState mouse = Mouse.GetState();
                    this.butPlay.Update(mouse); this.butExit.Update(mouse);
                    if (this.butPlay.isClicked || keyPress.IsPressedKey(Keys.Space, oldState))
                    {
                        //graphics.IsFullScreen = true; // set this to enable full screen
                        //this.graphics.ApplyChanges();
                        this.currentGameState = GameState.Playing;
                        this.butPlay.isClicked = false; // BugFix - revert back to be ready for next click if we go in menu
                    }
                    if (this.butExit.isClicked) this.currentGameState = GameState.Exit;
                    break;
                case GameState.Options:
                    break;
                case GameState.Playing:
                    if (!isLevelCompleated)
                    {
                        var pacmanMovement = this.pacmanInputHandler.Move(gameTime);
                        this.pacmanAnimator.UpdateAnimation(gameTime, pacmanMovement);
                        levelMatrix.Update(pacMan);
                        Fruit.CheckCollisions(pacMan);
                    }
                    else   // Wining Condition
                    {
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
                    base.Update(gameTime);
                    break;
                case GameState.Exit:
                    break;
            }

            this.Window.Title = $"Scores: {this.pacMan.Scores}   Left points:{this.levelMatrix.LeftPoints}  HEALTH:{this.pacMan.Health}";
            oldState = Keyboard.GetState();  // Update saved state.
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

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
                    if (this.pacMan.Health > 0)
                    {
                        this.levelMatrix.Draw(this.spriteBatch);
                        Fruit.Draw(this.spriteBatch, pacMan);
                        this.pacmanAnimator.Draw(this.spriteBatch);

                        if (this.levelMatrix.LeftPoints == 0)
                        {
                            var texture = Content.Load<Texture2D>("PacManWin_image");
                            this.spriteBatch.Draw(texture, new Vector2(250, 100));
                            isLevelCompleated = true;
                        }
                    }
                    break;
                case GameState.Exit:
                    Environment.Exit(0);
                    break;
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Reset()
        {
            isLevelCompleated = false;
            this.pacMan.X = 0;
            this.pacMan.Y = 0;
            this.pacMan.Scores = 0;
            this.pacMan.Health = 50;
            this.pacmanAnimator.CurrentDirection = Direction.Right;
            this.pacmanInputHandler.Reset();
            this.levelMatrix = new Matrix();
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
            Fruit.InitializeFruits(GraphicsDevice, levelMatrix);
            this.fruitList.Clear();
            this.fruitList.AddRange(Fruit.GetFruitList());
            this.levelMatrix.RemovePoints(fruitList);
            //Fruit.Draw(this.spriteBatch, pacMan);
        }
    }
}