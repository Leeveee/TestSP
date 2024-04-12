using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ShopItemsData", menuName = "Configs/ShopItemsData")]
    public class ShopItemsData : ScriptableObject
    {
        public GameObject[] Items;
    }
}
