using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseSteerSimple : MonoBehaviour
{
    public float range1;
    public float range2;
    public  float maxSpeed;
    public  float accel;

    [Header("Border")]
    public float Xmax;
    public float Ymax;

    private Vector2 velocity;
    private Vector2 pos;



    void Start()
    {
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;

    }
private void Position()
    {
        pos = new Vector2(transform.position.x,transform.position.y);
        pos.x = Mathf.Clamp(pos.x, -Xmax, Xmax);
        pos.y = Mathf.Clamp(pos.y, -Ymax, Ymax);
    }
    // Update is called once per frame
    void FixedUpdate()
    { 
        Position();
        if( Input. GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        Vector2 target = GetMousePosition();//这是函数
        
        transform.LookAt(target,Vector3.back);//看向target，默认z轴正方向是朝向，第二个参数是头顶的方向
        Vector2 targetOffset = target - pos;
        float distance = targetOffset.magnitude;//向量的模

        float rampedSpeed = distance < range1 ? 0 : maxSpeed * ((distance - range1) / range2);//a<b?c:d 如果a小于b成立则整个式子的值是c，反之则d
        float clippedSpeed = Mathf.Min(maxSpeed, rampedSpeed);
        Vector2 desiredVelocity = (clippedSpeed / distance) * targetOffset;
        
        Vector2 steering = desiredVelocity - velocity;

     if (Input.GetMouseButton(0))
       {
        velocity += steering * Time.fixedDeltaTime * accel;
        pos += velocity * Time.fixedDeltaTime;
       }

       transform.position= new Vector3(pos.x,pos.y,0.0f);


    }

    
    private Vector2 GetMousePosition() //返回值为Vector2
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);//从屏幕坐标系转换为世界坐标系
        return mousePos;
    }
}
