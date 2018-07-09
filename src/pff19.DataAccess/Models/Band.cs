using System;
using System.Collections.Generic;
using System.Text;

namespace pff19.DataAccess.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string ReferenceToScout { get; set; }
    }
}
