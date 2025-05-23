using NUnit.Framework;
using System;
using Systems.Player;
using UnityEngine;

namespace ScriptableObjects
{
    public enum ShipItemType
    {
        Weapon,
        Engine,
        Hull,
        Shield,
        Computer
    }

    [Serializable]
    public class ShipStatModification
    {
        public ShipStatistic statType;
        public float statMod;
        public Operation operation;
    }
    
    //[Serializable]
    //public class ShipAtributeModification
    //{
    //    public ShipAtribute atributeType;
    //    public int atributeMod;
    //    public Operation operation;
    //}

    [CreateAssetMenu(fileName = "NewShipItem", menuName = "Items/NewShipItem")]
    internal class ShipItem : Item
    {
        public ShipItemType type;
        public ShipStatModification[] shipStatMods;
        //public ShipAtributeModification[] shipAtributeMods;
    }
}
