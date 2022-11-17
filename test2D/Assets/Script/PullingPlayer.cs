using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingPlayer : MonoBehaviour
{
    public float pullingForce;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerStay");

        Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
        rb.AddForce(dir * pullingForce);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");

        Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
        rb.AddForce(dir * pullingForce);
    }
}
