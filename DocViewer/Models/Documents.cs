using System.Collections.Generic;

namespace DocViewer.Models
{
    public class Documents
    {
        public string? ProductId { get; set; }
        public List<Document>? DocumentsList { get; set; }

        public Documents() {
           DocumentsList = new List<Document>();
        }
    }
}