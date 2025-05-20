using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float bulletDMG;
    public Boolean isEnemy;
    public float shouldDie = 150f;

    private Rigidbody rb;

    [SerializeField] private GameObject particlesPrefab;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {   
        //rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Mathf.Abs(transform.position.x) > shouldDie || Mathf.Abs(transform.position.z) > shouldDie) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION: " + collision);

        Damageable damageable = collision.gameObject.GetComponent<Damageable>();

        dealDamage(damageable);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("TRIGGER: " + collider);

        Damageable damageable = collider.gameObject.GetComponent<Damageable>();

        dealDamage(damageable);
    }

    private void dealDamage(Damageable damageable)
    {
        if (damageable != null)
        {
            damageable.damage(bulletDMG);

            GameObject particles = Instantiate(particlesPrefab, rb.position, rb.rotation);

            Destroy(gameObject);
        }

    }

}
