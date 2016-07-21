namespace GameEngine.Interfaces
{
    public interface IGameObject
    {
        string Name { get; }
        float X { get; }
        float Y { get; }
        int QuadrantX { get; }
        int QuadrantY { get; }
    }
}