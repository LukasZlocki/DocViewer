using DocViewer.Models.Models;

namespace DocViewer.Services.Service 
{
    public interface IDocumentService {
        public Documents GetAllDocumentsByProductId(string productId);
    }
}