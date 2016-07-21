using GameEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models
{
    public class PacMan : GameObject
    {
        //not used now,but in future
        //private int speed = 5;

        public PacMan(Rectangle boundingBox , int quadrantX, int quadrantY) //Hardcore width and height
            : base("Pacman", 0,  0, boundingBox, quadrantX, quadrantY)
        {
           base.Texture = GameTexture.pacMan;
        }

        public int Scores { get; set; } = 0;

        public int Health { get; set; } = 50;
    }
}