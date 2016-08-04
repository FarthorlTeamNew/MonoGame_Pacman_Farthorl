namespace GameEngine.Animators
{
    using Enums;
    using Globals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models.LevelObjects;
    using System;
    using System.Collections.Generic;

    public abstract class GhostAnimator : Animator
    {
        protected List<Animation> animations = new List<Animation>();
        public Animation currentAnimation;

        protected GhostAnimator(Ghost ghost)
            : base(ghost)
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
            
            if (this.gameObject.Texture == GameTexture.GhostAsPokemon)
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
        }
    }
}