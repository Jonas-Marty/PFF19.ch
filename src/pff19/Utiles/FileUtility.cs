
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
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

        public void SaveImageWithThumbnail(IFormFile sponsorUploadImage, string type, string filename, Size maxImageSize, Size maxThumbnailSize)
        {
            var basePath = Path.Combine(_environment.WebRootPath, "assets", type);
            var imagePath = Path.Combine(basePath, "images", filename);
            var thumbnailPath = Path.Combine(basePath, "thumbnail", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                sponsorUploadImage.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (Image<Rgba32> image = Image.Load(memoryStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Max, Size = maxImageSize }));
                    image.Save(imagePath); // Automatic encoder selected based on extension.
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                using (Image<Rgba32> image = Image.Load(memoryStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Max, Size = maxThumbnailSize }));
                    image.Save(thumbnailPath); // Automatic encoder selected based on extension.
                }
            }
        }

        public void SaveImage(IFormFile sponsorUploadImage, string type, string filename, Size maxSize)
        {
            var basePath = Path.Combine(_environment.WebRootPath, "assets", type);
            var imagePath = Path.Combine(basePath, "images", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                sponsorUploadImage.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (Image<Rgba32> image = Image.Load(memoryStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Max, Size = maxSize }));
                    image.Save(imagePath); // Automatic encoder selected based on extension.
                }
            }
        }
    }
}
