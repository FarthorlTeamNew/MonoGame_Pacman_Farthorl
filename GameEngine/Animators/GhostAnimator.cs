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
        protected List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;

        public GhostAnimator(Ghost ghost)
            :base(ghost)
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
        }
    }
}
