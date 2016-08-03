namespace GameEngine.Animators
{
    using System;
    using System.Collections.Generic;
    using Globals;
    using Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Handlers;
    public class PacmanAnimator : Animator
    {
        List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;

        public PacmanAnimator(PacMan pacMan)
            :base(pacMan)
        {
            this.BufferFrames();
            this.currentAnimation = this.animations.Find(x => x.Face == base.currentDirection);
        }

        public Direction CurrentDirection
        {
            get { return base.currentDirection; }
            set { base.currentDirection = value; }
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
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Right);
                        base.currentDirection = Direction.Right;
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Left);
                        base.currentDirection = Direction.Left;
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Down);
                        base.currentDirection = Direction.Down;
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Up);
                        base.currentDirection = Direction.Up;
                    }
                }
            }
            else
            {
                this.currentAnimation = this.animations.Find(x => x.Face == base.currentDirection);
            }
            this.currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftPos = new Vector2(base.gameObject.X, base.gameObject.Y);
            Color tint = Color.White;
            var sourceRectangle = this.currentAnimation.CurrentRectangle;
            spriteBatch.Draw(base.gameObject.Texture, topLeftPos, sourceRectangle, tint);

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