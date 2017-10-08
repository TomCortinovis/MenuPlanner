using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;

namespace MenuPlanner.UI.Views.Popups
{
    /// <summary>
    /// Logique d'interaction pour PrintingView.xaml
    /// </summary>
    public partial class PrintingView : UserControl
    {
        public PrintingView()
        {
            InitializeComponent();
            this.Loaded += PrintingView_Loaded;
        }

        private void PrintingView_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("printPreview.xps"))
            {
                File.Delete("printPreview.xps");
            }
            var xpsDocument = new XpsDocument("printPreview.xps", FileAccess.ReadWrite);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.Write(((IDocumentPaginatorSource)Document).DocumentPaginator);
            var fixedDocument = xpsDocument.GetFixedDocumentSequence();
            xpsDocument.Close();

            Viewer.Document = fixedDocument;
        }
    }
}
