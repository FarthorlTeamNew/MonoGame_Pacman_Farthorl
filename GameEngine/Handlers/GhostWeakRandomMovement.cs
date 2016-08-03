namespace GameEngine.Handlers
{
    using Globals;
    using Enums;
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
            this.pixelMoved = Global.DefaultGhostSpeed;
            this.random = new Random(DateTime.Now.Millisecond);
        }

        private Direction SeePackman()
        {
            // watch left and right
            if (this.gameObject.QuadrantY == this.pacman.QuadrantY)
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

        protected override void CalculateDirection(Direction bannedDirection)
        {
            // checks if ghost is finishing his current direction to the end then randomize to the left, right or back
            // preferred left and right
            if (this.currentDir == Direction.Up && !this.IsMovingUpPossible())
            {
                if (this.IsMovingLeftPossible() && !this.IsMovingRightPossible()) // only right
                {
                    this.currentDir = Direction.Left;
                }
                else if (!this.IsMovingLeftPossible() && this.IsMovingRightPossible()) // only left
                {
                    this.currentDir = Direction.Right;
                }
                else if ((this.IsMovingLeftPossible() == false) && (this.IsMovingRightPossible() == false)) // only back
                {
                    this.currentDir = Direction.Down;
                }
                else
                {
                    Array values = new Direction[] { Direction.Right, Direction.Left };
                    Direction randomDir = (Direction)values.GetValue(this.random.Next(values.Length));
                    this.currentDir = randomDir;
                }
            }
            else if (this.currentDir == Direction.Down && !this.IsMovingDownPossible())
            {
                if (this.IsMovingLeftPossible() && !this.IsMovingRightPossible())
                {
                    this.currentDir = Direction.Left;
                }
                else if (!this.IsMovingLeftPossible() && this.IsMovingRightPossible())
                {
                    this.currentDir = Direction.Right;
                }
                else if ((this.IsMovingLeftPossible() == false) && (this.IsMovingRightPossible() == false))
                {
                    this.currentDir = Direction.Up;
                }
                else
                {
                    Array values = new Direction[] { Direction.Right, Direction.Left };
                    Direction randomDir = (Direction)values.GetValue(this.random.Next(values.Length));
                    this.currentDir = randomDir;
                }
            }
            else if (this.currentDir == Direction.Left && !this.IsMovingLeftPossible())
            {
                if (this.IsMovingUpPossible() && !this.IsMovingDownPossible())
                {
                    this.currentDir = Direction.Up;
                }
                else if (!this.IsMovingUpPossible() && this.IsMovingDownPossible())
                {
                    this.currentDir = Direction.Down;
                }
                else if ((this.IsMovingUpPossible() == false) && (this.IsMovingDownPossible() == false))
                {
                    this.currentDir = Direction.Right;
                }
                else
                {
                    Array values = new Direction[] { Direction.Up, Direction.Down };
                    Direction randomDir = (Direction)values.GetValue(this.random.Next(values.Length));
                    this.currentDir = randomDir;
                }
            }
            else if (this.currentDir == Direction.Right && !this.IsMovingRightPossible())
            {
                if (this.IsMovingUpPossible() && !this.IsMovingDownPossible())
                {
                    this.currentDir = Direction.Up;
                }
                else if (!this.IsMovingUpPossible() && this.IsMovingDownPossible())
                {
                    this.currentDir = Direction.Down;
                }
                else if ((this.IsMovingUpPossible() == false) && (this.IsMovingDownPossible() == false))
                {
                    this.currentDir = Direction.Left;
                }
                else
                {
                    Array values = new Direction[] { Direction.Up, Direction.Down };
                    Direction randomDir = (Direction)values.GetValue(this.random.Next(values.Length));
                    this.currentDir = randomDir;
                }
            }
            else
            {
                return; // without changing direction
            }
        }

        protected override Vector2 GetNextPointToMove()
        {
            if (this.IsReadyToChangeQuadrant())
            {
                Direction directionToPacman = this.SeePackman();
                if (directionToPacman != Direction.None)
                {
                    this.CalculateDirection(directionToPacman);
                }
                else
                {
                    this.CalculateDirection(Direction.None);
                }
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

        public override void GetDrunkThenRehab()
        {
        }
    }
}
