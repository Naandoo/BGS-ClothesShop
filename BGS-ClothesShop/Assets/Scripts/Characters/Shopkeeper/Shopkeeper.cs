using Store;
using UnityEngine;

namespace Shopkeeper
{
    public class ShopkeeperInteraction : MonoBehaviour
    {
        [SerializeField] StoreEventHandler storeEventHandler;

        public void OpenStore() => storeEventHandler.InitializeStore();
    }
}
