using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endAni : MonoBehaviour
{
    public GameObject button;
    public GameObject instruction;
    [Header("Ending Scene")]
    public  Vector3 endingPoint;
    public float speed;


    
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(EndAni(this.gameObject));

    }
    void Update()
    {
         if(Input.GetMouseButtonDown(0))
         {
            instruction.gameObject.SetActive(false);

         }

         if(Vector3.Distance(transform.position, endingPoint)==0)
        {
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
        
        if (line.gameObject.name == "endingLine")
        {
            Debug.Log("ReachingLIne");
            gameObject.GetComponent<MouseSteer>().enabled= false;
            transform.position = Vector3.MoveTowards(transform.position, endingPoint, speed * Time.deltaTime);

        }
    }
}
