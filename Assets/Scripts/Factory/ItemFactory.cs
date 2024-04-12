using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Factory
{
    public class ItemFactory : IItemFactory
    {
        private const string SHOP_ITEMS_DATA_PATH = "Configs/ShopItemsData";
        private readonly DiContainer _diContainer;
        private readonly ShopItemsData _shopItemsData;

        [Inject]
        public ItemFactory (DiContainer diContainer)
        {
            _diContainer = diContainer;
            _shopItemsData = Resources.Load<ShopItemsData>(SHOP_ITEMS_DATA_PATH);
        }
        
        public GameObject SpawnItem(int itemIndex, Transform container)
        {
            return  _diContainer.InstantiatePrefab(_shopItemsData.Items[itemIndex], Vector3.zero, Quaternion.identity, container);
        }
    }
}