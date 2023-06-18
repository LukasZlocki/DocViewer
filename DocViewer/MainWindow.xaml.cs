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
            DataContext = new MainWindowViewModel();
        }

        private void btnLanguage_Click(object sender, RoutedEventArgs e)
        {
            // ToDo: Code changing of flag img
            if (btnLanguage.Content == FindResource("PL"))
            {
                btnLanguage.Content = FindResource("UA");
                //userLanguageSettings.SetToUkraineLanguage();
            }
            else
            {
                btnLanguage.Content = FindResource("PL");
        
                //userLanguageSettings.SetToPolishLanguage();
            }
        }
    }
}
