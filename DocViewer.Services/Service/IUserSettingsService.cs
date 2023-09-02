using DocViewer.Models.Models;

namespace DocViewer.Services.Service
{
    public interface IUserSettingsService
    {
        // GET
        public UserSettings GetAllUserSettings();
        public UserPaths GetUserPaths();
        public string GetDocumentsPath();
        public WindowPosition GetWindowPosition();

        // UPDATE
        public void UpdateUserPaths(UserPaths pathSettings);
        public void UpdateWindowPosition(WindowPosition positionSettings);
        public void SaveAllUserSettings(UserSettings settings);
    }
}
