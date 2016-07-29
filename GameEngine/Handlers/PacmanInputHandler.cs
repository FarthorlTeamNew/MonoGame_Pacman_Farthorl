using GameEngine.Globals;
using GameEngine.Interfaces;
using GameEngine.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Handlers
{

    public class PacmanInputHandler : IMovable
    {
        private PacMan pacman;
        private Direction currentDir;
        private Direction desiredDir;
        private bool[,] obstacles;
        private static int pixelMoved = Global.PacmanSpeed; //inicialize how many pixels will move PacMan per iteration

        public PacmanInputHandler(PacMan pacMan, Matrix levelMatrix)
        {
            this.pacman = pacMan;
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
            if (this.desiredDir == this.currentDir)
            {
                this.CheckForStopMoving(); // e.g. Direction.None
            }
            else
            {
                //Change directio to Up
                if (desiredDir == Direction.Up
                    && pacman.Y > Global.quad_Height / 2
                    && (this.pacman.Y - pixelMoved >= this.pacman.QuadrantY * Global.quad_Height
                    || obstacles[pacman.QuadrantY - 1, pacman.QuadrantX] == false))
                {
                    this.currentDir = this.desiredDir;
                }
                //Change directio to Down
                else if (desiredDir == Direction.Down
                    && pacman.Y < (((Global.YMax - 1) * Global.quad_Height) - (Global.quad_Height / 2))
                    && (this.pacman.Y + pixelMoved <= this.pacman.QuadrantY * Global.quad_Height
                    || obstacles[pacman.QuadrantY + 1, pacman.QuadrantX] == false))
                {
                    currentDir = desiredDir;
                }
                //Change directio to Left
                else if (desiredDir == Direction.Left
                    && this.pacman.X > Global.quad_Width / 2
                    && (this.pacman.X - pixelMoved >= this.pacman.QuadrantX * Global.quad_Width
                    || obstacles[pacman.QuadrantY, pacman.QuadrantX - 1] == false))
                {
                    currentDir = desiredDir;
                }
                //Change directio to Right
                else if (desiredDir == Direction.Right
                    && this.pacman.X < ((Global.XMax - 1) * Global.quad_Width) - (Global.quad_Width / 2)
                    && (this.pacman.X + pixelMoved <= this.pacman.QuadrantX * Global.quad_Width
                    || obstacles[pacman.QuadrantY, pacman.QuadrantX + 1] == false))
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
                && (pacman.QuadrantY == 0
                || obstacles[pacman.QuadrantY - 1, pacman.QuadrantX] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Down
                && (pacman.QuadrantY == (Global.YMax - 1)
                || obstacles[pacman.QuadrantY + 1, pacman.QuadrantX] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Left
                && (pacman.QuadrantX == 0
                || obstacles[pacman.QuadrantY, pacman.QuadrantX - 1] == true))
            {
                currentDir = Direction.None;
            }
            else if (currentDir == Direction.Right
               && (pacman.QuadrantX == (Global.XMax - 1)
               || obstacles[pacman.QuadrantY, pacman.QuadrantX + 1] == true))
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

            if (pacman.X % Global.quad_Width == 0
                && pacman.Y % Global.quad_Height == 0)
            {
                pacman.QuadrantX = (int)pacman.X / 32;
                pacman.QuadrantY = (int)pacman.Y / 32;
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
                    desiredVelocity.Y = 0 - PacmanInputHandler.pixelMoved; // this magic number is velocity(pixels per gameTime) and he must devide 32(Global.quad_Width) with reminder 0
                    break;
                case Direction.Down:
                    desiredVelocity.X = 0;
                    desiredVelocity.Y = PacmanInputHandler.pixelMoved;
                    break;
                case Direction.Left:
                    desiredVelocity.X = 0 - PacmanInputHandler.pixelMoved;
                    desiredVelocity.Y = 0;
                    break;
                case Direction.Right:
                    desiredVelocity.X = PacmanInputHandler.pixelMoved;
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

            this.pacman.X += velocity.X /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.pacman.Y += velocity.Y /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.pacman.UpdateBoundingBox();

            return velocity;
        }
    }
}