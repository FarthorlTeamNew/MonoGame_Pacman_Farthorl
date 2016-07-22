using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class GhostKiller : LevelObject
    {
        public GhostKiller(Texture2D texture, float x, float y, Rectangle boundingBox) : base("GhostKiller", x, y, boundingBox)
        {
            this.Texture = texture;
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            Game1.sound.Eat();
        }
    }
}
