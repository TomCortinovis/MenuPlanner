using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MenuPlanner.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public string SaveScreenshot(BitmapEncoder encoder)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "planning.png");

            _fileRepository.SaveScreenshot(encoder, path);

            return path;
        }
    }
}
