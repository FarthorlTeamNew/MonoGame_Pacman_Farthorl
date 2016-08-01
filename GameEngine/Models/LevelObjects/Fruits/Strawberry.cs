using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public class Strawberry : Fruit
    {
        private const int StrawberryBonus = 9;
        public Strawberry(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = StrawberryBonus;
        }
    }
}