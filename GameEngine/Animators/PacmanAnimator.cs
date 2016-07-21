using System;
using System.Collections.Generic;
using GameEngine.Globals;
using GameEngine.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Animators
{
    public class PacmanAnimator : Animator
    {
        private string currentDirection = "WalkRight";
        private PacMan pacman;
        List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;

        public PacmanAnimator(PacMan pacMan)
        {
            this.pacman = pacMan;
            this.BufferFrames();
            this.currentAnimation = this.animations.Find(x => x.Name == currentDirection);
        }

        public string CurrentDirection
        {
            get { return currentDirection; }
            set { currentDirection = value; }
        }

        public override void UpdateAnimation(GameTime gameTime, Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                bool movingHorizontally = Math.Abs(velocity.X) > Math.Abs(velocity.Y);
                if (movingHorizontally)
                {
                    if (velocity.X > 0)
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkRight");
                        currentDirection = "WalkRight";
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkLeft");
                        currentDirection = "WalkLeft";
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkDown");
                        currentDirection = "WalkDown";
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Name == "WalkUp");
                        currentDirection = "WalkUp";
                    }
                }
            }
            else
            {
                this.currentAnimation = this.animations.Find(x => x.Name == currentDirection);
            }
            this.currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftPos = new Vector2(this.pacman.X, this.pacman.Y);
            Color tint = Color.White;
            var sourceRectangle = this.currentAnimation.CurrentRectangle;
            spriteBatch.Draw(GameTexture.pacMan, topLeftPos, sourceRectangle, tint);

        }

        public override void BufferFrames()
        {
            var walkDown = new Animation("WalkDown");
            walkDown.AddFrame(new Rectangle(10 * Global.quad_Width, Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(11 * Global.quad_Width, Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkUp = new Animation("WalkUp");
            walkUp.AddFrame(new Rectangle(10 * Global.quad_Width, 3 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(11 * Global.quad_Width, 3 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkLeft = new Animation("WalkLeft");
            walkLeft.AddFrame(new Rectangle(10 * Global.quad_Width, 2 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(11 * Global.quad_Width, 2 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkRight = new Animation("WalkRight");
            walkRight.AddFrame(new Rectangle(10 * Global.quad_Width, 0, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(11 * Global.quad_Width, 0, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            this.animations.Add(walkDown);
            this.animations.Add(walkUp);
            this.animations.Add(walkLeft);
            this.animations.Add(walkRight);
        }
    }
}