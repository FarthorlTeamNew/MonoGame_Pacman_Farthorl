using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Animators
{
    public abstract class GhostAnimator : Animator
    {
        public override void UpdateAnimation(GameTime gameTime, Vector2 velocity)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void BufferFrames()
        {
        }
    }
}
