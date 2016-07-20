using GameEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Handlers
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public class PacmanInputHandler
    {
        private PacMan pacman;
        private Direction currentDir;
        private Direction previousDir;
        private Direction desiredDir;
        private bool[,] obsticals; 

        public PacmanInputHandler(PacMan pacMan, Matrix levelMatrix)
        {
            this.pacman = pacMan;
            currentDir = Direction.None;
            previousDir = Direction.None;
            desiredDir = Direction.None;
            obsticals = new bool[Global.YMax, Global.XMax];

            //for (int i = 0; i < Global.YMax; i++)
            //{
            //    for (int j = 0; j < Global.XMax; j++)
            //    {
            //        string obstical = levelMatrix.PathsMatrix[i, j].Trim().Split(',')[0];
            //        obsticals[i,j] = obstical == "1";
            //    }
            //}
        }

        public Point GetInput()
        {
            KeyboardState state = Keyboard.GetState();
            Point point = new Point();

            if (state.GetPressedKeys().Length == 1)
            {
                if (state.IsKeyDown(Keys.Down))
                {
                    point.Y += 15;
                    desiredDir = Direction.Down;
                }
                if (state.IsKeyDown(Keys.Up))
                {
                    point.Y -= 15;
                    desiredDir = Direction.Up;
                }
                if (state.IsKeyDown(Keys.Left))
                {
                    point.X -= 15;
                    desiredDir = Direction.Left;
                }
                if (state.IsKeyDown(Keys.Right))
                {
                    point.X += 15;
                    desiredDir = Direction.Right;
                }
            }

            return point;
        }

        public void CalculateDirection()
        {
            if(desiredDir == Direction.Down)
            {
                if (pacman.QuadrantY < (Global.YMax - 1))
                {
                    if(obsticals[pacman.QuadrantY, pacman.QuadrantY + 1] == false)
                    {
                        //currentDir = desiredDir;
                    }
                }
                
            }
        }

        Vector2 GetDesiredVelocityFromInput()
        {
            Vector2 desiredVelocity = new Vector2();
            var newPoint = this.GetInput();
            CalculateDirection();

            if ((this.pacman.X + newPoint.X) + 17 < Global.GLOBAL_WIDTH && (this.pacman.X + newPoint.X) + 13 >= 0 &&
                (this.pacman.Y + newPoint.Y) + 17 < Global.GLOBAL_HEIGHT && (this.pacman.Y + newPoint.Y) + 13 >= 0)
            {
                desiredVelocity.X = newPoint.X;
                desiredVelocity.Y = newPoint.Y;

                if (desiredVelocity.X != 0 || desiredVelocity.Y != 0)
                {
                    desiredVelocity.Normalize();
                    float desiredSpeed = Global.PacmanSpeed;
                    desiredVelocity *= desiredSpeed;
                }
            }

            return desiredVelocity;
        }

        public Vector2 Move(GameTime gameTime)
        {
            var velocity = GetDesiredVelocityFromInput();

            this.pacman.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.pacman.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.pacman.UpdateBoundingBox();

            return velocity;
        }
    }
}