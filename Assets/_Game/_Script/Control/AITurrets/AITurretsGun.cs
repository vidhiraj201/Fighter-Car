using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.control
{
    public class AITurretsGun : MonoBehaviour
    {
        private FCar.core.GameManager gm;
        public AITurretsRadar AITurretsRadar;

        public GameObject Ammo;
        public Transform shootPoint;
        public float AmmoForce;
        public float bulletFireRate;
        private float bulletFire;
        void Start()
        {
            gm = FindObjectOfType<FCar.core.GameManager>();
        }        
        void Update()
        {
            if(AITurretsRadar.Player!=null && !gm.GameOver)
                fire();
        }
        void fire()
        {
            if (bulletFire > 0)
                bulletFire -= Time.deltaTime;

            if (bulletFire <= 0)
            {
                GameObject bullet = Instantiate(Ammo, shootPoint.position, Quaternion.Euler(90, 0, 0));
                bullet.GetComponent<Rigidbody>().AddForce(-shootPoint.forward * AmmoForce, ForceMode.Impulse);
                bulletFire = bulletFireRate;
            }
        }
    }
}
