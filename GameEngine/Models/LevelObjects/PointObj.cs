using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class PointObj :LevelObject
    {
        public PointObj(Texture2D texture ,float x, float y, Rectangle boundingBox)
            : base("Point", x, y, boundingBox)
        {
            this.Texture = texture;
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            Game1.sound.Eat();
            pacman.Scores++;
        }
    }
}
