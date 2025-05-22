using ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using Systems.Combat;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public enum Modifiers
    {
        BulletDMG,
        Cooldown,
        Heat
    }
    [System.Serializable]
    public class ShootingModifiers
    {
        public Modifiers mod;
        public float value;
    }
    public ShootingModifiers[] modifiers;

    [SerializeField] List<Transform> shootingPoints;
    public GameObject bulletPrefab;
    private PlayerControls playerControls;
    private bool shooting;
    public SoundEffectSO bulletSound;

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

        //heatScaleX = heatUI.transform.localScale.x;
        //heatScaleY = heatUI.transform.localScale.y;
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

        //heatRectUI();

    }

    private void WeaponCooldown()
    {
        ShootingModifiers cooldownModifier = modifiers.FirstOrDefault(m => m.mod == Modifiers.Cooldown);

        if (isHot) { 
            weaponHeat -= Time.deltaTime * (cooldownFactor * (1 + (cooldownModifier.value/100f))) * 1.5f;
        } else
        {
            weaponHeat -= Time.deltaTime * (cooldownFactor * (1 + (cooldownModifier.value / 100f))) * 3;
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

            ShootingModifiers bulletDmgModifier = modifiers.FirstOrDefault(m => m.mod == Modifiers.BulletDMG);
            bullet.SetModifiers(bulletDmgModifier.value);

            rb.linearVelocity = bulletObject.GetComponent<Bullet>().speed * transform.forward;

        });

        //SoundManager.PlaySound(SoundType.SHOT);
        bulletSound.Play();
    }

    //public void heatRectUI()
    //{

    //    heatUI.transform.localScale = new Vector3(heatScaleX, (heatScaleY * weaponHeat) / 100);
    //}
}
