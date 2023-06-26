using Microsoft.AspNetCore.Mvc;
using SongList.Core.Entities;
using SongList.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        public readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs);
        }
    }
}
