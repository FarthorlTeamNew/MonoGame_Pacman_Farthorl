namespace GameEngine
{
    using System;
    using Animators;
    using Globals;
    using Handlers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using Menu;
    using Models;
    using Animators.GhostAnimators;
    using Models.LevelObjects.Ghosts;
    using Interfaces;

    public class Engine : Game
    {
        public static Sound sound;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private PacMan pacMan;
        private Blinky blinky;
        private Clyde clyde;
        private Inky inky;
        private Pinky pinky;
        private List<Animator> animationObjects;
        private List<IMovable> movableObjects;
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
            this.movableObjects = new List<IMovable>();
            this.animationObjects = new List<Animator>();
            sound = new Sound(this);
            GameTexture.LoadTextures(this);
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

            this.movableObjects.Add(new PacmanInputHandler(this.pacMan, levelMatrix));
            this.movableObjects.Add(new GhostWeakRandomMovement(this.blinky, levelMatrix));
            this.movableObjects.Add(new GhostGoodRandomMovement(this.clyde, levelMatrix));
            this.movableObjects.Add(new GhostHuntingRandomMovement(this.inky, levelMatrix, pacMan));
            this.movableObjects.Add(new GhostHuntingRandomMovement(this.pinky, levelMatrix, pacMan));

            sound = new Sound(this);
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
                        for (int i = 0; i < movableObjects.Count; i++)
                        {
                            var movedToPoint = movableObjects[i].Move(gameTime);
                            animationObjects[i].UpdateAnimation(gameTime, movedToPoint);
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

                        foreach (var obj in animationObjects)
                        {
                            obj.Draw(this.spriteBatch);
                        }

                        if (this.levelMatrix.LeftPoints == 0 || blinky.IsColliding(pacMan) || clyde.IsColliding(pacMan)
                            || inky.IsColliding(pacMan) || pinky.IsColliding(pacMan)) 
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
            this.pacMan.Scores = 0;
            this.pacMan.Health = 50;
            for (int i = 0; i < movableObjects.Count; i++)
            {
                movableObjects[i].Reset();
                animationObjects[i].Reset();
            }
            
            this.levelMatrix = new Matrix();
            this.levelMatrix.InitializeMatrix(this.GraphicsDevice);
        }
    }
}