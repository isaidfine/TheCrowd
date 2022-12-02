using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleCrowd1 : MonoBehaviour
{
    public int peopleNum;
    public GameObject prefab;
    public GameObject circlePoint;
    public int radius;
    public int z;
 
    void Start()
    {
        List<Vector3Int> list = new List<Vector3Int>();
        for (var y = -radius; y < radius; y++)
        {
            for (var x = -radius; x < radius; x++)
            {
                if(x*x+y*y< radius*radius)
                {
                    list.Add(new Vector3Int(x, y, z));
                }
                
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            //var index = Random.Range(0, list.Count);
            //var pos = list[index];
            var pos=list[i];
            GameObject.Instantiate(prefab).transform.position = pos;
            //list.RemoveAt(index);
            list.RemoveAt(i);
        }
    }
}
