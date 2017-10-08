using System;
using System.Collections.Generic;
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

namespace MenuPlanner.Modules
{
    /// <summary>
    /// Logique d'interaction pour ModuleContent.xaml
    /// </summary>
    public partial class ModuleControl : UserControl
    {
        public static readonly DependencyProperty ModuleProperty =
            DependencyProperty.Register("Module", typeof(IModule), typeof(ModuleControl), new PropertyMetadata(default(IModule)));

        public IModule Module
        {
            get { return (IModule)GetValue(ModuleProperty); }
            set { SetValue(ModuleProperty, value); }
        }

        public ModuleControl()
        {
            InitializeComponent();
        }
    }
}
