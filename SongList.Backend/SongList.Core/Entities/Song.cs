using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace SongList.Core.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Index(0)]
        public string SongNumber{ get; set; }
        [Index(1)]
        public string Title { get; set; }
        [Index(2)]
        public string Artist { get; set; }
    }
}
