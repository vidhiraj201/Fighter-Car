using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.core
{
    public class AITurretsSpwnner : MonoBehaviour
    {
        public GameObject AITurrets;
        public List<GameObject> Turrets = new List<GameObject>();
        public Vector2 minPos;
        public Vector2 maxPos;

        public Vector3 spwanPos;

        public float delayInspwan;
        public int maxTurretSpwan;

        void Start()
        {
            for(int i = 0; i < 6; i++)
            {
                int x = (int)Random.Range(minPos.x, maxPos.x);
                int z = (int)Random.Range(minPos.y, maxPos.y);
                spwanPos = new Vector3(x + 1, -0.2f, z + 1);
                Turrets.Add(Instantiate(AITurrets, spwanPos, Quaternion.identity, transform));
            }
        }

        
        void Update()
        {
            SpwnAIs();
            CheckList();
        }
        void SpwnAIs()
        {
            if (delayInspwan > 0 && Turrets.Count <= maxTurretSpwan)
            {
                delayInspwan -= Time.deltaTime;
                if (delayInspwan <= 0)
                {                    
                    delayInspwan = 1;
                    int x = (int)Random.Range(minPos.x, maxPos.x);
                    int z = (int)Random.Range(minPos.y, maxPos.y);
                    spwanPos = new Vector3(x + 1, -0.2f, z + 1);
                    Turrets.Add(Instantiate(AITurrets, spwanPos, Quaternion.identity, transform));
                }
            }
        }

        public void CheckList()
        {
            if (Turrets.Count > 0)
            {
                for (int i = 0; i <= Turrets.Count - 1; i++)
                {
                    if (Turrets[i] == null)
                    {
                        Turrets.Remove(Turrets[i]);
                    }
                    if (i >= Turrets.Count)
                    {
                        i = 0;
                    }
                }
            }
            
        }
    }
}
