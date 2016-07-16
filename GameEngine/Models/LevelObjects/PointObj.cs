using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class PointObj :LevelObject
    {
        public PointObj(Texture2D texture, float x, float y, Rectangle boundingBox)
            : base("Point", x, y, boundingBox)
        {
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            pacman.Scores++;
        }
    }
}
