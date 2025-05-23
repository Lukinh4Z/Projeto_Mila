using Assets.Scripts.Interfaces;
using ScriptableObjects;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class DamageableShip : MonoBehaviour, IDamageable
    {
        public float health = 0.0f;
        public float shipHull = 0.0f;
        public float shipShield = 0.0f;
        public Ship ship;
        public GameObject particlesPrefab;
        public SoundEffectSO hitEffect;
        public SoundEffectSO deathSound;

        void Start() 
        {
            ship = GetComponent<Ship>();

            if (ship != null)
            {
                shipHull = ship.GetStat(ShipStatistic.Hull).statValue;
                shipShield = ship.GetStat(ShipStatistic.Shield).statValue;

                health = shipHull + shipShield;
            }
            else
            {
                Debug.Log("No Ship found!", gameObject);
            }
        }

        void Update() 
        {
            CheckDeath();
        }

        public void Damage(float damage, DamageType damageType)
        {
            Debug.Log("Health: " + health + ", Hull: " + shipHull + ", Shield: " + shipShield + ". Damage: " + damage);

            damage = ApplyDefences(damage, damageType);

            if (shipShield > 0.0f)
            {
                if (damageType == DamageType.Energy) damage *= 2;

                shipShield -= damage;
                health = shipHull + shipShield;
            }
            else if (shipHull > 0.0f)
            {
                if (damageType == DamageType.Physical) damage *= 2;

                shipShield = 0.0f;
                shipHull -= damage;
                health = shipHull + shipShield;
            }
            else
            {
                Debug.Log("Ship Hull error!", gameObject);
            }

            if(hitEffect) hitEffect.Play();

            Debug.Log("Health: " + health);
        }

        public float ApplyDefences(float damage, DamageType damageType) 
        {
            if (ship != null)
            {
                switch (damageType)
                { 
                    case DamageType.Energy:
                        damage -= (ship.GetStat(ShipStatistic.EnergyDmgReduction).statValue + ship.GetStat(ShipStatistic.Block).statValue);
                        return damage;

                    case DamageType.Physical:
                        damage -= (ship.GetStat(ShipStatistic.PhysicalDmgReduction).statValue + ship.GetStat(ShipStatistic.Block).statValue);
                        return damage;

                    default:
                        break;
                }
            }

            if(damage <  0.0f) damage = 0.0f;

            return damage;
        }
        public void CheckDeath()
        {
            if (health <= 0.0f)
            {
                if(particlesPrefab) Instantiate(particlesPrefab, gameObject.transform.position, gameObject.transform.rotation);
                if(deathSound) deathSound.Play();
                Destroy(gameObject);
            }
        }
    }
}
