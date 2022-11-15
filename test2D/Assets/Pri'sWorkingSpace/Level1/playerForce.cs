using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerForce : MonoBehaviour
{
    private Rigidbody2D player;
    public float thrust = 1.0f;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedSUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(h,v);
        Debug.Log(h);
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        player.AddForce( dir* thrust);
}

}

    
