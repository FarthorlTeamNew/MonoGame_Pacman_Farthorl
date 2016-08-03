namespace GameEngine.Models.LevelObjects.Fruits
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Peach : Fruit
    {
        private const int PeachBonus = 16;
        public Peach(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = PeachBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen, PacMan pacMan)
        {
            ghostGen.GhostMovements[nameof(PacMan)].GetDrunkThenRehab();
        }
    }
}