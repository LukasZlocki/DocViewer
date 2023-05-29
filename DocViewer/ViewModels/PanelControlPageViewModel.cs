using DocViewer.Helpers;
using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DocViewer.ViewModels
{
    class PanelControlPageViewModel : INotifyPropertyChanged
    {

        private DocumentService _documentService = new DocumentService();

        public event PropertyChangedEventHandler? PropertyChanged;

        public Documents Documents { get; set; } = new Documents();


        private int Page { get; set; } = 0;
        private int LimitPages { get; set; } = 0;
        private string _mainCounter;
        public string MainCounter
        {
            get { return _mainCounter; }
            set
            {
                if (value != _mainCounter)
                {
                    _mainCounter = value;
                    OnPropertyChanged("MainCounter");
                }
            }
        }

        public ICommand MoveDocumentsLeftCommand { get; set; }
        public ICommand MoveDocumentsRightCommand { get; set; }


        // constructor
        public PanelControlPageViewModel()
        {
            MoveDocumentsLeftCommand = new RelayCommand(MoveDocumentsLeft);
            MoveDocumentsRightCommand = new RelayCommand(MoveDocumentsRight);
            LoadingDataTest();
        }

        #region buttons methods
        private void MoveDocumentsLeft()
        {
            Page = Page - 1;
            if (Page <= 0) { Page = 0;  }
            RefreshCounter(Page, LimitPages);
        }

        private void MoveDocumentsRight()
        {
            Page = Page + 1;
            RefreshCounter(Page, LimitPages);

        }
        #endregion

        protected void OnPropertyChanged(string fieldName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }



        // For testing purpose
        public void LoadingDataTest()
        {
            // ToDo: retrive some example data from db in order to test service
            string productId = "150L0100";
            Documents = _documentService.GetDocumentsSetForProductId(productId);
            Page = 0;

            LimitPages = Documents.DocumentsList.Count;
        }

        private void RefreshCounter(int page, int limitPages)
        {
            MainCounter = "" + page + " / " + limitPages;
            OnPropertyChanged(nameof(MainCounter));
        }



    }
}
