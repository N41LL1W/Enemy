using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Dragon;

public class Arrow : MonoBehaviour
{
    public int damageAmount = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 10);
        Destroy(transform.GetComponent<Rigidbody>());

        if (other.tag == "Dragon")
        {
            transform.parent = other.transform;
            Destroy(transform.GetComponent<Rigidbody>());
            other.GetComponent<Dragon>().TakeDamage(-damageAmount);
        }
    }
}
