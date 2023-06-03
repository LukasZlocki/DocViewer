using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System.ComponentModel;

namespace DocViewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // ToDo : Testing if main view model can be used to

        private PanelControlPageViewModel _controlVm;

        // constructor
        public MainWindowViewModel()
        {

            
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}