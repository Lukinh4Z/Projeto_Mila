using UnityEngine;

namespace ScriptableObjects
{
    public enum CharItemType
    {
        Implant
    }

    [CreateAssetMenu(fileName = "NewCharItem", menuName = "Items/NewCharItem")]
    public class CharItem : Item
    {
        public CharItemType type;
    }
}