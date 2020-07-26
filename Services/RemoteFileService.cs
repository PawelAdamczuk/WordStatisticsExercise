using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WordStatisticsExercise.Controllers;
using WordStatisticsExercise.Interfaces;

namespace WordStatisticsExercise.Services
{
    public class RemoteFileService : IRemoteFileService
    {
        private readonly ILogger<WordStatisticsController> _logger;

        public RemoteFileService(ILogger<WordStatisticsController> logger)
        {
            _logger = logger;
        }

        public async Task<string> GetRawText(string uri)
        {
            _logger.LogInformation($"Accessing external resource: {uri}");
            using var client = new WebClient();
            await using var stream = client.OpenRead(uri);

            // ReSharper disable once AssignNullToNotNullAttribute
            using var reader = new StreamReader(stream);

            var result = await reader.ReadToEndAsync();
            _logger.LogInformation($"Fetched external text resource. Size: {System.Text.Encoding.UTF8.GetByteCount(result) / 1000f} kilobytes.");

            return result;
        }
    }
}