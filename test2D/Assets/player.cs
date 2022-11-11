using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float MoveSpeed=3;
 
    void Start()
    {
    }
 
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + MoveSpeed * h* Time.deltaTime;
        position.y = position.y + MoveSpeed * v* Time.deltaTime;
        transform.position = position;
    }
    void OnTiggerEnter()
    {
        
    }
}
