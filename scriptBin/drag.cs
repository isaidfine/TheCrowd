using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class drag : MonoBehaviour
{
    public int unInitialValue = -9999;
    float moveSpeed = 30.0f;
    public float turnSpeed = 3f;
    Vector3 mouseOld;
    private bool ifReturn;
 
    void Start()
    {
 
    }

    void Update()
    {
 
        if (ifReturn)
        {
            //return;
        }
        //抬起鼠标，初始化后返回
        if (Input.GetMouseButtonUp(0))
        {
            mouseOld.x = mouseOld.y = unInitialValue;
            return;
        }
 
        if (Input.GetMouseButton(0))
        {
            Debug.Log("GetMouseButton !!---click---------------->");
            FollowMouseRotate4();
            ifReturn = true;
        }
        FollowMouseMove();
 
    }
 
    private void FollowMouseRotate4()
    {
        //Vector3 mousePos = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        mouseOld.z = mousePos.z = 1;
        //第一次响应，记录位置后返回
        if (mouseOld.x <= unInitialValue + 1 || mouseOld.y <= unInitialValue + 1)
        {
            mouseOld.x = mousePos.x;
            mouseOld.y = mousePos.y;
            Debug.Log("Initial !!!!  x: " + mouseOld.x + " y: " + mouseOld.y);
            return;
        }
 
 
 
        //float angle = Vector3.Angle(mouseOld, mousePos) * Mathf.Rad2Deg;
        float angle = Vector2.Angle(mouseOld -transform.position, mousePos - transform.position);
        if (mouseOld.x < mousePos.x )
        {
            angle = 0-angle;
        }
        Debug.Log("Caculute old x: " + mouseOld.x + " y: " + mouseOld.y + "---- new x: " + mousePos.x + " y: " + mousePos.y + "angle: " + angle);
 
        transform.Rotate(0, 0, angle);
        mouseOld.x = mousePos.x;
        mouseOld.y = mousePos.y;
    }
 
    private void FollowMouseRotate3()
    {
        double orig = Mathf.Atan2(transform.position.y, transform.position.x) * (180 / 3.1415926);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position).normalized;
        float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - (float)orig;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
 
 
    private void FollowMouseRotate2()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector3 direction = worldPos - transform.position;
        direction.z = 0f;
        direction.Normalize();
 
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);
    }
 
 
    //物体跟随鼠标旋转
    private void FollowMouseRotate()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
        Vector3 direction = mouse - obj;
        //将Z轴置0,保持在2D平面内  
        direction.z = 0f;
        //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1  
        direction = direction.normalized;
        //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值  
        transform.up = direction;
    }
 
    //跟随鼠标移动
    private void FollowMouseMove()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);       
    }

    void OnMouseDrag()
    {

    }
}
