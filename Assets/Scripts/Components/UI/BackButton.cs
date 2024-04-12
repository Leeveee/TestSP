using Services.SceneLoaderService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components.UI
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        
        private ISceneLoaderService _sceneLoader;

        [Inject]
        private void Construct (ISceneLoaderService sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(LoadCharacterSelectorScene);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(LoadCharacterSelectorScene);
        }

        private void LoadCharacterSelectorScene()
        {
            _sceneLoader.LoadScene(SceneLoader.CharacterSelectorScene);
        }
    }
}