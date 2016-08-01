using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public abstract class LevelObject : GameObject
    {
        protected LevelObject(Texture2D texture, float x, float y, Rectangle boundingBox)
            :base(texture, x, y, boundingBox)
        {
        }

        public virtual Rectangle GetBoundingBox()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Texture.Width, this.Texture.Height);
        }

        public virtual bool IsColliding(GameObject gameObject)
        {
            return gameObject.X < this.X + 15 && gameObject.X > this.X - 15 && gameObject.Y < this.Y + 15 && gameObject.Y > this.Y - 15;
        }

        public abstract void ReactOnCollision(PacMan pacman);
    }
}