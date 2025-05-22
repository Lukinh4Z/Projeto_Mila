using Assets.Scripts.Interfaces;
using ScriptableObjects;
using Systems.Player;
using UnityEngine;

namespace Systems.Combat
{
    internal class Damageable : MonoBehaviour, IDamageable
    {
        public float health = 0.0f;
        [SerializeField] GameObject particlesPrefab;
        [SerializeField] SoundEffectSO hitEffect;
        [SerializeField] SoundEffectSO deathSound;

        void Update() 
        {
            CheckDeath();
        }

        public void Damage(float damage)
        {
            health -= damage;
            if(hitEffect) hitEffect.Play();
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
