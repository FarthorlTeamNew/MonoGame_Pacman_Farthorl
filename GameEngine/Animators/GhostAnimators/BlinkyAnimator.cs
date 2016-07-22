using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Animators.GhostAnimators
{
    public class BlinkyAnimator : GhostAnimator
    {
        public BlinkyAnimator(Ghost ghost) : base(ghost)
        {
        }

        public override void BufferFrames()
        {
            base.BufferFrames();
        }
    }
}
