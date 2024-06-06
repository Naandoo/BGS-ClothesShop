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
        [SerializeField] private Image _selectedFrame;
        public ItemScriptable ItemScriptable;
        public bool isSelected;
        string selectedArmorKey;

        private void Start()
        {
            selectedArmorKey = ItemScriptable.ID + " Selected";

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

            InventoryManager.Instance.OnEquipmentChangeEvent.AddListener((ItemObject item) => ToggleSelectItem(item));
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

            InventoryManager.Instance.OnEquipmentChangeEvent.RemoveListener((ItemObject item) => ToggleSelectItem(item));

        }

        public void UpdateGUI()
        {
            _image.sprite = ItemScriptable.Sprite;
            _coinValue.text = ItemScriptable.Price.ToString();

            ToggleSelectState(PlayerPrefs.GetString(selectedArmorKey) == "true");
        }

        public void Interact()
        {
            StoreEventHandler.Instance.OnItemInteraction(this);
            InventoryManager.Instance.OnItemInteraction(this);
        }

        public void ToggleSelectItem(ItemObject item)
        {
            bool sameID = this.ItemScriptable.ID == item.ItemScriptable.ID;

            if (sameID)
            {
                PlayerPrefs.SetString(selectedArmorKey, "true");
                ToggleSelectState(true);
            }
            else if (item.ItemScriptable._armorType == ItemScriptable._armorType && !sameID)
            {
                PlayerPrefs.SetString(selectedArmorKey, "false");
                ToggleSelectState(false);
            }
        }

        private void ToggleSelectState(bool value)
        {
            isSelected = value;
            _selectedFrame.enabled = value;
        }
        public void SetParent(RectTransform rectTransform) => this.transform.SetParent(rectTransform);
    }
}
