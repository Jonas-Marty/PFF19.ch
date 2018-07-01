using System;
using System.Collections.Generic;
using System.Text;

namespace pff.DataAccess.Models
{
    public class News
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
