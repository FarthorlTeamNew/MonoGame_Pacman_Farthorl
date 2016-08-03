namespace GameEngine.Models.LevelObjects.Fruits
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Strawberry : Fruit
    {
        private const int StrawberryBonus = 9;
        public Strawberry(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = StrawberryBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen, PacMan pacMan)
        {
        }
    }
}