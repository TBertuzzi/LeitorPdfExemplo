using System;
using System.IO;
using System.Threading.Tasks;

namespace LeitorPdfExemplo.Helpers
{
    public interface ILocalFileProvider
    {
        Task<string> SaveFileToDisk(Stream stream, string fileName);
    }
}
