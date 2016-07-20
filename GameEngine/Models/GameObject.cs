using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameEngine.Models
{
    public abstract class GameObject
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
            set { this.name = value; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public Rectangle BoundingBox
        {
            get { return this.boundingBox; }
            set { this.boundingBox = value; }
        }

        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public void UpdateBoundingBox()
        {
            this.boundingBox.X = (int)this.X;
            this.boundingBox.Y = (int)this.Y;
        }

        public int QuadrantX
        {
            get { return this.quadrantX; }
            set { this.quadrantX = value; }
        }

        public int QuadrantY
        {
            get { return this.quadrantX; }
            set { this.quadrantX = value; }
        }
    }
}