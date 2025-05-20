using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] List<Transform> shootingPoints;
    [SerializeField] GameObject bulletPrefab;
    private float timer;
    public float shootingSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1f/(shootingSpeed))
        {
            timer = 0;
            Shot();
        }
    }

    private void Shot()
    {
        if(bulletPrefab != null)
        {
            shootingPoints.ForEach(p =>
            {
                GameObject bullet = Instantiate(bulletPrefab, p.position, p.transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                rb.linearVelocity = bullet.GetComponent<Bullet>().speed * p.transform.up;

            });
        }
    }
}
