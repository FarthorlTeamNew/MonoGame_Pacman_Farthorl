namespace GameEngine.Models
{
    using Interfaces;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public abstract class GameObject : IGameObject
    {
        private Texture2D texture;
        private Rectangle boundingBox;
        private float x;
        private float y;
        protected int quadrantX;
        protected int quadrantY;

        protected GameObject(Texture2D texture, float x, float y, Rectangle box, int quadrantX = 0, int quadrantY = 0)
        {
            this.BoundingBox = box;
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.quadrantX = quadrantX;
            this.quadrantY = quadrantY;
        }

        protected GameObject()
        {
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public Rectangle BoundingBox
        {
            get { return this.boundingBox; }
            protected set { this.boundingBox = value; }
        }

        public float X
        {
            get { return this.x; }
            protected internal set { this.x = value; }
        }

        public float Y
        {
            get { return this.y; }
            protected internal set { this.y = value; }
        }

        public void UpdateBoundingBox()
        {
            this.boundingBox.X = (int)this.X;
            this.boundingBox.Y = (int)this.Y;
        }

        public int QuadrantX
        {
            get { return this.quadrantX; }
            protected internal set { this.quadrantX = value; }
        }

        public int QuadrantY
        {
            get { return this.quadrantY; }
            protected internal set { this.quadrantY = value; }
        }
    }
}