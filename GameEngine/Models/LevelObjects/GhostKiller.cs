using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class GhostKiller : LevelObject
    {
        public GhostKiller(Texture2D texture, float x, float y, Rectangle boundingBox) 
            : base(texture, x, y, boundingBox)
        {
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            pacman.CanEat = true;
            Engine.sound.PacManEatGhost();
        }
    }
}
