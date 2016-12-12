namespace Pacman.JsonConverter.Interfaces
{
    using System.Collections.Generic;

    public interface IHighscore
    {
        string Message { get; }

        IEnumerable<TEntity> GetTopPlayers<TEntity>();
    }
}