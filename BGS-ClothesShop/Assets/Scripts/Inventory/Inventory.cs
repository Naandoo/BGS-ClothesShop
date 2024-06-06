using UnityEngine;

namespace Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private RectTransform _inventoryContainer;
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private Canvas _backgroundLayer;
        private bool _inventoryOpen;
        public ContainerOpened OnInventoryOpenEvent = new();

        public void InitializeInventory()
        {
            _inventoryOpen = true;
            OnInventoryOpenEvent.Invoke(_inventoryContainer);
            _inventoryCanvas.enabled = true;
            _backgroundLayer.enabled = true;
        }

        public void CloseInventory()
        {
            _inventoryOpen = false;
            _inventoryCanvas.enabled = false;
            _backgroundLayer.enabled = false;
        }
    }
}