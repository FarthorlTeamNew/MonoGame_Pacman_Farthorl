namespace GameEngine.Models.LevelObjects.Fruits
{
    using Ghosts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public class Apple :Fruit
    {
        private const int AppleBonus = 10;

        public Apple(Texture2D texture, Rectangle boundingBox) 
            : base(texture, boundingBox)
        {
            base.FruitBonus = AppleBonus;
        }

        public override void ActivatePowerup(GhostGenerator ghostGen)
        {
            ghostGen.GhostMovements[nameof(Inky)].IncreaseSpeed();
            ghostGen.GhostMovements[nameof(Clyde)].IncreaseSpeed();
        }
    }
}