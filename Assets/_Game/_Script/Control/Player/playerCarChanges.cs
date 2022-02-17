using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.control
{
    public class playerCarChanges : MonoBehaviour
    {
        public GameObject[] cars;
        public int CarID;

        private void Start()
        {
            CarID = FCar.core.HomePage.CarSelection;
        }
        void Update()
        {
            if(CarID == 0)
            {
                cars[0].SetActive(true);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
            }

            if (CarID == 1)
            {
                cars[0].SetActive(false);
                cars[1].SetActive(true);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
            }

            if (CarID == 2)
            {
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(true);
                cars[3].SetActive(false);
            }

            if (CarID == 3)
            {
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(true);
            }
        }
    }
}
