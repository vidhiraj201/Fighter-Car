using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public float DamageAmount;
    public GameObject smokeEffect;
    bool destroy;
    Vector3 setPos;
    private void Update()
    {
        if (destroy)
        {
            transform.position = setPos;
            GetComponent<SphereCollider>().radius += 2;
            if (GetComponent<SphereCollider>().radius > 35)
                Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        destroy = true;
        setPos = transform.position;
        Destroy(Instantiate(smokeEffect, transform.position, Quaternion.identity), 1.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        destroy = true;
        setPos = transform.position;
        Destroy(Instantiate(smokeEffect, transform.position, Quaternion.identity), 1.5f);
    }
}
