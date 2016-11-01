namespace GameEngine.Models.LevelObjects.Fruits
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
                ghostGen.Ghosts[nameof(Blinky)].X = new Random().Next(3, 5) * Global.quad_Width;
                ghostGen.Ghosts[nameof(Blinky)].Y = new Random().Next(2, 4) * Global.quad_Height;
                ghostGen.MovableModels[nameof(Blinky)].Reset();
            }
            if (ghostGen.Ghosts.ContainsKey(nameof(Pinky)))
            {
                ghostGen.Ghosts[nameof(Pinky)].X = new Random().Next(17, 21) * Global.quad_Width;
                ghostGen.Ghosts[nameof(Pinky)].Y = new Random().Next(8, 11) * Global.quad_Height;
                ghostGen.MovableModels[nameof(Pinky)].Reset();
            }
        }
    }
}