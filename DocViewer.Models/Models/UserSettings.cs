namespace DocViewer.Models.Models
{
    public class UserSettings
    {
        public UserPaths? UserPaths { get; set; }
        public WindowPosition? WindowPosition { get; set; }

        public UserSettings()
        {
            UserPaths = new();
            WindowPosition = new();
        }

        public UserSettings(UserPaths userPaths, WindowPosition windowPosition)
        {
            UserPaths = userPaths;
            WindowPosition = windowPosition;
        }

    }
}
