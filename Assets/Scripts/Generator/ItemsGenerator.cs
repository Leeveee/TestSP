using Components;
using Data;
using Factory;
using ScriptableObjects;
using Services.SaveLoadService;
using UnityEngine;
using Zenject;

namespace Generator
{
    public class ItemsGenerator : IItemsGenerator
    {
        private const string CURRENT_ITEM_KEY = "CurrentItem";
        private const string ITEM_CONTAINER = "ITEM_CONTAINER";
        private const string SHOP_ITEMS_DATA_PATH = "Configs/ShopItemsData";
        private readonly GameData GameData = new GameData();
        private IItemFactory _itemFactory;
        private ShopItemsData _shopItemsData;
        private ISaveLoadService _saveLoadService;
        private IDestroyer _destroyer;
        private Transform _container;

        private Transform Container 
        { 
            get
            {
                if (_container == null)
                {
                    GameObject containerObject = new GameObject(ITEM_CONTAINER);
                    _container = containerObject.transform;
                }
                return _container;
            }
        }
        
        [Inject]
        public void Construct (IItemFactory itemFactory, ISaveLoadService saveLoadService,IDestroyer destroyer)
        {
            _itemFactory = itemFactory;
            _saveLoadService = saveLoadService;
            _destroyer = destroyer;
            _shopItemsData = Resources.Load<ShopItemsData>(SHOP_ITEMS_DATA_PATH);
        }
        
        public void CreateNewRandomItem()
        {
            ClearAllItems();

            var index = Random.Range(0, _shopItemsData.Items.Length);
            _itemFactory.SpawnItem(index, Container);
            GameData.CurrentShipItemIndex = index;
            _saveLoadService.Save(CURRENT_ITEM_KEY, GameData);
        }

        public void LoadCurrentItem()
        {
            ClearAllItems();

            var gameData = _saveLoadService.Load<GameData>(CURRENT_ITEM_KEY);
            if (gameData == null)
                return;
            
            _itemFactory.SpawnItem(gameData.CurrentShipItemIndex, Container);
        }

        private void ClearAllItems()
        {
            if (Container.childCount != 0)
            {
                for (int i = 0; i < Container.childCount; i++)
                {
                    _destroyer.DestroyObject(Container.GetChild(i).gameObject);
                }
            }
        }
    }
}