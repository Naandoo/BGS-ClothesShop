using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Item
{
    public class ItemGUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _coinValue;
        [SerializeField] private ItemScriptable _itemScriptable;

        private void OnEnable() => UpdateGUI();

        public void UpdateGUI()
        {
            _image.sprite = _itemScriptable.Sprite;
            _coinValue.text = _itemScriptable.Price.ToString();
        }

    }
}
