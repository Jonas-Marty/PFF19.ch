using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace pff19.Models
{
    public class BarViewModel
    {
        public int Id { get; set; }
        public string NameDe { get; set; }
        public string NameFr { get; set; }
        public string DescriptionDe { get; set; }
        public string DescriptionFr { get; set; }
        public int? Order { get; set; }
        public IFormFile ImageThumbnail { get; set; }
        public IFormFile ImageLarge { get; set; }
        public IFormFile ImageMobile { get; set; }
    }
}
