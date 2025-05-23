using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Player
{
    public enum ShipStatistic
    {
        // --- MAIN STATS
        Hull,
        Shield,
        Computer,
        Speed,
        
        // --- DEFENSIVE STATS
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
        PhysicalPower,
        WeaponCooldown,
    }

    [Serializable]
    public class ShipStatValue
    {
        public ShipStatistic statType;
        public float statValue;
        public float statModBase;
        public float statModPercent;

        public ShipStatValue(ShipStatistic statType, float statValue = 0)
        {
            this.statType = statType;
            this.statValue = (statValue + statModBase) * (1 + statModPercent/100f);
        }

        public void ModifyStatModBase(float statModBase) 
        {
            this.statModBase += statModBase;
            CalculateStat();

        }

        public void ModifyStatModPercent(float statModPercent)
        {
            this.statModPercent += statModPercent;
            CalculateStat();
        }

        public void CalculateStat()
        {
            statValue = (statValue + statModBase) * (1 + statModPercent / 100f);
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

        public void Init(float hull = 100f, float shield = 0.0f)
        {
            statValues.Add(new ShipStatValue(ShipStatistic.Hull, hull));
            statValues.Add(new ShipStatValue(ShipStatistic.Shield, shield));
            statValues.Add(new ShipStatValue(ShipStatistic.Computer, 100));
            statValues.Add(new ShipStatValue(ShipStatistic.Speed, 50));
            statValues.Add(new ShipStatValue(ShipStatistic.Evasion, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.Block, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.HullRepairRate, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.ShieldRechargeRate, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.EnergyDmgReduction, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.PhysicalDmgReduction, 0f));
            statValues.Add(new ShipStatValue(ShipStatistic.EnergyPower, 50f));
            statValues.Add(new ShipStatValue(ShipStatistic.PhysicalPower, 50f));
            statValues.Add(new ShipStatValue(ShipStatistic.WeaponCooldown, 50f));
        }
    }

    public class Ship : MonoBehaviour
    {
        [SerializeField] ShipStatGroup shipStats;

        public Ship()
        {
            shipStats = new ShipStatGroup();
            shipStats.Init();
        }

        void Awake()
        {
            if (shipStats == null || shipStats.statValues.Count == 0)
            {
                Debug.Log("create ship" + gameObject.name);
                shipStats = new ShipStatGroup();
                shipStats.Init();
            }
        }

        public ShipStatValue GetStat(ShipStatistic stat)
        {
            ShipStatValue shipStat = shipStats.statValues.Find(s => s.statType == stat);

            return shipStat;
        }

        public ShipStatValue SetStat(ShipStatistic stat, float value)
        {
            ShipStatValue shipStat = shipStats.statValues.Find(s => s.statType == stat);
            shipStat.statValue = value;

            return shipStat;
        }
    }
}

