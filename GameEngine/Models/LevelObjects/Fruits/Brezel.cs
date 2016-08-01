using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public class Brezel : Fruit
    {
        private const int BrezelBonus = 12;
        public Brezel(Texture2D texture, Rectangle boundingBox)
            : base(texture, boundingBox)
        {
            base.FruitBonus = BrezelBonus;
        }
    }
}