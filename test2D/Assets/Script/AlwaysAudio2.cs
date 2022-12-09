using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysAudio2 : MonoBehaviour
{
    public GameObject bgm;
    public GameObject bgmInstance = null;
    // Start is called before the first frame update
    void Start()
    {
        bgmInstance = GameObject.FindGameObjectWithTag("Sound");
        if(bgmInstance == null)
        {
            bgmInstance = (GameObject)Instantiate(bgm);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
