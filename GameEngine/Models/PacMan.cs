using GameEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models
{
    public class PacMan : GameObject
    {
        //not used now,but in future
        //private int speed = 5;
        private bool canEat;

        public PacMan(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture, 0,  0, boundingBox)
        {
            canEat = false;
           
        }

        public int Scores { get; set; } = 0;

        public int Health { get; set; } = 50;

        public bool CanEat { get; set; }

        public int Lives { get; set; } = 3;
    }
}