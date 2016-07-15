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

        public bool IsColliding(GameObject gameObject, PacMan pacman)
        {
            if (gameObject.BoundingBox.Intersects(pacman.BoundingBox))
            {
                return true;
            }
            return false;
        }

        public abstract void ReactOnCollision(PacMan pacman);
    }
}