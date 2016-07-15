using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models.LevelObjects
{
    public class PointObj :LevelObject
    {
        public PointObj(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base("Point", x, y, boundingBox)
        {
        }

        public override void ReactOnCollision()
        {
            InitializeMatrix.PathsMatrix[(int)this.X / 32, (int)base.Y / 32] = "0,0";
        }
    }
}
