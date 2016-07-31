using Microsoft.Xna.Framework;

namespace GameEngine.Handlers
{
    using Globals;
    using Models;

    public abstract class ObjectMover
    {
        protected GameObject gameObject;
        protected Direction currentDir;
        protected bool[,] obstacles;
        protected int pixelMoved; //inicialize how many pixels will move per iteration

        public ObjectMover(GameObject gameObject, Matrix levelMatrix)
        {
            this.gameObject = gameObject;
            currentDir = Direction.Right;
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

        public virtual void Reset()
        {
            currentDir = Direction.Right;
        }

        protected virtual bool IsReadyToChangeQuadrant()
        {
            if (gameObject.X % Global.quad_Width == 0
                && gameObject.Y % Global.quad_Height == 0)
            {
                gameObject.QuadrantX = (int)gameObject.X / Global.quad_Width;
                gameObject.QuadrantY = (int)gameObject.Y / Global.quad_Height;
                return true;
            }

            return false;
        }

        protected abstract void CalculateDirection();

        protected abstract Vector2 GetNextPointToMove();

        public virtual Vector2 Move(GameTime gameTime)
        {
            var nextPointToMove = this.GetNextPointToMove();

            this.gameObject.X += nextPointToMove.X /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.gameObject.Y += nextPointToMove.Y /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;
            this.gameObject.UpdateBoundingBox();

            return nextPointToMove;
        }

        protected virtual bool IsMovingLeftPossible()
        {
            if (gameObject.QuadrantX > 0
               && obstacles[gameObject.QuadrantY, gameObject.QuadrantX - 1] == false)
            {
                return true;
            }
            return false;
        }

        protected virtual bool IsMovingRightPossible()
        {
            if (gameObject.QuadrantX < Global.XMax - 1
               && obstacles[gameObject.QuadrantY, gameObject.QuadrantX + 1] == false)
            {
                return true;
            }
            return false;
        }

        protected virtual bool IsMovingUpPossible()
        {
            if (gameObject.QuadrantY > 0
               && obstacles[gameObject.QuadrantY - 1, gameObject.QuadrantX] == false)
            {
                return true;
            }
            return false;
        }

        protected virtual bool IsMovingDownPossible()
        {
            if (gameObject.QuadrantY < Global.YMax - 1
               && obstacles[gameObject.QuadrantY + 1, gameObject.QuadrantX] == false)
            {
                return true;
            }
            return false;
        }
    }
}
