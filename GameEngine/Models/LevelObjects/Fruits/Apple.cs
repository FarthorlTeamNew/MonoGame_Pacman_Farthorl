using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Apple :Fruit
    {
        private const int AppleBonus = 10;
        private const string fruitPath = "Apple";

        public Apple(Texture2D texture, float x, float y, Rectangle boundingBox) 
            : base(texture, x, y, boundingBox)
        {
            base.FruitBonus = AppleBonus;
        }
    }
}