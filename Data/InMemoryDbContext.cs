using System.Collections.Generic;
using GameResultsApi.Models;

namespace GameResultsApi.Data
{
    public class InMemoryDbContext
    {
        private readonly List<GameResult> _gameResults;

        public InMemoryDbContext()
        {
            _gameResults = new List<GameResult>();
        }

        public void AddGameResult(GameResult gameResult)
        {
            _gameResults.Add(gameResult);
        }

        public IEnumerable<GameResult> GetAllGameResults()
        {
            return _gameResults;
        }
    }
}