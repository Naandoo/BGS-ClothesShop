using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemScriptable", menuName = "Item/ItemScriptable")]
    public class ItemScriptable : ScriptableObject
    {
        [SerializeField] private string ID;
        public Sprite Sprite;
        public int Price;
        public string StorekeeperQuote;
        public bool IsPurchased { get; private set; }
        public ArmorType _armorType;

        public void Initialize()
        {
            IsPurchased = ID == GetSavedValue();
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

    public enum ArmorType
    {
        Boot,
        Elbow,
        Face,
        Hood,
        Pelvis,
        Shoulder,
        Torso,
        Wrist
    }
}
