using GameEngine.Handlers;
using GameEngine.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Animators
{
    public abstract class Animator
    {
        protected GameObject gameObject;
        protected Direction currentDirection;
        protected float defaultXcoord;
        protected float defaultYcoord;

        public Animator(GameObject gameObject)
        {
            currentDirection = Direction.Left;
            this.gameObject = gameObject;
            defaultXcoord = gameObject.X;
            defaultYcoord = gameObject.Y;
        }

        public abstract void UpdateAnimation(GameTime gameTime, Vector2 velocity);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void BufferFrames();

        public virtual void Reset()
        {
            currentDirection = Direction.Right;
            gameObject.X = defaultXcoord;
            gameObject.Y = defaultYcoord;
        }
    }
}