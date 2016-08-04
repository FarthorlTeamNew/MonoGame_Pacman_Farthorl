namespace GameEngine.Animators
{
    using Enums;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Animator
    {
        protected GameObject gameObject;
        protected Direction currentDirection;
        protected float defaultXcoord;
        protected float defaultYcoord;

        protected Animator(GameObject gameObject)
        {
            this.currentDirection = Direction.Left;
            this.gameObject = gameObject;
            this.defaultXcoord = gameObject.X;
            this.defaultYcoord = gameObject.Y;
        }

        public abstract void UpdateAnimation(GameTime gameTime, Vector2 velocity);
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 vector);
        public abstract void BufferFrames();

        public virtual void Reset()
        {
            this.currentDirection = Direction.Right;
            this.gameObject.X = this.defaultXcoord;
            this.gameObject.Y = this.defaultYcoord;
        }
    }
}