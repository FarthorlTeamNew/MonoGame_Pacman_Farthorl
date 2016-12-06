using Pacman.Models;

namespace Pacman.Interfaces
{
    public interface IMatrix
    {
        string[,] PathsMatrix { get; set; }
        Level Level { get; set; }
    }
}
