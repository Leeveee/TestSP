namespace Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        void Save<T>(string key, T value);
        T Load<T>(string key, T defaultValue = default);
    }
}