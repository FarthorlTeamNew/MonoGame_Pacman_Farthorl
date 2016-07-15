using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Brezel : Fruit
    {
        private const int BrezelBonus = 12;
        public Brezel(Texture2D texture, float x, float y) : base(texture, x, y)
        {
            base.FruitBonus = BrezelBonus;
        }
    }
}