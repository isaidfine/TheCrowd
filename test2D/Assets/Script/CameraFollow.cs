using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{

    // 摄像机跟随的对象

    public Transform target;

    // The speed with which the camera will be following.

    public float smoothing = 5f;

    //偏移量

    Vector3 offset;

    void Start()
    {

        //计算偏移量

        offset = transform.position - target.position;

    }



    void LateUpdate()
    {

        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        Vector3 CamPos = transform.position;
        CamPos.y = 0;
        transform.position = CamPos;

    }

}
