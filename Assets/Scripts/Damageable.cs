using Assets.Scripts.Interfaces;
using ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] float health = 0.0f;
        [SerializeField] GameObject particlesPrefab;
        [SerializeField] SoundEffectSO hitEffect;
        [SerializeField] SoundEffectSO deathSound;

        void Update() 
        {
            checkDeath();
        }

        public void damage(float damage)
        {
            health -= damage;
            hitEffect.Play();
        }

        public void checkDeath()
        {
            if (health <= 0.0f)
            {
                Instantiate(particlesPrefab, gameObject.transform.position, gameObject.transform.rotation);
                deathSound.Play();
                Destroy(gameObject);
            }
        }
    }
}
