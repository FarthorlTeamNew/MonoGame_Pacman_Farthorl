namespace GameEngine.Animators
{
    using Handlers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Models.LevelObjects;
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

            }
            this.currentAnimation.Update(gameTime);
        }

        public Direction CalculateDirection(Vector2 velocity)
        {
            if (velocity.X < this.gameObject.QuadrantX)
            {
                if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX - 1, this.gameObject.QuadrantY))
                {
                    return Direction.Left;
                }
                else if (velocity.Y < this.gameObject.QuadrantY &&
                    !GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX, this.gameObject.QuadrantY - 1))
                {
                    return Direction.Up;
                }
                else if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX, this.gameObject.QuadrantY + 1))
                {
                    return Direction.Down;
                }
            }

            if (velocity.X > this.gameObject.QuadrantX)
            {
                if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX + 1, this.gameObject.QuadrantY))
                {
                    return Direction.Right;
                }
                else if (velocity.Y < this.gameObject.QuadrantY &&
                    !GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX, this.gameObject.QuadrantY - 1))
                {
                    return Direction.Up;
                }
                else if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX, this.gameObject.QuadrantY + 1))
                {
                    return Direction.Down;
                }
            }

            if (velocity.Y < this.gameObject.QuadrantY)
            {
                if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX, this.gameObject.QuadrantY - 1))
                {
                    return Direction.Up;
                }
                else if (velocity.X < this.gameObject.QuadrantX &&
                    !GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX - 1, this.gameObject.QuadrantY))
                {
                    return Direction.Left;
                }
                else if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX + 1, this.gameObject.QuadrantY))
                {
                    return Direction.Right;
                }
            }

            if (velocity.Y > this.gameObject.QuadrantY)
            {
                if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX, this.gameObject.QuadrantY + 1))
                {
                    return Direction.Down;
                }
                else if (velocity.X < this.gameObject.QuadrantX &&
                    !GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX - 1, this.gameObject.QuadrantY))
                {
                    return Direction.Left;
                }
                else if (!GameEngine.Matrix.IsThereABrick(this.gameObject.QuadrantX + 1, this.gameObject.QuadrantY))
                {
                    return Direction.Right;
                }
            }

            return this.currentDirection;

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
