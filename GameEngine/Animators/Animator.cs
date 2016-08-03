namespace GameEngine.Animators
{
    using Handlers;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

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