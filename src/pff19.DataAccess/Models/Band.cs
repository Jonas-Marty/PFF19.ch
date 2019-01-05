using System;
using System.ComponentModel.DataAnnotations;

namespace pff19.DataAccess.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string DescriptionDe { get; set; }
        public string DescriptionFr { get; set; }
        public string SpotifyPlaylist { get; set; }
        public DateTime? PlayTime { get; set; }
        public string ImageLarge { get; set; }
        public string ImageThumbnail { get; set; }
        public string YoutubeUrls { get; set; }
        public string WebSiteUrl { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public int Order { get; set; }
    }
}
