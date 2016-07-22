using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Interfaces
{
    public interface IGameObject
    {
        Texture2D Texture { get; }
        float X { get; }
        float Y { get; }
        int QuadrantX { get; }
        int QuadrantY { get; }
    }
}