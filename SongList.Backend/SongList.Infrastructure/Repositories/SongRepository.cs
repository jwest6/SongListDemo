using Microsoft.EntityFrameworkCore;
using SongList.Core.Entities;
using SongList.Core.Interfaces;
using SongList.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongList.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly SongListContext _context;

        public SongRepository(SongListContext context)
        {
            _context = context;
        }

        public async Task AddSongsAsync(List<Song> songs)
        {
            await _context.Songs.AddRangeAsync(songs);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Song>> GetAllSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }
    }
}
