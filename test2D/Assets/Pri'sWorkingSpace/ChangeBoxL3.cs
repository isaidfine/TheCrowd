using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxL3 : MonoBehaviour
{
   // public List<Transform> oldBoxes= new List<Transform>()
    //Transform[] old;
    public GameObject old1;
    public GameObject old2;
    public GameObject old3;
    public GameObject old4;
    public GameObject new1;
    public GameObject new2;
    public GameObject new3;
    public GameObject new4;

IEnumerator change;


    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Change());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Change()
    {
        old1.SetActive(false);
        new1.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        old2.SetActive(false);
        new2.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        old3.SetActive(false);
        new3.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        old4.SetActive(false);
        new4.SetActive(true);
        yield return null;


    }

    public void ChangeBoxes()
    {
        //oldBoxes.SetActive(false);
        //newBoxes.SetActive(true);
    }
}
