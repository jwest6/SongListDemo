//using System.Threading.Tasks;
//using SongList.Core.Interfaces;
//using SongList.Infrastructure.Data;

//namespace SongList.Infrastructure.Repositories
//{
//    internal class UploadRepository : IUploadRepository
//    {
//        private readonly SongListContext _context;

//        public UploadRepository(SongListContext context)
//        {
//            _context = context;
//        }

//        public async Task<int> AddUploadAsync(string fileName)
//        {
//            var upload = new Upload { FileName = fileName };

//            _context.Uploads.Add(upload);
//            await _context.SaveChangesAsync();

//            return upload.Id;
//        }
//    }
//}
