using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordStatisticsExercise.Interfaces;
using WordStatisticsExercise.Model;

#pragma warning restore CS1591

namespace WordStatisticsExercise.Controllers
{
    /// <summary>
    /// Word statistics controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WordStatisticsController : ControllerBase
    {
        private readonly ILogger<WordStatisticsController> _logger;
        private readonly IRemoteFileService _remoteFileService;
        private readonly IWordStatisticsService _wordStatisticsService;

        public WordStatisticsController(ILogger<WordStatisticsController> logger, IRemoteFileService remoteFileService, IWordStatisticsService wordStatisticsService)
        {
            _logger = logger;
            _remoteFileService = remoteFileService;
            _wordStatisticsService = wordStatisticsService;
        }

        /// <summary>
        /// Get top 10 words statistics
        /// </summary>
        /// <param name="resourceUri">URL to an HTTP-accessible text resource [ example: https://ia903105.us.archive.org/1/items/LordOfTheRingsApocalypticProphecies/Lord%20of%20the%20Rings%20Apocalyptic%20Prophecies_djvu.txt ]</param>
        /// <returns>10 most frequently used words in a text</returns>
        [HttpGet]
        public async Task<IActionResult> Get(string resourceUri)
        {
            _logger.LogInformation($"Received request to {ControllerContext.ActionDescriptor.ControllerName} controller. Resource URI parameter: {resourceUri}.");

            try
            {
                var (totalWords, countedWords) = _wordStatisticsService.CountWords(await _remoteFileService.GetRawText(resourceUri));

                return Ok(new WordStatistics
                {
                    TotalWordCount = totalWords,
                    Words = countedWords.OrderByDescending(x => x.Occurrences).Take(10)
                });
            }
            catch (WebException)
            {
                _logger.LogError("Failed to fetch external resource: {ResourceUri}", resourceUri);
                return StatusCode(500, $"Could not access remote resource using provided URI: {resourceUri}");
            }
        }
    }
}
