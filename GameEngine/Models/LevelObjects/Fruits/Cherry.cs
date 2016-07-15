using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Cherry : Fruit
    {
        private const int CherryBonus = 14;
        public Cherry(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture, x, y, boundingBox)
        {
            base.FruitBonus = CherryBonus;
        }
    }
}