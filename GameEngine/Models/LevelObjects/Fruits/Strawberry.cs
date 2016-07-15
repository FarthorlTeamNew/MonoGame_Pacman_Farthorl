using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Strawberry : Fruit
    {
        private const int StrawberryBonus = 9;
        public Strawberry(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture, x, y, boundingBox)
        {
            base.FruitBonus = StrawberryBonus;
        }
    }
}