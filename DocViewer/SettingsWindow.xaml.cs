using DocViewer.ViewModels;
using System.Windows;

namespace DocViewer
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = new SettingsWindowViewModel();
        }
    }
}
