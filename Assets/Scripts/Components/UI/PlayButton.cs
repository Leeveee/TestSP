using Services.SceneLoaderService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components.UI
{
    public class PlayButton : MonoBehaviour
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
            _button.onClick.AddListener(LoadGameScene);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(LoadGameScene);
        }
        
        private void LoadGameScene()
        {
            _sceneLoader.LoadScene(SceneLoader.GameScene);
        }
    }
}