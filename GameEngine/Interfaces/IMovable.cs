using Microsoft.Xna.Framework;

namespace GameEngine.Interfaces
{
    public interface IMovable
    {
        Vector2 Move(GameTime gameTime);
        void Reset();
        void DecreaseSpeed();
    }
}
