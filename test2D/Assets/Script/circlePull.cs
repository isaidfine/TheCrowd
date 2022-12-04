using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlePull : MonoBehaviour
{
   public GameObject player;
    public float pushing;
    public float stayingTime;
    public float stillTime;
    public float TickoutSpeed;
    public float radius;
    public float maxSpeed;
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
        
        tickingTimer += Time.deltaTime;
        dir =player.transform.position-this.gameObject.transform.position;
        IsEnter();
        if(IsIn)
        {
            stayingTimer += Time.deltaTime;
            if (stayingTimer<stayingTime)
            {
                speed+= (radius- dir.magnitude)*pushing*Time.deltaTime;

            }
            else if(stayingTimer>= stayingTime)
            {
                speed += TickoutSpeed*Time.deltaTime;
                IsTickingOut = true;
            }
        }

        else if(!IsIn)
        {
            if (IsTickingOut)
            {
                tickingTimer += Time.deltaTime;

            }
                if(speed>0)
                {    
                    speed =Mathf.MoveTowards(speed,0.0f,speed/stillTime*Time.deltaTime);
                }
                if (speed <= 0) OpenOtherCircle();            
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
            stayingTimer=0;
            IsIn = true;
            }
        }
        else if (dir.magnitude >= radius) 
        {
            if(IsIn)
            {
            IsIn = false;
            CloseOtherCircle();
            stayingTimer=0;
            if (IsTickingOut)
            {
                //StartCoroutine(tick);
                tickingTimer=0;
            }
            
            }
            
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


    IEnumerator Timer()
    {
        if(!IsTickingOut)
        {
            yield return new WaitForSeconds(stayingTime);
            IsTickingOut= true;
            StopCoroutine(timer);

        }
    }

        IEnumerator TickingOut()
        {
            player.GetComponent<WASDController_position>().enabled=false;
            //player.GetComponent<Collider2D>().enabled=false;

            yield return new WaitForSeconds(stillTime);

            player.GetComponent<WASDController_position>().enabled=true;
            //player.GetComponent<Collider2D>().enabled=true;
            IsTickingOut = false;

        }
}
