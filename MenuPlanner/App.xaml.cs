using MenuPlanner.Utils.Helpers;
using MenuPlanner.Utils.Transverse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MenuPlanner
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }


    }
}
