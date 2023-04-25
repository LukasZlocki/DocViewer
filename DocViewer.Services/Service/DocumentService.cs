using DocViewer.Models.Models;

namespace DocViewer.Services.Service
{
    public class DocumentService : IDocumentService
    {
        private DocumentsXmlDbRepository _dbReader = new DocumentsXmlDbRepository();

        public Documents GetDocumentsSetForProductId(string productId) {
            Documents documents = new Documents();
            documents = _dbReader.ReadDocumentsSetFromDatabaseByProductId(productId);
            return documents;
        }
    }
}