﻿using System;

namespace pff19.DataAccess.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Link { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
