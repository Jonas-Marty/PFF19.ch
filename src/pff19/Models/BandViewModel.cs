using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace pff19.Models
{
    public class BandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionDe { get; set; }
        public string DescriptionFr { get; set; }
        public string SpotifyPlaylist { get; set; }
        public string PlayTime { get; set; }
        public string YoutubeUrls { get; set; }
        public string WebSiteUrl { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public int? Order { get; set; }
        public IFormFile ImageThumbnail { get; set; }
        public IFormFile ImageLarge { get; set; }
    }
}
