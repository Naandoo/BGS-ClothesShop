
using Shopkeeper;
using UnityEngine;

namespace Character
{
    public class CharacterInteraction : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.TryGetComponent(out ShopkeeperInteraction shopkeeper)
            && Input.GetKey(KeyCode.Space))
            {
                if (shopkeeper != null)
                {
                    shopkeeper.OpenStore();
                }
            }
        }
    }
}