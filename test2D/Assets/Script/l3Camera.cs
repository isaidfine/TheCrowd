using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l3Camera : MonoBehaviour
{
    [Header("moving")]
    public GameObject player;
    public GameObject box;
    public GameObject newBox;
    public float  startFollowingX;
    public float movingspeed;

    [Header("Changing color")]
    public List<Transform> pathPoints = new List<Transform>();
    Transform[] theArray;
    public GameObject Sprite;

    [Header("Sphere")]
    public GameObject sphere;


    private float CamX;
    private float colorDepth;
    private Vector3 playerPos;
    private int i;
    private Vector3 x1;
    private Vector3 x2;
    private float length;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform pathPoint in theArray){
            if(pathPoint != this.transform){
                pathPoints.Add(pathPoint);
            }
        i=0;      
    }
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.gameObject.transform.position;
        CamX= player.gameObject.transform.position.x>startFollowingX ? player. gameObject.transform.position.x:startFollowingX;
        float pos= Mathf.MoveTowards(transform.position.x,CamX,movingspeed*Time.deltaTime);
        transform.position = new Vector3(pos,0,-10);
        box.transform.position= new Vector3(pos,0,0);
        newBox.transform.position= new Vector3(pos,0,0);
        
        if (i<pathPoints.Count)
        {
            x1 = pathPoints[i].position;
            x2 = pathPoints[i+1].position;
            float l1=Vector3.Distance(playerPos, x1);
            float l2=Vector3.Distance(playerPos, x2);
            colorDepth = (l1<l2 ? l1:l2)/100.0f;
            colorDepth = Mathf.Clamp(1-colorDepth,0.1f,1.0f);

            if(l1>l2) 
             {
             pathPoints[i].GetComponent<SpriteRenderer>().enabled= false;
             i++;
            }
        }
        else if (i>= pathPoints.Count)
        {
            x1 = pathPoints[i].position;
            float l1=Vector3.Distance(playerPos, x1);
            colorDepth = l1/100.0f;
            sphere.SetActive(false);
        }
         
        //for(int i = 0;i<pathPoints.Count;i++){
            //float x1 = pathPoints[i].position.x;
            //float x2 = pathPoints[i+1].position.x;
            //if(x1<pos & x2>pos )
           // {
             //  colorDepth =(x2-pos)/(x2-x1);
              // break;
           // }
       // }
       //Debug.Log(colorDepth);
        Sprite.GetComponent<SpriteRenderer>().color=new Color (colorDepth,colorDepth,colorDepth,1.0f);
        sphere.transform.position = playerPos;
        
    }
}
