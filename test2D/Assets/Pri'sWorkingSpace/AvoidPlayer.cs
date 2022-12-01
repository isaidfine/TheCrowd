using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    public GameObject player;
    public float watchingDistance;
    public float avoidSpeed;

    private Vector3 distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       distance = transform.position-player.transform.position;
        if (distance.magnitude < watchingDistance)
        {
            transform.Translate(distance* Time.deltaTime * avoidSpeed / distance.magnitude, Space.Self);
        }

    }
}
