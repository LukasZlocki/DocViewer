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
            var settings = _dbReader.ReadAllUserSettingsFromDatabase();
            return settings;
        }

        // READ
        public UserPaths GetUserPaths()
        {
            var settings = _dbReader.ReadAllUserSettingsFromDatabase();
            var paths = settings.UserPaths;
            return paths;
        }

        // READ
        public WindowPosition GetWindowPosition()
        {
            var settings = _dbReader.ReadAllUserSettingsFromDatabase();
            var position = settings.WindowPossition;
            return position;
        }

        // UPDATE
        public void SaveAllUserSettings(UserSettings settings)
        {
            _dbReader.SaveAllUserSettingsToDatabase(settings);
        }

        // UPDATE
        public void UpdateUserPaths(UserPaths pathSettings)
        {
            var settings = _dbReader.ReadAllUserSettingsFromDatabase();
            settings.UserPaths = pathSettings;
            _dbReader.SaveAllUserSettingsToDatabase(settings);
        }

        // UPDATE
        public void UpdateWindowPosition(WindowPosition positionSettings)
        {
            var settings = _dbReader.ReadAllUserSettingsFromDatabase();
            settings.WindowPossition = positionSettings;
            _dbReader.SaveAllUserSettingsToDatabase(settings);
        }
    }
}
