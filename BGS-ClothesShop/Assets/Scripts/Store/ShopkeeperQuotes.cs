using UnityEngine;
using Item;
using TMPro;
using System.Collections;

namespace Shopkeeper
{
    public class ShopkeeperQuotes : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _timePerCharacter;
        [SerializeField] private string _onPlayerSold;
        private WaitForSeconds _secondsPerCharacter;
        private bool _isTalking;

        public void UpdateText(ItemScriptable itemScriptable)
        {
            if (!itemScriptable.IsPurchased) StartCoroutine(UpdateDialogText(itemScriptable.StorekeeperQuote));
            else StartCoroutine(UpdateDialogText(_onPlayerSold));

        }

        private IEnumerator UpdateDialogText(string text)
        {
            if (_isTalking) yield break;

            _isTalking = true;
            float secondsBetweenPhrases = 1.5f;
            _secondsPerCharacter = new(_timePerCharacter);

            for (int i = 0; i <= text.Length; i++)
            {
                _text.text = text.Substring(0, i);

                yield return _secondsPerCharacter;
            }

            yield return secondsBetweenPhrases;
            _isTalking = false;
        }
    }
}
