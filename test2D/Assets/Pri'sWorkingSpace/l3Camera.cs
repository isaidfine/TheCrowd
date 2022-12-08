using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l3Camera : MonoBehaviour
{
    [Header("moving")]
    public GameObject player;
    public GameObject box;
    public float  startFollowingX;
    public float movingspeed;

    [Header("Changing color")]
    public List<Transform> pathPoints = new List<Transform>();
    Transform[] theArray;
    public GameObject Sprite;

    private float CamX;
    private float colorDepth;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform pathPoint in theArray){
            if(pathPoint != this.transform){
                pathPoints.Add(pathPoint);
            }
    
        
    }
    }

    // Update is called once per frame
    void Update()
    {
        CamX= player.gameObject.transform.position.x>startFollowingX ? player. gameObject.transform.position.x:startFollowingX;
        float pos= Mathf.MoveTowards(transform.position.x,CamX,movingspeed*Time.deltaTime);
        transform.position = new Vector3(pos,0,0);
        box.transform.position= new Vector3(pos,0,0);
        

        for(int i = 0;i<pathPoints.Count;i++){
            float x1 = pathPoints[i].position.x;
            float x2 = pathPoints[i+1].position.x;
            if(x1<pos & x2>pos )
            {
               colorDepth =(x2-pos)/(x2-x1);
               break;
            }
        }
        Sprite.GetComponent<SpriteRenderer>().color=new Color (colorDepth,colorDepth,colorDepth,1.0f);
        
    }
}
