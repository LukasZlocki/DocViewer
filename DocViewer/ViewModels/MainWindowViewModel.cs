using System.Collections.Generic;
using DocViewer.FakeDbs;
using DocViewer.Models.Models;
using DocViewer.Services.Service;

namespace DocViewer.ViewModels
{
    public class MainWindowViewModel
    {
        private DocumentService _documentService = new DocumentService();

        public Documents Documents { get; set; }
        public int PresentPage { get; set; }
        public int MaxPage { get; set; }

        public MainWindowViewModel(string productId)
        {   
            // creating fake db
            var db = FakeDocuments.CreateFakeDataToXmlDatabase();
            _documentService.SaveDocumentsListToDatabase(db);
            //productId = "150L0065";
            //Documents = _documentService.GetDocumentsSetForProductId(productId);
            
        }

    }
}