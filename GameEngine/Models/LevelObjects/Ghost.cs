using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameEngine.Models.LevelObjects
{
    public abstract class Ghost : LevelObject
    {
        public Ghost(string name, Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(name, x, y, boundingBox)
        {
            base.Texture = texture;
        }

        public override void ReactOnCollision(PacMan pacMan)
        {
            //Just to check the collisin, TODO real collision details
            Task task = Task.Run(() => { Console.Beep(500, 500); });
        }
    }
}