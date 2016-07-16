using GameEngine.Globals;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Matrix
    {
        private static string Level = @"DataFiles\Levels\CSharpLove.txt";
        public static string[,] PathsMatrix = new string[24, 13];

        private Texture2D brickTexture;
        private Texture2D pointTexture;
        private List<Wall> bricksList;
        private List<PointObj> pointsList;

        public Matrix(GraphicsDevice graphicsDevice)
        {
            bricksList = new List<Wall>();
            pointsList = new List<PointObj>();
        }

        public int GetLeftPoints()
        {
            return this.pointsList.Count;
        }

        public void LoadLevelMatrix(GraphicsDevice graphicsDevice)
        {
            PathsMatrix = GetMatrixValues();

            for (int y = 0; y < Global.YMax; y++)
            {
                for (int x = 0; x < Global.XMax; x++)
                {
                    var elements = PathsMatrix[x, y].Trim().Split(',');
                    int quadrant = int.Parse(elements[0]);
                    int pointIndex = int.Parse(elements[1]);

                    if (quadrant == 1)
                    {
                        Wall brick = new Wall(brickTexture, x * 32, y * 32, new Rectangle(x * 32, y * 32, 32, 32));
                        using (var stream = TitleContainer.OpenStream("Content/brick.png"))
                        {
                            brick.Texture = Texture2D.FromStream(graphicsDevice, stream);
                        }
                        bricksList.Add(brick);
                    }
                    else if (pointIndex == 1)
                    {
                        PointObj point = new PointObj(pointTexture, x * 32, y * 32, new Rectangle(x * 32, y * 32, 32, 32));
                        using (var stream = TitleContainer.OpenStream("Content/Point.png"))
                        {
                            point.Texture = Texture2D.FromStream(graphicsDevice, stream);
                        }
                        pointsList.Add(point);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, PacMan pacMan, List<Fruit> fruitList)
        {
            foreach (var brick in bricksList)
            {
                spriteBatch.Draw(brick.Texture, brick.BoundingBox, Color.White);
            }

            foreach (var point in pointsList)
            {
                // Remove points if pacman reaches them
                spriteBatch.Draw(point.Texture, point.BoundingBox, Color.White);
                if (point.IsColliding(pacMan))
                {
                    point.ReactOnCollision(pacMan);
                    pointsList.Remove(point);
                    break;
                }
                // Remove points that have fruit placed on top of them
                foreach (var fruit in fruitList)
                {
                    if (point.IsColliding(fruit))
                    {
                        pointsList.Remove(point);
                        return;
                    }
                }
            }        
        }
        private static string[,] GetMatrixValues()
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

                        //Add element data in to the specific point in the 2D array
                        PathsMatrix[arrayX, arrayY] = arrayValue;
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
