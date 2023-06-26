using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongList.Core.Entities;
using SongList.Core.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace SongList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadSongList(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            if (!IsCsvFile(file.FileName))
                return BadRequest("Invalid file format. Only CSV files are allowed.");

            var fileBytes = await ReadFileBytesAsync(file);
            var songs = await _uploadService.UploadSongsAsync(fileBytes);

            return Ok(songs);
        }

        private async Task<byte[]> ReadFileBytesAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        private bool IsCsvFile(string fileName)
        {
            return Path.GetExtension(fileName).Equals(".csv", System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
