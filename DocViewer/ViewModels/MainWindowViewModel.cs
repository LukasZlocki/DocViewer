using DocViewer.Helpers;
using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
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
            RefreshCounter(this.Page, this.LimitPages);
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
            RefreshDocumentOnScreen(this.Page, this.Documents);
        }

        private void MoveDocumentsRight()
        {
            Page = Page + 1;
            if (Page >= LimitPages) { Page = LimitPages; }
            RefreshCounter(Page, LimitPages);
            RefreshDocumentOnScreen(this.Page, this.Documents);
        }
        #endregion

        protected void OnPropertyChanged(string fieldName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

        public void LoadingDocuments(string productId)
        {
            Documents = _documentService.GetDocumentsSetForProductId(productId);
            SetupPageLimits(Documents, this.Page, this.LimitPages);
            RefreshCounter(this.Page, this.LimitPages);
            // ToDo: BUG ! No strings with file name in documentsList ! 
            //ShowThisDocumentOnScreen(Documents.DocumentsList[Page].DocumentName);
            RefreshDocumentOnScreen(this.Page, this.Documents);
        }

        // Setting up page counters and page liniters basis on quantity of loaded documents
        private void SetupPageLimits(Documents documents, int page, int limitPages)
        {
            this.Page = 0;
            this.LimitPages = documents.DocumentsList.Count - 1;
        }

        // Refreshing main documents counter 
        private void RefreshCounter(int _page, int _limitPages)
        {
            this.Page = _page;
            this.LimitPages = _limitPages;
            MainCounter = "" + _page + " / " + _limitPages;
            OnPropertyChanged(nameof(MainCounter));
            OnPropertyChanged(nameof(txtBox));
        }

        private void RefreshDocumentOnScreen(int page, Documents documents)
        {
            // ToDo : Path settings need to be covered by user setup class
            string documentPath = "C:\\0 VirtualServer\\Documents\\";
            string documentExtension = ".jpg";
            string documentName = documents.DocumentsList[page].DocumentName;
            string fullPath = documentPath + documentName + documentExtension;
            ShowThisDocumentOnScreen(fullPath);
        }
        private void ShowThisDocumentOnScreen(string fullPath)
        {    
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