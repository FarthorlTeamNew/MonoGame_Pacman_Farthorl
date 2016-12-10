using System.Linq;

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
            var coordinates = Engine.GetLevel().LevelCoordinates.Where(c => !c.isWall).ToList();
            Random rnd = new Random();
            int randomCoordinate = rnd.Next(0, coordinates.Count-1);
            pacMan.X =coordinates[randomCoordinate].QuadrantX * Global.quad_Width;
            pacMan.Y =coordinates[randomCoordinate].QuadrantY * Global.quad_Height;

            base.ActivatePowerup(ghostGen, pacMan);
        }
    }
}