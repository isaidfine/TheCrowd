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
    public GameObject Loader;

    private bool IsEnd;


    
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(EndAni(this.gameObject));

    }
    void Update()
    {
        if (IsEnd)
        {
            this.transform.position= Vector3.MoveTowards(transform.position, endingPoint, speed*Time.deltaTime);
            if(Vector3.Distance(transform.position, endingPoint)==0)
            {
                Loader.GetComponent<LevelLoader>().LoadNextLevel();
            }

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

    void OnTriggerEnter2D(Collider2D endingline)
    {
        if (endingline.gameObject.tag == "EndingLine")
        {
            gameObject.GetComponent<MouseSteer>().enabled= false;
            IsEnd = true;

        }
    }
}
