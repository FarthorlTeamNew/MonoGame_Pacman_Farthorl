namespace GameEngine.Interfaces
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IGameObject
    {
        Texture2D Texture { get; }
        float X { get; }
        float Y { get; }
        int QuadrantX { get; }
        int QuadrantY { get; }
    }
}