using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlePull : MonoBehaviour
{
   public GameObject player;
    public float pushing;
    public float leavingTime;
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
    IEnumerator tick;

void OnDrawGizmos(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
            }

    void Start()
    {
        timer= Timer();
        tick = TickingOut();
        
    }

    void FixedUpdate()
    {
        
        dir =player.transform.position-this.gameObject.transform.position;
        IsEnter();
        if(IsIn)
        {
            if(!IsTickingOut)
            {
            speed+= pushing*Time.deltaTime;

            }
            else
            {
                speed +=(radius- dir.magnitude)*TickoutSpeed*Time.deltaTime; 
            }
        }
        else if(!IsIn)
        {
                if(speed>0)
                {
                    CloseOtherCircle();
                    speed =Mathf.MoveTowards(speed,0.0f,stillTime);
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
            StartCoroutine(timer);
            IsIn = true;
            }
        }
        else if (dir.magnitude >= radius) 
        {
            if(IsIn)
            {
            StopCoroutine(timer);
            if (IsTickingOut)
            {
                StartCoroutine(tick);
            }
            IsIn = false;
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
            yield return new WaitForSeconds(leavingTime);
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
