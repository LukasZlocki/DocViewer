using DocViewer.ViewModels;
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

namespace DocViewer.Controls
{
    /// <summary>
    /// Interaction logic for PanelControl.xaml
    /// </summary>
    public partial class PanelControl : UserControl
    {
        public PanelControl()
        {
            InitializeComponent();

            DataContext = new PanelControlPageViewModel();

            //LoadingDataTest();

        }

        /*
        // For testing purpose
        public void LoadingDataTest()
        {
            // ToDo: retrive some example data from db in order to test service
            MainWindowViewModel MainVM = new MainWindowViewModel("150L0065");
        }
        */


        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

        }
    }
}
