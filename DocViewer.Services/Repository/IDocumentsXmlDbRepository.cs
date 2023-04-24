using DocViewer.Models.Models;

namespace DocViewer.Services.Repository
{
    public interface IDocumentsXmlDbRepository
    {
        // READ
         public Documents ReadDocumentsFromDatabaseByProductId(string ProductId);
    }
}