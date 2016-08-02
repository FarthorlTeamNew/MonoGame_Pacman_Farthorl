using Microsoft.Xna.Framework;

namespace GameEngine.Handlers
{
    using Globals;
    using Interfaces;
    using Models;
    using Models.LevelObjects;
    using System;
    using System.Collections.Generic;

    class GhostHuntingRandomMovement : ObjectMover, IMovable
    {
        private PacMan pacman;
        private Random random;
        List<Direction> possibleDirections;

        public GhostHuntingRandomMovement(Ghost gameObject, Matrix levelMatrix, PacMan pacman)
            :base(gameObject, levelMatrix)
        {
            this.pacman = pacman;
            random = new Random(DateTime.Now.Millisecond);
            possibleDirections = new List<Direction>();
            pixelMoved = Global.DefaultGhostSpeed;
        }

        protected override void CalculateDirection()
        {
            this.possibleDirections.Clear();

            if (SeePackman())
            {
                return;
            }
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
                if (possibleDirections.Count == 0) // go back
                {
                    currentDir = Direction.Down;
                    return;
                }
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
            }

            ChooseRandomDirection();
        }

        private bool SeePackman()
        {
            // watch left and right
            if(gameObject.QuadrantY == pacman.QuadrantY)
            {
                int distanceToSee = 1;
                while (gameObject.QuadrantX - distanceToSee >= 0 
                    && obstacles[gameObject.QuadrantY, gameObject.QuadrantX - distanceToSee] != true)
                {
                    if (gameObject.QuadrantX - distanceToSee == pacman.QuadrantX)
                    {
                        this.currentDir = Direction.Left;
                        return true;
                    }
                    distanceToSee++;
                }

                distanceToSee = 1;
                while (gameObject.QuadrantX + distanceToSee <= Global.XMax - 1
                    && obstacles[gameObject.QuadrantY, gameObject.QuadrantX + distanceToSee] != true)
                {
                    if (gameObject.QuadrantX + distanceToSee == pacman.QuadrantX)
                    {
                        this.currentDir = Direction.Right;
                        return true;
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
                        this.currentDir = Direction.Up;
                        return true;
                    }
                    distanceToSee++;
                }

                distanceToSee = 1;
                while (gameObject.QuadrantY + distanceToSee <= Global.YMax - 1
                    && obstacles[gameObject.QuadrantY + distanceToSee, gameObject.QuadrantX] != true)
                {
                    if (gameObject.QuadrantY + distanceToSee == pacman.QuadrantY)
                    {
                        this.currentDir = Direction.Down;
                        return true;
                    }
                    distanceToSee++;
                }
            }

            return false;
        }

        private void TurnBackImmediatelyIfSeePackman()
        {
            switch (currentDir)
            {
                case Direction.Up:
                    if (gameObject.QuadrantX == pacman.QuadrantX)
                    {
                        int distanceToSee = 1;
                        while (gameObject.QuadrantY + distanceToSee <= Global.YMax - 1
                            && obstacles[gameObject.QuadrantY + distanceToSee, gameObject.QuadrantX] != true)
                        {
                            if (gameObject.QuadrantY + distanceToSee == pacman.QuadrantY)
                            {
                                this.currentDir = Direction.Down;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
                case Direction.Down:
                    if (gameObject.QuadrantX == pacman.QuadrantX)
                    {
                        int distanceToSee = 1;
                        while (gameObject.QuadrantY - distanceToSee >= 0
                            && obstacles[gameObject.QuadrantY - distanceToSee, gameObject.QuadrantX] != true)
                        {
                            if (gameObject.QuadrantY - distanceToSee == pacman.QuadrantY)
                            {
                                this.currentDir = Direction.Up;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
                case Direction.Left:
                    if (gameObject.QuadrantY == pacman.QuadrantY)
                    {
                        int distanceToSee = 1;
                        while (gameObject.QuadrantX + distanceToSee <= Global.XMax - 1
                            && obstacles[gameObject.QuadrantY, gameObject.QuadrantX + distanceToSee] != true)
                        {
                            if (gameObject.QuadrantX + distanceToSee == pacman.QuadrantX)
                            {
                                this.currentDir = Direction.Right;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
                case Direction.Right:
                    if (gameObject.QuadrantY == pacman.QuadrantY)
                    {
                        int distanceToSee = 1;
                        while (gameObject.QuadrantX - distanceToSee >= 0
                            && obstacles[gameObject.QuadrantY, gameObject.QuadrantX - distanceToSee] != true)
                        {
                            if (gameObject.QuadrantX - distanceToSee == pacman.QuadrantX)
                            {
                                this.currentDir = Direction.Left;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
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
            if (IsReadyToChangeQuadrant())
            {
                CalculateDirection();
            }

            TurnBackImmediatelyIfSeePackman();

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

        public void DecreaseSpeed()
        {
            this.pixelMoved--;
        }
    }
}
