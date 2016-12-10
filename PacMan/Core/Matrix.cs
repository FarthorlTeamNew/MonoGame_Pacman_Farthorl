namespace Pacman.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Factories;
    using Globals;
    using Models;
    using Models.LevelObjects;
    using Models.LevelObjects.Fruits;
    using Models.LevelObjects.Ghosts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Enums;
    using Utilities;
    using Interfaces;

    public class Matrix : IMatrix
    {
        private Level level;
        private string[,] pathsMatrix = new string[Global.YMax, Global.XMax];

        private static List<Wall> bricksList;
        private readonly List<PointObj> pointsList;
        private readonly List<Fruit> fruits;
        private readonly List<GhostKiller> ghostKillers;

        public Matrix(Level level)
        {
            bricksList = new List<Wall>();
            this.pointsList = new List<PointObj>();
            this.fruits = new List<Fruit>();
            this.ghostKillers = new List<GhostKiller>();
            Global.GhostKillerTimer = new Stopwatch();
            Global.PeachTimer = new Stopwatch();
            Global.HungryGhosts = new Stopwatch();
            this.level = level;
        }

        public int LeftPoints
        {
            get { return this.pointsList.Count; }
        }

        public string[,] PathsMatrix
        {
            get { return this.pathsMatrix; }

            set { this.pathsMatrix = value; }
        }


        public Level Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        public void InitializeMatrix(GraphicsDevice graphicsDevice)
        {

            foreach (var coordinates in this.level.LevelCoordinates)
            {
                if (coordinates.isWall)
                {
                    Wall brick = new Wall(GameTexture.Brick,
                                          coordinates.QuadrantX * Global.quad_Width,
                                          coordinates.QuadrantY * Global.quad_Height,
                                          new Rectangle(coordinates.QuadrantX * Global.quad_Width,
                                                        coordinates.QuadrantY * Global.quad_Height,
                                                        Global.quad_Width, Global.quad_Height)
                                         );
                    bricksList.Add(brick);
                }
                else if (coordinates.isPoint)
                {
                    PointObj point = new PointObj(GameTexture.Point,
                                                  coordinates.QuadrantX * Global.quad_Width,
                                                  coordinates.QuadrantY * Global.quad_Height,
                                                  new Rectangle(coordinates.QuadrantX * Global.quad_Width,
                                                                coordinates.QuadrantY * Global.quad_Height,
                                                                Global.quad_Width, Global.quad_Height)
                                                 );
                    this.pointsList.Add(point);
                }
            }
            PointObj pointZero = pointsList.FirstOrDefault(p => p.QuadrantX == 0 && p.QuadrantY == 0);
            pointsList.Remove(pointZero);
            this.LoadFruit();
            this.RemovePoints();
        }

        private void LoadFruit()
        {
            List<Texture2D> fruitTextures = GameTexture.FruitTexturesList;
            FruitFactory factory = new FruitFactory();
            try
            {
                foreach (var fruitTexture in fruitTextures)
                {
                    Fruit fruit = factory.CreateFruit(fruitTexture);
                    this.PlaceOnRandomXY(fruit);
                    this.fruits.Add(fruit);
                }
            }
            catch (Exception e)
            {
                Log.AddToLog(e.Message, LogEnumerable.Errors);
            }

            for (int i = 0; i < 4; i++)
            {
                this.ghostKillers.Add(new GhostKiller(GameTexture.GhostKiller, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height)));
                this.PlaceOnRandomXY(this.ghostKillers[i]);
            }
        }

        private void PlaceOnRandomXY(GameObject edible)
        {
            string[] placeAvailable = this.AvailableXY().Split();
            int placeFruitX = int.Parse(placeAvailable[0]);
            int placeFruitY = int.Parse(placeAvailable[1]);
            edible.X = placeFruitX;
            edible.Y = placeFruitY;
            edible.UpdateBoundingBox();
        }

        private string AvailableXY()
        {
            Random rnd = new Random();
            while (true)
            {
                int tryX = rnd.Next(1, Global.XMax - 1) * Global.quad_Width;
                int tryY = rnd.Next(1, Global.YMax - 1) * Global.quad_Height;

                var coordinates = this.level.LevelCoordinates.FirstOrDefault(coordinate => coordinate.QuadrantX * Global.quad_Width == tryX 
                                                                                        && coordinate.QuadrantY * Global.quad_Height == tryY);
                if (coordinates != null && !coordinates.isWall && this.fruits.Count(f => f.X == tryX && f.Y == tryY) == 0
                                                          && this.ghostKillers.Count(gk => gk.X == tryX  && gk.Y == tryY) == 0 )
                {
                    return $"{tryX} {tryY}";
                }
            }
        }

        private void RemovePoints()
        {
            // Remove points that have fruit placed on top of them
            foreach (var fruit in this.fruits)
            {
                this.pointsList.Remove(this.pointsList.FirstOrDefault(p => p.IsColliding(fruit)));
            }
            foreach (var ghostKiller in this.ghostKillers)
            {
                this.pointsList.Remove(this.pointsList.FirstOrDefault(p => p.IsColliding(ghostKiller)));
            }
        }

        public void Update(PacMan pacMan, ModelGenerator ghostGen)
        {
            this.pointsList.FirstOrDefault(x => x.IsColliding(pacMan))?.ReactOnCollision(pacMan);
            this.pointsList.Remove(this.pointsList.FirstOrDefault(x => x.IsColliding(pacMan)));

            Fruit fruitToEatActivateRemove = this.fruits.FirstOrDefault(x => x.IsColliding(pacMan));
            if (fruitToEatActivateRemove != null)
            {
                fruitToEatActivateRemove.ReactOnCollision(pacMan);
                fruitToEatActivateRemove.ActivatePowerup(ghostGen, pacMan);
                this.fruits.Remove(fruitToEatActivateRemove);
                if (fruitToEatActivateRemove is Peach)
                {
                    Global.PeachTimer.Start();
                }
                if (fruitToEatActivateRemove is Pear)
                {
                    Global.HungryGhosts.Start();
                }
            }
            if (Global.PeachTimer.ElapsedMilliseconds > Global.TimeDrunk)
            {
                ghostGen.MovableModels[nameof(PacMan)].DrunkMovement();
                ResetStopTimer(Global.PeachTimer);
            }
            if (Global.HungryGhosts.ElapsedMilliseconds > Global.TimeHungryGhosts && ghostGen.Ghosts.ContainsKey(nameof(Pinky)))
            {
                if (ghostGen.Ghosts.ContainsKey(nameof(Clyde)))
                {
                    ghostGen.Ghosts[nameof(Clyde)].EnoughIsEnough();
                }
                if (ghostGen.Ghosts.ContainsKey(nameof(Pinky)))
                {
                    ghostGen.Ghosts[nameof(Pinky)].EnoughIsEnough();
                }
                ResetStopTimer(Global.HungryGhosts);
            }

            GhostKiller ghostKiller = this.ghostKillers.FirstOrDefault(x => x.IsColliding(pacMan));
            if (ghostKiller != null)
            {
                ghostKiller.ReactOnCollision(pacMan);
                this.ghostKillers.Remove(ghostKiller);
                Global.GhostKillerTimer.Reset();
                Global.GhostKillerTimer.Start();
            }
            if (Global.GhostKillerTimer.ElapsedMilliseconds > Global.TimePokeball)
            {
                pacMan.CanEat = false;
                pacMan.Texture = GameTexture.PacmanAndGhost;
                ResetStopTimer(Global.GhostKillerTimer);
            }
            foreach (var point in this.pointsList)
            {
                if (ghostGen.Ghosts.Where(g => g.Value.Hungry).Any(x => x.Value.IsColliding(point)))
                {
                    this.pointsList.Remove(point);
                    break;
                }
            }
            foreach (var ghost in ghostGen.Ghosts)
            {
                if (ghost.Value.Texture == GameTexture.GhostAsPokemon && ghost.Value.GhostTransformingTimer.ElapsedMilliseconds > Global.TimePikachu)
                {
                    ghost.Value.Texture = GameTexture.PacmanAndGhost;
                    ghost.Value.CanKillPakman = true;
                    ResetStopTimer(ghost.Value.GhostTransformingTimer);
                }
            }
        }

        private static void ResetStopTimer(Stopwatch timer)
        {
            timer.Reset();
            timer.Stop();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var brick in bricksList)
            {
                spriteBatch.Draw(brick.Texture, brick.BoundingBox, Color.White);
            }

            foreach (var point in this.pointsList)
            {
                spriteBatch.Draw(point.Texture, point.BoundingBox, Color.White);
            }
            foreach (var fruit in this.fruits)
            {
                spriteBatch.Draw(fruit.Texture, fruit.BoundingBox, Color.White);
            }

            foreach (var ghostKiller in this.ghostKillers)
            {
                spriteBatch.Draw(ghostKiller.Texture, ghostKiller.BoundingBox, Color.White);
            }
        }

        public static bool IsThereABrick(int quadrantX, int quadrantY)
        {
            if (bricksList.Any(b => b.X / Global.quad_Width == quadrantX && b.Y / Global.quad_Height == quadrantY) ||
                quadrantX < 0 || quadrantX > Global.XMax || quadrantY < 0 || quadrantY > Global.YMax)
            {
                return true;
            }
            return false;
        }
    }
}