using DocViewer.Models.Models;

namespace DocViewer.Services.Repository
{
    public interface IUserSettingsXmlDbRepository
    {
        public UserSettings ReadUserSettingsFromDatabase();
        public bool SaveUserSettingsToDatabase(UserSettings settings);
    }
}
