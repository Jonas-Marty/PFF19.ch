using System;

namespace pff19.DataAccess.Models
{
    public class News
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateCreated { get; set; }
        public string TitleDe { get; set; }
        public string TitleFr { get; set; }
        public string PreviewDe { get; set; }
        public string PreviewFr { get; set; }
        public string ContentDe { get; set; }
        public string ContentFr { get; set; }
        public string Images { get; set; }
        public string LinkInstagram { get; set; }
        public string LinkFacebook { get; set; }
    }
}
