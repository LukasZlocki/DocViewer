using DocViewer.Models.Models;

namespace DocViewer.Services.Service
{
    public interface IUserSettingsService
    {
        public UserSettings GetUserSettings();
        public void SaveUserSettings(UserSettings settings);
    }
}
