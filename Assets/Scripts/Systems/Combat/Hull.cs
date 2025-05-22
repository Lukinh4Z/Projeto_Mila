using ScriptableObjects;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class Hull : Damageable
    {
        public new float health = 0.0f;
        [SerializeField] SoundEffectSO hitEffect;
        public Ship ship;
        public float repairRate;

        public Hull()
        {
            health = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.Hull).statValue;
            repairRate = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.HullRepairRate).statValue;
        }

        public new void Damage(float damage)
        {
            Shield shield = ship.gameObject.GetComponent<Shield>();

            if (shield != null && shield.health <= 0.0f)
            {
                health -= damage;
                if (hitEffect) hitEffect.Play();
            }
        }
    }
}
