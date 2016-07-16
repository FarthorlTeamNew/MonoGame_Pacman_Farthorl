using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public abstract class LevelObject:GameObject
    {
        protected LevelObject(string name, float x, float y, Rectangle boundingBox) 
            : base(name, x, y, boundingBox)
        {
        }

        public virtual Rectangle GetBoundingBox()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Texture.Width, this.Texture.Height);
        }

        public virtual bool IsColliding(GameObject gameObject)
        {
            if (gameObject.X < this.X + 15 && gameObject.X  > this.X - 15 && gameObject.Y < this.Y + 15 && gameObject.Y > this.Y - 15)
            {
                return true;
            }
            return false;
        }

        public abstract void ReactOnCollision(PacMan pacman);
    }
}