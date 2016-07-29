using GameEngine.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Animators
{
    public abstract class Animator
    {
        protected Direction currentDirection = Direction.Right;

        public abstract void UpdateAnimation(GameTime gameTime, Vector2 velocity);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void BufferFrames();

        public virtual void Reset()
        {
            currentDirection = Direction.Right;
        }
    }
}