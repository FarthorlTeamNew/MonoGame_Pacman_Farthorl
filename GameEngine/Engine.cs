namespace GameEngine
{
    using System;
    using Animators;
    using Globals;
    using Handlers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Menu;
    using Models;
    using Factories;

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
        GameState currentGameState = GameState.MainMenu;
        CButton butPlay;
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
            this.pacMan = new PacMan(GameTexture.pacmanAndGhost, 0, 0, new Rectangle(0, 0, 32, 32));
            this.graphics.PreferredBackBufferWidth = Global.GLOBAL_WIDTH;
            this.graphics.PreferredBackBufferHeight = Global.GLOBAL_HEIGHT;
            this.levelMatrix = new Matrix();
            //graphics.IsFullScreen = true; // set this to enable full screen
            this.graphics.ApplyChanges();
            keyPress = new KeyPress();
            oldState = Keyboard.GetState();
            isLevelCompleated = false;
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
            this.ghostGen = new GhostGenerator(levelMatrix, pacMan);
            this.ghostGen.GhostAnimators.Add(nameof(PacMan), new PacmanAnimator(this.pacMan));
            this.ghostGen.GhostMovements.Add(nameof(PacMan), new PacmanInputHandler(this.pacMan, levelMatrix));
            sound = new Sound(this);
            sound.Begin();
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
                    if (this.butPlay.isClicked || this.keyPress.IsPressedKey(Keys.Space, this.oldState))
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
                        foreach (var kvp in ghostGen.GhostMovements)
                        {
                            var movedToPoint = ghostGen.GhostMovements[kvp.Key].Move(gameTime);
                            ghostGen.GhostAnimators[kvp.Key].UpdateAnimation(gameTime, movedToPoint);
                        }
                        levelMatrix.Update(pacMan);
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

                        foreach (var kvp in ghostGen.GhostAnimators)
                        {
                            kvp.Value.Draw(this.spriteBatch);
                        }

                        if (this.levelMatrix.LeftPoints == 0) 
                        {
                            var texture = Content.Load<Texture2D>("PacManWin_image");
                            this.spriteBatch.Draw(texture, new Vector2(250, 100));
                            isLevelCompleated = true;
                        }
                        foreach (var ghost in ghostGen.Ghosts)
                        {
                            if (ghost.Value.IsColliding(pacMan) && !pacMan.CanEat)
                            {
                                var texture = Content.Load<Texture2D>("PacManWin_image");
                                this.spriteBatch.Draw(texture, new Vector2(250, 100));
                                isLevelCompleated = true;
                            }
                            else if (ghost.Value.IsColliding(pacMan) && pacMan.CanEat)
                            {
                                ghostGen.GhostMovements.Remove(ghost.Key);
                                ghostGen.GhostAnimators.Remove(ghost.Key);
                                ghostGen.Ghosts.Remove(ghost.Key);
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