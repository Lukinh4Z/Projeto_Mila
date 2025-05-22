using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Player
{
    public enum ShipStatistic
    {
        Evasion,
        Block,
        HullRepair,
        ShieldRecharge,
        EnergyDmgReduction,
        PhysicalDmgReduction,
        EnergyPower,
        PhysicalPower
    }

    [Serializable]
    public class ShipStatValue
    {
        public ShipStatistic statType;
        public float statValue;

        public ShipStatValue(ShipStatistic statType, float statValue = 0)
        {
            this.statType = statType;
            this.statValue = statValue;
        }
    }

    [Serializable]
    public class ShipStatGroup
    {
        public List<ShipStatValue> statValues;

        public ShipStatGroup()
        {
            statValues = new List<ShipStatValue>();
            statValues.Add(new ShipStatValue(ShipStatistic.Evasion));
            statValues.Add(new ShipStatValue(ShipStatistic.Block));
            statValues.Add(new ShipStatValue(ShipStatistic.HullRepair));
            statValues.Add(new ShipStatValue(ShipStatistic.ShieldRecharge));
            statValues.Add(new ShipStatValue(ShipStatistic.EnergyDmgReduction));
            statValues.Add(new ShipStatValue(ShipStatistic.PhysicalDmgReduction));
            statValues.Add(new ShipStatValue(ShipStatistic.EnergyPower));
            statValues.Add(new ShipStatValue(ShipStatistic.PhysicalPower));
        }
    }

    public enum ShipAtribute
    {
        //Determines maneuver
        Speed,
        //Determines real "life"
        Hull,
        //Determines shield
        Shield,
        //Determines ship power
        Computer
    }

    [Serializable]
    public class ShipAtributeValue
    {
        public ShipAtribute atributeType;
        public int atributeValue;

        public ShipAtributeValue(ShipAtribute atributeType, int atributeValue = 0)
        {
            this.atributeType = atributeType;
            this.atributeValue = atributeValue;
        }
    }

    [Serializable]
    public class ShipAtributeGroup
    {
        public List<ShipAtributeValue> atributeValues;

        public ShipAtributeGroup()
        {
            atributeValues = new List<ShipAtributeValue>();
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Speed));
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Hull));
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Shield));
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Computer));
        }
    }


    public class Ship : MonoBehaviour
    {
        [SerializeField] ShipAtributeGroup shipAtributes;
        [SerializeField] ShipStatGroup shipStats;

        public void Start()
        {
            shipAtributes = new ShipAtributeGroup();
            shipStats = new ShipStatGroup();
        }
    }

}

