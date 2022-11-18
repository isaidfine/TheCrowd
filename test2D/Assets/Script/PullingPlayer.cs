using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingPlayer : MonoBehaviour
{
    public float pullingForce = 5f;
    public float stayingForce=2f;

    [Range(0.0f,1.0f)] 
    public float fadingSpeed = 0.5f;
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
        
        if(other.CompareTag("follower"))
        {
            Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
            rb.AddForce(dir * pullingForce);

            Debug.Log("TriggerEnter!");
        }

        
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");
        float x =rb.velocity.x*fadingSpeed;
        float y= rb.velocity.y*fadingSpeed;

        rb.velocity= new Vector3(x,y,0);
    }
}
