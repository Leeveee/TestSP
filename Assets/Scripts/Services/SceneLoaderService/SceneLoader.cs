using UnityEngine.SceneManagement;

namespace Services.SceneLoaderService
{
    public class SceneLoader : ISceneLoaderService
    {
        public const string CharacterSelectorScene = "CharacterSelector";
        public const string GameScene = "Game";
        
        public void LoadScene(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
        }
    }
}