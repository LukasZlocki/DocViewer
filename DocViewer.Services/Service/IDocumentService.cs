using DocViewer.Models.Models;

namespace DocViewer.Services.Service 
{
    public interface IDocumentService {
        public Documents GetDocumentsSetForProductId(string productId);
    }
}