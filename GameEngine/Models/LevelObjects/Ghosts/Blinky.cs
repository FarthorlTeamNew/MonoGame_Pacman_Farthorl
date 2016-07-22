using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Ghosts
{
    public class Blinky : Ghost
    {
        public Blinky(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture, x, y, boundingBox)
        {

        }
    }
}
