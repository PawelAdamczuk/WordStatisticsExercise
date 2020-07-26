using System.Collections.Generic;
using WordStatisticsExercise.Model;

namespace WordStatisticsExercise.Interfaces
{
    public interface IWordStatisticsService
    {
        (int, IEnumerable<Word>) CountWords(string input);
    }
}