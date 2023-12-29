using DocViewer.Models.Models;
using DocViewer.ViewModels;
using System.Windows;

namespace DocViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WindowPosition thisWindowPosition = new WindowPosition();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
