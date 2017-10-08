using System.Windows;

namespace MenuPlanner.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PopupControl.MouseLeftButtonDown += PopupControl_MouseLeftButtonDown;
        }

        private void PopupControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

    }
}
