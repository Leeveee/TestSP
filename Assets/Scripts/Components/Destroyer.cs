using UnityEngine;

namespace Components
{
    public class Destroyer : MonoBehaviour, IDestroyer
    {
        public void DestroyObject (GameObject obj) => Destroy(obj);
    }
    public interface IDestroyer
    {
        public void DestroyObject (GameObject obj);
    }
}