using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public  abstract class LevelObject:GameObject
    {
        public LevelObject(string name, float x, float y) 
            : base(name, x, y)
        {
        }

        public virtual Rectangle GetBoundingBox()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Texture.Width, this.Texture.Height);
        }
        public abstract void ReactOnCollision(PacMan pacman);
    }
}