using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseSteer : MonoBehaviour
{
    [SerializeField] private float range1;
    [SerializeField] private float range2;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accel;

    [Header("Border")]
    public float Xmax;
    public float Ymax;

    private Vector2 velocity;

    private Vector2 Position
    {
        get => transform.position;
        set
        {
            Vector3 pos = value;
            pos.x = Mathf.Clamp(pos.x, -Xmax, Xmax);
            pos.y = Mathf.Clamp(pos.y, -Ymax, Ymax);
            pos.z=0;
            transform.position = pos;
        }
    }

    void Start()
    {
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if( Input. GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        var target = GetMousePosition();
        //target  = Camera.main.ScreenToWorldPoint(target);
        
        transform.LookAt(target,Vector3.back);
        var targetOffset = target - Position;
        float distance = targetOffset.magnitude;

        float rampedSpeed = distance < range1 ? 0 : maxSpeed * ((distance - range1) / range2);
        float clippedSpeed = Mathf.Min(maxSpeed, rampedSpeed);
        Vector2 desiredVelocity = (clippedSpeed / distance) * targetOffset;
        
        Vector2 steering = desiredVelocity - velocity;

     if (Input.GetMouseButton(0))
       {
        velocity += steering * Time.fixedDeltaTime * accel;
        Position += velocity * Time.fixedDeltaTime;
       }


    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
}
