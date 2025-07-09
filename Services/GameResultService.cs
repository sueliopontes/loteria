using System.Collections.Generic;
using GameResultsApi.Models;
using GameResultsApi.Data;

namespace GameResultsApi.Services
{
    public class GameResultService
    {
        private readonly InMemoryDbContext _context;

        public GameResultService(InMemoryDbContext context)
        {
            _context = context;
        }

        public void SaveGameResults(IEnumerable<GameResult> gameResults)
        {
            foreach (var result in gameResults)
            {
                _context.AddGameResult(result);
            }
        }

        public IEnumerable<GameResult> GetAllGameResults()
        {
            return _context.GetAllGameResults();
        }
    }
}