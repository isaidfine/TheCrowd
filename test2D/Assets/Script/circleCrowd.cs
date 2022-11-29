using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleCrowd : MonoBehaviour
{
    public int peopleNum = 30;
    public GameObject prefab;
    public GameObject circlePoint;
    public int radius;
 
    void Start()
    {
        List<Vector3Int> list = new List<Vector3Int>();
        for (var y = -radius; y < radius; y++)
        {
            for (var x = -radius; x < radius; x++)
            {
                if(x*x+y*y< radius*radius)
                {
                    list.Add(new Vector3Int(x, y, 0));
                }
                
            }
        }
        for (int i = 0; i < peopleNum; i++)
        {
            var index = Random.Range(0, list.Count);
            var pos = list[index];
            GameObject.Instantiate(prefab).transform.position = pos;
            list.RemoveAt(index);
        }
    }
}
