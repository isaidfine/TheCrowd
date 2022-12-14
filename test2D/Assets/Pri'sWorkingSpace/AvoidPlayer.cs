using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour
{
    private GameObject player;
    //private Quaternion OriginalRotation;
    private Vector3 OriginalPos;
    public float watchingDistance;
    public float avoidSpeed;

    private Vector3 distance;

    void Start()
    {
        player =GameObject.FindGameObjectWithTag("Player");
        OriginalPos = this.transform.position;

       // OriginalRotation= this.transform.rotation;
        //uup = new Vector3(0.0f,1.0f,0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
       distance = transform.position-player.transform.position;
        if (distance.magnitude < watchingDistance)
        {
            Debug.Log("Find!");
            transform.Translate(distance* Time.deltaTime * avoidSpeed / distance.magnitude, Space.Self);
            transform.LookAt(player.transform.position,Vector3.back);
        }
        else transform.LookAt(OriginalPos,Vector3.back);

    }
}
