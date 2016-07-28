using GameEngine.Globals;
using GameEngine.Models;
using GameEngine.Models.LevelObjects.Ghosts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameEngine.Handlers
{
    class ClydeRandomMovement
    {
        private Clyde clyde;
        private Direction currentDir;
        private Direction desiredDir;
        private bool[,] obstacles;
        private static int pixelMoved = Global.DefaultGhostSpeed; //inicialize how many pixels will move PacMan per iteration

        public ClydeRandomMovement(Clyde clyde, Matrix levelMatrix)
        {
            this.clyde = clyde;
            currentDir = Direction.Right;
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

        private void CalculateDirection()
        {
            // checks if ghost is finishing his current direction to the end then randomize to the left, right or back
            // preferred left and right
            if (currentDir == Direction.Up && !IsMovingUpPossible())
            {
                if (IsMovingLeftPossible() && !IsMovingRightPossible()) // only right
                {
                    currentDir = Direction.Left;
                }
                else if (!IsMovingLeftPossible() && IsMovingRightPossible()) // only left
                {
                    currentDir = Direction.Right;
                }
                else if ((IsMovingLeftPossible() == false) && (IsMovingRightPossible() == false)) // only back
                {
                    currentDir = Direction.Down;
                }
                else
                {
                    Array values = new Direction[] { Direction.Right, Direction.Left };//Enum.GetValues(typeof(Direction));
                    Random random = new Random(DateTime.Now.Millisecond);
                    Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
                    currentDir = randomDir;
                }
            }
            else if (currentDir == Direction.Down && !IsMovingDownPossible())
            {
                if (IsMovingLeftPossible() && !IsMovingRightPossible())
                {
                    currentDir = Direction.Left;
                }
                else if (!IsMovingLeftPossible() && IsMovingRightPossible())
                {
                    currentDir = Direction.Right;
                }
                else if ((IsMovingLeftPossible() == false) && (IsMovingRightPossible() == false))
                {
                    currentDir = Direction.Up;
                }
                else
                {
                    Array values = new Direction[] { Direction.Right, Direction.Left };
                    Random random = new Random(DateTime.Now.Millisecond);
                    Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
                    currentDir = randomDir;
                }
            }
            else if (currentDir == Direction.Left && !IsMovingLeftPossible())
            {
                if (IsMovingUpPossible() && !IsMovingDownPossible())
                {
                    currentDir = Direction.Up;
                }
                else if (!IsMovingUpPossible() && IsMovingDownPossible())
                {
                    currentDir = Direction.Down;
                }
                else if ((IsMovingUpPossible() == false) && (IsMovingDownPossible() == false))
                {
                    currentDir = Direction.Right;
                }
                else
                {
                    Array values = new Direction[] { Direction.Up, Direction.Down };
                    Random random = new Random(DateTime.Now.Millisecond);
                    Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
                    currentDir = randomDir;
                }
            }
            else if (currentDir == Direction.Right && !IsMovingRightPossible())
            {
                if (IsMovingUpPossible() && !IsMovingDownPossible())
                {
                    currentDir = Direction.Up;
                }
                else if (!IsMovingUpPossible() && IsMovingDownPossible())
                {
                    currentDir = Direction.Down;
                }
                else if ((IsMovingUpPossible() == false) && (IsMovingDownPossible() == false))
                {
                    currentDir = Direction.Left;
                }
                else
                {
                    Array values = new Direction[] { Direction.Up, Direction.Down };
                    Random random = new Random(DateTime.Now.Millisecond);
                    Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
                    currentDir = randomDir;
                }
            }
            else
            {
                return; // without changing direction
            }
        }

        private bool IsMovingLeftPossible()
        {
            if (clyde.QuadrantX > 0
               && obstacles[clyde.QuadrantY, clyde.QuadrantX - 1] == false)
            {
                return true;
            }
            return false;
        }

        private bool IsMovingRightPossible()
        {
            if (clyde.QuadrantX < Global.XMax - 1
               && obstacles[clyde.QuadrantY, clyde.QuadrantX + 1] == false)
            {
                return true;
            }
            return false;
        }

        private bool IsMovingUpPossible()
        {
            if (clyde.QuadrantY > 0
               && obstacles[clyde.QuadrantY - 1, clyde.QuadrantX] == false)
            {
                return true;
            }
            return false;
        }

        private bool IsMovingDownPossible()
        {
            if (clyde.QuadrantY < Global.YMax - 1
               && obstacles[clyde.QuadrantY + 1, clyde.QuadrantX] == false)
            {
                return true;
            }
            return false;
        }

        private bool IsReadyToChangeGhostQuadrant()
        {
            if (clyde.X % Global.quad_Width == 0
                && clyde.Y % Global.quad_Height == 0)
            {
                clyde.QuadrantX = (int)clyde.X / 32;
                clyde.QuadrantY = (int)clyde.Y / 32;
                return true;
            }

            return false;
        }

        private Vector2 GetNextMovementPoint()
        {
            //GetInput(); // listens for key pressed

            if (IsReadyToChangeGhostQuadrant())
            {
                CalculateDirection();
            }

            Vector2 nextPointToMove = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0 - ClydeRandomMovement.pixelMoved; // this magic number is velocity(pixels per gameTime) and he must devide 32(Global.quad_Width) with reminder 0
                    break;
                case Direction.Down:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = ClydeRandomMovement.pixelMoved;
                    break;
                case Direction.Left:
                    nextPointToMove.X = 0 - ClydeRandomMovement.pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.Right:
                    nextPointToMove.X = ClydeRandomMovement.pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.None:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0;
                    break;
            }

            return nextPointToMove;
        }

        public Vector2 Move(GameTime gameTime)
        {
            var nextPointToMove = this.GetNextMovementPoint();

            this.clyde.X += nextPointToMove.X /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.clyde.Y += nextPointToMove.Y /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.clyde.UpdateBoundingBox();

            return nextPointToMove;
        }
    }
}
