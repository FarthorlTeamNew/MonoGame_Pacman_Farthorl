using System.Dynamic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameEngine.Models.LevelObjects.Fruits;
using System.Collections.Generic;
using System;

namespace GameEngine.Models.LevelObjects
{
    public abstract class Fruit : LevelObject
    {
        private static List<Fruit> fruits;

        public Fruit(Texture2D texture, float x, float y, Rectangle boundingBox) 
            : base(texture.Name, x, y, boundingBox)
        {
            base.Texture = texture;
        }
        public int FruitBonus { get; set; }

        public override void ReactOnCollision(PacMan pacMan)
        {
            //Just simple logic to heal the pacman with fruit bonus.. but not to overcome 
            //if (pacman.Health+this.FruitBonus<=100)
            //{
            //    pacman.Health += this.FruitBonus;
            //}
        }
        
        //sealed??? 

        public static void InicializeFruits(GraphicsDevice graphicsDevice)
        {
            Texture2D tempTecture = new Texture2D(graphicsDevice, 32,32);
            Fruit apple = new Apple(tempTecture ,2, 3, new Rectangle(0,0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Apple.png"))
            {
                apple.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }          

            Fruit banana = new Banana(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Banana.png"))
            {
                banana.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }

            Fruit brezel = new Brezel(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Brezel.png"))
            {
                brezel.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }

            Fruit cherry = new Cherry(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Cherry.png"))
            {
                cherry.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }

            Fruit peach = new Peach(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Peach.png"))
            {
                peach.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }

            Fruit pear = new Pear(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Pear.png"))
            {
                pear.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }

            Fruit strawberry = new Strawberry(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
            using (var stream = TitleContainer.OpenStream("Content/FruitImages/Strawberry.png"))
            {
                strawberry.Texture = Texture2D.FromStream(graphicsDevice, stream);
            }

            fruits = new List<Fruit> { apple, banana, brezel, cherry, peach, pear, strawberry };

            foreach (var fruit in fruits)
            {
                string[] placeAvailable = AvailableFruitXY().Split();
                int placeFruitX = int.Parse(placeAvailable[0]);
                int placeFruitY = int.Parse(placeAvailable[1]);
                fruit.X = placeFruitX * 32;
                fruit.Y = placeFruitY * 32;
                fruit.UpdateBoundingBox();
            }
        }

        private static string AvailableFruitXY()
        {
            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(1, 24);
                int tryY = new Random(DateTime.Now.Millisecond).Next(1, 13);
                var elements = Matrix.PathsMatrix[tryX, tryY].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    Matrix.PathsMatrix[tryX, tryY] = "0,0";
                    return $"{tryX} {tryY}";
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch, PacMan pacMan)
        {
            foreach (var fruit in fruits)
            {
                spriteBatch.Draw(fruit.Texture, fruit.BoundingBox, Color.White);
                if (fruit.IsColliding(pacMan))
                {
                    fruit.ReactOnCollision(pacMan);
                    fruits.Remove(fruit);
                    break;
                }
            }
        }
    }
}