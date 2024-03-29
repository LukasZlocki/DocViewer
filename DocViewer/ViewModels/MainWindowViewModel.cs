using DocViewer.Helpers;
using DocViewer.Models.Models;
using DocViewer.Services.Service;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace DocViewer.ViewModels
{

    class MainWindowViewModel : INotifyPropertyChanged
    {
        // Services
        private DocumentService _documentService = new DocumentService();
        private UserSettingsService _UserSettingsService = new UserSettingsService();

        public event PropertyChangedEventHandler? PropertyChanged;
        public Documents DocumentsBase;

        // Static Values
        private static string NO_DOCUMENTS = "BrakDokumentu";

        private int Page { get; set; } = 0;
        private int LimitPages { get; set; } = 0;

        private string _language = "PL";

        private string _imgSource;
        private string _txtBox;
        private Image _imgLanguage;

        // Position of main window.
        WindowPosition windowPosition = new();

        public ICommand MoveDocumentsLeftCommand { get; set; }
        public ICommand MoveDocumentsRightCommand { get; set; }
        public ICommand StartTxtCommand { get; set; }
        public ICommand LanguageChangeCommand { get; set; }

        public ICommand SettingsWindowRunCommand { get; set; }
        public ICommand PositionWindowFreezeCommand { get; set; }


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

        public Image ImgLanguage
        {
            get { return _imgLanguage; }
            set
            {
                if (value != _imgLanguage)
                {
                    _imgLanguage = value;
                    OnPropertyChanged("ImgLanguage");
                }
            }
        }

        // this is productId
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

        public string ImgSource
        {
            get { return _imgSource; }
            set
            {
                if (value != _imgSource)
                {
                    _imgSource = value;
                    OnPropertyChanged("ImgSource");
                }
            }
        }

        private string _imgSource2;
        public string ImgSource2
        {
            get { return _imgSource2; }
            set
            {
                if (value != _imgSource2)
                {
                    _imgSource2 = value;
                    OnPropertyChanged("ImgSource2");
                }
            }
        }

        public string Language
        {
            get { return _language; }
            set
            {
                if (value != _language)
                {
                    _language = value;
                    OnPropertyChanged("Language");
                }
            }
        }

        public double WindowPosX
        {
            get { return windowPosition.Xpos; }
            set
            {
                if (value != windowPosition.Xpos)
                {
                    windowPosition.Xpos = value;
                    OnPropertyChanged(nameof(WindowPosX));
                }
            }
        }

        public double WindowPosY
        {
            get { return windowPosition.Ypos; }
            set
            {
                if (value != windowPosition.Ypos)
                {
                    windowPosition.Ypos = value;
                    OnPropertyChanged(nameof(WindowPosY));
                }
            }
        }

        public double WindowHeight
        {
            get { return windowPosition.HeightWin; }
            set
            {
                if (value != windowPosition.HeightWin)
                {
                    windowPosition.HeightWin = value;
                    OnPropertyChanged(nameof(WindowHeight));
                }
            }
        }

        public double WindowWidth
        {
            get { return windowPosition.WidthWin; }
            set
            {
                if (value != windowPosition.WidthWin)
                {
                    windowPosition.WidthWin = value;
                    OnPropertyChanged(nameof(WindowWidth));
                }
            }
        }

        // constructor
        public MainWindowViewModel()
        {
            // Activate bindings
            MoveDocumentsLeftCommand = new RelayCommand(MoveDocumentsLeft);
            MoveDocumentsRightCommand = new RelayCommand(MoveDocumentsRight);
            LanguageChangeCommand = new RelayCommand(LanguageChange);
            StartTxtCommand = new RelayCommand(txtLoading);
            SettingsWindowRunCommand = new RelayCommand(SettingsWindowRun);
            PositionWindowFreezeCommand = new RelayCommand(PositionWindowFreeze);


            // Loading window position.
            windowPosition =  _UserSettingsService.GetWindowPosition();
            // if first run set up window width and height to default
            if (windowPosition.WidthWin == 0)
            {
                windowPosition.WidthWin = 500.00;
            }
            if (windowPosition.HeightWin == 0)
            {
                windowPosition.HeightWin = 600.00;
            }

            // Refreshing counter on UI
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
            RefreshDocumentOnScreen(this.Page, this.DocumentsBase, this.Language);
        }

        private void MoveDocumentsRight()
        {
            Page = Page + 1;
            if (Page >= LimitPages) { Page = LimitPages; }
            RefreshCounter(Page, LimitPages);
            RefreshDocumentOnScreen(this.Page, this.DocumentsBase, this.Language);
        }
        #endregion

        // ToDo: Solve problem of flags here
        private void LanguageChange()
        {
            string _fullPath = "";
            string _relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            if (Language == "PL")
            {
                Language = "UA";
            }
            else
            {
                Language = "PL";
            }
            OnPropertyChanged(nameof(Language));
            LoadingDocuments(txtBox);
        }


        protected void OnPropertyChanged(string fieldName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

        public void LoadingDocuments(string productId)
        {
            DocumentsBase = new Documents();
            DocumentsBase = _documentService.GetDocumentsSetForProductId(productId);
            if(DocumentsBase.DocumentsList.Count == 0) // no docs found
            {
                ShowAlertNoDocumentsFound(this.Language);
            }
            else
            {
                SetupPageLimits(DocumentsBase, this.Page, this.LimitPages);
                RefreshCounter(this.Page, this.LimitPages);
                // ToDo: BUG ! No strings with file name in documentsList ! 
                //ShowThisDocumentOnScreen(Documents.DocumentsList[Page].DocumentName);
                RefreshDocumentOnScreen(this.Page, this.DocumentsBase, this.Language);
            }
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

        private void RefreshDocumentOnScreen(int page, Documents documents, string language)
        {
            // ToDo : Include it to UsetSettings class - Path settings need to be covered by user setup class
            //string documentPath = "C:\\0 VirtualServer\\Documents\\";
            string documentPath = _UserSettingsService.GetDocumentsPath();
            string documentExtension = ".jpg";
            string documentName = documents.DocumentsList[page].DocumentName;
            
            // Add UA mark to document name if ukrainian language is choosen 
            if (language == "UA")
            {
                documentName = documentName + "_UA";
            }
            string fullPath = documentPath + documentName + documentExtension;
            ShowThisDocumentOnScreen(fullPath);
        }
        private void ShowThisDocumentOnScreen(string fullPath)
        {    
            ImgSource = fullPath;
            OnPropertyChanged(nameof(ImgSource));
        }

        private void ShowAlertNoDocumentsFound(string language)
        {
            Document noDoc = new();
            noDoc.DocumentName = NO_DOCUMENTS; // name of document showing no dosc found
            Documents noDocuments = new();
            noDocuments.DocumentsList.Add(noDoc); // no docs so name of document showing no docs is passed
            RefreshDocumentOnScreen(0, noDocuments, language);
        }

        private void SettingsWindowRun()
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        // Save window position to file.
        private void PositionWindowFreeze()
        {
            _UserSettingsService.UpdateWindowPosition(windowPosition);
        }
    }
}