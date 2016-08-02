using System;
using GameEngine.Models.LevelObjects.Ghosts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public class Cherry : Fruit
    {
        private const int CherryBonus = 14;
        public Cherry(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = CherryBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen, PacMan pacMan)
        {
            if (ghostGen.Ghosts.ContainsKey(nameof(Blinky)))
            {
                ghostGen.Ghosts[nameof(Blinky)].X = new Random().Next(3, 5) * 32;
                ghostGen.Ghosts[nameof(Blinky)].Y = new Random().Next(2, 4) * 32;
                ghostGen.GhostMovements[nameof(Blinky)].Reset();
            }
            if (ghostGen.Ghosts.ContainsKey(nameof(Pinky)))
            {
                ghostGen.Ghosts[nameof(Pinky)].X = new Random().Next(17, 21) * 32;
                ghostGen.Ghosts[nameof(Pinky)].Y = new Random().Next(8, 11) * 32;
                ghostGen.GhostMovements[nameof(Pinky)].Reset();
            }
        }
    }
}