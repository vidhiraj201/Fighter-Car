using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FCar.control
{
    public class PlayerGun : MonoBehaviour
    {
        [Header("Machine Gun")]
        public Image ReloadTimer;
        public TextMeshProUGUI AmmoCount;

        public AmmoShootButton AmmoShootButton;
        public Transform shootPoint;


        public GameObject Ammo;
        public int maxAmmo;
        public int GunStorage;
        public float AmmoForce;
        public float bulletFireRate;

        public float ReloadTime;

        [Header("Missile Gun")]
        public GameObject missile;
        public Image mReloadTimer;
        public TextMeshProUGUI mAmmoCount;
        public MissileShootButton MissileShootButton;
        public int MMaxAmmo;
        public int MGunStorage;
        public float MAmmoForce;
        public float MBulletFireRate;

        public float mReloadTime;

        private int mCurrentAmmo;
        private float mReload;
        private float mBulletFire;



        private int currentAmmo;
        private float reload;
        private float bulletFire;
        void Start()
        {


            if (currentAmmo<=0)
                currentAmmo = GunStorage;
            if (mCurrentAmmo <= 0)
                mCurrentAmmo = MGunStorage;

            mReload = mReloadTime;

            reload = ReloadTime;
        }
        
        void Update()
        {
            MachineGun();
            MissileGun();

            if (MissileShootButton.isShootButtonPressed)
                mMissileShoot();

            if (AmmoShootButton.isShootButtonPressed)
                bulletShoot();
        }
        public void MissileGun()
        {
            if (mBulletFire > 0)
            {
                mBulletFire -= Time.deltaTime;
            }
            if (mCurrentAmmo <= 0 && mReload > 0 && MMaxAmmo > 0)
            {
                mReload -= Time.deltaTime;

                mReloadTimer.fillAmount = mReload / mReloadTime;

                if (mReload <= 0)
                {
                    MMaxAmmo -= MGunStorage;
                    mCurrentAmmo = MGunStorage;

                    mReload = mReloadTime;
                }
            }
            mAmmoCount.text = mCurrentAmmo + " / " + MMaxAmmo;

        }

        public void mMissileShoot()
        {
            if (mCurrentAmmo > 0 && mBulletFire <= 0)
            {
                mCurrentAmmo -= 1;
                mBulletFire = MBulletFireRate;
                GameObject bullet = Instantiate(missile, shootPoint.position, Quaternion.Euler(90, 0, 0));
                bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * MAmmoForce, ForceMode.Impulse);
            }
        }

        public void MachineGun()
        {
            if (bulletFire > 0)
            {
                bulletFire -= Time.deltaTime;
            }
            if (currentAmmo <= 0 && reload > 0 && maxAmmo > 15)
            {
                reload -= Time.deltaTime;
                ReloadTimer.fillAmount = reload / ReloadTime;
                if (reload <= 0)
                {
                    maxAmmo -= GunStorage;
                    if (maxAmmo > 15)
                        currentAmmo = GunStorage;
                    else
                    {
                        currentAmmo = 15;
                    }
                    reload = ReloadTime;
                }
            }
            AmmoCount.text = currentAmmo + " / " + maxAmmo;

        }
        
        public void bulletShoot()
        {
            if (currentAmmo > 0 && bulletFire<=0)
            {
                currentAmmo -= 1;
                bulletFire = bulletFireRate;
                GameObject bullet = Instantiate(Ammo, shootPoint.position, Quaternion.Euler(90,0,0));
                bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * AmmoForce, ForceMode.Impulse);
            }
        }
        
    }
}
