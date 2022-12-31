using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2CamFocus : MonoBehaviour
{
    // Start is called before the first frame update
    public  float CamSpeed;
    public GameObject Cam;

    private Vector3 OriPos;
    private Vector3 TargetPos;
    private Ray CamRay;
    private GameObject player;
    private bool focusing;


    void Start()
    {
        OriPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");



        
    }

    // Update is called once per frame
    void Update()
    {
        CamRay = Camera.main.ScreenPointToRay(player.transform.position);
        
    }

}
