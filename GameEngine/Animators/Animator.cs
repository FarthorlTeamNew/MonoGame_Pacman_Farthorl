using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Animators
{
    public abstract class Animator
    {
        public abstract void UpdateAnimation(GameTime gameTime, Vector2 velocity);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void BufferFrames();
    }
}