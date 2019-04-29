using System;
using System.IO;
using System.Threading.Tasks;
using LeitorPdfExemplo.Droid.Helpers;
using LeitorPdfExemplo.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileProvider))]
namespace LeitorPdfExemplo.Droid.Helpers
{
    public class LocalFileProvider : ILocalFileProvider
    {
       
        private readonly string _rootDir = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "pdfjs");

        public async Task<string> SaveFileToDisk(Stream pdfStream, string fileName)
        {
            if (!Directory.Exists(_rootDir))
                Directory.CreateDirectory(_rootDir);

            var filePath = Path.Combine(_rootDir, fileName);

            using (var memoryStream = new MemoryStream())
            {
                await pdfStream.CopyToAsync(memoryStream);
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }

            return filePath;
        }
    }
}
