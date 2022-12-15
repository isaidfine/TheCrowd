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

    [Header("Sphere&Music")]
    public GameObject sphere;
    public GameObject startMusic;


    private float CamX;
    private float colorDepth;
    private Vector3 playerPos;
    private int i;
    private Vector3 x1;
    private Vector3 x2;
    private float l1;
    private float l2;
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
         x1 = pathPoints[i].position;
        x2 = pathPoints[i+1].position;
        l1=Vector3.Distance(playerPos, x1);
        l2=Vector3.Distance(playerPos, x2);

        
        if (i<pathPoints.Count-2)
        {
           
            colorDepth = (l1<l2 ? l1:l2)/100.0f;
            

            if(l1>l2) 
             {
             pathPoints[i].GetComponent<SpriteRenderer>().enabled= false;
             i++;
            }
            //Debug.Log(i);

        }
        else if (i>= pathPoints.Count-2 )
        {   
            if (l1>130.0f)
            {
                CamX += 70.0f;
                GetComponent<Camera>().orthographicSize= Mathf.MoveTowards(GetComponent<Camera>().orthographicSize,50f,5.0f*Time.deltaTime);
            }
            
            else if (l1>100.0f)
            {
                CamX += 70.0f;
                startMusic.GetComponent<AudioSource>().Pause();
                sphere.SetActive(false);
            } 
            
            else if (l1>50f)
            {
                CamX += 70.0f;
                GetComponent<Camera>().orthographicSize= Mathf.MoveTowards(GetComponent<Camera>().orthographicSize,60f,5.0f*Time.deltaTime);

            }


           
            
            colorDepth = l1/100.0f;   
            //Debug.Log(CamX);
        }
        colorDepth = Mathf.Clamp(1-colorDepth,0.1f,1.0f);

        float pos= Mathf.MoveTowards(transform.position.x,CamX,movingspeed*Time.deltaTime);
        transform.position = new Vector3(pos,0,-10);
        box.transform.position= new Vector3(pos,0,0);
        newBox.transform.position= new Vector3(pos,0,0);
        Sprite.GetComponent<SpriteRenderer>().color=new Color (colorDepth,colorDepth,colorDepth,1.0f);
        sphere.transform.position = playerPos;
        
    }
}
