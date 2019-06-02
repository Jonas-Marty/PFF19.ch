using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace pff19.Models
{
    public class UploadedFileViewModel
    {
        public IFormFile File { get; set; }
    }
}
