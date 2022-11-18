using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{

    // ���������Ķ���

    public Transform target;

    // The speed with which the camera will be following.

    public float smoothing = 5f;

    //ƫ����

    Vector3 offset;

    void Start()
    {

        //����ƫ����

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
