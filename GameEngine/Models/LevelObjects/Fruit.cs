using System.Dynamic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameEngine.Models.LevelObjects.Fruits;
using System.Collections.Generic;
using System;
using GameEngine.Globals;
using GameEngine.Menu;

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
            Fruit apple = new Apple(GameTexture.apple, 2, 3, new Rectangle(0, 0, 32, 32));
            Fruit banana = new Banana(GameTexture.banana, 2, 3, new Rectangle(0, 0, 32, 32));
            Fruit brezel = new Brezel(GameTexture.brezel, 2, 3, new Rectangle(0, 0, 32, 32));
            Fruit cherry = new Cherry(GameTexture.cherry, 2, 3, new Rectangle(0, 0, 32, 32));
            Fruit peach = new Peach(GameTexture.peach, 2, 3, new Rectangle(0, 0, 32, 32));
            Fruit pear = new Pear(GameTexture.pear, 2, 3, new Rectangle(0, 0, 32, 32));
            Fruit strawberry = new Strawberry(GameTexture.strawberry, 2, 3, new Rectangle(0, 0, 32, 32));
          
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
                ghostKiller.Texture = GameTexture.ghostKiller;
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
                var elements = level.PathsMatrix[tryY, tryX].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    level.PathsMatrix[tryY, tryX] = "0,0";
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
                var elements = level.PathsMatrix[tryY, tryX].Trim().Split(',');
                int placeAvailable = int.Parse(elements[1]);
                if (placeAvailable == 1)
                {
                    level.PathsMatrix[tryY, tryX] = "0,0";
                    return $"{tryX} {tryY}";
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch, PacMan pacMan)
        {
            foreach (var fruit in fruits)
            {
                spriteBatch.Draw(fruit.Texture, fruit.BoundingBox, Color.White);
            }

            foreach (var ghostKiller in ghostKillers)
            {
                spriteBatch.Draw(ghostKiller.Texture, ghostKiller.BoundingBox, Color.White);
            }
        }

        public static void CheckCollisions(PacMan pacman)
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                if (fruits[i].IsColliding(pacman))
                {
                    fruits[i].ReactOnCollision(pacman);
                    fruits.Remove(fruits[i]);
                }
            }

            for (int i = 0; i < ghostKillers.Count; i++)
            {
                if (ghostKillers[i].IsColliding(pacman))
                {
                    ghostKillers[i].ReactOnCollision(pacman);
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