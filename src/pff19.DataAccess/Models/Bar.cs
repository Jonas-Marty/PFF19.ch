using System;
using System.Collections.Generic;
using System.Text;

namespace pff19.DataAccess.Models
{
    public class Bar
    {
        public int Id { get; set; }
        public string NameDe { get; set; }
        public string NameFr { get; set; }
        public string DescriptionDe { get; set; }
        public string DescriptionFr { get; set; }
        public int Order { get; set; }
        public string ImageThumbnail { get; set; }
        public string ImageLarge { get; set; }
        public string ImageMobile { get; set; }
    }
}
