namespace DocViewer.Models.Models
{
    public class UserSettings
    {
        // todo: add separate classes for this model as soon as more settings are needed (ex paths to documents, screen possitions, ...)
        public string? DocumentsPath { get; set; }
        public string? MatrixPath { get; set; }

        public WindowPosition WindowPossition { get; set; }
    }
}
