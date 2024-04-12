using UnityEngine;

namespace Factory
{
    public interface IItemFactory
    {
       public GameObject SpawnItem (int itemIndex, Transform container);
    }
}