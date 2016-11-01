namespace GameEngine.Handlers
{
    using Microsoft.Xna.Framework.Input;
    using Enums;
    using Microsoft.Xna.Framework;
    using Globals;
    using Models;

    public class PacmanInputHandler : ObjectMover
    {
        private Direction desiredDir;
        private bool movementTypeNormal = true;

        public PacmanInputHandler(PacMan pacMan, Core.Matrix levelMatrix)
            :base(pacMan, levelMatrix)
        {
            this.desiredDir = Direction.None;
            this.pixelMoved = Global.PacmanSpeed;
        }

        public override void Reset()
        {
            this.currentDir = Direction.None;
            this.desiredDir = Direction.None;
        }

        private void GetInput()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.GetPressedKeys().Length == 1)
            {
                if (state.IsKeyDown(Keys.Down))
                {
                    this.desiredDir = Direction.Down;
                }
                else if (state.IsKeyDown(Keys.Up))
                {
                    this.desiredDir = Direction.Up;
                }
                else if (state.IsKeyDown(Keys.Left))
                {
                    this.desiredDir = Direction.Left;
                }
                else if (state.IsKeyDown(Keys.Right))
                {
                    this.desiredDir = Direction.Right;
                }
            }
        }

        private void GetDrunkInput()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.GetPressedKeys().Length == 1)
            {
                if (state.IsKeyDown(Keys.Down))
                {
                    this.desiredDir = Direction.Up;
                }
                else if (state.IsKeyDown(Keys.Up))
                {
                    this.desiredDir = Direction.Down;
                }
                else if (state.IsKeyDown(Keys.Left))
                {
                    this.desiredDir = Direction.Right;
                }
                else if (state.IsKeyDown(Keys.Right))
                {
                    this.desiredDir = Direction.Left;
                }
            }
        }

        protected override void CalculateDirection(Direction directionToAvoid)
        {
            if (this.desiredDir == this.currentDir)
            {
                this.CheckForStopMoving(); // e.g. Direction.None
            }
            else
            {
                //Change directio to Up
                if (this.desiredDir == Direction.Up
                    && this.gameObject.Y > Global.quad_Height / 2
                    && (this.gameObject.Y - this.pixelMoved >= this.gameObject.QuadrantY * Global.quad_Height
                    || this.obstacles[this.gameObject.QuadrantY - 1, this.gameObject.QuadrantX] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                //Change directio to Down
                else if (this.desiredDir == Direction.Down
                    && this.gameObject.Y < (((Global.YMax - 1) * Global.quad_Height) - (Global.quad_Height / 2))
                    && (this.gameObject.Y + this.pixelMoved <= this.gameObject.QuadrantY * Global.quad_Height
                    || this.obstacles[this.gameObject.QuadrantY + 1, this.gameObject.QuadrantX] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                //Change directio to Left
                else if (this.desiredDir == Direction.Left
                    && this.gameObject.X > Global.quad_Width / 2
                    && (this.gameObject.X - this.pixelMoved >= this.gameObject.QuadrantX * Global.quad_Width
                    || this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX - 1] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                //Change directio to Right
                else if (this.desiredDir == Direction.Right
                    && this.gameObject.X < ((Global.XMax - 1) * Global.quad_Width) - (Global.quad_Width / 2)
                    && (this.gameObject.X + this.pixelMoved <= this.gameObject.QuadrantX * Global.quad_Width
                    || this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX + 1] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                else
                {
                    this.CheckForStopMoving();
                }
            }
        }

        private void CheckForStopMoving()
        {
            if (this.currentDir == Direction.Up
                && (this.gameObject.QuadrantY == 0
                || this.obstacles[this.gameObject.QuadrantY - 1, this.gameObject.QuadrantX] == true))
            {
                this.currentDir = Direction.None;
            }
            else if (this.currentDir == Direction.Down
                && (this.gameObject.QuadrantY == (Global.YMax - 1)
                || this.obstacles[this.gameObject.QuadrantY + 1, this.gameObject.QuadrantX] == true))
            {
                this.currentDir = Direction.None;
            }
            else if (this.currentDir == Direction.Left
                && (this.gameObject.QuadrantX == 0
                || this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX - 1] == true))
            {
                this.currentDir = Direction.None;
            }
            else if (this.currentDir == Direction.Right
               && (this.gameObject.QuadrantX == (Global.XMax - 1)
               || this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX + 1] == true))
            {
                this.currentDir = Direction.None;
            }
        }

        protected override bool IsReadyToChangeQuadrant()
        {
            if (this.currentDir == Direction.Up && this.desiredDir == Direction.Down ||
               this.currentDir == Direction.Down && this.desiredDir == Direction.Up ||
               this.currentDir == Direction.Right && this.desiredDir == Direction.Left ||
               this.currentDir == Direction.Left && this.desiredDir == Direction.Right)
            {
                return true; //Change direction immediately if the changed direction is opposite(back)
            }

            if (this.gameObject.X % Global.quad_Width == 0
                && this.gameObject.Y % Global.quad_Height == 0)
            {
                this.gameObject.QuadrantX = (int) this.gameObject.X / Global.quad_Width;
                this.gameObject.QuadrantY = (int) this.gameObject.Y / Global.quad_Height;
                return true;
            }

            return false;
        }

        protected override Vector2 GetNextPointToMove()
        {
            if (this.movementTypeNormal)
            {
                this.GetInput(); // listen for key pressed
            }
            else if (!this.movementTypeNormal)
            {
                this.GetDrunkInput();
            }

            if (this.IsReadyToChangeQuadrant())
            {
                this.CalculateDirection(Direction.None);
            }

            Vector2 desiredVelocity = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = 0 - this.pixelMoved; // this magic number is velocity(pixels per gameTime) and he must devide Global.quad_Width with remainder 0
                    break;
                case Direction.Down:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = this.pixelMoved;
                    break;
                case Direction.Left:
                    desiredVelocity.X = 0 - this.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.Right:
                    desiredVelocity.X = this.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.None:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = 0;
                    break;
            }

            return desiredVelocity;
        }

        public override void DecreaseSpeed()
        {
            this.pixelMoved-=2;
        }

        public override void DrunkMovement()
        {
            if (this.movementTypeNormal)
            {
                this.movementTypeNormal = false;
            }
            else if (!this.movementTypeNormal)
            {
                this.movementTypeNormal = true;
            }
        }
    }
}