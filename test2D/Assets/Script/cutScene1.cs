using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutScene1 : MonoBehaviour
{
    public Transform endingPoint;
    public float speed;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endingPoint.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, endingPoint.position)==0)
        {
            SceneManager.LoadScene(1);
        }

    }
}
