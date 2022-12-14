using UnityEngine;
using System.Collections;

public class findPath : MonoBehaviour {

    //public bool StartFollow = false;
    public path PathToFollow;
    public int CurrentWayPointID = 0;
    //public float Speed;
    public Sprite redDot;
    public Sprite redCircle;
    public float reachDistance = 0f;
    public string PathName;
    public GameObject EndScript;
    public AudioSource CircleSFX;
    public GameObject eatingAudio;

    public GameObject circleAll;


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
        if (distance<= 20) CircleSFX.Play();
        if (distance <= reachDistance)
        {
            
            eatingAudio.GetComponent<AudioSource>().Play();
            PathToFollow.path_objs[CurrentWayPointID].gameObject.GetComponent<SpriteRenderer>().sprite=redDot;
            CurrentWayPointID++;
            PathToFollow.path_objs[CurrentWayPointID].gameObject.GetComponent<SpriteRenderer>().enabled=true;
            Debug.Log("find"+CurrentWayPointID);

        }
        if (CurrentWayPointID >= PathToFollow.path_objs.Count-1)
        {
            Debug.Log("finished!");
            GetComponent<MouseSteer>().enabled = false;
            //GetComponent<PullingPlayer>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            circleAll.SetActive(false);
           //GetComponent<SphereCollider2D>().enabled=false;
            //transform.GetChild(0).GetComponent<Animation>().enabled = true;
            GetComponent<startenter>().IsEnd = true;

        }
    }
}
