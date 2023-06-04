using DocViewer.Helpers;
using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System.ComponentModel;
using System.Windows.Input;

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

        private string _mainCounter2;
        public string MainCounter2
        {
            get { return _mainCounter2; }
            set
            {
                if (value != _mainCounter2)
                {
                    _mainCounter2 = value;
                    OnPropertyChanged("MainCounter2");
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

        public void SearchDocumentsByProductId(string productId)
        {
            // to do code here
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
        }

        // Refreshing main documents counter 
        private void RefreshCounter(int page, int limitPages)
        {
            MainCounter = "" + page + " / " + limitPages;
            MainCounter2 = MainCounter;
            OnPropertyChanged(nameof(MainCounter));
            OnPropertyChanged(nameof(MainCounter2));
            OnPropertyChanged(nameof(txtBox));
        }
    }
}