namespace GameEngine.Handlers
{
    using Globals;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Models.LevelObjects;
    using System;

    class GhostWeakRandomMovement : ObjectMover
    {
        private Random random;

        public GhostWeakRandomMovement(Ghost blinky, GameEngine.Matrix levelMatrix)
            :base(blinky, levelMatrix)
        {
            pixelMoved = Global.DefaultGhostSpeed;
            random = new Random(DateTime.Now.Millisecond);
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
                CalculateDirection(Direction.None);
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
