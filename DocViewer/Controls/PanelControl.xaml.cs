using DocViewer.ViewModels;
using System.Windows.Controls;

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


    }
}
