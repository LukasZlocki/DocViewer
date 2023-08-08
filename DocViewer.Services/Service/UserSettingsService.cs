using DocViewer.Models.Models;
using DocViewer.Services.Repository;

namespace DocViewer.Services.Service
{
    public class UserSettingsService : IUserSettingsService
    {
        private UserSettingsXmlDbRepository _dbReader = new UserSettingsXmlDbRepository();
        public UserSettings GetUserSettings()
        {
            var settings = _dbReader.ReadUserSettingsFromDatabase();
            return settings;
        }

        public void SaveUserSettings(UserSettings settings)
        {
            _dbReader.SaveUserSettingsToDatabase(settings);
        }
    }
}
