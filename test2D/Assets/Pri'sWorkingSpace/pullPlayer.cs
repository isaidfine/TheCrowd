using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullPlayer : MonoBehaviour
{
    
    public float pull;
    public float movingSpeed;// Start is called before the first frame update
    private float h;
    private float v;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical"); 
        rb.AddForce(new Vector3(h,v,0)*movingSpeed);

    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerStay");

        Vector3 dir = other.gameObject.transform.position-this.gameObject.transform.position;
        rb.AddForce(dir*pull);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");

        Vector3 dir = other.gameObject.transform.position-this.gameObject.transform.position;
        rb.AddForce(dir*pull);
    }

}
