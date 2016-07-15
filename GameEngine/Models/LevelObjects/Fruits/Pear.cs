using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Pear : Fruit
    {
        private const int PearBonus = 17;
        public Pear(Texture2D texture, float x, float y) : base(texture, x, y)
        {
            base.FruitBonus = PearBonus;
        }
    }
}