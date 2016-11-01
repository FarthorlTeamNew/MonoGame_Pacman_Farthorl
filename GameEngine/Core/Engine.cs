namespace GameEngine.Core
{
    using System;
    using Enums;
    using Globals;
    using Handlers;
    using Menu;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Utilities;

    public class Engine : Game
    {
        public static Sound sound;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private PacMan pacMan;
        private ModelGenerator modelGenerator;
        private Matrix levelMatrix;
        private KeyPress keyPress;
        private KeyboardState oldState;
        private bool isLevelCompleated;
        private GameState currentGameState = GameState.MainMenu;
        private CButton butEasyPlay;
        private CButton butHardPlay;
        private CButton butOptions;
        private CButton butExit;

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
            this.pacMan = new PacMan(GameTexture.PacmanAndGhost, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));
            this.graphics.PreferredBackBufferWidth = Global.Screen_Width;
            this.graphics.PreferredBackBufferHeight = Global.Screen_Height;
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
            this.butEasyPlay = new CButton(GameTexture.PlayButton, this.graphics.GraphicsDevice);
            this.butEasyPlay.SetPosition(new Vector2(300, 166));
            this.butHardPlay = new CButton(GameTexture.HardPlayGame, this.graphics.GraphicsDevice);
            this.butHardPlay.SetPosition(new Vector2(300, 200));
            this.butOptions = new CButton(GameTexture.OptionsButton, this.graphics.GraphicsDevice);
            this.butOptions.SetPosition(new Vector2(300, 234));
            this.butExit = new CButton(GameTexture.ExitButton, this.graphics.GraphicsDevice);
            this.butExit.SetPosition(new Vector2(300, 268));
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
            this.modelGenerator = new ModelGenerator(this.levelMatrix, this.pacMan);
            sound = new Sound(this);
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
                    MainMenuState();
                    break;
                case GameState.Options:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        this.currentGameState = GameState.MainMenu;
                        this.butOptions.isClicked = false;
                    }
                    break;
                case GameState.Playing:
                    PlayingState(gameTime);
                    break;
                case GameState.Exit:
                    break;
            }
            this.oldState = Keyboard.GetState();  // Update saved state.
        }

        private void MainMenuState()
        {
            MouseState mouse = Mouse.GetState();
            this.butEasyPlay.Update(mouse); this.butHardPlay.Update(mouse); this.butExit.Update(mouse); this.butOptions.Update(mouse);
            if (this.butEasyPlay.isClicked || this.keyPress.IsPressedKey(Keys.Space, this.oldState)
                || this.keyPress.IsPressedKey(Keys.E, this.oldState))
            {
                sound.Begin();
                //graphics.IsFullScreen = true; // set this to enable full screen
                //this.graphics.ApplyChanges();
                Global.Difficulty = DifficultyEnumerable.Easy;
                this.currentGameState = GameState.Playing;
                this.butEasyPlay.isClicked = false;
            }
            if (this.butHardPlay.isClicked || this.keyPress.IsPressedKey(Keys.H, this.oldState))
            {
                sound.Begin();
                //graphics.IsFullScreen = true; // set this to enable full screen
                //this.graphics.ApplyChanges();
                Global.Difficulty = DifficultyEnumerable.Hard;
                this.currentGameState = GameState.Playing;
                this.butEasyPlay.isClicked = false;
            }
            if (this.butExit.isClicked) this.currentGameState = GameState.Exit;
            if (this.butOptions.isClicked) this.currentGameState = GameState.Options;
        }

        private void PlayingState(GameTime gameTime)
        {
            if (!this.isLevelCompleated)
            {
                foreach (var kvp in this.modelGenerator.MovableModels)
                {
                    var movedToPoint = this.modelGenerator.MovableModels[kvp.Key].Move(gameTime);
                    this.modelGenerator.AnimationModels[kvp.Key].UpdateAnimation(gameTime, movedToPoint);
                }
                this.levelMatrix.Update(this.pacMan, this.modelGenerator);
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
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Green);

            this.spriteBatch.Begin();
            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    this.spriteBatch.Draw(GameTexture.MainMenu, new Rectangle(0, 0, Global.Screen_Width, Global.Screen_Height), Color.White);
                    this.butEasyPlay.Draw(this.spriteBatch);
                    this.butHardPlay.Draw(this.spriteBatch);
                    this.butExit.Draw(this.spriteBatch);
                    this.butOptions.Draw(this.spriteBatch);
                    break;
                case GameState.Options:
                    this.spriteBatch.Draw(GameTexture.Instruction, new Rectangle(0, 0, Global.Screen_Width, Global.Screen_Height), Color.White);
                    break;
                case GameState.Playing:

                    //Test scores background.. if you want delete it :)
                    ScoreBoard.LoadBoard(this.pacMan, this.spriteBatch, this, this.levelMatrix);

                    //==================

                    if (this.pacMan.Health > 0)
                    {
                        this.levelMatrix.Draw(this.spriteBatch);

                        foreach (var kvp in this.modelGenerator.AnimationModels)
                        {
                            kvp.Value.Draw(this.spriteBatch);
                        }

                        if (this.levelMatrix.LeftPoints == 0)
                        {
                            this.spriteBatch.Draw(GameTexture.WinPic, new Vector2(250, 100));
                            this.isLevelCompleated = true;
                        }
                        foreach (var ghost in this.modelGenerator.Ghosts)
                        {
                            if (ghost.Value.IsColliding(this.pacMan) && !this.pacMan.CanEat && ghost.Value.CanKillPakman)
                            {
                                this.spriteBatch.Draw(GameTexture.LosePic, new Vector2(250, 100));
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
                                if (Global.Difficulty == DifficultyEnumerable.Easy)
                                {
                                    ghost.Value.Texture = GameTexture.GhostAsPokemon;
                                    ghost.Value.CanKillPakman = false;
                                    ghost.Value.StartTransformingToGhost();
                                    //this.ghostGen.GhostMovements.Remove(ghost.Key);
                                    //this.ghostGen.GhostAnimators.Remove(ghost.Key);
                                    //this.ghostGen.Ghosts.Remove(ghost.Key);
                                }
                                else
                                {
                                    ghost.Value.Texture = GameTexture.GhostAsPokemon;
                                    ghost.Value.CanKillPakman = false;
                                    ghost.Value.StartTransformingToGhost();
                                }
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
            //base.Draw(gameTime);
        }
        private void Reset()
        {
            this.Initialize();
        }
    }
}