using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Peach : Fruit
    {
        private const int PeachBonus = 16;
        public Peach(Texture2D texture, float x, float y) : base(texture, x, y)
        {
            base.FruitBonus = PeachBonus;
        }
    }
}