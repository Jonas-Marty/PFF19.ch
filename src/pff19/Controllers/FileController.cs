using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;
using pff19.Models;
using pff19.Utiles;

namespace pff19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ApiControllerBase
    {
        private readonly FileUtility _fileUtility;

        public FileController(FileUtility fileUtility)
        {
            _fileUtility = fileUtility;
        }

        // GET: api/file
        [HttpGet, Authorize]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IActionResult Get()
        {
            return Ok(_fileUtility.GetFiles());
        }

        // POST: api/file
        [HttpPost, Authorize]
        public IActionResult Post([FromForm] UploadedFileViewModel uploadedFile)
        {
            var uploadPath = _fileUtility.SaveFile(uploadedFile.File.OpenReadStream(), uploadedFile.File.FileName);
            return Ok("/" + uploadPath.Replace("\\", "/"));
        }

        // POST: api/file/inline
        [HttpPost("{subPath}"), Authorize]
        public IActionResult PostInline(string subPath, [FromForm] UploadedFileViewModel uploadedFile)
        {
            var uploadPath = _fileUtility.SaveFile(uploadedFile.File.OpenReadStream(), subPath, uploadedFile.File.FileName);
            return Ok("/" + uploadPath.Replace("\\", "/"));
        }

        // DELETE: api/file/<name>
        [HttpDelete("{name}"), Authorize]
        public IActionResult Delete(string name)
        {
            _fileUtility.DeleteFile(name);

            return NoContent();
        }
    }
}
