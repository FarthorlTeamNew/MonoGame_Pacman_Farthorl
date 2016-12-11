using System.Linq;

namespace Pacman.Models.LevelObjects.Fruits
{
    using Core;
    using System;
    using Ghosts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Globals;

    public class Cherry : Fruit
    {
        private const int CherryBonus = 14;
        public Cherry(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.FruitBonus = CherryBonus;
        }

        public override void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan)
        {
            if (ghostGen.Ghosts.ContainsKey(nameof(Blinky)))
            {
                var coordinates = Engine.GetLevel().LevelCoordinates.Where(c => !c.isWall).ToList();
                Random rnd = new Random();
                int randomCoordinate = rnd.Next(0, coordinates.Count - 1);
                ghostGen.Ghosts[nameof(Blinky)].X = coordinates[randomCoordinate].QuadrantX * Global.quad_Width;
                ghostGen.Ghosts[nameof(Blinky)].Y = coordinates[randomCoordinate].QuadrantY * Global.quad_Height;
                ghostGen.MovableModels[nameof(Blinky)].Reset();
            }
            if (ghostGen.Ghosts.ContainsKey(nameof(Pinky)))
            {
                var coordinates = Engine.GetLevel().LevelCoordinates.Where(c => !c.isWall).ToList();
                Random rnd = new Random();
                int randomCoordinate = rnd.Next(0, coordinates.Count - 1);
                ghostGen.Ghosts[nameof(Pinky)].X = coordinates[randomCoordinate].QuadrantX * Global.quad_Width;
                ghostGen.Ghosts[nameof(Pinky)].Y = coordinates[randomCoordinate].QuadrantY * Global.quad_Height;
                ghostGen.MovableModels[nameof(Pinky)].Reset();
            }
            
            base.ActivatePowerup(ghostGen, pacMan);
        }
    }
}