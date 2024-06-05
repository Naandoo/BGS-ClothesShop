using UnityEngine;
using Item;
using TMPro;
using System.Collections;
using System.Text;

namespace Shopkeeper
{
    public class ShopkeeperQuotes : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _timePerCharacter;
        [SerializeField] private string _onPlayerSold;
        private WaitForSeconds _secondsPerCharacter;

        public void UpdateText(ItemScriptable itemScriptable)
        {
            if (!itemScriptable.IsPurchased) StartCoroutine(UpdateDialogText(itemScriptable.StorekeeperQuote));
            else StartCoroutine(UpdateDialogText(_onPlayerSold));
        }

        private IEnumerator UpdateDialogText(string text)
        {
            _secondsPerCharacter = new(_timePerCharacter);

            for (int i = 0; i <= text.Length; i++)
            {
                _text.text = text.Substring(0, i);

                yield return _secondsPerCharacter;
            }
        }
    }
}
