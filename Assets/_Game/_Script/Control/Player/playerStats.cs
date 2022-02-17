using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FCar.control
{
    public class playerStats : MonoBehaviour
    {
        public GameObject smokeEffects;
        public PlayerGun gun;
        [SerializeField] private float maxHP;
        public float currentHP;
        public Slider HP;

        void Start()
        {
            if (currentHP <= 0) currentHP = maxHP;
            HP.maxValue = maxHP;
        }

        
        void Update()
        {
            currentHP = Mathf.Clamp(currentHP, 0, 100);
            HP.value = currentHP;

            if (currentHP <= 0)
            {
                FindObjectOfType<FCar.core.GameManager>().GameOver = true;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("AIAmmo"))
            {
                currentHP -= other.gameObject.GetComponent<AmmoControl>().DamageAmount;
                Destroy(Instantiate(smokeEffects, other.transform.position,Quaternion.identity), 5);
                Destroy(other.gameObject,0.1f);
            }

            if (other.gameObject.CompareTag("SAP"))
            {
                gun.maxAmmo += 100;
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("LAP"))
            {
                gun.maxAmmo += 200;
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("SHP"))
            {
                if (currentHP < maxHP)
                    currentHP += 5;
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("LHP"))
            {
                if (currentHP < maxHP)
                    currentHP += 25;
                Destroy(other.gameObject);
            }
        }
    }
}
