using DocViewer.Helpers;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DocViewer.ViewModels
{
    class SettingsWindowViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string _txtBoxMatrixPath;
        public string _txtBoxDocumentsPath;

        public ICommand SaveSettingsCommand { get; set; }
        public ICommand MatrycaPathTxtCommand { get; set; }

        // constructor
        public SettingsWindowViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSetttings);
           // MatrycaPathTxtCommand = new RelayCommand(SaveSetttings);
        }


        // this is path to matrix
        public string txtBoxMatrixPath
        {
            get { return _txtBoxMatrixPath; }
            set
            {
                if (value != _txtBoxMatrixPath)
                {
                    _txtBoxMatrixPath = value;
                    OnPropertyChanged("txtBoxMatrixPath");
                }
            }
        }

        // this is path to documents
        public string txtBoxDocumentsPath
        {
            get { return _txtBoxDocumentsPath; }
            set
            {
                if (value != _txtBoxDocumentsPath)
                {
                    _txtBoxDocumentsPath = value;
                    OnPropertyChanged("txtBoxDocumentsPath");
                }
            }
        }

        private void SaveSetttings()
        {
            // ToDo: Write logic for saving matrix and document folder settings
            foreach (Window window in Application.Current.Windows)
            {
                if (window is SettingsWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        protected void OnPropertyChanged(string fieldName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

    }
}
