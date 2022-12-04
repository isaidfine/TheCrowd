using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSteer : MonoBehaviour
{
    [SerializeField] private float range1;
    [SerializeField] private float range2;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accel;

    private Vector2 velocity;

    private Vector2 Position
    {
        get => transform.position;
        set
        {
            Vector3 pos = value;
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var target = GetMousePosition();
        var targetOffset = target - Position;
        float distance = targetOffset.magnitude;

        float rampedSpeed = distance < range1 ? 0 : maxSpeed * ((distance - range1) / range2);
        float clippedSpeed = Mathf.Min(maxSpeed, rampedSpeed);
        Vector2 desiredVelocity = (clippedSpeed / distance) * targetOffset;
        
        Vector2 steering = desiredVelocity - velocity;

        velocity += steering * Time.fixedDeltaTime * accel;
        Position += velocity * Time.fixedDeltaTime;

    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
}
