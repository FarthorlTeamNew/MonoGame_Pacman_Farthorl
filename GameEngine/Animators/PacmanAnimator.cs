namespace GameEngine.Animators
{
    using System;
    using Enums;
    using System.Collections.Generic;
    using Globals;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PacmanAnimator : Animator
    {
        List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;

        public PacmanAnimator(PacMan pacMan)
            :base(pacMan)
        {
            this.BufferFrames();
            this.currentAnimation = this.animations.Find(x => x.Face == this.currentDirection);
        }

        public Direction CurrentDirection
        {
            get { return this.currentDirection; }
            set { this.currentDirection = value; }
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
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Right);
                        this.currentDirection = Direction.Right;
                    }
                    else
                    {
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Left);
                        this.currentDirection = Direction.Left;
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Down);
                        this.currentDirection = Direction.Down;
                    }
                    else
                    {
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Up);
                        this.currentDirection = Direction.Up;
                    }
                }
            }
            else
            {
                this.currentAnimation = this.animations.Find(x => x.Face == this.currentDirection);
            }
            this.currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftPos = new Vector2(this.gameObject.X, this.gameObject.Y);
            Color tint = Color.White;
            var sourceRectangle = this.currentAnimation.CurrentRectangle;
            if (this.gameObject.Texture == GameTexture.PacmanPokeball)
            {
                sourceRectangle.X = 0;
                sourceRectangle.Y = 0;
                spriteBatch.Draw(this.gameObject.Texture, topLeftPos, sourceRectangle, tint);
            }
            else
            {
                spriteBatch.Draw(this.gameObject.Texture, topLeftPos, sourceRectangle, tint);
            }
        }

        public override void BufferFrames()
        {
            var walkDown = new Animation(Direction.Down);
            walkDown.AddFrame(new Rectangle(10 * Global.quad_Width, Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(11 * Global.quad_Width, Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkUp = new Animation(Direction.Up);
            walkUp.AddFrame(new Rectangle(10 * Global.quad_Width, 3 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(11 * Global.quad_Width, 3 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkLeft = new Animation(Direction.Left);
            walkLeft.AddFrame(new Rectangle(10 * Global.quad_Width, 2 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(11 * Global.quad_Width, 2 * Global.quad_Height, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            var walkRight = new Animation(Direction.Right);
            walkRight.AddFrame(new Rectangle(10 * Global.quad_Width, 0, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(11 * Global.quad_Width, 0, Global.quad_Width, Global.quad_Height), TimeSpan.FromSeconds(.25));

            this.animations.Add(walkDown);
            this.animations.Add(walkUp);
            this.animations.Add(walkLeft);
            this.animations.Add(walkRight);
        }
    }
}