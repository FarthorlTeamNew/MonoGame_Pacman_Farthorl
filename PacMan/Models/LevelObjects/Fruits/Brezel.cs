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
            Random rnd = new Random();
            pacMan.X = rnd.Next(2, 20) * Global.quad_Width;
            pacMan.Y = rnd.Next(1, 10) * Global.quad_Height;

            base.ActivatePowerup(ghostGen, pacMan);
        }
    }
}