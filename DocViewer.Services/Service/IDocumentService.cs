using DocViewer.Models.Models;

namespace DocViewer.Services.Service 
{
    internal interface IDocumentService {
        public Documents GetAllDocumentsByProductId(string productId);
    }
}