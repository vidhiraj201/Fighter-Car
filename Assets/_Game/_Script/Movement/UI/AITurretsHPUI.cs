using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FCar.movement
{
    public class AITurretsHPUI : MonoBehaviour
    {
        public FCar.control.AITurretsStats AITurretsStats;
        public Slider HP;
        
        // Start is called before the first frame update
        void Start()
        {
            HP.maxValue = AITurretsStats.maxHP;
        }

        // Update is called once per frame
        void Update()
        {
            transform.forward = Camera.main.transform.forward;
            HP.value = AITurretsStats.currentHP;
        }
    }
}
