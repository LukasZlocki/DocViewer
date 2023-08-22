﻿using DocViewer.Helpers;
using DocViewer.Models.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DocViewer.ViewModels
{
    class SettingsWindowViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // settings of user paths for documents and matrix file
        UserPaths userPaths = new UserPaths();

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
            get { return userPaths.MatrixPath; }
            set
            {
                if (value != userPaths.MatrixPath)
                {
                    userPaths.MatrixPath = value;
                    OnPropertyChanged("txtBoxMatrixPath");
                }
            }
        }

        // this is path to documents
        public string txtBoxDocumentsPath
        {
            get { return userPaths.DocumentsPath; }
            set
            {
                if (value != userPaths.DocumentsPath)
                {
                    userPaths.DocumentsPath = value;
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
