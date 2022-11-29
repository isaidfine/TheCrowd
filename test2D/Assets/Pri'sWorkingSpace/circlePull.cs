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

    private float speed;
    private Vector3 dir;
    private bool IsTickingOut;
    private bool IsIn;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        dir =player.transform.position-this.gameObject.transform.position;
        if(IsIn)
        {
            if(!IsTickingOut)
            {
            speed+= pushing*Time.deltaTime;
            player.transform.position += speed*dir/dir.magnitude;
            }
            else
            {
                speed +=(1-(dir.magnitude/radius))*TickoutSpeed*Time.deltaTime; 
                player.transform.position += speed*dir/dir.magnitude; 
            }
        }
        else if(!IsIn)
        {
            if(IsTickingOut)
            player.transform.position += speed*dir/dir.magnitude;
        }

        IsEnter();

    }
        
    void IsEnter()
    {
        if (dir.magnitude< radius) 
        {
            if(!IsIn)
            {
            StartCoroutine(Timer());
            IsIn = true;
            }
        }
        else if (dir.magnitude > radius) 
        {
            if(IsIn)
            {
            IsTickingOut= false;
            StartCoroutine(Leaving());
            StopCoroutine(Timer());
            Debug.Log("Leaving");
            IsIn = false;
            }
            
        }
    }



    IEnumerator Timer()
    {
        if(!IsTickingOut)
        {
            yield return new WaitForSeconds(leavingTime);
            IsTickingOut= true;
        }
    }
     IEnumerator Leaving()
    {
        yield return new WaitForSeconds(stillTime);
        IsTickingOut = false;
        speed=0;
        StopCoroutine(Leaving());
        Debug.Log("LeavingTriggered!!!");
    }

}
