using Item;
using ScriptableVariables;
using UnityEngine;

namespace Store
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private RectTransform _storeContainer;
        [SerializeField] private RectTransform _inventoryContainer;
        [SerializeField] private BoolVariable _OpenPopup;
        private void Awake()
        {
            _OpenPopup.Value = false;
            MovePurchasedItems();
        }

        private void MovePurchasedItems()
        {
            int childCount = _storeContainer.childCount;

            while (childCount > 0)
            {
                ItemObject item = _storeContainer.GetChild(childCount - 1).GetComponent<ItemObject>();
                if (item.ItemScriptable.IsPurchased)
                {
                    item.transform.SetParent(_inventoryContainer);
                }
                else item.transform.SetParent(_storeContainer);

                childCount--;
            }
        }
    }
}