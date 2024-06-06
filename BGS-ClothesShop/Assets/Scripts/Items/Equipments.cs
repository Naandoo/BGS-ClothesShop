using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "Equipments", menuName = "Item/Equipments")]
    public class Equipments : ScriptableObject
    {
        public DoubleSidedItemScriptable _bootArmor;
        public DoubleSidedItemScriptable _elbowArmor;
        public ItemScriptable _faceArmor;
        public ItemScriptable _hoodArmor;
        public ItemScriptable _pelvisArmor;
        public DoubleSidedItemScriptable _shoulderArmor;
        public ItemScriptable _torsoArmor;
        public DoubleSidedItemScriptable _wristArmor;
    }
}
