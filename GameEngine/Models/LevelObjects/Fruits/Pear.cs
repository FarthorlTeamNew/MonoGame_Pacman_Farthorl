using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Pear : Fruit
    {
        private const int PearBonus = 17;
        public Pear(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture, x, y, boundingBox)
        {
            base.FruitBonus = PearBonus;
        }
    }
}