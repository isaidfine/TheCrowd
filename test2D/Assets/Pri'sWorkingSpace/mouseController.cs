using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseController : MonoBehaviour
{

    public float speed;
    public float MaxSpeed;

    private Vector3 dir;
    private float timer;
    private float acceleration;

    void Start()
    {
        
        Cursor.visible = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Input.mousePosition;
        point = Camera.main.ScreenToWorldPoint(point);
        point.z=0;
        transform.LookAt(point,Vector3.back);

        dir = point-transform.position;
        if(Input.GetMouseButtonDown(0))
        {
            timer=0;
            acceleration=0;
        }
        if (Input.GetMouseButton(0))
        {
            timer+= Time.deltaTime;
            acceleration= speed*timer*timer;
            acceleration= Mathf.Clamp(acceleration,0.0f,MaxSpeed);
            transform.Translate(dir*acceleration*Time.deltaTime,Space.World);
        }

        
    }
}
