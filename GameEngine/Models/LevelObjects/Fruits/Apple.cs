using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Apple :Fruit
    {
        private const int AppleBonus = 10;
        public Apple(Texture2D texture, float x, float y) 
            : base(texture, x, y)
        {
            base.FruitBonus = AppleBonus;
        }
    }
}