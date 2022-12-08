using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l3Camera : MonoBehaviour
{
    public GameObject player;
    public float  startFollowingX;
    public float movingspeed;

    private float CamX;

    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        CamX= player.gameObject.transform.position.x>startFollowingX ? player. gameObject.transform.position.x:startFollowingX;
         float pos= Mathf.MoveTowards(transform.position.x,CamX,movingspeed*Time.deltaTime);
        transform.position = new Vector3(pos,0,0);
        
    }
}
