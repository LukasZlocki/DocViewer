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
            productId = "150L0100";
            Documents = _documentService.GetDocumentsSetForProductId(productId); 
        }

    }
}