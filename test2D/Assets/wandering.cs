using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandering : MonoBehaviour
{
    private Vector3 dir; 
    private float time ;
    private bool isWalk;
    public GameObject rec;
    public float speed;
    public Vector2 worldPosLeftBottom;
    public Vector2 worldPosTopRight;

    void Start()
    {
        dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0);
        time = 0;
        isWalk = true;
    }

    void Update()
    {
        time += Time.deltaTime;//定时
        if(time>3)//3秒改变一次状态，让游戏物体可以停停走走，不然很僵硬
        {
            ChangeState();
        }
        if(isWalk)
        {
            //运动: anim.play("run")
            transform.localPosition += dir.normalized * speed * Time.deltaTime;
        }
        LimitPosition(this.transform);
    }

    public void LimitPosition(Transform trNeedLimit)
    {
        trNeedLimit.position = new Vector3(Mathf.Clamp(trNeedLimit.position.x, worldPosLeftBottom.x, worldPosTopRight.x),
                                           Mathf.Clamp(trNeedLimit.position.y, worldPosLeftBottom.y, worldPosTopRight.y),
                                           trNeedLimit.position.z);
    }
    void ChangeState()
    {
        int value = Random.Range(0, 2);
        if(value==0) //停下来
        {
           isWalk = false;//停止
        }
        else //继续走
        {
            if(!isWalk)//如果本来是停下来的鸡，现在变为走动，那就转一下方向
            {
                dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),0);
            }
            isWalk = true;//运动
        }
        time = 0;//定时器清零
    }
}
