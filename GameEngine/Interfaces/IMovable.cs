namespace GameEngine.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IMovable
    {
        Vector2 Move(GameTime gameTime);
        void Reset();
        void DecreaseSpeed();
        void GetDrunkThenRehab();
    }
}
