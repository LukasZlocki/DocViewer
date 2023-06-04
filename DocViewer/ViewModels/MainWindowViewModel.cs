using DocViewer.Helpers;
using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DocViewer.ViewModels
{

    class MainWindowViewModel : INotifyPropertyChanged
    {
        private DocumentService _documentService = new DocumentService();
        public event PropertyChangedEventHandler? PropertyChanged;
        public Documents Documents { get; set; } = new Documents();

        private int Page { get; set; } = 0;
        private int LimitPages { get; set; } = 0;

        public ICommand MoveDocumentsLeftCommand { get; set; }
        public ICommand MoveDocumentsRightCommand { get; set; }
        public ICommand StartTxtCommand { get; set; }

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
        
        private string _txtBox;
        public string txtBox
        {
            get { return _txtBox; }
            set
            {
                if (value != _txtBox)
                {
                    _txtBox = value;
                    OnPropertyChanged("txtBox");
                }
            }
        }



        private string _imgSource;
        public string ImgSource
        {
            get { return _imgSource; }
            set
            {
                if (value != _imgSource)
                {
                    _imgSource = value;
                    OnPropertyChanged("imgSource");
                }
            }
        }


        // constructor
        public MainWindowViewModel()
        {
            MoveDocumentsLeftCommand = new RelayCommand(MoveDocumentsLeft);
            MoveDocumentsRightCommand = new RelayCommand(MoveDocumentsRight);
            StartTxtCommand = new RelayCommand(txtLoading);
            RefreshCounter(Page, LimitPages);
        }

        public void SearchDoc(string productId)
        {
            LoadingDocuments(productId);
        }

        public void txtLoading()
        {
            LoadingDocuments(txtBox);
        }


        #region buttons methods
        private void MoveDocumentsLeft()
        {
            Page = Page - 1;
            if (Page <= 0) { Page = 0; }
            RefreshCounter(Page, LimitPages);
        }

        private void MoveDocumentsRight()
        {
            Page = Page + 1;
            if (Page >= LimitPages) { Page = LimitPages; }
            RefreshCounter(Page, LimitPages);

        }
        #endregion

        protected void OnPropertyChanged(string fieldName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

        public void LoadingDocuments(string productId)
        {
            Documents = _documentService.GetDocumentsSetForProductId(productId);
            Page = 0;
            LimitPages = Documents.DocumentsList.Count + 1;
            RefreshCounter(Page, LimitPages);
            //ShowThisDocumentOnScreen(Documents.DocumentsList[Page].DocumentName);
            ShowThisDocumentOnScreen("Sm");
        }

        // Refreshing main documents counter 
        private void RefreshCounter(int _page, int _limitPages)
        {
            _page = _page + 1;
            MainCounter = "" + _page + " / " + _limitPages;
            OnPropertyChanged(nameof(MainCounter));
            OnPropertyChanged(nameof(txtBox));
        }

        private void ShowThisDocumentOnScreen(string documentName)
        {
            // ToDo : Path settings need to be covered by user setup class
            string documentPath = "C:\\0 VirtualServer\\Documents\\";
            string documentExtension = ".jpg";
            string fullPath = documentPath + documentName + documentExtension;

            ImgSource = fullPath;
            OnPropertyChanged(nameof(ImgSource));

            /*
            try
            {
                //ImageSource imagesource = new BitmapImage(new Uri(fullPath));
                //ImageShow.Source = imagesource;
            }
            catch
            {
                if (documentName == "")
                {
                   // ShowFailDocument("FALSE_NO_FILE_WITH_DOCUMENT", userSettings);
                }

            }
            */
        }

    }
}