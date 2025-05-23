using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Systems.Combat
{
    public class Bullet : MonoBehaviour
    {
        public float speed;
        public float bulletDMG; 
        public Boolean isEnemy;
        public float shouldDie = 150f;
        public DamageType damageType;

        private Rigidbody rb;

        [SerializeField] private GameObject particlesPrefab;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Debug.Log(bulletDMG);
        }


        void FixedUpdate()
        {   
            //rb.velocity = new Vector2(speed, rb.velocity.y);

            if (Mathf.Abs(transform.position.x) > shouldDie || Mathf.Abs(transform.position.z) > shouldDie) Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("COLLISION: " + collision);

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            dealDamage(damageable);
        }

        private void OnTriggerEnter(Collider collider)
        {
            Debug.Log("TRIGGER: " + collider);

            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();

            dealDamage(damageable);
        }

        public void SetModifiers(float energyMod = 0, float physicalMod = 0)
        {
            switch (damageType)
            {
                case DamageType.Energy:
                    bulletDMG = (1 + (energyMod / 100f)) * bulletDMG;
                    break;

                case DamageType.Physical:
                    bulletDMG = (1 + (physicalMod / 100f)) * bulletDMG;
                    break;

                default:
                    break;
            }
        }

        private void dealDamage(IDamageable damageable)
        {
            if (damageable != null)
            {
                damageable.Damage(bulletDMG, damageType);

                GameObject particles = Instantiate(particlesPrefab, rb.position, rb.rotation);

                Destroy(gameObject);
            }

        }

    }

}
