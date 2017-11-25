using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MenuPlanner.Services
{
    public interface IFileRepository
    {
        void SaveScreenshot(BitmapEncoder encoder, string path);
    }
}
