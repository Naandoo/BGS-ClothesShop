using UnityEngine;
using Item;
using Character;

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

        public void OnItemInteraction(ItemObject item)
        {
            if (!_inventoryOpen) return;

            UpdateEquipment(item.ItemScriptable);
        }

        private void UpdateEquipment(ItemScriptable itemScriptable)
        {
            switch (itemScriptable._armorType)
            {
                case ArmorType.Boot:
                    _playerEquipments._bootArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetBoots();
                    _playerVisual.SetBoots();
                    break;
                case ArmorType.Elbow:
                    _playerEquipments._elbowArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetElbows();
                    _playerVisual.SetElbows();
                    break;
                case ArmorType.Face:
                    _playerEquipments._faceArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetFace();
                    _playerVisual.SetFace();
                    break;
                case ArmorType.Hood:
                    _playerEquipments._hoodArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetHood();
                    _playerVisual.SetHood();
                    break;
                case ArmorType.Pelvis:
                    _playerEquipments._pelvisArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetPelvis();
                    _playerVisual.SetPelvis();
                    break;
                case ArmorType.Shoulder:
                    _playerEquipments._shoulderArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetShoulder();
                    _playerVisual.SetShoulder();
                    break;
                case ArmorType.Torso:
                    _playerEquipments._torsoArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetTorso();
                    _playerVisual.SetTorso();
                    break;
                case ArmorType.Wrist:
                    _playerEquipments._wristArmor.Sprite = itemScriptable.Sprite;
                    _dummyVisual.SetWrist();
                    _playerVisual.SetWrist();
                    break;
            }
        }
    }
}