using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2avoidPlayer : MonoBehaviour
{
    public float speed;
    public float stepBackSpeed;
    public float rotateSpeed;
    public float watchingDistance;
    public GameObject player;
    public Transform LookingPoint;

    private Quaternion OriginalRotation;
    private bool isRotate =false;
    private Vector3 OriginalPosition;
    private Vector3 pos;
    private bool IsSet= false;

    void awake (){

        OriginalRotation= this.transform.rotation;
        //OriginalPosition= this.transform.position;

    }
 
    void Start()
    {
        StartCoroutine(GetPosition());
    }
 
    void Update(){

        //if(dir.magnite< watchingDistance)
       // {
            if (false)
            {
                Vector3 vec = LookingPoint.position;
                Quaternion rotate = Quaternion.LookRotation(vec);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, rotate, rotateSpeed);
                if (Vector3.Angle(vec, transform.forward) < 0.1f)
                {
                    isRotate = false;
                }
            }           
        if (IsSet) transform.position = Vector3.MoveTowards(transform.position, pos, stepBackSpeed*Time.deltaTime);

 
}
IEnumerator GetPosition()
{
    yield return new WaitForSeconds(2.0f);
        IsSet = true;
    pos = this.transform.position;
    OriginalPosition= this .transform.position;
    //transform.position = Vector3.MoveTowards(transform.position, OriginalPosition, stepBackSpeed*Time.deltaTime);
}

}
