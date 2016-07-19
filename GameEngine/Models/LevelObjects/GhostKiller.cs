using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public class GhostKiller : LevelObject
    {
        public GhostKiller(float x, float y, Rectangle boundingBox) : base("GhostKiller", x, y, boundingBox)
        {

        }

        public override void ReactOnCollision(PacMan pacman)
        {
        }
    }
}
