namespace Pacman.Models.LevelObjects.Fruits
{
    using Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Banana : Fruit
    {
        private const int BananaBonus = 15;
        public Banana(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.FruitBonus = BananaBonus;
        }

        public override void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan)
        {
            ghostGen.MovableModels[nameof(PacMan)].DecreaseSpeed();

            base.ActivatePowerup(ghostGen, pacMan);
        }
    }
}