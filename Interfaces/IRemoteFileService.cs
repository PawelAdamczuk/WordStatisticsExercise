using System.Threading.Tasks;

namespace WordStatisticsExercise.Interfaces
{
    public interface IRemoteFileService
    {
        Task<string> GetRawText(string uri);
    }
}