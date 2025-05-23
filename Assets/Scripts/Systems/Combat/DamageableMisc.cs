using Assets.Scripts.Interfaces;
using ScriptableObjects;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class DamageableMisc : MonoBehaviour, IDamageable
    {
        public float health = 1.0f;
        public GameObject particlesPrefab;
        public SoundEffectSO hitEffect;
        public SoundEffectSO deathSound;

        void Update() 
        {
            CheckDeath();
        }

        public void Damage(float damage, DamageType damageType)
        {
            Debug.Log("Health: " + health + ". Damage: " + damage);

            damage = ApplyDefences(damage, damageType);

            health -= damage;

            if(hitEffect) hitEffect.Play();

            Debug.Log("Health: " + health);
        }

        public float ApplyDefences(float damage, DamageType damageType) 
        {

            if(damage <  0.0f) damage = 0.0f;

            return damage;
        }

        public void CheckDeath()
        {
            if (health <= 0.0f)
            {
                if(particlesPrefab) Instantiate(particlesPrefab, gameObject.transform.position, gameObject.transform.rotation);
                if(deathSound) deathSound.Play();
                Fracture fracture = GetComponent<Fracture>();
                fracture.FractureObject();
                //Destroy(gameObject);
            }
        }
    }
}
