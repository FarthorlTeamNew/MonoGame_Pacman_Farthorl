namespace GameEngine.Models.LevelObjects.Fruits
{
    using Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Peach : Fruit
    {
        private const int PeachBonus = 16;
        public Peach(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            this.FruitBonus = PeachBonus;
        }

        public override void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan)
        {
            ghostGen.MovableModels[nameof(PacMan)].DrunkMovement();
        }
    }
}