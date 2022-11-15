using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullPlayer : MonoBehaviour
{
    
    public float pull;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        //vector2 dir= new vector2(other.gameObject.position-this.gameObject.position);
        //this. GetCompenent<Rigidbody2D>().AddForce(pull);

    }
}
