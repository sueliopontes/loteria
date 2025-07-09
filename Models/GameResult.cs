using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GameResultsApi.Models
{
    public class GameResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime Date { get; set; }
        public List<int> Numbers { get; set; }
    }
}
