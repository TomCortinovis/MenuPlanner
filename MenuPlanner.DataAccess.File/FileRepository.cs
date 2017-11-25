using MenuPlanner.Services;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MenuPlanner.DataAccess.Files
{
    public class FileRepository : IFileRepository
    {
        public void SaveScreenshot(BitmapEncoder encoder, string path)
        {
            using (Stream file = File.Create(path))
            {
                encoder.Save(file);
            }
        }
    }
}
