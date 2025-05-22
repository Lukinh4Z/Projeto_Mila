using UnityEngine;

namespace ScriptableObjects
{
    public enum ItemType {
        WEAPON,
        ENGINE,
        HULL,
        SHIELD,
        COMPUTER
    }

    public enum ItemRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        LEGENDARY
    }

    [System.Serializable]
    public class ItemWeaponModifiers
    {
        public PlayerShooting.Modifiers modifier;
        public float modValue;
    }
    
    [System.Serializable]
    public class ItemEngineModifiers
    {
        public PlayerMovement.MovementModifiers modifier;
        public float modValue;
    }

    [CreateAssetMenu(fileName = "NewItem", menuName = "NewItem")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public string itemDesc;
        public ItemType type;
        public ItemRarity rarity;
        public ItemEngineModifiers[] engineModifiers;
        public ItemWeaponModifiers[] weaponModifiers;

    }

}
