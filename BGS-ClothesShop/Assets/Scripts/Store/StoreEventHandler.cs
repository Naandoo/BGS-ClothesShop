
using System.Collections;
using Item;
using ScriptableVariables;
using Shopkeeper;
using UnityEngine;

namespace Store
{
    public class StoreEventHandler : Singleton<StoreEventHandler>
    {
        [SerializeField] private Transform _shopContainer;
        [SerializeField] private Transform _inventoryContainer;
        [SerializeField] private IntVariable _coins;
        [SerializeField] private float _coinUpdateDuration;
        [SerializeField] private ShopkeeperQuotes _shopkeeperQuotes;
        private WaitForSeconds _coinPerSeconds;

        public void OnItemInteraction(ItemObject item)
        {
            if (item.ItemScriptable.IsPurchased) Sell(item);
            else Buy(item);
        }

        public void Buy(ItemObject itemObject)
        {
            ItemScriptable itemScriptable = itemObject.ItemScriptable;

            if (_coins.Value < itemScriptable.Price) return;

            itemObject.transform.SetParent(_inventoryContainer);
            StartCoroutine(DecrementCoins(itemScriptable.Price));
            _shopkeeperQuotes.UpdateText(itemScriptable);
            itemScriptable.IsPurchased = true;
        }

        public void Sell(ItemObject itemObject)
        {
            ItemScriptable itemScriptable = itemObject.ItemScriptable;

            itemObject.transform.SetParent(_shopContainer);
            StartCoroutine(IncreaseCoins(itemScriptable.Price));
            _shopkeeperQuotes.UpdateText(itemScriptable);
            itemScriptable.IsPurchased = false;
        }

        private IEnumerator IncreaseCoins(int value)
        {
            for (int i = 0; i < value; i++)
            {
                _coins.Value++;
                yield return _coinPerSeconds;
            }
        }

        private IEnumerator DecrementCoins(int value)
        {
            for (int i = value; i > 0; i--)
            {
                _coins.Value--;
                yield return _coinPerSeconds;
            }
        }
    }
}
