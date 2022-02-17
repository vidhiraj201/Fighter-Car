using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.core
{
    public class BoosterPacks : MonoBehaviour
    {
        
        void Start()
        {

        }

        
        void Update()
        {
            if (transform.position.y <= 1.5f)
            {
                transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            }
        }
    }
}

