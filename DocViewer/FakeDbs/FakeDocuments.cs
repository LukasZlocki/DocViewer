using System.Collections.Generic;
using DocViewer.Models.Models;
using DocViewer.Services.Service;

namespace DocViewer.FakeDbs
{   
    public class FakeDocuments
    {
        private DocumentService _documentService = new DocumentService();

        private Documents documents = new Documents();

        public void TestSavingDb() {
            // creating fake db
            var db = FakeDocuments.CreateFakeDataToXmlDatabase();
            _documentService.SaveDocumentsListToDatabase(db);
        }

        public void TestReadingDb() {
            // reading from db
            string productId = "150L0100";
            documents = _documentService.GetDocumentsSetForProductId(productId); 
        }


        public static List<Documents> CreateFakeDataToXmlDatabase() {
            Documents doc1 = new Documents() {
                ProductId = "150L0099",
                DocumentsList = new List<Document>(){
                    new Document(){ DocumentName = "Document1" },
                    new Document(){ DocumentName = "Document2" },
                    new Document(){ DocumentName = "Document3" },
                    new Document(){ DocumentName = "Document4" },
                    new Document(){ DocumentName = "Document5" },
                },
            };
            Documents doc2 = new Documents() {
                ProductId = "150L0100",
                DocumentsList = new List<Document>(){
                    new Document(){ DocumentName = "Document7" },
                    new Document(){ DocumentName = "Document8" },
                    new Document(){ DocumentName = "Document9" },
                    new Document(){ DocumentName = "Document10" },
                    new Document(){ DocumentName = "Document11" },
                },
            };
            Documents doc3 = new Documents() {
                ProductId = "150L0101",
                DocumentsList = new List<Document>(){
                    new Document(){ DocumentName = "Document13" },
                    new Document(){ DocumentName = "Document23" },
                    new Document(){ DocumentName = "Document33" },
                    new Document(){ DocumentName = "Document43" },
                    new Document(){ DocumentName = "Document53" },
                },
            };

            List<Documents> _docsList = new List<Documents>();
            _docsList.Add(doc1);
            _docsList.Add(doc2);
            _docsList.Add(doc3);
            return _docsList;
        }
    }
}