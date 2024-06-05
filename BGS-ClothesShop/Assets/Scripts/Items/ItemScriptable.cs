using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemScriptable", menuName = "Item/ItemScriptable")]
    public class ItemScriptable : ScriptableObject
    {
        public Sprite Sprite;
        public int Price;
        public string StorekeeperQuote;
        public bool IsPurchased;
    }
}
