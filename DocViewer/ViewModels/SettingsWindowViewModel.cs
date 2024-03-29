﻿using DocViewer.Helpers;
using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DocViewer.ViewModels
{
    class SettingsWindowViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private UserSettingsService userSettingsService = new UserSettingsService();

        // settings of user paths for documents and matrix file
        UserPaths userPaths = new UserPaths();

        public ICommand SaveSettingsCommand { get; set; }
        public ICommand MatrycaPathTxtCommand { get; set; }

        // constructor
        public SettingsWindowViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSetttings);
            // MatrycaPathTxtCommand = new RelayCommand(SaveSetttings);
            userPaths = userSettingsService.GetUserPaths();
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
            // Add slash to path if needed
            userPaths.DocumentsPath = AddBackslashToPathIfNeeded(userPaths.DocumentsPath); 
            // Update user paths in database
            userSettingsService.UpdateUserPaths(userPaths);
            // Closing user settings window
            foreach (Window window in Application.Current.Windows)
            {
                if (window is SettingsWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        private string AddBackslashToPathIfNeeded(string path)
        {
            // check if path have backslash at the end of path 
            // if there is no backslash adding two backslash signs
            char lastCharacter = path[path.Length - 1];
            if (lastCharacter != '\\')
            {
                string _revisedPath = path + "\\";
                return _revisedPath;
            }
            else
            {
                return path;
            }
        }

        protected void OnPropertyChanged(string fieldName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

    }
}
