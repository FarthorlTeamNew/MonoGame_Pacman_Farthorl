namespace GameEngine.Models.LevelObjects.Fruits
{
    using Core;
    using Ghosts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Apple :Fruit
    {
        private const int AppleBonus = 10;

        public Apple(Texture2D texture, Rectangle boundingBox) 
            : base(texture, boundingBox)
        {
            this.FruitBonus = AppleBonus;
        }

        public override void ActivatePowerup(ModelGenerator ghostGen, PacMan pacMan)
        {
            if(ghostGen.MovableModels.ContainsKey(nameof(Inky)))
                ghostGen.MovableModels[nameof(Inky)].DecreaseSpeed();
            if (ghostGen.MovableModels.ContainsKey(nameof(Clyde)))
                ghostGen.MovableModels[nameof(Clyde)].DecreaseSpeed();
        }
    }
}