namespace Pacman.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PacMan : GameObject
    {
        public PacMan(Texture2D texture, Rectangle boundingBox)
            : base(texture, 0,  0, boundingBox)
        {
            this.CanEat = false;
        }

        public PacMan() : base()
        {
            this.CanEat = false;
        }

        public int Health { get; set; } = 50;

        public bool CanEat { get; set; }

        public int Lives { get; set; } = 3;
    }
}