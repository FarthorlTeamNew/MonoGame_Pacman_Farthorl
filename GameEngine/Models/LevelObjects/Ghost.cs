using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class Ghost : LevelObject
    {
        public Ghost(Texture2D texture, float x, float y) 
            : base(texture.Name, x, y)
        {
            base.Texture = texture;
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            //Just to check the collisin, TODO real collision details
            Task task = Task.Run(() => { Console.Beep(500, 500); });
        }
    }
}