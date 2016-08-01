using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Ghosts
{
    public class Pinky : Ghost
    {
        public Pinky(Texture2D texture,  Rectangle boundingBox)
            : base(texture, boundingBox)
        {
        }
    }
}
