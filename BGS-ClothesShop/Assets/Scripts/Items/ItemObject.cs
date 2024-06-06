using Store;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Inventory;

namespace Item
{
    public class ItemObject : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _coinValue;
        public ItemScriptable ItemScriptable;

        private void Start()
        {
            ItemScriptable.Initialize();
            UpdateGUI();

            SubscribeInEvents();
        }

        private void OnDisable()
        {
            UnsubscribeInEvents();
        }

        private void SubscribeInEvents()
        {
            StoreEventHandler.Instance.OnStoreOpenEvent.AddListener((RectTransform rectTransform) =>
            {
                if (ItemScriptable.IsPurchased) SetParent(rectTransform);
            });

            InventoryManager.Instance.OnInventoryOpenEvent.AddListener((RectTransform rectTransform) =>
            {
                if (ItemScriptable.IsPurchased) SetParent(rectTransform);
            });
        }

        private void UnsubscribeInEvents()
        {
            StoreEventHandler.Instance.OnStoreOpenEvent.RemoveListener((RectTransform rectTransform) =>
            {
                if (ItemScriptable.IsPurchased) SetParent(rectTransform);
            });

            InventoryManager.Instance.OnInventoryOpenEvent.RemoveListener((RectTransform rectTransform) =>
            {
                if (ItemScriptable.IsPurchased) SetParent(rectTransform);
            });
        }

        public void UpdateGUI()
        {
            _image.sprite = ItemScriptable.Sprite;
            _coinValue.text = ItemScriptable.Price.ToString();
        }

        public void Interact()
        {
            StoreEventHandler.Instance.OnItemInteraction(this);
        }

        public void SetParent(RectTransform rectTransform) => this.transform.SetParent(rectTransform);
    }
}
