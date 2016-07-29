using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public interface IMoving
    {
        Vector2 Move(GameTime gameTime);
        void Reset();
    }
}
