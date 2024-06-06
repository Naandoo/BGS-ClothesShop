using Item;
using UnityEngine;

namespace Store
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _storeContainer;
        [SerializeField] private RectTransform _inventoryContainer;

        private void Awake()
        {
            int childCount = _storeContainer.childCount;

            for (int i = 0; i < childCount; i++)
            {
                ItemObject item = _storeContainer.GetChild(i).GetComponent<ItemObject>();
                if (item.ItemScriptable.IsPurchased)
                {
                    item.transform.SetParent(_inventoryContainer);
                    i--;
                }
                else item.transform.SetParent(_storeContainer);
            }
        }
    }
}