namespace GameEngine.Models.LevelObjects.Fruits
{
    using Core;
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Brezel : Fruit
    {
        private const int BrezelBonus = 12;
        public Brezel(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.FruitBonus = BrezelBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen, PacMan pacMan)
        {
            pacMan.X = new Random().Next(2, 20) * 32;
            pacMan.Y = new Random().Next(1, 10) * 32;
        }
    }
}