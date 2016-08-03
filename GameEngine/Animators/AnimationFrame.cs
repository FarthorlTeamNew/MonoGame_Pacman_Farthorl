namespace GameEngine.Animators
{
    using System;
    using Microsoft.Xna.Framework;

    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public TimeSpan Duration { get; set; }
    }
}