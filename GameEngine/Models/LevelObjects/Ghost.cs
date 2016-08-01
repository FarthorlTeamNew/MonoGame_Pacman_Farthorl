using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public abstract class Ghost : LevelObject
    {
        protected Ghost(Texture2D texture, Rectangle boundingBox)
            : base(texture, 0, 0, boundingBox)
        {
        }

        public override void ReactOnCollision(PacMan pacMan)
        {      
            //Just to check the collisin, TODO real collision details   
        }
    }
}