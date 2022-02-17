using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.control
{
    public class AITurretsRadar : MonoBehaviour
    {
        private FCar.core.GameManager gm;
        public float radarRedius;
        public float turretTargetSpeed = 50;
        public GameObject Player;
        public Transform turret;



        private void Start()
        {
            gm = FindObjectOfType<FCar.core.GameManager>();
            transform.GetChild(2).GetComponent<SphereCollider>().radius = radarRedius;
        }
        private void Update()
        {
            if(!gm.GameOver)
                aimTowardPlayer();
        }



        void aimTowardPlayer()
        {
            if (Player != null)
            {
                Vector3 yRot = (turret.position - Player.transform.position).normalized;
                Quaternion rot = Quaternion.LookRotation(new Vector3(yRot.x,0, yRot.z));

                turret.rotation = Quaternion.Slerp(Quaternion.Euler(turret.eulerAngles.x, turret.eulerAngles.y, turret.eulerAngles.z), rot, turretTargetSpeed * Time.deltaTime);
                
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player = other.gameObject;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player = null;
            }
        }
    }
}
