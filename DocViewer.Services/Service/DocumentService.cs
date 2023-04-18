using DocViewer.Models.Models;

namespace DocViewer.Services.Service
{
    public class DocumentService : IDocumentService
    {
        public Documents GetAllDocumentsByProductId(string productId) {
            Document documents = new Document();
            // ToDo: Code retriving data from db here ! ReadDocumentsFromDatabaseByProductId(productId) 
            // documents = db.ReadDocumentsFromDatabaseByProductId(productId);
            // return documents
            throw new NotImplementedException();
        }
    }
}