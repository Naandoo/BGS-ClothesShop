using Store;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Item
{
    public class ItemObject : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _coinValue;
        public ItemScriptable ItemScriptable;

        private void OnEnable() => UpdateGUI();

        public void UpdateGUI()
        {
            _image.sprite = ItemScriptable.Sprite;
            _coinValue.text = ItemScriptable.Price.ToString();
        }

        public void Interact()
        {
            StoreEventHandler.Instance.OnItemInteraction(this);
        }
    }
}
