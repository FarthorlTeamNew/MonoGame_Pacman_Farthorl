using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models
{
    public abstract class GameObject
    {
        private string name;
        private Texture2D texture;
        private float x;
        private float y;

        protected GameObject(string name, float x, float y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
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
    }
}