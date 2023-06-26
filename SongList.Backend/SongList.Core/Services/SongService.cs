using SongList.Core.Entities;
using SongList.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongList.Core.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public Task<List<Song>> GetAllSongsAsync()
        {
            return _songRepository.GetAllSongsAsync();
        }
    }
}
