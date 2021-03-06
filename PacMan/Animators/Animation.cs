﻿namespace Pacman.Animators
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public class Animation
    {
        List<AnimationFrame> frames = new List<AnimationFrame>();
        private TimeSpan timeIntoAnimation;

        public Animation(Direction face)
        {
            this.Face = face;
        }

        public Direction Face { get; set; }

        TimeSpan Duration
        {
            get
            {
                double totalSeconds = 0;
                foreach (var animationFrame in this.frames)
                {
                    totalSeconds += animationFrame.Duration.TotalSeconds;
                }
                return TimeSpan.FromSeconds(totalSeconds);
            }
        }
        public Rectangle CurrentRectangle
        {
            get
            {
                AnimationFrame currentFrame = null;

                // See if we can find the frame
                TimeSpan accumulatedTime = new TimeSpan();
                foreach (var frame in this.frames)
                {
                    if (accumulatedTime + frame.Duration >= this.timeIntoAnimation)
                    {
                        currentFrame = frame;
                        break;
                    }
                    else
                    {
                        accumulatedTime += frame.Duration;
                    }
                }

                // If no frame was found, then try the last frame, 
                // just in case timeIntoAnimation somehow exceeds Duration
                if (currentFrame == null)
                {
                    currentFrame = this.frames.LastOrDefault();
                }

                // If we found a frame, return its rectangle, otherwise
                // return an empty rectangle (one with no width or height)
                if (currentFrame != null)
                {
                    return currentFrame.SourceRectangle;
                }
                else
                {
                    return Rectangle.Empty;
                }
            }
        }

        public void AddFrame(Rectangle rectangle, TimeSpan duration)
        {
            var frame = new AnimationFrame()
            {
                Duration = duration,
                SourceRectangle = rectangle
            };
            this.frames.Add(frame);
        }

        public void Update(GameTime gameTime)
        {
            double secondsIntoAnimation = this.timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;
            double remainder = secondsIntoAnimation % this.Duration.TotalSeconds;

            this.timeIntoAnimation = TimeSpan.FromSeconds(remainder);
        }
    }
}