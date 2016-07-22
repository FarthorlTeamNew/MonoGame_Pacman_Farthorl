namespace GameEngine.Animators
{
    using Globals;
    using Handlers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models.LevelObjects;
    using System;
    using System.Collections.Generic;

    public abstract class GhostAnimator : Animator
    {
        private Direction currentDirection = Direction.Right;
        private Ghost ghost;
        List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;

        public GhostAnimator(Ghost ghost)
        {
            this.ghost = ghost;
            this.BufferFrames();
            this.currentAnimation = this.animations.Find(x => x.Face == currentDirection);
        }

        public Direction CurrentDirection
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
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Right);
                        currentDirection = Direction.Right;
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Left);
                        currentDirection = Direction.Left;
                    }
                }
                else
                {
                    if (velocity.Y > 0)
                    {
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Down);
                        currentDirection = Direction.Down;
                    }
                    else
                    {
                        currentAnimation = this.animations.Find(x => x.Face == Direction.Up);
                        currentDirection = Direction.Up;
                    }
                }
            }
            else
            {
                this.currentAnimation = this.animations.Find(x => x.Face == currentDirection);
            }
            this.currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftPos = new Vector2(this.ghost.X, this.ghost.Y);
            Color tint = Color.White;
            var sourceRectangle = this.currentAnimation.CurrentRectangle;
            spriteBatch.Draw(ghost.Texture, topLeftPos, sourceRectangle, tint);

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
