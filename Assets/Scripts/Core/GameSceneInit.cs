using Generator;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameSceneInit : MonoBehaviour
    {
        private IItemsGenerator _itemsGenerator;

        [Inject]
        private void Construct(IItemsGenerator itemsGenerator)
        {
            _itemsGenerator = itemsGenerator;
        }

        private void Start()
        {
            _itemsGenerator.LoadCurrentItem();
        }
    }
}