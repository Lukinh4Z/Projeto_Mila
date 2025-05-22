using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Player
{
    public enum ShipStatistic
    {
        // --- DEFENSIVE STATS
        Hull,
        Shield,
        //Hit evasion chance
        Evasion,

        //Hit block chance (modified by shield)
        Block,

        //Repair of the hull per second
        HullRepairRate,

        //Recharge of the shield per second
        ShieldRechargeRate,

        //Reduction of DMG types taken
        EnergyDmgReduction,
        PhysicalDmgReduction,

        // -- OFFENSIVE STATS (Modify weapons)
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
        }

        public void Init()
        {
            statValues.Add(new ShipStatValue(ShipStatistic.Evasion, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.Block, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.HullRepairRate, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.ShieldRechargeRate, 10f));
            statValues.Add(new ShipStatValue(ShipStatistic.EnergyDmgReduction, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.PhysicalDmgReduction, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.EnergyPower, 10f));
            statValues.Add(new ShipStatValue(ShipStatistic.PhysicalPower, 10f));
        }
    }

    public enum ShipAtribute
    {
        //Determines maneuverability
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
        }

        public void Init()
        {
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Speed, 10));
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Hull, 100));
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Shield, 100));
            atributeValues.Add(new ShipAtributeValue(ShipAtribute.Computer, 100));
        }
    }

    public class Ship : MonoBehaviour
    {
        public ShipAtributeGroup shipAtributes;
        public ShipStatGroup shipStats;

        public void Start()
        {
            shipAtributes = new ShipAtributeGroup();
            shipAtributes.Init();

            shipStats = new ShipStatGroup();
            shipStats.Init();
        }
    }
}

