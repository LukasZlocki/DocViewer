using DocViewer.Models.Models;
using DocViewer.ViewModels;
using System.Windows;
using System.Windows.Input;

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


        // Moving This form by mouse    
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

            thisWindowPosition.Xpos = this.Left;
            thisWindowPosition.Ypos = this.Top;

            // update this window possition in database
            // ToDo: Code updating window ossition in file: _positionService.UpdateMainWindowPosition(thisWindowPosition);
        }



    }
}
