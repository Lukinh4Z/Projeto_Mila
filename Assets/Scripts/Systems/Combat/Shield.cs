using Systems.Combat;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class Shield : Damageable
    {
        public new float health = 0.0f;
        public Ship ship;
        public float rechargeRate;

        public Shield()
        {
            health = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.Shield).statValue;
            rechargeRate = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.ShieldRechargeRate).statValue;
        }
    }

}