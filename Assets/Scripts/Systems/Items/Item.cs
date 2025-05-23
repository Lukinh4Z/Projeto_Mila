using UnityEngine;

namespace ScriptableObjects
{
    public enum ItemRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        LEGENDARY
    }

    public enum Operation
    {
        ADD,
        ADD_PERCENTAGE,
    }

    [CreateAssetMenu(fileName = "NewItem", menuName = "Items/NewGenericItem")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public string itemDesc;
        public ItemRarity rarity;
        public Sprite icon;

        //public float ModifyStat(float statValue, float modifier, Operation operation) 
        //{
        //    float modifiedStat = statValue;

        //    switch (operation)
        //    {
        //        case Operation.ADD:
        //            modifiedStat = modifiedStat + modifier;
        //            return modifiedStat;

        //        case Operation.SUBTRACT:
        //            modifiedStat = modifiedStat - modifier;
        //            return modifiedStat;

        //        case Operation.MULTIPLY:
        //            modifiedStat = modifiedStat * modifier;
        //            return modifiedStat;

        //        case Operation.ADD_PERCENTAGE:
        //            modifiedStat = (1 + modifier/100f) * modifiedStat;
        //            return modifiedStat;

        //        case Operation.SUBTRACT_PERCENTAGE:
        //            modifiedStat = (1 - modifier/100f) * modifiedStat;
        //            return modifiedStat;

        //        case Operation.SET:
        //            modifiedStat = modifier;
        //            return modifiedStat;

        //        default:
        //            break;
        //    }

        //    return modifiedStat;
        //}

        //public int ModifyAtribute(int atrValue, int modifier, Operation operation)
        //{
        //    int modifiedAtr = atrValue;

        //    switch (operation)
        //    {
        //        case Operation.ADD:
        //            modifiedAtr = modifier + modifiedAtr;
        //            return modifiedAtr;

        //        case Operation.SUBTRACT:
        //            modifiedAtr = modifiedAtr - modifier;
        //            return modifiedAtr;

        //        case Operation.MULTIPLY:
        //            modifiedAtr = modifiedAtr * modifier;
        //            return modifiedAtr;

        //        case Operation.ADD_PERCENTAGE:
        //            modifiedAtr = (1 + modifier/100) * modifiedAtr;
        //            return modifiedAtr;

        //        case Operation.SUBTRACT_PERCENTAGE:
        //            modifiedAtr = (1 - modifier/100) * modifiedAtr;
        //            return modifiedAtr;

        //        case Operation.SET: 
        //            modifiedAtr = modifier;
        //            return modifiedAtr;

        //        default:
        //            break;
        //    }

        //    return modifiedAtr;
        //}
    }
}
