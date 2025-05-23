using ScriptableObjects;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class Hull : DamageableMisc
    {
        //public Ship ship;
        //public float repairRate;

        //void Start()
        //{
        //    float shipHull = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.Hull).statValue;
        //    Debug.Log(shipHull);
        //    health = shipHull;
        //    repairRate = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.HullRepairRate).statValue;
        //}

        //public new void Damage(float damage)
        //{
        //    Shield shield = ship.gameObject.GetComponent<Shield>();

        //    if (shield != null && shield.health <= 0.0f)
        //    {
        //        health -= damage;
        //        if (hitEffect) hitEffect.Play();
        //    }
        //}
    }
}
