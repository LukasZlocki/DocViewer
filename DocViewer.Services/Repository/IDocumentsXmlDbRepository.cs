using DocViewer.Models.Models;

namespace DocViewer.Services.Repository
{
    public interface IDocumentsXmlDbRepository
    {
        // READ
         public Documents ReadDocumentsSetFromDatabaseByProductId(string ProductId);
         public void SaveDocumentsListToDatabase(List<Documents> docsList);
    }
}