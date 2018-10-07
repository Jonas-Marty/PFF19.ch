using System;

using Microsoft.AspNetCore.Http;

namespace pff19.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TitleDe { get; set; }
        public string TitleFr { get; set; }
        public string PreviewDe { get; set; }
        public string PreviewFr { get; set; }
        public string ContentDe { get; set; }
        public string ContentFr { get; set; }
        public IFormFile UploadImage { get; set; }
    }
}
