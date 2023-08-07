using DocViewer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DocViewer;

namespace DocViewer.ViewModels
{
    class SettingsWindowViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string _txtBoxMatrixPath;

        public ICommand SaveSettingsCommand { get; set; }
        public ICommand MatrycaPathTxtCommand { get; set; }

        // constructor
        public SettingsWindowViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSetttings);
           // MatrycaPathTxtCommand = new RelayCommand(SaveSetttings);
        }


        // this is productId
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
