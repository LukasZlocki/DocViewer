using System.Xml.Serialization;
using DocViewer.Models.Models;

namespace DocViewer.Services.Repository
{
    internal static class DbXmlEngine
    {
        internal static string DB_FILE_NAME = "dbfile.xml";

        /// <summary>
        /// Retriving list of documents from xml database
        /// </summary>
        /// <returns>List<Documents></returns>
        internal static List<Documents> LoadDatabase() {
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
        /// Save list of documents to xml file
        /// </summary>
        /// <param name="documentsList"></param>
        private static void SaveDatabase(List<Documents> documentsList) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Documents>));
            TextWriter tw = new StreamWriter(DB_FILE_NAME);
            xmlSerializer.Serialize(tw, documentsList);
            tw.Close();
        }
    }
}