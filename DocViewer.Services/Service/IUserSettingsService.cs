using DocViewer.Models.Models;

namespace DocViewer.Services.Service
{
    public interface IUserSettingsService
    {
        // GET
        public UserSettings GetAllUserSettings();
        public UserSettings GetUserPaths();
        public UserSettings GetWindowPosition();

        // UPDATE
        public void UpdateUserPaths(UserSettings pathSettings);
        public void UpdateWindowPosition(UserSettings positionSettings);
        public void SaveAllUserSettings(UserSettings settings);
    }
}
