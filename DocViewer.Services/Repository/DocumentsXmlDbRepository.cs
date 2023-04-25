using System.Xml.Serialization;
using DocViewer.Models.Models;
using DocViewer.Services.Repository;

namespace DocViewer.Services 
{
    public class DocumentsXmlDbRepository : IDocumentsXmlDbRepository
    {
        internal static string DB_FILE_NAME = "dbfile.xml";
        
        // READ
        public Documents ReadDocumentsSetFromDatabaseByProductId(string ProductId) {
            List<Documents> documentsList = new List<Documents>();
            Documents? documents = new Documents();
            // Loading database
            documentsList = LoadDatabase();
            // Extracting data refering proper ProductId           
            documents = documentsList.Where(id => id.ProductId == ProductId).FirstOrDefault();
            if (documents == null) {
                documents = new Documents();
            }
            documents.ProductId = ProductId;
            return documents;
        }
        
        #region Static methods
        /// <summary>
        /// Retriving list of all part numbers and its documents from xml database
        /// </summary>
        /// <returns>List<Documents></returns>
        private static List<Documents> LoadDatabase() {
            List<Documents> docsList = new List<Documents>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Documents>));
            try{
                TextReader tr = new StreamReader(DB_FILE_NAME);
                docsList = (List<Documents>)xmlSerializer.Deserialize(tr);
            }
            catch(Exception ex){
                Console.WriteLine("No data base found. Creating empty file with database. Error: " + ex);
            }
            if (docsList == null){
                docsList = new List<Documents>();
            }
            return docsList;
        }

        /// <summary>
        /// Save all products id and its list of documents to xml file
        /// </summary>
        /// <param name="documentsList"></param>
        private static void SaveDocumentsToDatabase(List<Documents> documentsList) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Documents>));
            TextWriter tw = new StreamWriter(DB_FILE_NAME);
            xmlSerializer.Serialize(tw, documentsList);
            tw.Close();
        }
        #endregion // Static methods
    }
}