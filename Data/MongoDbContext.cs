using GameResultsApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace GameResultsApi.Data
{
    public class MongoDbContext
    {
        private readonly IMongoCollection<GameResult> _gameResults;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _gameResults = database.GetCollection<GameResult>(settings.Value.CollectionName);
        }

        public void AddGameResult(GameResult gameResult)
        {
            _gameResults.InsertOne(gameResult);
        }

        public IEnumerable<GameResult> GetAllGameResults()
        {
            return _gameResults.Find(_ => true).ToList();
        }
    }
}