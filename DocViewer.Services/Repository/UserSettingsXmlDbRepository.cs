using DocViewer.Models.Models;
using System.Xml.Serialization;

namespace DocViewer.Services.Repository
{
    public class UserSettingsXmlDbRepository : IUserSettingsXmlDbRepository
    {
        internal static string DB_SETTINGS_FILE_NAME = "dbsettings.xml";

        // READ
        /// <summary>
        /// Read user settings to UserSettings class object
        /// </summary>
        /// <returns>UserSettings</returns>
        public UserSettings ReadAllUserSettingsFromDatabase()
        {
            UserSettings settings = new UserSettings();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSettings));
            try
            {
                using (TextReader tr = new StreamReader(DB_SETTINGS_FILE_NAME))
                {
                    settings = (UserSettings)xmlSerializer.Deserialize(tr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No data base found. Creating empty file with database. Error: " + ex);
                UserPaths userPaths = new();
                userPaths.MatrixPath = "Paste matrix path here...";
                userPaths.DocumentsPath = "Paste documents path here...";
                WindowPosition winPosition = new();
                winPosition.Xpos = 0.0;
                winPosition.Ypos = 0.0;

                settings = new(userPaths, winPosition);
                return settings;
            }
            if (settings == null)
            {
                Console.WriteLine("No data in database. Creating default data");
                UserPaths userPaths = new();
                userPaths.MatrixPath = "Paste matrix path here...";
                userPaths.DocumentsPath = "Paste documents path here...";
                WindowPosition winPosition = new();
                winPosition.Xpos = 0.0;
                winPosition.Ypos = 0.0;

                settings = new(userPaths, winPosition);
                return settings;
            }
            return settings;
        }

        // UPDATE
        /// <summary>
        /// Save user settings class to xml file
        /// </summary>
        /// <param name="settings"></param>
        /// <returns>bool</returns>
        public bool SaveAllUserSettingsToDatabase(UserSettings settings)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSettings));
                using (TextWriter tw = new StreamWriter(DB_SETTINGS_FILE_NAME))
                {
                    xmlSerializer.Serialize(tw, settings);
                }
                return true;
            }
            catch (Exception ex)
            {
                 Console.WriteLine("Error: " + ex);
                return false;
            }
        }
    }
}
