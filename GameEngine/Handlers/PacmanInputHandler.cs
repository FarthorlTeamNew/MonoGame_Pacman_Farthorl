using GameEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Handlers
{
    public class PacmanInputHandler
    {
        private PacMan pacman;
        public PacmanInputHandler(PacMan pacMan)
        {
            this.pacman = pacMan;
        }

        public Point GetInput()
        {
            KeyboardState state = Keyboard.GetState();
            Point point = new Point();

            if (state.IsKeyDown(Keys.Down))
            {
                point.Y += 15;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                point.Y -= 15;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                point.X -= 15;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                point.X += 15;
            }
            return point;
        }

        Vector2 GetDesiredVelocityFromInput()
        {
            Vector2 desiredVelocity = new Vector2();
            var newPoint = this.GetInput();

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