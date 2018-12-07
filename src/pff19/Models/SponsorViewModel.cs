using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using pff19.DataAccess.Models;

namespace pff19.Models
{
    public class SponsorViewModel
    {
        public int Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }

        public string Link { get; set; }

        public IFormFile UploadImage { get; set; }
    }
}
