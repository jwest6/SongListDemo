using System.Threading.Tasks;

namespace SongList.Core.Interfaces
{
    public interface IUploadRepository
    {
        Task<int> AddUploadAsync(string fileName);
    }
}
