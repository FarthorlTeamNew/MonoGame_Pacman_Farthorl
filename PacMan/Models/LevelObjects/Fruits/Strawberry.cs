namespace Pacman.Models.LevelObjects.Fruits
{
    using Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Strawberry : Fruit
    {
        private const int StrawberryBonus = 9;
        public Strawberry(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.FruitBonus = StrawberryBonus;
        }

        public override void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan)
        {
            base.ActivatePowerup(ghostGen, pacMan);
        }
    }
}