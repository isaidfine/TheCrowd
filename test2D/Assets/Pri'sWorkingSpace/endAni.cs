using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endAni : MonoBehaviour
{
    public GameObject button;
    public GameObject instruction;
    [Header("Ending Scene")]
    public  Vector2 endingPoint;
    public float speed;


    
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(EndAni(this.gameObject));

    }
    void Update()
    {

         if(Vector3.Distance(transform.position, endingPoint)==0)
        {
            Debug.Log("LoadScene!");
            SceneManager.LoadScene(1);
        }

    }

    IEnumerator EndAni(GameObject obj)
    {
        yield return new WaitForSeconds(3);
        obj.gameObject.GetComponent<Animator>().enabled =false;
        obj.gameObject.GetComponent<MouseSteer>().enabled= true;
        instruction.gameObject.SetActive(true);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D line)
    {
        if (line.gameObject.tag == "range")
        {
            gameObject.GetComponent<MouseSteer>().enabled= false;
            transform.position= Vector3.MoveTowards(transform.position, endingPoint, speed*Time.deltaTime);

        }
    }
}
