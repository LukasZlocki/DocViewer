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
using DocViewer.ViewModels;

namespace DocViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //LoadingDataTest();
        }

        /*
        // For testing purpose
        public void LoadingDataTest() {
            // ToDo: retrive some example data from db in order to test service
            MainWindowViewModel MainVM = new MainWindowViewModel("150L0065");
        }
        */

    }
}
