using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models.LevelObjects
{
    public class Point :LevelObject
    {
        public Point(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture.Name, x, y, boundingBox)
        {
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            //On collision with pacman .. to destroy point :) and pacman earns point
            throw new NotImplementedException();
        }
    }
}
