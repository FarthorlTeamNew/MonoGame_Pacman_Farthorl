using Microsoft.Xna.Framework;

namespace GameEngine.Handlers
{
    using Microsoft.Xna.Framework.Input;
    using Globals;
    using Interfaces;
    using Models;

    public class PacmanInputHandler : ObjectMover, IMovable
    {
        private Direction desiredDir;

        public PacmanInputHandler(PacMan pacMan, Matrix levelMatrix)
            :base(pacMan, levelMatrix)
        {
            desiredDir = Direction.None;
            pixelMoved = Global.PacmanSpeed;
        }

        public override void Reset()
        {
            currentDir = Direction.None;
            desiredDir = Direction.None;
        }

        private void GetInput()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.GetPressedKeys().Length == 1)
            {
                if (state.IsKeyDown(Keys.Down))
                {
                    desiredDir = Direction.Down;
                }
                else if (state.IsKeyDown(Keys.Up))
                {
                    desiredDir = Direction.Up;
                }
                else if (state.IsKeyDown(Keys.Left))
                {
                    desiredDir = Direction.Left;
                }
                else if (state.IsKeyDown(Keys.Right))
                {
                    desiredDir = Direction.Right;
                }
            }
        }

        protected override void CalculateDirection()
        {
            if (this.desiredDir == this.currentDir)
            {
                this.CheckForStopMoving(); // e.g. Direction.None
            }
            else
            {
                //Change directio to Up
                if (desiredDir == Direction.Up
                    && gameObject.Y > Global.quad_Height / 2
                    && (this.gameObject.Y - pixelMoved >= this.gameObject.QuadrantY * Global.quad_Height
                    || obstacles[gameObject.QuadrantY - 1, gameObject.QuadrantX] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                //Change directio to Down
                else if (desiredDir == Direction.Down
                    && gameObject.Y < (((Global.YMax - 1) * Global.quad_Height) - (Global.quad_Height / 2))
                    && (this.gameObject.Y + pixelMoved <= this.gameObject.QuadrantY * Global.quad_Height
                    || obstacles[gameObject.QuadrantY + 1, gameObject.QuadrantX] == false))
                {
                    currentDir = desiredDir;
                }
                //Change directio to Left
                else if (desiredDir == Direction.Left
                    && this.gameObject.X > Global.quad_Width / 2
                    && (this.gameObject.X - pixelMoved >= this.gameObject.QuadrantX * Global.quad_Width
                    || obstacles[gameObject.QuadrantY, gameObject.QuadrantX - 1] == false))
                {
                    currentDir = desiredDir;
                }
                //Change directio to Right
                else if (desiredDir == Direction.Right
                    && this.gameObject.X < ((Global.XMax - 1) * Global.quad_Width) - (Global.quad_Width / 2)
                    && (this.gameObject.X + pixelMoved <= this.gameObject.QuadrantX * Global.quad_Width
                    || obstacles[gameObject.QuadrantY, gameObject.QuadrantX + 1] == false))
                {
                    currentDir = desiredDir;
                }
                else
                {
                    CheckForStopMoving();
                }
            }
        }

        private void CheckForStopMoving()
        {
            if (currentDir == Direction.Up
                && (gameObject.QuadrantY == 0
                || obstacles[gameObject.QuadrantY - 1, gameObject.QuadrantX] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Down
                && (gameObject.QuadrantY == (Global.YMax - 1)
                || obstacles[gameObject.QuadrantY + 1, gameObject.QuadrantX] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Left
                && (gameObject.QuadrantX == 0
                || obstacles[gameObject.QuadrantY, gameObject.QuadrantX - 1] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Right
               && (gameObject.QuadrantX == (Global.XMax - 1)
               || obstacles[gameObject.QuadrantY, gameObject.QuadrantX + 1] == true))
            {
                currentDir = Direction.None;
            }
        }

        protected override bool IsReadyToChangeQuadrant()
        {
            if (this.currentDir == Direction.Up && desiredDir == Direction.Down ||
               this.currentDir == Direction.Down && this.desiredDir == Direction.Up ||
               this.currentDir == Direction.Right && this.desiredDir == Direction.Left ||
               this.currentDir == Direction.Left && this.desiredDir == Direction.Right)
            {
                return true; //Change direction immediately if the changed direction is opposite(back)
            }

            if (gameObject.X % Global.quad_Width == 0
                && gameObject.Y % Global.quad_Height == 0)
            {
                gameObject.QuadrantX = (int)gameObject.X / 32;
                gameObject.QuadrantY = (int)gameObject.Y / 32;
                return true;
            }

            return false;
        }

        protected override Vector2 GetNextPointToMove()
        {
            GetInput(); // listens for key pressed

            if (IsReadyToChangeQuadrant())
            {
                CalculateDirection();
            }

            Vector2 desiredVelocity = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = 0 - base.pixelMoved; // this magic number is velocity(pixels per gameTime) and he must devide 32(Global.quad_Width) with reminder 0
                    break;
                case Direction.Down:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = base.pixelMoved;
                    break;
                case Direction.Left:
                    desiredVelocity.X = 0 - base.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.Right:
                    desiredVelocity.X = base.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.None:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = 0;
                    break;
            }

            return desiredVelocity;
        }
    }
}