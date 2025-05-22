using Assets.Scripts.Interfaces;
using ScriptableObjects;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class Damageable : MonoBehaviour, IDamageable
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
            if (ship != null) 
            { 
                shipHull = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.Hull).statValue;
                shipShield = ship.shipStats.statValues.Find(a => a.statType == ShipStatistic.Shield).statValue;

                health = shipHull + shipShield;
            }
        }

        void Update() 
        {
            CheckDeath();
        }

        public void Damage(float damage)
        {
            Debug.Log("Health: " + health + ", Hull: " + shipHull + ", Shield: " + shipShield + ". Damage: " + damage);

            if (shipShield > 0.0f)
            {
                shipShield -= damage;
                health = shipHull + shipShield;
            }
            else if (shipHull > 0.0f)
            {
                shipShield = 0.0f;
                shipHull -= damage;
                health = shipHull + shipShield;
            }
            else
            { 
                health -= damage;
            }

            if(hitEffect) hitEffect.Play();

            Debug.Log("Health: " + health);
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
