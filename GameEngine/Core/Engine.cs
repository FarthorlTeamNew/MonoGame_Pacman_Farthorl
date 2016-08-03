using System;
using GameEngine.Enums;
using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Menu;
using GameEngine.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Core
{
    public class Engine : Game
    {
        public static Sound sound;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private PacMan pacMan;
        private GhostGenerator ghostGen;
        private Matrix levelMatrix;
        private KeyPress keyPress;
        private KeyboardState oldState;
        private bool isLevelCompleated;
        private SpriteFont font;
        GameState currentGameState = GameState.MainMenu;
        CButton butPlay;
        CButton butOptions;
        CButton butExit;

        public Engine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            sound = new Sound(this);
            GameTexture.LoadTextures(this);
            this.pacMan = new PacMan(GameTexture.PacmanAndGhost, new Rectangle(0, 0, 32, 32));
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new Matrix();
            this.graphics.ApplyChanges();
            this.keyPress = new KeyPress();
            this.oldState = Keyboard.GetState();
            this.isLevelCompleated = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.butPlay = new CButton(GameTexture.PlayButton, this.graphics.GraphicsDevice);
            this.butPlay.SetPosition(new Vector2(300, 166));
            this.butExit = new CButton(GameTexture.ExitButton, this.graphics.GraphicsDevice);
            this.butExit.SetPosition(new Vector2(300, 235));
            this.butOptions = new CButton(GameTexture.OptionsButton, this.graphics.GraphicsDevice);
            this.butOptions.SetPosition(new Vector2(300, 200));
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
            this.ghostGen = new GhostGenerator(this.levelMatrix, this.pacMan);
            this.font = this.Content.Load<SpriteFont>("ScoresFont");
            sound = new Sound(this);
            sound.Begin();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (this.keyPress.IsPressedKey(Keys.Escape, this.oldState))
            {
                if (this.currentGameState == GameState.Playing)
                {
                    this.currentGameState = GameState.MainMenu;
                    this.Reset();
                }
                else if (this.currentGameState == GameState.MainMenu)
                {
                    this.Exit();
                    return;
                }
            }

            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    MouseState mouse = Mouse.GetState();
                    this.butPlay.Update(mouse); this.butExit.Update(mouse); this.butOptions.Update(mouse);
                    if (this.butPlay.isClicked || this.keyPress.IsPressedKey(Keys.Space, this.oldState))
                    {
                        //graphics.IsFullScreen = true; // set this to enable full screen
                        //this.graphics.ApplyChanges();
                        this.currentGameState = GameState.Playing;
                        this.butPlay.isClicked = false; 
                    }
                    if (this.butExit.isClicked) this.currentGameState = GameState.Exit;
                    if (this.butOptions.isClicked) this.currentGameState = GameState.Options;
                    break;
                case GameState.Options:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        this.currentGameState = GameState.MainMenu;
                        this.butOptions.isClicked = false;
                    }
                    break;
                case GameState.Playing:
                    if (!this.isLevelCompleated)
                    {
                        foreach (var kvp in this.ghostGen.GhostMovements)
                        {
                            var movedToPoint = this.ghostGen.GhostMovements[kvp.Key].Move(gameTime);
                            this.ghostGen.GhostAnimators[kvp.Key].UpdateAnimation(gameTime, movedToPoint);
                        }
                        this.levelMatrix.Update(this.pacMan, this.ghostGen);
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
                            using (var game = new Engine())
                                game.Run();
                        }
                    }
                    base.Update(gameTime);
                    break;
                case GameState.Exit:
                    break;
            }

            this.Window.Title = "PACMAN FARTHORL v.2.0";
            this.oldState = Keyboard.GetState();  // Update saved state.
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Green);

            this.spriteBatch.Begin();
            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    this.spriteBatch.Draw(GameTexture.MainMenu, new Rectangle(0, 0, Global.GLOBAL_WIDTH, Global.GLOBAL_HEIGHT), Color.White);
                    this.butPlay.Draw(this.spriteBatch);
                    this.butExit.Draw(this.spriteBatch);
                    this.butOptions.Draw(this.spriteBatch);
                    break;
                case GameState.Options:
                    this.spriteBatch.Draw(GameTexture.Instruction, new Rectangle(0, 0, Global.GLOBAL_WIDTH, Global.GLOBAL_HEIGHT), Color.White);
                    break;
                case GameState.Playing:

                    //Test scores background.. if you want delete it :)
                    ScoreBoard.LoadBoard(this.pacMan,this.spriteBatch,this,this.font,this.levelMatrix);

                    //==================

                    if (this.pacMan.Health > 0)
                    {
                        this.levelMatrix.Draw(this.spriteBatch);

                        foreach (var kvp in this.ghostGen.GhostAnimators)
                        {
                            kvp.Value.Draw(this.spriteBatch);
                        }

                        if (this.levelMatrix.LeftPoints == 0)
                        {
                            var texture = this.Content.Load<Texture2D>("PacManWin_image");
                            this.spriteBatch.Draw(texture, new Vector2(250, 100));
                            this.isLevelCompleated = true;
                        }
                        foreach (var ghost in this.ghostGen.Ghosts)
                        {
                            if (ghost.Value.IsColliding(this.pacMan) && !this.pacMan.CanEat)
                            {
                                var texture = this.Content.Load<Texture2D>("PacManLose");
                                this.spriteBatch.Draw(texture, new Vector2(250, 100));
                                if (this.isLevelCompleated == false)
                                {
                                    this.pacMan.Lives--;
                                    this.isLevelCompleated = true;
                                    sound.Dead();
                                }
                            }

                            else if (ghost.Value.IsColliding(this.pacMan) && this.pacMan.CanEat)
                            {
                                sound.GhostDies();
                                this.ghostGen.GhostMovements.Remove(ghost.Key);
                                this.ghostGen.GhostAnimators.Remove(ghost.Key);
                                this.ghostGen.Ghosts.Remove(ghost.Key);
                                break;
                            }
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
            //isLevelCompleated = false;
            //this.pacMan.Scores = 0;
            //this.pacMan.Health = 50;
            this.Initialize();
            //foreach (var kvp in ghostGen.GhostMovements)
            //{
            //    ghostGen.GhostMovements[kvp.Key].Reset();
            //    ghostGen.GhostAnimators[kvp.Key].Reset();
            //}        
            //this.levelMatrix = new Matrix();
            //this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
        }
    }
}