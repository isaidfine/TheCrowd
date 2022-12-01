using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStartPoint : MonoBehaviour
{
    public GameObject startPoint;// Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
