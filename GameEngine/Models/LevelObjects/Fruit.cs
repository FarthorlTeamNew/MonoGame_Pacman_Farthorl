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
        private static List<GhostKiller> ghostKillers;
        private static int coefficientX = 1;
        private static int coefficientY = 1;
        //private string fruitPath;

        public Fruit(Texture2D texture, float x, float y, Rectangle boundingBox) 
            : base(texture.Name, x, y, boundingBox)
        {
            base.Texture = texture;
           // Fruit.fruits.Add(this);//**
        }
        public int FruitBonus { get; set; }

        public override void ReactOnCollision(PacMan pacMan)
        {
            //Just simple logic to heal the pacman with fruit bonus.. but not to overcome 
            if (pacMan.Health + this.FruitBonus <= 100)
            {
                pacMan.Health += this.FruitBonus;
            }
            else
            {
                pacMan.Health = 100;
            }
        }
        
        public static void InitializeFruits(GraphicsDevice graphicsDevice, Matrix level)
        {
            Texture2D tempTecture = new Texture2D(graphicsDevice, 32, 32);
            Fruit apple = new Apple(tempTecture, 2, 3, new Rectangle(0, 0, 32, 32));
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
                string[] placeAvailable = AvailableFruitXY(level).Split();
                int placeFruitX = int.Parse(placeAvailable[0]);
                int placeFruitY = int.Parse(placeAvailable[1]);
                fruit.X = placeFruitX * 32;
                fruit.Y = placeFruitY * 32;
                fruit.UpdateBoundingBox();
            }

            ghostKillers = new List<GhostKiller>();
            for (int i = 0; i < 4; i++)
            {
                GhostKiller ghostKiller = new GhostKiller(2, 3, new Rectangle(0, 0, 32, 32));
                using (var stream = TitleContainer.OpenStream("Content/GhostKiller.png"))
                {
                    ghostKiller.Texture = Texture2D.FromStream(graphicsDevice, stream);
                }
                ghostKillers.Add(ghostKiller);
            }

            foreach (var killer in ghostKillers)
            {
                string[] placeAvailable = AvailableGhostKillerXY(level).Split();
                int placeKillerX = int.Parse(placeAvailable[0]);
                int placeKillerY = int.Parse(placeAvailable[1]);
                killer.X = placeKillerX*32;
                killer.Y = placeKillerY*32;
                killer.UpdateBoundingBox();
                coefficientX += 5;
                coefficientY += 2;
            }
        coefficientX = 1;
        coefficientY = 1;
    }

        private static string AvailableFruitXY(Matrix level)
        {
            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(1, 23);
                int tryY = new Random(DateTime.Now.Millisecond).Next(1, 12);
                var elements = level.PathsMatrix[tryX, tryY].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    level.PathsMatrix[tryX, tryY] = "0,0";
                    return $"{tryX} {tryY}";
                }
            }
        }

        private static string AvailableGhostKillerXY(Matrix level)
        {

            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(coefficientX, coefficientX + 5);
                int tryY = new Random(DateTime.Now.Millisecond).Next(coefficientY, coefficientY + 4);
                var elements = level.PathsMatrix[tryX, tryY].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    level.PathsMatrix[tryX, tryY] = "0,0";
                    return $"{tryX} {tryY}";
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch, PacMan pacMan)
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                spriteBatch.Draw(fruits[i].Texture, fruits[i].BoundingBox, Color.White);
                if (fruits[i].IsColliding(pacMan))
                {
                    fruits[i].ReactOnCollision(pacMan);
                    fruits.Remove(fruits[i]);
                }
            }
            for (int i = 0; i < ghostKillers.Count; i++)
            {
                spriteBatch.Draw(ghostKillers[i].Texture, ghostKillers[i].BoundingBox, Color.White);
                if (ghostKillers[i].IsColliding(pacMan))
                {
                    ghostKillers[i].ReactOnCollision(pacMan);
                    ghostKillers.Remove(ghostKillers[i]);
                }
            }
        }

        public static List<Fruit> GetFruitList()
        {
            return fruits;
        }


        public static List<GhostKiller> GetGhostKillerList()
        {
            return ghostKillers;
        }
    }
}