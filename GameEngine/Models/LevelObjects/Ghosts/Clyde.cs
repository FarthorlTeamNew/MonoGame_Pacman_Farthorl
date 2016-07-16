using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects.Ghosts
{
    public class Clyde : Ghost
    {
        public Clyde(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base(texture.Name, texture, x, y, boundingBox)
        {
            base.Texture = texture;
        }
    }
}
