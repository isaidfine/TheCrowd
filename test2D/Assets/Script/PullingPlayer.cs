using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingPlayer : MonoBehaviour
{
    public float pullingForce;
    public float stayingForce;
    public float fadingSpeed;
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
        Debug.Log("TriggerEnter");

        Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
        rb.AddForce(dir * pullingForce);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
        float x =rb.velocity.x/fadingSpeed;
        float y= rb.velocity.y/fadingSpeed;

        rb.velocity= new Vector3(x,y,0);
    }
}
