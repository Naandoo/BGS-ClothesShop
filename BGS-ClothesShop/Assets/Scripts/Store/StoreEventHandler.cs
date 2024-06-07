
using System.Collections;
using Item;
using ScriptableVariables;
using Shopkeeper;
using UnityEngine;
using UnityEngine.Events;

namespace Store
{
    public class StoreEventHandler : Singleton<StoreEventHandler>
    {
        [SerializeField] private RectTransform _onSaleContainer;
        [SerializeField] private RectTransform _onPurchaseBackContainer;
        [SerializeField] private IntVariable _coins;
        [SerializeField] private float _coinUpdateDuration;
        [SerializeField] private ShopkeeperQuotes _shopkeeperQuotes;
        [SerializeField] private Canvas _storeCanvas;
        [SerializeField] private Canvas _backgroundLayer;
        [SerializeField] private BoolVariable _popupOpen;
        [SerializeField] private UnityEvent _onStoreOpen;
        private WaitForSeconds _coinPerSeconds;
        private bool _storeOpen;
        public ContainerOpened OnSaleEvent = new();
        public ContainerOpened OnPurchaseBackEvent = new();

        public void InitializeStore()
        {
            if (_storeOpen) return;

            _onStoreOpen.Invoke();
            _storeOpen = true;
            _popupOpen.Value = true;
            OnSaleEvent.Invoke(_onSaleContainer);
            OnPurchaseBackEvent.Invoke(_onPurchaseBackContainer);
            _storeCanvas.enabled = true;
            _backgroundLayer.enabled = true;
        }

        public void CloseStore()
        {
            _storeOpen = false;
            _storeCanvas.enabled = false;
            _backgroundLayer.enabled = false;
            _popupOpen.Value = false;

        }

        public void OnItemInteraction(ItemObject item)
        {
            if (!_storeOpen) return;
            if (item.ItemScriptable.IsPurchased) Sell(item);
            else Buy(item);
        }

        public void Buy(ItemObject itemObject)
        {
            ItemScriptable itemScriptable = itemObject.ItemScriptable;

            if (_coins.Value < itemScriptable.Price) return;

            itemObject.transform.SetParent(_onPurchaseBackContainer);
            StartCoroutine(DecrementCoins(itemScriptable.Price));
            _shopkeeperQuotes.UpdateText(itemScriptable);
            itemScriptable.Purchase();
        }

        public void Sell(ItemObject itemObject)
        {
            if (itemObject.IsSelected) return;
            ItemScriptable itemScriptable = itemObject.ItemScriptable;

            itemObject.transform.SetParent(_onSaleContainer);
            StartCoroutine(IncreaseCoins(itemScriptable.Price));
            _shopkeeperQuotes.UpdateText(itemScriptable);
            itemScriptable.Sell();
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
