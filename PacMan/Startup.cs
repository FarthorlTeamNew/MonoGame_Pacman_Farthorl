using Pacman.Data;
using Pacman.Models;

namespace Pacman
{
    using Core;

    public static class Startup
    {
        static void Main()
        {

            using (var game = new Engine())
                game.Run();
        }
    }
}