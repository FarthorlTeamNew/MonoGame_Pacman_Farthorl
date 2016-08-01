using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public class Banana : Fruit
    {
        private const int BananaBonus = 15;
        public Banana(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = BananaBonus;
        }
    }
}