using GameEngine.Core;

namespace GameEngine
{
    public static class Startup
    {
        static void Main()
        {
            using (var game = new Engine())
                game.Run();
        }
    }
}