using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public class Apple :Fruit
    {
        private const int AppleBonus = 10;

        public Apple(Texture2D texture, Rectangle boundingBox) 
            : base(texture, boundingBox)
        {
            base.FruitBonus = AppleBonus;
        }
    }
}