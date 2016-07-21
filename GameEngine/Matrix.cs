using GameEngine.Globals;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine.Models;

namespace GameEngine
{
    public class Matrix
    {
        private string Level = @"DataFiles\Levels\Labirint.txt";
        public string[,] PathsMatrix = new string[Global.YMax, Global.XMax];

        private Texture2D brickTexture;
        private Texture2D pointTexture;
        private List<Wall> bricksList;
        private List<PointObj> pointsList;

        public Matrix()
        {
            bricksList = new List<Wall>();
            pointsList = new List<PointObj>();
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
                        Wall brick = new Wall(brickTexture, x * Global.quad_Width, y * Global.quad_Height, new Rectangle(x * Global.quad_Width, y * Global.quad_Height, Global.quad_Width, Global.quad_Height));
                        brick.Texture = GameTexture.brick;                       
                        bricksList.Add(brick);
                    }
                    else if (pointIndex == 1)
                    {
                        PointObj point = new PointObj(x * Global.quad_Width, y * Global.quad_Height, new Rectangle(x * Global.quad_Width, y * Global.quad_Height, Global.quad_Width, Global.quad_Height));
                        point.Texture = GameTexture.point;
                        pointsList.Add(point);
                    }
                }
            }
        }

        public void RemovePoints(List<LevelObject> fruitList)
        {
            // Remove points that have fruit placed on top of them
            for (int i = 0; i < pointsList.Count; i++)
            {
                foreach (var fruit in fruitList)
                {
                    if (pointsList[i].IsColliding(fruit) && i < pointsList.Count - 1)
                    {
                        pointsList.Remove(pointsList[i]);
                        i--;
                    }
                }
            }
        }

        public void Update(PacMan pacMan)
        {
            PointObj pointEaten = pointsList.FirstOrDefault(x => x.IsColliding(pacMan));
            pointEaten?.ReactOnCollision(pacMan);
            pointsList?.Remove(pointEaten);
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
