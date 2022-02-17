using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoControl : MonoBehaviour
{
    public float DamageAmount;
    public GameObject smokeEffect;
    private void Start()
    {
        Destroy(this.gameObject, 15);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Instantiate(smokeEffect, transform.position, Quaternion.identity), 1.5f);
        Destroy(this.gameObject,0.1f);    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(Instantiate(smokeEffect, transform.position,Quaternion.identity), 1.5f);
        Destroy(this.gameObject,0.1f);
    }
}
