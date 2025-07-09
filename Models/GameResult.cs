using System;
using System.Collections.Generic;

namespace GameResultsApi.Models
{
    public class GameResult
    {
        public DateTime Date { get; set; }
        public List<int> Numbers { get; set; }

    }
}
