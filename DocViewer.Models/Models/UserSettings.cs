﻿namespace DocViewer.Models.Models
{
    public class UserSettings
    {
        public UserPaths? UserPaths { get; set; }
        public WindowPosition? WindowPossition { get; set; }

        public UserSettings()
        {
            UserPaths = new();
            WindowPossition = new();
        }
    }
}
