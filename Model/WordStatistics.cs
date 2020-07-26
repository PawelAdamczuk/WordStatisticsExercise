using System.Collections.Generic;

namespace WordStatisticsExercise.Model
{
    public class WordStatistics
    {
        public IEnumerable<Word> Words { get; set; }
        public int TotalWordCount { get; set; }
    }
}