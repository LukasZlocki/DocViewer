using DocViewer.Models.Models;
using DocViewer.Services.Repository;

namespace DocViewer.Services.Service
{
    public class UserSettingsService : IUserSettingsService
    {
        private UserSettingsXmlDbRepository _dbReader = new UserSettingsXmlDbRepository();

        // READ
        public UserSettings GetAllUserSettings()
        {
            var settings = _dbReader.ReadUserSettingsFromDatabase();
            return settings;
        }

        // READ
        public UserSettings GetUserPaths()
        {
            throw new NotImplementedException();
        }

        // READ
        public UserSettings GetWindowPosition()
        {
            throw new NotImplementedException();
        }

        // UPDATE
        public void SaveUserSettings(UserSettings settings)
        {
            _dbReader.SaveAllUserSettingsToDatabase(settings);
        }

        // UPDATE
        public void UpdateUserPaths(UserSettings pathSettings)
        {
            throw new NotImplementedException();
        }

        // UPDATE
        public void UpdateWindowPosition(UserSettings positionSettings)
        {
            throw new NotImplementedException();
        }
    }
}
