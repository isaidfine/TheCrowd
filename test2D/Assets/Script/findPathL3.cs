using UnityEngine;
using System.Collections;

public class findPathL3 : MonoBehaviour {

    //public bool StartFollow = false;
    public path PathToFollow;
    public int CurrentWayPointID = 0;
    public Sprite redDot;
    public Sprite redCircle;
    //public float Speed;
    public float reachDistance = 0f;
    public string PathName;
    public GameObject empty;
    public GameObject change;

     
    private string LastName;
    private bool ChangePath = true;



    void Start () {

    }

    void Update () {
        //if (!StartFollow) return;
        if (ChangePath)
        {
            PathToFollow = GameObject.Find(PathName).GetComponent<path>();
            ChangePath = false;
            Debug.Log("FindPath");
        }
        if (LastName != PathName)
        {
            ChangePath = true;
        }
        LastName = PathName;

        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        //transform.Translate(PathToFollow.path_objs[CurrentWayPointID].position * Time.deltaTime * Speed, Space.Self);
        //transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * Speed);
        if (distance <= reachDistance)
        {          
            PathToFollow.path_objs[CurrentWayPointID].gameObject.GetComponent<SpriteRenderer>().sprite=redDot;
            CurrentWayPointID++;
            PathToFollow.path_objs[CurrentWayPointID].gameObject.GetComponent<SpriteRenderer>().enabled=true;
            Debug.Log("find"+CurrentWayPointID);

        }
        if (CurrentWayPointID >= PathToFollow.path_objs.Count-1)
        {
            Debug.Log("finished!");
            if (Vector3.Distance(transform.position,empty.gameObject.transform.position)<= 20.0f)
            {
                //GetComponent<MouseSteer>().enabled = false;
                change.SetActive(true);
            }
            

        }
    }
}
