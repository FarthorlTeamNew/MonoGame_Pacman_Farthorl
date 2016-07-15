using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Cherry : Fruit
    {
        private const int CherryBonus = 14;
        public Cherry(Texture2D texture, float x, float y) : base(texture, x, y)
        {
            base.FruitBonus = CherryBonus;
        }
    }
}