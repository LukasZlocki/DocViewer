using DocViewer.ViewModels;
using System.Windows.Controls;
using DocViewer.ViewModels;
using System.Windows.Input;

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
        }

        // ToDo : bind it and remove this method 
        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
              // DataContext.SearchDoc(txtBoxID.Text);
            }
        }
    }
}
