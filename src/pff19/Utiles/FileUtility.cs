
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Transforms;
using SixLabors.Primitives;

namespace pff19.Utiles
{
    public class FileUtility
    {
        private readonly IHostingEnvironment _environment;

        public FileUtility(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void SaveImage(IFormFile sponsorUploadImage, string type, string filename, Size thumbnailSize)
        {
            var basePath = Path.Combine(_environment.WebRootPath, "assets", type);
            var imagePath = Path.Combine(basePath, "images", filename);
            var thumbnailPath = Path.Combine(basePath, "thumbnail", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));

            using (MemoryStream memoryStream = new MemoryStream())
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                sponsorUploadImage.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
                
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (Image<Rgba32> image = Image.Load(memoryStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions() { Mode = ResizeMode.Max, Size = thumbnailSize}));
                    image.Save(thumbnailPath); // Automatic encoder selected based on extension.
                }
            }
        }
    }
}
