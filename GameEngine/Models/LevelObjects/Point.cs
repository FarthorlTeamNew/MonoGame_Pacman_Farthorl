using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models.LevelObjects
{
    public class Point :LevelObject
    {
        public Point(string name, float x, float y) 
            : base(name, x, y)
        {
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            //On collision with pacman .. to destroy point :) and pacman earns point
            throw new NotImplementedException();
        }
    }
}
