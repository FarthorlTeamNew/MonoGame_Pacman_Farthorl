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


        public string Name
        {
            get { return base.Name; }
            protected set { base.Name = value; }
        }

        public float X
        {
            get { return base.X; }
            protected set { base.X = value; }
        }

        public float Y
        {
            get { return base.Y; }
            protected set { base.Y = value; }
        }

        public Rectangle BoundingBox
        {
            get { return base.BoundingBox; }
            protected set { base.BoundingBox = value; }
        }



        public abstract void ReactOnCollision(PacMan pacman);
    }
}