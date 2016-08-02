using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public abstract class Fruit : LevelObject
    {
        protected Fruit(Texture2D texture, Rectangle boundingBox)
            : base(texture, 0, 0, boundingBox)
        {
        }

        public int FruitBonus { get; set; }

        public override void ReactOnCollision(PacMan pacMan)
        {
            //Just simple logic to heal the pacman with fruit bonus.. but not to overcome 
            if (pacMan.Health + this.FruitBonus <= 100)
            {
                Engine.sound.PacManEatGhost();
                pacMan.Health += this.FruitBonus;
            }
            else
            {
                Engine.sound.PacManEatGhost();
                pacMan.Health = 100;
            }
        }

        public abstract void ActivatePowerup(GhostGenerator ghostGen);
    }
}