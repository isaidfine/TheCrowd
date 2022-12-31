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

   // IEnumerator timer;
    private float stayingTimer;
    //IEnumerator tick;
    private float tickingTimer;

    [Header("Cam Focusing")]
    public  float CamSpeed;
    public GameObject Cam;
    private Vector3 OriPos;
    private Ray CamRay;

    private Vector3 TarPos;
    private float FocusingScale;


void OnDrawGizmos(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
            }

    void Start()
    {
        //timer= Timer();
        //tick = TickingOut();
        Cam = Camera.main.gameObject;
        CamSpeed = 3.0f;
        OriPos = Cam.transform.position;
        stayingTimer=0;
        tickingTimer=0;
        
    }

    void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        dir =player.transform.position-this.gameObject.transform.position;
        IsEnter();

        CamRay = Camera.main.ScreenPointToRay(player.transform.position);
        TarPos = OriPos + player.transform.position;


        if(IsIn)
        {
            

            stayingTimer += Time.deltaTime;
            if (stayingTimer<stayingTime)
            {
                FocusingScale+= CamSpeed*Time.deltaTime;
                speed= (radius- dir.magnitude)/dir.magnitude*pushing;

            }
            else if(stayingTimer>= stayingTime)
            {
                speed = TickoutSpeed;
                IsTickingOut = true;
                FocusingScale =0.0f;
                //tickingTimer=0;
            }
            
        }

        else if(!IsIn)
        {
            FocusingScale =0.0f;
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
        //speed =Mathf.Clamp(speed,0.0f,maxSpeed);       
        player.transform.position += speed*dir/dir.magnitude;
        FocusCam(FocusingScale);
        

        
    }
        
    void IsEnter()
    {
        if (dir.magnitude<= radius) 
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

    void FocusCam(float scale)
    {
        if (scale >0)
        {
            Cam.transform.position = Vector3.MoveTowards(Cam.transform.position,TarPos,CamSpeed*Time.deltaTime);
            
            Cam.GetComponent<Camera>().orthographicSize= 50.0f -scale;
            Debug.Log(TarPos.x);
        }

        else if(scale ==0)
        {
            Cam.transform.position = Vector3.MoveTowards(Cam.transform.position,OriPos,CamSpeed*Time.deltaTime);
            Cam.GetComponent<Camera>().orthographicSize= Mathf.MoveTowards(Cam.GetComponent<Camera>().orthographicSize,50.0f,CamSpeed*Time.deltaTime);
        }

        Cam.transform.position = new Vector3(Cam.transform.position.x,Cam.transform.position.y,OriPos.z);
    }
}
