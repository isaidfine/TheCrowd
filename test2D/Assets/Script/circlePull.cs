using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlePull : MonoBehaviour
{
    
    public GameObject player;
    public float pushing;
    public float maxSpeed;
    public float TickoutSpeed;
    [Header(" ")]
    public float stayingTime;
    public float stillTime;
    
    public float radius;
    
    public List<Transform> otherCircle = new List<Transform>();
    Transform[] theArray;

    private float speed;
    private Vector3 dir;
    private bool IsTickingOut;
    private bool IsIn;

    IEnumerator timer;
    private float stayingTimer;
    IEnumerator tick;
    private float tickingTimer;

void OnDrawGizmos(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
            }

    void Start()
    {
        //timer= Timer();
        //tick = TickingOut();
        stayingTimer=0;
        tickingTimer=0;
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        dir =player.transform.position-this.gameObject.transform.position;
        IsEnter();
        if(IsIn)
        {
            stayingTimer += Time.deltaTime;
            if (stayingTimer<stayingTime)
            {
                speed= (radius- dir.magnitude)/dir.magnitude*pushing;

            }
            else if(stayingTimer>= stayingTime)
            {
                speed = TickoutSpeed;
                IsTickingOut = true;
                //tickingTimer=0;
            }
        }

        else if(!IsIn)
        {
            if (IsTickingOut)
            {
                player.GetComponent<MouseSteer>().enabled=false;
                tickingTimer += Time.deltaTime;
                CloseOtherCircle();
                
                   if (tickingTimer>= stillTime)
                    {
                    player.GetComponent<MouseSteer>().enabled=true;
                    OpenOtherCircle(); 
                    IsTickingOut=false;
                    speed=0;
                    tickingTimer=0;
                }    
        }speed =Mathf.MoveTowards(speed,0.0f,speed/stillTime*Time.deltaTime);
        }
        speed =Mathf.Clamp(speed,0.0f,maxSpeed);       
        player.transform.position += speed*dir/dir.magnitude;
    }
        
    void IsEnter()
    {
        if (dir.magnitude< radius) 
        {
            if(!IsIn)
            {
            //stayingTimer=0;
            IsIn = true;
            }
        }
        else if (dir.magnitude >= radius) 
        {
            if(IsIn)
            {
            IsIn = false;           
            if (IsTickingOut)
                {
                    CloseOtherCircle();//StartCoroutine(tick);
                    tickingTimer=0;
                }
            }
            stayingTimer=0;
        }
    }
    void CloseOtherCircle()
    {
        for(int i = 0;i<otherCircle.Count;i++){
            otherCircle[i].gameObject.SetActive(false);
            }
    }

        void OpenOtherCircle()
    {
        for(int i = 0;i<otherCircle.Count;i++){
            otherCircle[i].gameObject.SetActive(true);
            }
    }

}
