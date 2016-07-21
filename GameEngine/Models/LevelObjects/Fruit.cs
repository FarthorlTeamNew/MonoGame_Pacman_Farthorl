using System.Dynamic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameEngine.Models.LevelObjects.Fruits;
using System.Collections.Generic;
using System;
using System.Linq;
using GameEngine.Globals;

namespace GameEngine.Models.LevelObjects
{
    public abstract class Fruit : LevelObject
    {
        private static List<Fruit> fruits;
        private static List<GhostKiller> ghostKillers;
        private static int coefficientX;
        private static int coefficientY;

        public Fruit(Texture2D texture, float x, float y, Rectangle boundingBox) 
            : base(texture.Name, x, y, boundingBox)
        {
            coefficientX = 1;
            coefficientY = 1;
            base.Texture = texture;
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
            Fruit apple = new Apple(GameTexture.apple, 0, 0, new Rectangle(0, 0, 32, 32));
            Fruit banana = new Banana(GameTexture.banana, 0, 0, new Rectangle(0, 0, 32, 32));
            Fruit brezel = new Brezel(GameTexture.brezel, 0, 0, new Rectangle(0, 0, 32, 32));
            Fruit cherry = new Cherry(GameTexture.cherry, 0, 0, new Rectangle(0, 0, 32, 32));
            Fruit peach = new Peach(GameTexture.peach, 0, 0, new Rectangle(0, 0, 32, 32));
            Fruit pear = new Pear(GameTexture.pear, 0, 0, new Rectangle(0, 0, 32, 32));
            Fruit strawberry = new Strawberry(GameTexture.strawberry, 0, 0, new Rectangle(0, 0, 32, 32));
          
            fruits = new List<Fruit> { apple, banana, brezel, cherry, peach, pear, strawberry };

            foreach (var fruit in fruits)
            {
                string[] placeAvailable = AvailableFruitXY(level).Split();
                int placeFruitX = int.Parse(placeAvailable[0]);
                int placeFruitY = int.Parse(placeAvailable[1]);
                fruit.X = placeFruitX * Global.quad_Width;
                fruit.Y = placeFruitY * Global.quad_Height;
                fruit.UpdateBoundingBox();
            }

            ghostKillers = new List<GhostKiller>();
            for (int i = 0; i < 4; i++)
            {
                ghostKillers.Add(new GhostKiller(GameTexture.ghostKiller, 0, 0, new Rectangle(0, 0, 32, 32)));
            }

            foreach (var killer in ghostKillers)
            {
                string[] placeAvailable = AvailableGhostKillerXY(level).Split();
                int placeKillerX = int.Parse(placeAvailable[0]);
                int placeKillerY = int.Parse(placeAvailable[1]);
                killer.X = placeKillerX*Global.quad_Width;
                killer.Y = placeKillerY*Global.quad_Height;
                killer.UpdateBoundingBox();
                coefficientX += 5;
                coefficientY += 2;
            }
        }

        private static string AvailableFruitXY(Matrix level)
        {
            while (true)
            {
                int tryX = new Random(DateTime.Now.Millisecond).Next(1, Global.XMax - 1);
                int tryY = new Random(DateTime.Now.Millisecond).Next(1, Global.YMax - 1);
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
            fruits.FirstOrDefault(x => x.IsColliding(pacman))?.ReactOnCollision(pacman);
            fruits.Remove(fruits.FirstOrDefault(x => x.IsColliding(pacman)));
            
            ghostKillers.FirstOrDefault(x => x.IsColliding(pacman))?.ReactOnCollision(pacman);
            ghostKillers.Remove(ghostKillers.FirstOrDefault(x => x.IsColliding(pacman)));
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