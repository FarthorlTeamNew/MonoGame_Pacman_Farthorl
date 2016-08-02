using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public class Brezel : Fruit
    {
        private const int BrezelBonus = 12;
        public Brezel(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = BrezelBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen, PacMan pacMan)
        {
            pacMan.X = new Random().Next(2, 20) * 32;
            pacMan.Y = new Random().Next(1, 10) * 32;
        }
    }
}