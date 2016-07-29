using GameEngine.Globals;
using GameEngine.Models;
using GameEngine.Models.LevelObjects.Ghosts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GameEngine.Handlers
{
    class ClydeRandomMovement
    {
        private Clyde clyde;
        private Direction currentDir;
        private Direction desiredDir;
        private bool[,] obstacles;
        private static int pixelMoved = Global.DefaultGhostSpeed; //inicialize how many pixels will move PacMan per iteration
        private Random random;
        List<Direction> possibleDirections;

        public ClydeRandomMovement(Clyde clyde, Matrix levelMatrix)
        {
            this.clyde = clyde;
            currentDir = Direction.Right;
            desiredDir = Direction.None;
            obstacles = new bool[Global.YMax, Global.XMax];
            random = new Random(DateTime.Now.Millisecond);
            possibleDirections = new List<Direction>();

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
            this.possibleDirections.Clear();
            // checks if ghost is can randomize direction if not going back
            // preferred left, right, front
            if (currentDir == Direction.Up)
            {
                if (IsMovingLeftPossible())
                {
                    possibleDirections.Add(Direction.Left);
                }
                if (IsMovingRightPossible())
                {
                    possibleDirections.Add(Direction.Right);
                }
                if (IsMovingUpPossible())
                {
                    possibleDirections.Add(Direction.Up);
                }
                if(possibleDirections.Count == 0) // go back
                {
                    currentDir = Direction.Down;
                    return;
                }
                ChooseRandomDirection();
            }
            else if (currentDir == Direction.Down)
            {
                if (IsMovingLeftPossible())
                {
                    possibleDirections.Add(Direction.Left);
                }
                if (IsMovingRightPossible())
                {
                    possibleDirections.Add(Direction.Right);
                }
                if (IsMovingDownPossible())
                {
                    possibleDirections.Add(Direction.Down);
                }
                if (possibleDirections.Count == 0) // go back
                {
                    currentDir = Direction.Up;
                    return;
                }
                ChooseRandomDirection();
            }
            else if (currentDir == Direction.Left)
            {
                if (IsMovingLeftPossible())
                {
                    possibleDirections.Add(Direction.Left);
                }
                if (IsMovingDownPossible())
                {
                    possibleDirections.Add(Direction.Down);
                }
                if (IsMovingUpPossible())
                {
                    possibleDirections.Add(Direction.Up);
                }
                if (possibleDirections.Count == 0) // go back
                {
                    currentDir = Direction.Right;
                    return;
                }

                ChooseRandomDirection();
            }
            else if (currentDir == Direction.Right)
            {
                if (IsMovingRightPossible())
                {
                    possibleDirections.Add(Direction.Right);
                }
                if (IsMovingDownPossible())
                {
                    possibleDirections.Add(Direction.Down);
                }
                if (IsMovingUpPossible())
                {
                    possibleDirections.Add(Direction.Up);
                }
                if (possibleDirections.Count == 0) // go back
                {
                    currentDir = Direction.Left;
                    return;
                }

                ChooseRandomDirection();
            }
        }

        private void ChooseRandomDirection()
        {
            if (this.possibleDirections.Count == 1)
            {
                currentDir = this.possibleDirections[0];
            }
            else
            {
                Direction randomDir = (Direction)this.possibleDirections.ToArray().GetValue(random.Next(this.possibleDirections.Count));
                currentDir = randomDir;
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
