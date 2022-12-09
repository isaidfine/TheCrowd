using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startenter : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject EndingPoint;
    public float movingSpeed;
    public GameObject LevelLoader;


    public bool IsEnd;
    public bool IsEnter;
    // Start is called before the first frame update

    private Vector3 endingPoint;
    private Vector3 startPoint;

    void Start()
    {
        endingPoint= EndingPoint.transform.position;
        startPoint = StartPoint.transform.position;
        IsEnter = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnter)
        {
            this.transform.position= Vector3.MoveTowards(transform.position, startPoint, movingSpeed*Time.deltaTime);
            if(Vector3.Distance(transform.position, startPoint)==0)
            {
                IsEnter=false;
                GetComponent<MouseSteer>().enabled= true;
                
            }

        }
        if (IsEnd)
        {
            this.transform.position= Vector3.MoveTowards(transform.position, endingPoint, movingSpeed*Time.deltaTime);
            GetComponent<MouseSteer>().enabled= false;
            if(Vector3.Distance(transform.position, endingPoint)==0)
            {
                LevelLoader.SetActive(true);
            }

        }
        
    }

}
