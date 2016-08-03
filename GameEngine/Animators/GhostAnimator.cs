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
            : base(ghost)
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
            var direction = CalculateDirection(velocity);
            if (velocity != Vector2.Zero)
            {
                switch (direction)
                {
                    case Direction.Right:
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Right);
                        base.currentDirection = Direction.Right;
                        break;

                    case Direction.Left:
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Left);
                        base.currentDirection = Direction.Left;
                        break;

                    case Direction.Down:
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Down);
                        base.currentDirection = Direction.Down;
                        break;

                    case Direction.Up:
                        this.currentAnimation = this.animations.Find(x => x.Face == Direction.Up);
                        base.currentDirection = Direction.Up;
                        break;
                    default:
                        this.currentAnimation = this.animations.Find(x => x.Face == base.currentDirection);
                        break;
                }
            }
            this.currentAnimation.Update(gameTime);
        }

        public Direction CalculateDirection(Vector2 velocity)
        {
            var random = new Random();
            List<Direction> directions = new List<Direction>();

            if (velocity != Vector2.Zero)
            {
                if (velocity.X > this.gameObject.X)
                {
                    directions.Add(Direction.Right);
                }
                if (velocity.X < this.gameObject.X)
                {
                    directions.Add(Direction.Left);
                }
                if (velocity.Y > this.defaultYcoord)
                {
                    directions.Add(Direction.Down);
                }
                if (velocity.Y < this.defaultYcoord)
                {
                    directions.Add(Direction.Up);
                }
            }
            int randomIndex = random.Next(0, directions.Count - 1);
            return directions[randomIndex];
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