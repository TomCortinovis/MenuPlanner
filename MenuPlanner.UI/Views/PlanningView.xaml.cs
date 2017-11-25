using MenuPlanner.UI.ViewModel;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MenuPlanner.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour PlanningView.xaml
    /// </summary>
    public partial class PlanningView : UserControl
    {
        public PlanningViewModel ViewModel
        {
            get { return DataContext as PlanningViewModel; }
        }

        public PlanningView()
        {
            InitializeComponent();

            Loaded += (_, __) => ViewModel.ScreenshotRequested += ViewModel_ScreenshotRequested;
            Unloaded += (_, __) =>
            {
                if (ViewModel != null)
                {
                    ViewModel.ScreenshotRequested -= ViewModel_ScreenshotRequested;
                }
            };
        }

        private void ViewModel_ScreenshotRequested(object sender, System.EventArgs e)
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)Schedule.ActualWidth, (int)Schedule.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(Schedule);

            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            ViewModel.SaveScreenshot(encoder);
        }
        
    }
}
