using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MenuPlanner.Services
{
    public interface IFileService
    {
        string SaveScreenshot(BitmapEncoder encoder);
    }
}
