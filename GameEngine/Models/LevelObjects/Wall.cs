using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models.LevelObjects
{
    public class Wall : LevelObject
    {
        public Wall(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base("Wall" , x, y, boundingBox)
        {            
        }

        public override void ReactOnCollision(PacMan pacMan)
        {
            
        }
    }
}
