using System;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemScriptable", menuName = "Item/ItemScriptable")]
    public class ItemScriptable : ScriptableObject
    {
        public Sprite Sprite;
        public int Price;
        public string StorekeeperQuote;
        public bool IsPurchased { get; private set; }
        [SerializeField] private string ID;

        public void Initialize()
        {
            IsPurchased = PlayerPrefs.GetString(ID) == ID;
            Debug.Log(ID + " " + IsPurchased);
        }

        public void Purchase()
        {
            PlayerPrefs.SetString(ID, ID);
            IsPurchased = true;
        }

        public void Sell()
        {
            PlayerPrefs.SetString(ID, string.Empty);
            IsPurchased = false;
        }

        private string GetSavedValue()
        {
            if (PlayerPrefs.HasKey(ID)) return PlayerPrefs.GetString(ID);
            else
            {
                PlayerPrefs.SetString(ID, string.Empty);
            }

            return PlayerPrefs.GetString(ID);
        }
    }

}
