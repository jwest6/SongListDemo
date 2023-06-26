using SongList.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongList.Core.Interfaces
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAllSongsAsync();
        Task AddSongsAsync(List<Song> songs);
    }
}
