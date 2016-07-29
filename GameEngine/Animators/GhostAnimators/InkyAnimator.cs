using GameEngine.Globals;
using GameEngine.Handlers;
using GameEngine.Models.LevelObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngine.Animators.GhostAnimators
{
    public class InkyAnimator : GhostAnimator
    {
        public InkyAnimator(Ghost ghost) : base(ghost)
        {
        }

        public override void BufferFrames()
        {
            var walkDown = new Animation(Direction.Down);
            walkDown.AddFrame(new Rectangle(4 * Global.quad_Width, Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(5 * Global.quad_Width, Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkUp = new Animation(Direction.Up);
            walkUp.AddFrame(new Rectangle(4 * Global.quad_Width, 3 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(5 * Global.quad_Width, 3 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkLeft = new Animation(Direction.Left);
            walkLeft.AddFrame(new Rectangle(4 * Global.quad_Width, 2 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(5 * Global.quad_Width, 2 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkRight = new Animation(Direction.Right);
            walkRight.AddFrame(new Rectangle(4 * Global.quad_Width, 0, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(5 * Global.quad_Width, 0, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            this.animations.Add(walkDown);
            this.animations.Add(walkUp);
            this.animations.Add(walkLeft);
            this.animations.Add(walkRight);
        }
    }
}
