namespace GameEngine.Models.LevelObjects.Fruits
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Pear : Fruit
    {
        private const int PearBonus = 17;
        public Pear(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = PearBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen, PacMan pacMan)
        {

        }
    }
}