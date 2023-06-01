using DocViewer.ViewModels;
using System.Windows;

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
            DataContext = new PanelControlPageViewModel();
        }
    }
}
