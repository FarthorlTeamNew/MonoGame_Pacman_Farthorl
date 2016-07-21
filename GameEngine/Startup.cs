using System;

namespace GameEngine
{
    public static class Startup
    {
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}