using DocViewer.Models.Models;
using DocViewer.Services.Service;

namespace DocViewer.ViewModels
{
    public class MainWindowViewModel
    {
        private IDocumentService _documentService = new DocumentService();

        public Documents Documents { get; set; }
        public int PresentPage { get; set; }
        public int MaxPage { get; set; }

        public MainWindowViewModel(string productId)
        {
            // Documents = _documentService.GetAllDocumentsByProductId(productId);
        }
    }
}