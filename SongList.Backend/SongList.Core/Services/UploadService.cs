using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using SongList.Core.Entities;
using SongList.Core.Interfaces;

namespace SongList.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly ISongRepository _songRepository;

        public UploadService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<List<Song>> UploadSongsAsync(byte[] fileBytes)
        {
            var songs = ParseCsvFile(fileBytes);
            await _songRepository.AddSongsAsync(songs);

            return songs;
        }


        private List<Song> ParseCsvFile(byte[] fileBytes)
        {
            List<Song> songs = new List<Song>();

            // Convert byte array to string
            string csvContent = System.Text.Encoding.Default.GetString(fileBytes);

            // Create a StringReader from the CSV content
            using (StringReader reader = new StringReader(csvContent))
            {
                using (TextFieldParser csvParser = new TextFieldParser(reader))
                {
                    csvParser.SetDelimiters(","); // Set the delimiter character (e.g., comma)
                    csvParser.HasFieldsEnclosedInQuotes = true; // Set if fields are enclosed in quotes

                    // Skip the first row (header)
                    csvParser.ReadLine();

                    // Read remaining lines
                    while (!csvParser.EndOfData)
                    {
                        string[] fields = csvParser.ReadFields();

                        // Assuming the CSV columns are in the following order: SongName, Artist, Album

                        if (fields.Length >= 3)
                        {
                            Song song = new Song
                            {
                                SongNumber = fields[0],
                                Title = fields[1],
                                Artist = fields[2]
                            };

                            songs.Add(song);
                        }
                        // You may want to handle incomplete or invalid rows gracefully.
                        // For example, log a warning or skip the row.
                    }
                }
            }

            return songs;
        }

    }
}
