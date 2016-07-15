using System;
using Microsoft.Xna.Framework;

namespace GameEngine.Animators
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public TimeSpan Duration { get; set; }
    }
}