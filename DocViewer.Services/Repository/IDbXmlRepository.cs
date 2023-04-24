using DocViewer.Models.Models;

namespace DocViewer.Services.Repository
{
    public interface IDbXmlRepository
    {
        // READ
         public Documents ReadDocumentsFromDatabaseByProductId(string ProductId);
    }
}