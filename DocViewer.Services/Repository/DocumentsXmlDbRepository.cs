using System.Xml.Serialization;
using DocViewer.Models.Models;
using DocViewer.Services.Repository;

namespace DocViewer.Services 
{
    public class DocumentsXmlDbRepository : IDocumentsXmlDbRepository
    {

        
        // READ
        public Documents ReadDocumentsFromDatabaseByProductId(string ProductId) {
            List<Documents> documentsList = new List<Documents>();
            Documents? documents = new Documents();
            // Loading database
            documentsList = DocumentsDbXmlEngine.LoadDatabase();
            // Extracting data refering proper ProductId           
            documents = documentsList.Where(id => id.ProductId == ProductId).FirstOrDefault();
            if (documents == null) {
                documents = new Documents();
            }
            return documents;
        }
        


    }
}