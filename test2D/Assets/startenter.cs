using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class startenter : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject EndingPoint;
    public float movingSpeed;
    public GameObject LevelLoader;


    public bool IsEnd=false;
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
            GetComponent<MouseSteer>().enabled= false;
            Quaternion rotation = Quaternion.LookRotation(Vector3.right, Vector3.back);
            transform.rotation = rotation;
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
            Quaternion rotation = Quaternion.LookRotation(Vector3.right, Vector3.back);
            transform.rotation = rotation;
            if(Vector3.Distance(transform.position, endingPoint)==0)
            {
                LevelLoader.GetComponent<LevelLoader>().LoadNextLevel();
            }

        }
        
    }

}
