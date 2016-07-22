using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public abstract class LevelObject : GameObject
    {
        protected LevelObject(string name, float x, float y, Rectangle boundingBox)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.BoundingBox = boundingBox;
        }

        public virtual Rectangle GetBoundingBox()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Texture.Width, this.Texture.Height);
        }

        public virtual bool IsColliding(GameObject gameObject)
        {
            if (gameObject.X < this.X + 15 && gameObject.X > this.X - 15 && gameObject.Y < this.Y + 15 && gameObject.Y > this.Y - 15)
            {
                return true;
            }
            return false;
        }

        public abstract void ReactOnCollision(PacMan pacman);
    }
}