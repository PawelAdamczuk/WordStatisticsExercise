using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordStatisticsExercise.Interfaces;
using WordStatisticsExercise.Model;

namespace WordStatisticsExercise.Services
{
    public class WordStatisticsService : IWordStatisticsService
    {
        private static readonly Regex WordRegex = new Regex("[\\p{L}']+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public (int, IEnumerable<Word>) CountWords(string input)
        {
            var wordCounts = new Dictionary<string, int>();
            var matchCollection = WordRegex.Matches(input);

            foreach (Match match in matchCollection)
            {
                if (wordCounts.ContainsKey(match.Value.ToLowerInvariant()))
                    wordCounts[match.Value.ToLowerInvariant()]++;
                else
                    wordCounts.Add(match.Value.ToLowerInvariant(), 1);
            }

            return (matchCollection.Count, wordCounts.Select(x => new Word {NormalizedText = x.Key, Occurrences = x.Value}));
        }
    }
}