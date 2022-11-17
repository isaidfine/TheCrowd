using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    public float speed = 0.1f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updated!");
        //get the current position
        Vector3 position = transform.position;

        //if the up key is pressed
        if (Input.GetKey(upKey)) {
            //increase the y value of the position
            position.y += speed;
        }
        //if the left key is pressed
        if (Input.GetKey(leftKey)) {
            //decrease the x value of the position
            position.x -= speed;
        }
        //if the down key is pressed
        if (Input.GetKey(downKey)) {
            //decrease the y value of the position
            position.y -= speed;
        }
        //if the right key is pressed
        if (Input.GetKey(rightKey)) {
            //increase the x value of the position
            position.x += speed;
            
        }
        //reassign the transform position to the new position
        transform.position = position;
    }
}
