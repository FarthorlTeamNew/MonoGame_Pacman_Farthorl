namespace Pacman.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
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
    using global::Pacman.Interfaces;

    public class Matrix : IMatrix
    {
        private string Level = Global.LevelPath;
        private string[,] pathsMatrix = new string[Global.YMax, Global.XMax];

        private static List<Wall> bricksList;
        private readonly List<PointObj> pointsList;
        private readonly List<Fruit> fruits;
        private readonly List<GhostKiller> ghostKillers;

        public Matrix()
        {
            bricksList = new List<Wall>();
            this.pointsList = new List<PointObj>();
            this.fruits = new List<Fruit>();
            this.ghostKillers = new List<GhostKiller>();
            Global.GhostKillerTimer = new Stopwatch();
            Global.PeachTimer = new Stopwatch();
            Global.HungryGhosts = new Stopwatch();
        }

        public int LeftPoints
        {
            get { return this.pointsList.Count; }
        }

        public string[,] PathsMatrix
        {
            get{ return pathsMatrix; }

            set{ pathsMatrix = value; }
        }

        public void InitializeMatrix(GraphicsDevice graphicsDevice)
        {
            this.PathsMatrix = this.GetMatrixValues();

            for (int y = 0; y < Global.YMax; y++)
            {
                for (int x = 0; x < Global.XMax; x++)
                {
                    var elements = this.PathsMatrix[y, x].Trim().Split(',');
                    int quadrant = int.Parse(elements[0]);
                    int pointIndex = int.Parse(elements[1]);

                    if (quadrant == 1)
                    {
                        Wall brick = new Wall(GameTexture.Brick, x * Global.quad_Width, y * Global.quad_Height, new Rectangle(x * Global.quad_Width, y * Global.quad_Height, Global.quad_Width, Global.quad_Height));
                        bricksList.Add(brick);
                    }
                    else if (pointIndex == 1)
                    {
                        PointObj point = new PointObj(GameTexture.Point, x * Global.quad_Width, y * Global.quad_Height, new Rectangle(x * Global.quad_Width, y * Global.quad_Height, Global.quad_Width, Global.quad_Height));
                        this.pointsList.Add(point);
                    }
                }
            }
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
            edible.X = placeFruitX * Global.quad_Width;
            edible.Y = placeFruitY * Global.quad_Height;
            edible.UpdateBoundingBox();
        }

        private string AvailableXY()
        {
            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(1, Global.XMax - 1);
                int tryY = new Random(DateTime.Now.Millisecond).Next(1, Global.YMax - 1);
                var elements = this.PathsMatrix[tryY, tryX].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    this.PathsMatrix[tryY, tryX] = "0,0";
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

        private string[,] GetMatrixValues()
        {
            try
            {
                using (var fileMatrix = new StreamReader(this.Level))
                {
                    string inputLine;
                    while ((inputLine = fileMatrix.ReadLine()) != null)
                    {
                        // Get values from the Coordinates.txt example splitLine[0]
                        var splitLine = inputLine.Trim().Split('=');

                        //Get the position values for the 2D array example arrayXYValues[0]=1 arrayXYValues[0]=0 
                        var arrayXyValues = splitLine[0].Trim().Split(',');
                        int arrayX;
                        int arrayY;

                        //This is the values of the array cell
                        string arrayValue = splitLine[1];
                        try
                        {
                            arrayX = int.Parse(arrayXyValues[0]);
                            arrayY = int.Parse(arrayXyValues[1]);
                        }
                        catch (Exception exception)
                        {
                            Log.AddToLog(exception.Message, LogEnumerable.Errors);
                            throw new ArgumentException("Cannot convert string to integer");
                        }

                        if (arrayX >= Global.XMax || arrayY >= Global.YMax)
                        {
                            continue;
                        }
                        //Add element data in to the specific point in the 2D array
                        this.PathsMatrix[arrayY, arrayX] = arrayValue;
                    }
                }
                return this.PathsMatrix;
            }
            catch (Exception exception)
            {
                Log.AddToLog(exception.Message, LogEnumerable.Errors);
                throw new FileLoadException("Level file didn't load!");
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