namespace GameEngine.Models
{
    using GameEngine.Interfaces;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public abstract class GameObject : IGameObject
    {
        private string name;
        private Texture2D texture;
        private Rectangle boundingBox;
        private float x;
        private float y;
        protected int quadrantX;
        protected int quadrantY;

        protected GameObject(string name, float x, float y, Rectangle box, int quadrantX = 0, int quadrantY = 0)
        {
            this.BoundingBox = box;
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.quadrantX = quadrantX;
            this.quadrantY = quadrantY;
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
            protected set { this.texture = value; }
        }

        public Rectangle BoundingBox
        {
            get { return this.boundingBox; }
            private set { this.boundingBox = value; }
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
            protected set { this.quadrantX = value; }
        }

        public int QuadrantY
        {
            get { return this.quadrantY; }
            protected set { this.quadrantY = value; }
        }
    }
}