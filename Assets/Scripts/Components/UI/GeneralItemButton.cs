using Generator;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Components.UI
{
    public class GeneralItemButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        
        private IItemsGenerator _itemsGenerator;

        [Inject]
        private void Construct(IItemsGenerator itemsGenerator)
        {
            _itemsGenerator = itemsGenerator;
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(SpawnItem);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(SpawnItem);
        }

        private void SpawnItem()
        {
            _itemsGenerator.CreateNewRandomItem();
        }
    }
}