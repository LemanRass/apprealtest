using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Managers
{
    public class FileSaveMethod
    {
        private readonly string SAVES_DIRECTORY_PATH;
        private readonly string USER_DATA_PATH;

        FileSaveMethod()
        {
            SAVES_DIRECTORY_PATH = Path.Combine(Application.persistentDataPath, "Saves");
            USER_DATA_PATH = Path.Combine(SAVES_DIRECTORY_PATH, "UserData.json");
        }

        public async Task SaveUser()
        {
            //Create saves directory if not exists
            if(!Directory.Exists(SAVES_DIRECTORY_PATH))
            {
                Directory.CreateDirectory(SAVES_DIRECTORY_PATH);
            }

            //Get user data
            string userJSON = UserManager.SerializeToJSON();

            //Remove old saves if exists
            if(File.Exists(USER_DATA_PATH))
            {
                File.Delete(USER_DATA_PATH);
            }

            //Save user data to file
            using(var stream = File.OpenWrite(USER_DATA_PATH))
            {
                using(var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(userJSON);
                }
            }
        }

        public void RemoveSaves()
        {
            //Remove entire saves folder
            if(Directory.Exists(SAVES_DIRECTORY_PATH))
            {
                Directory.Delete(SAVES_DIRECTORY_PATH, true);
            }
        }
    }
}