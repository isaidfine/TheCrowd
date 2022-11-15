using UnityEngine;
using System.Collections;

public class followPath : MonoBehaviour {

    public bool StartFollow = false;
    public path PathToFollow;
    public int CurrentWayPointID = 0;
    public float Speed;//移动速度
    public float reachDistance = 0f;//里路径点的最大范围
    public string PathName;//跟随路径的名字
    private string LastName;
    private bool ChangePath = true;



    void Start () {

    }

    void Update () {
        if (!StartFollow)
            return;
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
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * Speed);
        if (distance <= reachDistance)
        {
            CurrentWayPointID++;
        }
        if (CurrentWayPointID >= PathToFollow.path_objs.Count)
        {
            CurrentWayPointID = 0;
        }
    }
}
