using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Fruits
{
    public partial class Banana : Fruit
    {
        private const int BananaBonus = 15;
        public Banana(Texture2D texture, float x, float y) 
            : base(texture, x, y)
        {
            base.FruitBonus = BananaBonus;
        }
    }
}