using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.control
{
    public class AITurretsStats : MonoBehaviour
    {
        public float maxHP;
        public GameObject smokeEffects;
        [HideInInspector]public float currentHP;
        void Start()
        {
            currentHP = maxHP;
            StartCoroutine(Destroy());
        }

        
        void Update()
        {
            if (currentHP <= 0)
            {

                FindObjectOfType<FCar.core.GameManager>().KilledTurretCount += 1;

                Destroy(this.gameObject);
            }
        }
        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(1);
            if (transform.position.y > 20)
                Destroy(this.gameObject);
        }
  /*      private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ammo"))
            {
                currentHP -= collision.gameObject.GetComponent<AmmoControl>().DamageAmount;
                Destroy(collision.gameObject);
            }
        }*/

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ammo"))
            {
                print("$Spwan");
                Destroy(Instantiate(smokeEffects, other.transform.position,Quaternion.identity), 5);
                try
                {
                    currentHP -= other.gameObject.GetComponent<AmmoControl>().DamageAmount;
                }
                catch
                {
                    currentHP -= other.gameObject.GetComponent<MissileControl>().DamageAmount;
                }
                Destroy(other.gameObject,0.1f);
            }
        }
    }
}
