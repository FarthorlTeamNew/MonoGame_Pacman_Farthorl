using System.Dynamic;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class Fruit : LevelObject
    {
        public Fruit(Texture2D texture, float x, float y) 
            : base(texture.Name, x, y)
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