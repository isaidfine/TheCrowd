using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEdges : MonoBehaviour
{
    public Animator Top;
    public Animator Bottom;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if (other.gameObject.name == "AppearLine")
        {
            Top.SetBool("TopAppear", true);
            Bottom.SetBool("BottomAppear", true);
            Debug.Log("hit");
        }
    }

    void Update()
    {
        
    }
}
