using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FCar.core
{
    public class BoosterPackSpwnner : MonoBehaviour
    {
        public List<GameObject> Booster = new List<GameObject>();
        public List<GameObject> Packs = new List<GameObject>();
        public Vector2 minPos;
        public Vector2 maxPos;

        public Vector3 spwanPos;

        public float delayInspwan;

        void Start()
        {

        }
        
        void Update()
        {
            SpwnAIs();
            CheckList();
        }
        void SpwnAIs()
        {
            if (delayInspwan > 0 && Packs.Count <= 5)
            {
                delayInspwan -= Time.deltaTime;
                if (delayInspwan <= 0)
                {
                    delayInspwan = 1;
                    int B = (int)Random.Range(0, 4);
                    int x = (int)Random.Range(minPos.x, maxPos.x);
                    int z = (int)Random.Range(minPos.y, maxPos.y);
                    spwanPos = new Vector3(x , 30f, z );
                    Packs.Add(Instantiate(Booster[B], spwanPos, Quaternion.identity, transform));
                }
            }
        }

        public void CheckList()
        {
            if (Packs.Count > 0)
            {
                for (int i = 0; i <= Packs.Count - 1; i++)
                {
                    if (Packs[i] == null)
                    {
                        Packs.Remove(Packs[i]);
                    }
                    if (i >= Packs.Count)
                    {
                        i = 0;
                    }
                }
            }
        }
    }
}
