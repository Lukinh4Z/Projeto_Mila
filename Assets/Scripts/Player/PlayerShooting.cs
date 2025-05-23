using ScriptableObjects;
using System.Collections.Generic;
using Systems.Combat;
using Systems.Player;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] List<Transform> shootingPoints;
    public GameObject bulletPrefab;
    private PlayerControls playerControls;
    private bool shooting;
    public SoundEffectSO bulletSound;
    Ship ship;

    public float timeBtwShots = 1.0f;
    public float shotTimeCounter = 0f;

    public float weaponHeat = 0.0f;
    public float shotHeat = 1.0f;
    public float cooldownFactor = 10.0f;
    public bool isHot = false;

    void Start()
    {
        playerControls = new PlayerControls();
        shotTimeCounter = timeBtwShots;
        ship = GetComponent<Ship>();
    }


    void Update()
    {
        if (weaponHeat >= 100.0f)
        {
            isHot = true;
        }

        shooting = UserInput.instance.playerControls.Controls.Shoot.IsPressed();

        if (!isHot && shooting && shotTimeCounter >= timeBtwShots)
        {
            shotTimeCounter = 0;
            Shoot();
            weaponHeat += shotHeat;
        }

        shotTimeCounter += Time.deltaTime;

        if (weaponHeat > 0.0f)
        {
            WeaponCooldown();
        }
    }

    private void WeaponCooldown()
    {
        //ShootingModifiers cooldownModifier = modifiers.FirstOrDefault(m => m.mod == Modifiers.Cooldown);
        float cooldownModifier = 0;

        if (isHot) { 
            weaponHeat -= Time.deltaTime * (cooldownFactor * (1 + (cooldownModifier/100f))) * 1.5f;
        } else
        {
            weaponHeat -= Time.deltaTime * (cooldownFactor * (1 + (cooldownModifier/ 100f))) * 3;
        }

        if (weaponHeat <= 0.0f)
        {
            weaponHeat = 0.0f;
            isHot = false;
        }
    }

    public void Shoot()
    {
        shootingPoints.ForEach(p =>
        {
            GameObject bulletObject = Instantiate(bulletPrefab, p.position, Quaternion.FromToRotation(transform.up, transform.forward));
            Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
            Bullet bullet = bulletObject.GetComponent<Bullet>();

            float energyPower = ship.GetStat(ShipStatistic.EnergyPower).statValue;
            float physicalMod = ship.GetStat(ShipStatistic.PhysicalPower).statValue;

            bullet.SetModifiers(energyPower, physicalMod);

            rb.linearVelocity = bulletObject.GetComponent<Bullet>().speed * transform.forward;

        });

        bulletSound.Play();
    }
}
