using GameEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models
{
    public class PacMan : GameObject
    {
        //not used now,but in future
        //private int speed = 5;

        public PacMan(Texture2D texture, float x, float y, Rectangle boundingBox, int quadrantX, int quadrantY)
            : base(texture, 0,  0, boundingBox, quadrantX, quadrantY)
        {

        }

        public int Scores { get; set; } = 0;

        public int Health { get; set; } = 50;
    }
}