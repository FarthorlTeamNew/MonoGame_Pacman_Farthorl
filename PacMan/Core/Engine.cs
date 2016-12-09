﻿namespace Pacman.Core
{
    using System;
    using Enums;
    using Globals;
    using Handlers;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Data;

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
        private bool isLevelCompleted;
        private GameState currentGameState = GameState.Playing;
        private Level level;
        private DifficultyEnumerable difficulty;

        public Engine(Level level, DifficultyEnumerable difficulty)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.level = level;
            this.difficulty = difficulty;
            Global.Difficulty = this.difficulty;
        }

        protected override void Initialize()
        {
            sound = new Sound(this);
            GameTexture.LoadTextures(this);
            this.pacMan = new PacMan(GameTexture.PacmanAndGhost, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));
            this.graphics.PreferredBackBufferWidth = Global.Screen_Width;
            this.graphics.PreferredBackBufferHeight = Global.Screen_Height;
            this.levelMatrix = new Matrix(this.level);
            this.graphics.ApplyChanges();
            this.keyPress = new KeyPress();
            this.oldState = Keyboard.GetState();
            this.isLevelCompleted = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
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

                Exit();
                return;
            }

            switch (this.currentGameState)
            {
                case GameState.Playing:
                    PlayingState(gameTime);
                    break;
            }
            this.oldState = Keyboard.GetState();  // Update saved state.
        }

        private void PlayingState(GameTime gameTime)
        {
            if (!this.isLevelCompleted)
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
                    string levelName = this.level.Name;
                    Level newLevel = DataBridge.GetLevelByName(levelName);
                    if (newLevel != null)
                    {
                        using (var game = new Engine(newLevel, this.difficulty))
                            game.Run();
                    }
                    else
                    {
                        throw new EntryPointNotFoundException($"The levels with name {newLevel} not found");
                    }

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
                case GameState.Playing:

                    //Test scores background.. if you want delete it :)
                    ScoreBoard.LoadBoard(this.pacMan, this.spriteBatch, this, this.levelMatrix);

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
                            if (Global.Difficulty == 0)
                            {
                                GameStatistic.EasyLevelsCompleted++;
                            }
                            else
                            {
                                GameStatistic.HardLevelsCompleted++;
                            }
                            this.isLevelCompleted = true;
                        }
                        foreach (var ghost in this.modelGenerator.Ghosts)
                        {
                            if (ghost.Value.IsColliding(this.pacMan) && !this.pacMan.CanEat && ghost.Value.CanKillPakman)
                            {
                                this.spriteBatch.Draw(GameTexture.LosePic, new Vector2(250, 100));
                                if (this.isLevelCompleted == false)
                                {
                                    this.pacMan.Lives--;
                                    GameStatistic.PlayerTimesDied++;
                                    GameStatistic.GhostThatAtePacman = ghost.Key;
                                    this.isLevelCompleted = true;
                                    sound.Dead();
                                }
                            }

                            else if (ghost.Value.IsColliding(this.pacMan) && this.pacMan.CanEat)
                            {
                                sound.GhostDies();
                                if (Global.Difficulty == DifficultyEnumerable.Easy)
                                {
                                    //ghost.Value.Texture = GameTexture.GhostAsPokemon;
                                    //ghost.Value.CanKillPakman = false;
                                    //ghost.Value.StartTransformingToGhost();
                                    GameStatistic.PlayerGhostsEatenCount++;
                                    this.modelGenerator.MovableModels.Remove(ghost.Key);
                                    this.modelGenerator.AnimationModels.Remove(ghost.Key);
                                    this.modelGenerator.Ghosts.Remove(ghost.Key);
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