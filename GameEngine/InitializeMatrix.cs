using GameEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class InitializeMatrix
    {
        private static string Level = @"DataFiles\Levels\CSharpLove.txt";
        private static string[,] PathsMatrix = new string[24, 13];

        private Texture2D[,] bricks;
        private Rectangle[,] brickRectangles;

        private Texture2D[,] points;
        private Rectangle[,] pointRectangle;

        public InitializeMatrix()
        {
            bricks = new Texture2D[24, 13];
            brickRectangles = new Rectangle[24, 13];
            points = new Texture2D[24, 13];
            pointRectangle = new Rectangle[24, 13];
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
                        Stream stream = TitleContainer.OpenStream(@"Content\brick.png");
                        bricks[x, y] = Texture2D.FromStream(graphicsDevice, stream);

                        Vector2 position = new Vector2(x * 32, y * 32);

                        brickRectangles[x, y] = new Rectangle((int)position.X, (int)position.Y, 32, 32);
                    }
                    else if (pointIndex == 1)
                    {
                        Stream stream = TitleContainer.OpenStream(@"Content\Point.png");
                        points[x, y] = Texture2D.FromStream(graphicsDevice, stream);

                        Vector2 position = new Vector2(x * 32, y * 32);

                        pointRectangle[x, y] = new Rectangle((int)position.X, (int)position.Y, 32, 32);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Global.YMax; y++)
            {
                for (int x = 0; x < Global.XMax; x++)
                {
                    var elements = PathsMatrix[x, y].Trim().Split(',');
                    int quadrant = int.Parse(elements[0]);
                    int pointIndex = int.Parse(elements[1]);

                    if (quadrant == 1)
                    {
                        Vector2 position = new Vector2(x * 32, y * 32);

                        spriteBatch.Draw(bricks[x, y], position, Color.White);
                    }
                    else if (pointIndex == 1)
                    {
                        Vector2 position = new Vector2(x * 32, y * 32);

                        spriteBatch.Draw(points[x, y], position, Color.White);
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
