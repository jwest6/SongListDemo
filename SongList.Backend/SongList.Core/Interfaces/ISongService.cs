using SongList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongList.Core.Interfaces
{
    public interface ISongService
    {
        Task<List<Song>> GetAllSongsAsync();
    }
}
