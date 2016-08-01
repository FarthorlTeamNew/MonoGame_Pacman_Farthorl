using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Models.LevelObjects
{
    public class GhostKiller : LevelObject
    {
        public GhostKiller(Texture2D texture, Rectangle boundingBox) 
            : base(texture, 0, 0, boundingBox)
        {
        }

        public override void ReactOnCollision(PacMan pacman)
        {
            pacman.CanEat = true;
            Engine.sound.PacManEatGhost();
        }
    }
}
