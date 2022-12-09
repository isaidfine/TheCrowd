using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    public GameObject startPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            other.transform.position = startPoint.transform.position;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        }
    }
}
