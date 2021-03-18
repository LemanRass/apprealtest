using Game.User;
using UnityEngine;

namespace Game.Managers
{
    public static class UserManager
    {
        public static UserData data { get; private set; }

        public static void Init()
        {
            //Load all things related to User from file, server, etc...
        }

        public static string SerializeToJSON()
        {
            //Let it crush here if data is null
            return JsonUtility.ToJson(data);
        }

        public static void DeserializeFromJSON(string json)
        {
            //Let it crush here if json is not valid
            data = JsonUtility.FromJson<UserData>(json);
        }
    }
}