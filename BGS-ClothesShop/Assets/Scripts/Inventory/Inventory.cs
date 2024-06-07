using UnityEngine;
using Item;
using Character;
using UnityEngine.Events;
using ScriptableVariables;

namespace Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private RectTransform _inventoryContainer;
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private Canvas _backgroundLayer;
        [SerializeField] private CharacterVisual _dummyVisual;
        [SerializeField] private CharacterVisual _playerVisual;
        [SerializeField] private Equipments _playerEquipments;
        [SerializeField] private BoolVariable _popupOpen;
        private bool _inventoryOpen;
        public ContainerOpened OnInventoryOpenEvent = new();
        public EquipmentChange OnEquipmentChangeEvent = new();

        public void InitializeInventory()
        {
            _inventoryOpen = true;
            _popupOpen.Value = true;
            _inventoryContainer.gameObject.SetActive(true);
            OnInventoryOpenEvent.Invoke(_inventoryContainer);
            _inventoryCanvas.enabled = true;
            _backgroundLayer.enabled = true;
        }

        public void CloseInventory()
        {
            _inventoryOpen = false;
            _inventoryCanvas.enabled = false;
            _backgroundLayer.enabled = false;
            _popupOpen.Value = false;
        }

        public void OnItemInteraction(ItemObject item)
        {
            if (!_inventoryOpen) return;

            UpdateEquipment(item);
        }

        private void UpdateEquipment(ItemObject item)
        {
            ItemScriptable itemScriptable = item.ItemScriptable;
            switch (itemScriptable._armorType)
            {
                case ArmorType.Boot:
                    _playerEquipments._bootArmor = (DoubleSidedItemScriptable)itemScriptable;
                    _dummyVisual.SetBoots();
                    _playerVisual.SetBoots();
                    break;
                case ArmorType.Elbow:
                    _playerEquipments._elbowArmor = (DoubleSidedItemScriptable)itemScriptable;
                    _dummyVisual.SetElbows();
                    _playerVisual.SetElbows();
                    break;
                case ArmorType.Face:
                    _playerEquipments._faceArmor = itemScriptable;
                    _dummyVisual.SetFace();
                    _playerVisual.SetFace();
                    break;
                case ArmorType.Hood:
                    _playerEquipments._hoodArmor = itemScriptable;
                    _dummyVisual.SetHood();
                    _playerVisual.SetHood();
                    break;
                case ArmorType.Pelvis:
                    _playerEquipments._pelvisArmor = itemScriptable;
                    _dummyVisual.SetPelvis();
                    _playerVisual.SetPelvis();
                    break;
                case ArmorType.Shoulder:
                    _playerEquipments._shoulderArmor = (DoubleSidedItemScriptable)itemScriptable;
                    _dummyVisual.SetShoulder();
                    _playerVisual.SetShoulder();
                    break;
                case ArmorType.Torso:
                    _playerEquipments._torsoArmor = itemScriptable;
                    _dummyVisual.SetTorso();
                    _playerVisual.SetTorso();
                    break;
                case ArmorType.Wrist:
                    _playerEquipments._wristArmor = (DoubleSidedItemScriptable)itemScriptable;
                    _dummyVisual.SetWrist();
                    _playerVisual.SetWrist();
                    break;
            }

            OnEquipmentChangeEvent.Invoke(item);
        }
    }

    public class EquipmentChange : UnityEvent<ItemObject> { }
}