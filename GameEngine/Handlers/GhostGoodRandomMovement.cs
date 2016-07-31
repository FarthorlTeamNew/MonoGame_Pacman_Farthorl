using Microsoft.Xna.Framework;

namespace GameEngine.Handlers
{
    using Globals;
    using Interfaces;
    using Models.LevelObjects;
    using System;
    using System.Collections.Generic;

    class GhostGoodRandomMovement : ObjectMover, IMovable
    {
        private Random random;
        List<Direction> possibleDirections;

        public GhostGoodRandomMovement(Ghost gameObject, Matrix levelMatrix)
            : base(gameObject, levelMatrix)
        {
            pixelMoved = Global.DefaultGhostSpeed;
            random = new Random(DateTime.Now.Millisecond);
            possibleDirections = new List<Direction>();
        }

        protected override void CalculateDirection()
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

        protected override Vector2 GetNextPointToMove()
        {
            if (base.IsReadyToChangeQuadrant())
            {
                CalculateDirection();
            }

            Vector2 nextPointToMove = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0 - base.pixelMoved;
                    break;
                case Direction.Down:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = base.pixelMoved;
                    break;
                case Direction.Left:
                    nextPointToMove.X = 0 - base.pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.Right:
                    nextPointToMove.X = base.pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.None:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0;
                    break;
            }

            return nextPointToMove;
        }
    }
}
