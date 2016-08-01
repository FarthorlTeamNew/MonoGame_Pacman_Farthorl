﻿using GameEngine.Globals;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine.Factories;
using GameEngine.Models;

namespace GameEngine
{
    public class Matrix
    {
        private string Level = @"DataFiles\Levels\Labirint.txt";
        public string[,] PathsMatrix = new string[Global.YMax, Global.XMax];
        
        private readonly List<Wall> bricksList;
        private readonly List<PointObj> pointsList;
        private List<Fruit> fruits;
        private List<GhostKiller> ghostKillers;

        public Matrix()
        {
            bricksList = new List<Wall>();
            pointsList = new List<PointObj>();
            fruits = new List<Fruit>();
            ghostKillers = new List<GhostKiller>();
        }

        public int LeftPoints
        {
            get { return this.pointsList.Count; }
        }

        public void InitializeMatrix(GraphicsDevice graphicsDevice)
        {
            PathsMatrix = GetMatrixValues();

            for (int y = 0; y < Global.YMax; y++)
            {
                for (int x = 0; x < Global.XMax; x++)
                {
                    var elements = PathsMatrix[y, x].Trim().Split(',');
                    int quadrant = int.Parse(elements[0]);
                    int pointIndex = int.Parse(elements[1]);

                    if (quadrant == 1)
                    {
                        Wall brick = new Wall(GameTexture.brick, x * Global.quad_Width, y * Global.quad_Height, new Rectangle(x * Global.quad_Width, y * Global.quad_Height, Global.quad_Width, Global.quad_Height));             
                        bricksList.Add(brick);
                    }
                    else if (pointIndex == 1)
                    {
                        PointObj point = new PointObj(GameTexture.point, x * Global.quad_Width, y * Global.quad_Height, new Rectangle(x * Global.quad_Width, y * Global.quad_Height, Global.quad_Width, Global.quad_Height));
                        pointsList.Add(point);
                    }
                }
            }
            this.LoadFruit();
            this.RemovePoints();
        }

        private void LoadFruit()
        {
            List<Texture2D> fruitTextures = GameTexture.fruitTexturesList;
            FruitFactory factory = new FruitFactory();
            foreach (var fruitTexture in fruitTextures)
            {
                Fruit fruit = factory.CreateFruit(fruitTexture);
                fruits.Add(fruit);
            }

            foreach (var fruit in fruits)
            {
                PlaceOnRandomXY(fruit);
            }

            for (int i = 0; i < 4; i++)
            {
                ghostKillers.Add(new GhostKiller(GameTexture.ghostKiller, new Rectangle(0, 0, 32, 32)));
            }

            foreach (var killer in ghostKillers)
            {
                PlaceOnRandomXY(killer);
            }
        }

        private void PlaceOnRandomXY(GameObject edible)
        {
            string[] placeAvailable = AvailableXY().Split();
            int placeFruitX = int.Parse(placeAvailable[0]);
            int placeFruitY = int.Parse(placeAvailable[1]);
            edible.X = placeFruitX*Global.quad_Width;
            edible.Y = placeFruitY*Global.quad_Height;
            edible.UpdateBoundingBox();
        }

        private string AvailableXY()
        {
            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(1, Global.XMax - 1);
                int tryY = new Random(DateTime.Now.Millisecond).Next(1, Global.YMax - 1);
                var elements = PathsMatrix[tryY, tryX].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    PathsMatrix[tryY, tryX] = "0,0";
                    return $"{tryX} {tryY}";
                }
            }
        }

        private void RemovePoints()
        {
            // Remove points that have fruit placed on top of them
            foreach (var fruit in fruits)
            {
                pointsList.Remove(pointsList.FirstOrDefault(p => p.IsColliding(fruit)));
            }
            foreach (var ghostKiller in ghostKillers)
            {
                pointsList.Remove(pointsList.FirstOrDefault(p => p.IsColliding(ghostKiller)));
            }
        }

        public void Update(PacMan pacMan)
        {
            pointsList.FirstOrDefault(x => x.IsColliding(pacMan))?.ReactOnCollision(pacMan);
            pointsList.Remove(pointsList.FirstOrDefault(x => x.IsColliding(pacMan)));

            fruits.FirstOrDefault(x => x.IsColliding(pacMan))?.ReactOnCollision(pacMan);
            fruits.Remove(fruits.FirstOrDefault(x => x.IsColliding(pacMan)));

            ghostKillers.FirstOrDefault(x => x.IsColliding(pacMan))?.ReactOnCollision(pacMan);
            ghostKillers.Remove(ghostKillers.FirstOrDefault(x => x.IsColliding(pacMan)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var brick in bricksList)
            {
                spriteBatch.Draw(brick.Texture, brick.BoundingBox, Color.White);
            }

            foreach (var point in pointsList)
            {
                spriteBatch.Draw(point.Texture, point.BoundingBox, Color.White);
            }
            foreach (var fruit in fruits)
            {
                spriteBatch.Draw(fruit.Texture, fruit.BoundingBox, Color.White);
            }

            foreach (var ghostKiller in ghostKillers)
            {
                spriteBatch.Draw(ghostKiller.Texture, ghostKiller.BoundingBox, Color.White);
            }
        }


        private string[,] GetMatrixValues()
        {
            try
            {
                using (var fileMatrix = new StreamReader(Level))
                {
                    string inputLine;
                    while ((inputLine = fileMatrix.ReadLine()) != null)
                    {
                        // Get values from the coordinates.txt example splitLine[0]
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
                        catch (Exception)
                        {
                            throw new ArgumentException("Cannot convert string to integer");
                        }

                        if (arrayX >= Global.XMax || arrayY >= Global.YMax)
                        {
                            continue;
                        }
                        //Add element data in to the specific point in the 2D array
                        PathsMatrix[arrayY, arrayX] = arrayValue;
                    }
                }
                return PathsMatrix;
            }
            catch (Exception)
            {
                throw new FileLoadException("Level file didn't load!");
            }
        }
    }
}
