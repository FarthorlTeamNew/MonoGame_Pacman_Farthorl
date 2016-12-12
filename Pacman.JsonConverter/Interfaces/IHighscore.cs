namespace Pacman.JsonConverter.Interfaces
{
    using System.Collections.Generic;

    public interface IHighscore<out TEntity>
    {
        string Message { get; }

        IEnumerable<TEntity> GetTopScores();
    }
}