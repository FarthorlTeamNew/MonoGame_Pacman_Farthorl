using GameEngine.Enums;

namespace GameEngine.Handlers
{
    using Globals;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Models;
    using Models.LevelObjects;
    using System;

    class GhostWeakRandomMovement : ObjectMover
    {
        private PacMan pacman;
        private Random random;

        public GhostWeakRandomMovement(Ghost blinky, Core.Matrix levelMatrix, PacMan pacman)
            :base(blinky, levelMatrix)
        {
            this.pacman = pacman;
            pixelMoved = Global.DefaultGhostSpeed;
            random = new Random(DateTime.Now.Millisecond);
        }

        private Direction SeePackman()
        {
            // watch left and right
            if (gameObject.QuadrantY == pacman.QuadrantY)
            {
                int distanceToSee = 1;
                while (gameObject.QuadrantX - distanceToSee >= 0
                    && obstacles[gameObject.QuadrantY, gameObject.QuadrantX - distanceToSee] != true)
                {
                    if (gameObject.QuadrantX - distanceToSee == pacman.QuadrantX)
                    {
                        return Direction.Left;
                    }
                    distanceToSee++;
                }

                distanceToSee = 1;
                while (gameObject.QuadrantX + distanceToSee <= Global.XMax - 1
                    && obstacles[gameObject.QuadrantY, gameObject.QuadrantX + distanceToSee] != true)
                {
                    if (gameObject.QuadrantX + distanceToSee == pacman.QuadrantX)
                    {
                        return Direction.Right;
                    }
                    distanceToSee++;
                }
            }

            // watch up and down
            if (gameObject.QuadrantX == pacman.QuadrantX)
            {
                int distanceToSee = 1;
                while (gameObject.QuadrantY - distanceToSee >= 0
                    && obstacles[gameObject.QuadrantY - distanceToSee, gameObject.QuadrantX] != true)
                {
                    if (gameObject.QuadrantY - distanceToSee == pacman.QuadrantY)
                    {
                        return Direction.Up;
                    }
                    distanceToSee++;
                }

                distanceToSee = 1;
                while (gameObject.QuadrantY + distanceToSee <= Global.YMax - 1
                    && obstacles[gameObject.QuadrantY + distanceToSee, gameObject.QuadrantX] != true)
                {
                    if (gameObject.QuadrantY + distanceToSee == pacman.QuadrantY)
                    {
                        return Direction.Down;
                    }
                    distanceToSee++;
                }
            }

            return Direction.None;
        }

        protected override void CalculateDirection(Direction bannedDirection)
        {
            // checks if ghost is finishing his current direction to the end then randomize to the left, right or back
            // preferred left and right
            if (currentDir == Direction.Up && !IsMovingUpPossible())
            {
                if ( IsMovingLeftPossible() && !IsMovingRightPossible()) // only right
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
                    Array values = new Direction[] { Direction.Right, Direction.Left };
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
                    Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
                    currentDir = randomDir;
                }
            }
            else
            {
                return; // without changing direction
            }
        }

        protected override Vector2 GetNextPointToMove()
        {
            if (base.IsReadyToChangeQuadrant())
            {
                Direction directionToPacman = SeePackman();
                if (directionToPacman != Direction.None)
                {
                    CalculateDirection(directionToPacman);
                }
                else
                {
                    CalculateDirection(Direction.None);
                }
            }

            Vector2 nextPointToMove = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0 - pixelMoved;
                    break;
                case Direction.Down:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = pixelMoved;
                    break;
                case Direction.Left:
                    nextPointToMove.X = 0 - pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.Right:
                    nextPointToMove.X = pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.None:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0;
                    break;
            }

            return nextPointToMove;
        }
        public override void DecreaseSpeed()
        {
            this.pixelMoved--;
        }

        public override void GetDrunkThenRehab()
        {
        }
    }
}
