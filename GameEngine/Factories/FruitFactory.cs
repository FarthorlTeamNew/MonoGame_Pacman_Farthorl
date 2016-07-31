using GameEngine.Models.LevelObjects;
using GameEngine.Models.LevelObjects.Fruits;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Factories
{
    public class FruitFactory
    {
        public Fruit CreateFruit(Texture2D texture)
        {
            switch (texture.Name)
            {
                case @"FruitImages/Apple":
                    return new Apple(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
                case @"FruitImages/Banana":
                    return new Banana(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
                case @"FruitImages/Brezel":
                    return new Brezel(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
                case @"FruitImages/Cherry":
                    return new Cherry(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
                case @"FruitImages/Peach":
                    return new Peach(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
                case @"FruitImages/Pear":
                    return new Pear(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
                case @"FruitImages/Strawberry":
                    return new Strawberry(texture, 0, 0, new Rectangle(0, 0, 32, 32));
                    break;
            }
            return null;
        }           
    }
}
