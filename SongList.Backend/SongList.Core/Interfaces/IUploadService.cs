using SongList.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongList.Core.Interfaces
{
    public interface IUploadService
    {
        Task<List<Song>> UploadSongsAsync(byte[] fileBytes);
    }
}
