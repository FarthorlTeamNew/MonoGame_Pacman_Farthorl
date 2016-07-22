using GameEngine.Globals;
using GameEngine.Models;
using GameEngine.Models.LevelObjects.Ghosts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameEngine.Handlers
{
    class BlinkyRandomMovement
    {
        private Blinky blinky;
        private Direction currentDir;
        private Direction desiredDir;
        private bool[,] obstacles;
        private static int pixelMoved = Global.BlinkySpeed; //inicialize how many pixels will move PacMan per iteration

        public BlinkyRandomMovement(Blinky blinky, Matrix levelMatrix)
        {
            this.blinky = blinky;
            currentDir = Direction.None;
            desiredDir = Direction.None;
            obstacles = new bool[Global.YMax, Global.XMax];

            for (int i = 0; i < Global.YMax; i++)
            {
                for (int j = 0; j < Global.XMax; j++)
                {
                    string obstical = levelMatrix.PathsMatrix[i, j].Trim().Split(',')[0];
                    obstacles[i, j] = obstical == "1";
                }
            }
        }

        public void Reset()
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

        private void CalculateDirection()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));

            if (this.desiredDir == this.currentDir)
            {
                this.CheckForStopMoving(); // e.g. Direction.None
            }
            else
            {
                //Change directio to Up
                if (desiredDir == Direction.Up
                    && blinky.Y > Global.quad_Height / 2
                    && (this.blinky.Y - pixelMoved >= this.blinky.QuadrantY * Global.quad_Height
                    || obstacles[blinky.QuadrantY - 1, blinky.QuadrantX] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                //Change directio to Down
                else if (desiredDir == Direction.Down
                    && blinky.Y < (((Global.YMax - 1) * Global.quad_Height) - (Global.quad_Height / 2))
                    && (this.blinky.Y + pixelMoved <= this.blinky.QuadrantY * Global.quad_Height
                    || obstacles[blinky.QuadrantY + 1, blinky.QuadrantX] == false))
                {
                    currentDir = desiredDir;
                }
                //Change directio to Left
                else if (desiredDir == Direction.Left
                    && this.blinky.X > Global.quad_Width / 2
                    && (this.blinky.X - pixelMoved >= this.blinky.QuadrantX * Global.quad_Width
                    || obstacles[blinky.QuadrantY, blinky.QuadrantX - 1] == false))
                {
                    currentDir = desiredDir;
                }
                //Change directio to Right
                else if (desiredDir == Direction.Right
                    && this.blinky.X < ((Global.XMax - 1) * Global.quad_Width) - (Global.quad_Width / 2)
                    && (this.blinky.X + pixelMoved <= this.blinky.QuadrantX * Global.quad_Width
                    || obstacles[blinky.QuadrantY, blinky.QuadrantX + 1] == false))
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
                && (blinky.QuadrantY == 0
                || obstacles[blinky.QuadrantY - 1, blinky.QuadrantX] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Down
                && (blinky.QuadrantY == (Global.YMax - 1)
                || obstacles[blinky.QuadrantY + 1, blinky.QuadrantX] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Left
                && (blinky.QuadrantX == 0
                || obstacles[blinky.QuadrantY, blinky.QuadrantX - 1] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Right
               && (blinky.QuadrantX == (Global.XMax - 1)
               || obstacles[blinky.QuadrantY, blinky.QuadrantX + 1] == true))
            {
                currentDir = Direction.None;
            }
        }

        private bool IsReadyToChangePackmanQuadrant()
        {
            if (this.currentDir == Direction.Up && desiredDir == Direction.Down ||
               this.currentDir == Direction.Down && this.desiredDir == Direction.Up ||
               this.currentDir == Direction.Right && this.desiredDir == Direction.Left ||
               this.currentDir == Direction.Left && this.desiredDir == Direction.Right)
            {
                return true; //Change direction immediately if the changed direction is pposite
            }

            if (blinky.X % Global.quad_Width == 0
                && blinky.Y % Global.quad_Height == 0)
            {
                blinky.QuadrantX = (int)blinky.X / 32;
                blinky.QuadrantY = (int)blinky.Y / 32;
                return true;
            }

            return false;
        }

        private Vector2 GetDesiredVelocityFromInput()
        {
             GetInput(); // listens for key pressed

            if (IsReadyToChangePackmanQuadrant())
            {
                CalculateDirection();
            }

            //CalculateDirection();

            Vector2 desiredVelocity = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = 0 - BlinkyRandomMovement.pixelMoved; // this magic number is velocity(pixels per gameTime) and he must devide 32(Global.quad_Width) with reminder 0
                    break;
                case Direction.Down:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = BlinkyRandomMovement.pixelMoved;
                    break;
                case Direction.Left:
                    desiredVelocity.X = 0 - BlinkyRandomMovement.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.Right:
                    desiredVelocity.X = BlinkyRandomMovement.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.None:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = 0;
                    break;
            }

            return desiredVelocity;
        }

        public Vector2 Move(GameTime gameTime)
        {
            var velocity = this.GetDesiredVelocityFromInput();

            this.blinky.X += velocity.X /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.blinky.Y += velocity.Y /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.blinky.UpdateBoundingBox();

            return velocity;
        }
    }
}
