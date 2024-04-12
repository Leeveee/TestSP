using UnityEngine;

namespace Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        public void Save<T>(string key,T value)
        {
            string json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
        
        public T Load<T>(string key, T defaultValue = default)
        {
            if (!PlayerPrefs.HasKey(key))
                return defaultValue;

            string prefsData = PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(prefsData))
                return defaultValue;

            return JsonUtility.FromJson<T>(prefsData);
        }
    }
}