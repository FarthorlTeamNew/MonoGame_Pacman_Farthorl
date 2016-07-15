using System.Dynamic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public class Fruit : LevelObject
    {
        public Fruit(Texture2D texture, float x, float y, Rectangle boundingBox) 
            : base(texture.Name, x, y, boundingBox)
        {
            base.Texture = texture;
        }
        public int FruitBonus { get; set; }

        public override void ReactOnCollision(PacMan pacman)
        {
            //Just simple logic to heal the pacman with fruit bonus.. but not to overcome 
            if (pacman.Health+this.FruitBonus<=100)
            {
                pacman.Health += this.FruitBonus;
            }
        }
    }
}