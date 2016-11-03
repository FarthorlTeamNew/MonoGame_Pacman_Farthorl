namespace Pacman.Models.LevelObjects.Fruits
{
    using Core;
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Globals;

    public class Brezel : Fruit
    {
        private const int BrezelBonus = 12;
        public Brezel(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.FruitBonus = BrezelBonus;
        }

        public override void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan)
        {
            pacMan.X = new Random().Next(2, 20) * Global.quad_Width;
            pacMan.Y = new Random().Next(1, 10) * Global.quad_Height;
        }
    }
}