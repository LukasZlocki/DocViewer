using DocViewer.Models.Models;

namespace DocViewer.Services.Repository
{
    public interface IUserSettingsXmlDbRepository
    {
        public UserSettings ReadAllUserSettingsFromDatabase();
        public bool SaveAllUserSettingsToDatabase(UserSettings settings);
    }
}
