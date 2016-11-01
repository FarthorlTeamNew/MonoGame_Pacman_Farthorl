namespace GameEngine.Handlers
{
    using Globals;
    using Models;
    using Enums;
    using Microsoft.Xna.Framework;
    using Models.LevelObjects;
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class GhostHuntingRandomMovement : ObjectMover
    {
        private PacMan pacman;
        private Random random;
        List<Direction> possibleDirections;

        public GhostHuntingRandomMovement(Ghost gameObject, Core.Matrix levelMatrix, PacMan pacman)
            :base(gameObject, levelMatrix)
        {
            this.pacman = pacman;
            this.random = new Random(DateTime.Now.Millisecond);
            this.possibleDirections = new List<Direction>();
            this.pixelMoved = Global.DefaultGhostSpeed;
        }

        protected override void CalculateDirection(Direction directionToAvoid)
        {
            this.possibleDirections.Clear();
            
            // checks if ghost is can randomize direction if not going back
            // preferred left, right, front
            if (this.currentDir == Direction.Up)
            {
                if (this.IsMovingLeftPossible() && directionToAvoid != Direction.Left)
                {
                    this.possibleDirections.Add(Direction.Left);
                }
                if (this.IsMovingRightPossible() && directionToAvoid != Direction.Right)
                {
                    this.possibleDirections.Add(Direction.Right);
                }
                if (this.IsMovingUpPossible() && directionToAvoid != Direction.Up)
                {
                    this.possibleDirections.Add(Direction.Up);
                }
                if (this.IsMovingDownPossible() && this.possibleDirections.Count == 0 && directionToAvoid != Direction.Down) // go back
                {
                    this.currentDir = Direction.Down;
                    return;
                }
                else if(this.possibleDirections.Count == 0)
                {
                    this.currentDir = Direction.None;
                }
            }
            else if (this.currentDir == Direction.Down)
            {
                if (this.IsMovingLeftPossible() && directionToAvoid != Direction.Left)
                {
                    this.possibleDirections.Add(Direction.Left);
                }
                if (this.IsMovingRightPossible() && directionToAvoid != Direction.Right)
                {
                    this.possibleDirections.Add(Direction.Right);
                }
                if (this.IsMovingDownPossible() && directionToAvoid != Direction.Down)
                {
                    this.possibleDirections.Add(Direction.Down);
                }
                if (this.IsMovingUpPossible() && this.possibleDirections.Count == 0 && directionToAvoid != Direction.Up) // go back
                {
                    this.currentDir = Direction.Up;
                    return;
                }
                else if(this.possibleDirections.Count == 0)
                {
                    this.currentDir = Direction.None;
                    return;
                }
            }
            else if (this.currentDir == Direction.Left)
            {
                if (this.IsMovingLeftPossible() && directionToAvoid != Direction.Left)
                {
                    this.possibleDirections.Add(Direction.Left);
                }
                if (this.IsMovingDownPossible() && directionToAvoid != Direction.Down)
                {
                    this.possibleDirections.Add(Direction.Down);
                }
                if (this.IsMovingUpPossible() && directionToAvoid != Direction.Up)
                {
                    this.possibleDirections.Add(Direction.Up);
                }
                if (this.IsMovingRightPossible() && this.possibleDirections.Count == 0 && directionToAvoid != Direction.Right) // go back
                {
                    this.currentDir = Direction.Right;
                    return;
                }
                else if (this.possibleDirections.Count == 0)
                {
                    this.currentDir = Direction.None;
                    return;
                }
            }
            else if (this.currentDir == Direction.Right)
            {
                if (this.IsMovingRightPossible() && directionToAvoid != Direction.Right)
                {
                    this.possibleDirections.Add(Direction.Right);
                }
                if (this.IsMovingDownPossible() && directionToAvoid != Direction.Down)
                {
                    this.possibleDirections.Add(Direction.Down);
                }
                if (this.IsMovingUpPossible() && directionToAvoid != Direction.Up)
                {
                    this.possibleDirections.Add(Direction.Up);
                }
                if (this.IsMovingLeftPossible() && this.possibleDirections.Count == 0 && directionToAvoid != Direction.Left) // go back
                {
                    this.currentDir = Direction.Left;
                    return;
                }
                else if (this.possibleDirections.Count == 0)
                {
                    this.currentDir = Direction.None;
                    return;
                }
            }
            else if (this.currentDir == Direction.None && directionToAvoid == Direction.None)
            {
                if (this.IsMovingLeftPossible())
                {
                    this.possibleDirections.Add(Direction.Left);
                }
                if (this.IsMovingDownPossible())
                {
                    this.possibleDirections.Add(Direction.Down);
                }
                if (this.IsMovingUpPossible())
                {
                    this.possibleDirections.Add(Direction.Up);
                }
                if (this.IsMovingRightPossible())
                {
                    this.possibleDirections.Add(Direction.Right);
                }
            }

            if (this.possibleDirections.Count > 0)
            {
                this.ChooseRandomDirectionFromPossible();
            }
        }

        private Direction SeePackman()
        {
            // watch left and right
            if(this.gameObject.QuadrantY == this.pacman.QuadrantY)
            {
                int distanceToSee = 1;
                while (this.gameObject.QuadrantX - distanceToSee >= 0 
                    && this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX - distanceToSee] != true)
                {
                    if (this.gameObject.QuadrantX - distanceToSee == this.pacman.QuadrantX)
                    {
                        return Direction.Left;
                    }
                    distanceToSee++;
                }

                distanceToSee = 1;
                while (this.gameObject.QuadrantX + distanceToSee <= Global.XMax - 1
                    && this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX + distanceToSee] != true)
                {
                    if (this.gameObject.QuadrantX + distanceToSee == this.pacman.QuadrantX)
                    {
                        return Direction.Right;
                    }
                    distanceToSee++;
                }
            }

            // watch up and down
            if (this.gameObject.QuadrantX == this.pacman.QuadrantX)
            {
                int distanceToSee = 1;
                while (this.gameObject.QuadrantY - distanceToSee >= 0
                    && this.obstacles[this.gameObject.QuadrantY - distanceToSee, this.gameObject.QuadrantX] != true)
                {
                    if (this.gameObject.QuadrantY - distanceToSee == this.pacman.QuadrantY)
                    {
                        return Direction.Up;
                    }
                    distanceToSee++;
                }

                distanceToSee = 1;
                while (this.gameObject.QuadrantY + distanceToSee <= Global.YMax - 1
                    && this.obstacles[this.gameObject.QuadrantY + distanceToSee, this.gameObject.QuadrantX] != true)
                {
                    if (this.gameObject.QuadrantY + distanceToSee == this.pacman.QuadrantY)
                    {
                        return Direction.Down;
                    }
                    distanceToSee++;
                }
            }

            return Direction.None;
        }

        private void TurnBackImmediatelyIfSeePackman()
        {
            switch (this.currentDir)
            {
                case Direction.Up:
                    if (this.gameObject.QuadrantX == this.pacman.QuadrantX)
                    {
                        int distanceToSee = 1;
                        while (this.gameObject.QuadrantY + distanceToSee <= Global.YMax - 1
                            && this.obstacles[this.gameObject.QuadrantY + distanceToSee, this.gameObject.QuadrantX] != true)
                        {
                            if (this.gameObject.QuadrantY + distanceToSee == this.pacman.QuadrantY)
                            {
                                this.currentDir = Direction.Down;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
                case Direction.Down:
                    if (this.gameObject.QuadrantX == this.pacman.QuadrantX)
                    {
                        int distanceToSee = 1;
                        while (this.gameObject.QuadrantY - distanceToSee >= 0
                            && this.obstacles[this.gameObject.QuadrantY - distanceToSee, this.gameObject.QuadrantX] != true)
                        {
                            if (this.gameObject.QuadrantY - distanceToSee == this.pacman.QuadrantY)
                            {
                                this.currentDir = Direction.Up;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
                case Direction.Left:
                    if (this.gameObject.QuadrantY == this.pacman.QuadrantY)
                    {
                        int distanceToSee = 1;
                        while (this.gameObject.QuadrantX + distanceToSee <= Global.XMax - 1
                            && this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX + distanceToSee] != true)
                        {
                            if (this.gameObject.QuadrantX + distanceToSee == this.pacman.QuadrantX)
                            {
                                this.currentDir = Direction.Right;
                                return;
                            }
                            distanceToSee++;
                        }
                    }
                    break;
                case Direction.Right:
                    if (this.gameObject.QuadrantY == this.pacman.QuadrantY)
                    {
                        int distanceToSee = 1;
                        while (this.gameObject.QuadrantX - distanceToSee >= 0
                            && this.obstacles[this.gameObject.QuadrantY, this.gameObject.QuadrantX - distanceToSee] != true)
                        {
                            if (this.gameObject.QuadrantX - distanceToSee == this.pacman.QuadrantX)
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

        private void ChooseRandomDirectionFromPossible()
        {
            if (this.possibleDirections.Count == 1)
            {
                this.currentDir = this.possibleDirections[0];
            }
            else
            {
                Direction randomDir = (Direction)this.possibleDirections.ToArray().GetValue(this.random.Next(this.possibleDirections.Count));
                this.currentDir = randomDir;
            }
        }

        protected override Vector2 GetNextPointToMove()
        {
            if (this.IsReadyToChangeQuadrant())
            {
                Direction directionToPacman = this.SeePackman();

                if (this.pacman.CanEat) // run away
                {
                    this.CalculateDirection(directionToPacman);
                }
                else // catch him
                {
                    switch (directionToPacman)
                    {
                        case Direction.Up:
                            this.currentDir = Direction.Up;
                            break;
                        case Direction.Down:
                            this.currentDir = Direction.Down;
                            break;
                        case Direction.Left:
                            this.currentDir = Direction.Left;
                            break;
                        case Direction.Right:
                            this.currentDir = Direction.Right;
                            break;
                        default:
                            this.CalculateDirection(Direction.None);
                            break;
                    }
                }
            }

            if (!this.pacman.CanEat) // catch him immediately
            {
                this.TurnBackImmediatelyIfSeePackman();
            }

            Vector2 nextPointToMove = new Vector2();
            switch (this.currentDir)
            {
                case Direction.Up:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = 0 - this.pixelMoved;
                    break;
                case Direction.Down:
                    nextPointToMove.X = 0;
                    nextPointToMove.Y = this.pixelMoved;
                    break;
                case Direction.Left:
                    nextPointToMove.X = 0 - this.pixelMoved;
                    nextPointToMove.Y = 0;
                    break;
                case Direction.Right:
                    nextPointToMove.X = this.pixelMoved;
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

        public override void DrunkMovement()
        {
        }
    }
}
