using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneScript : MonoBehaviour
{

    public void ReloadStartScreen ()
    {
        Debug.Log("Reload Scene");
        SceneManager.LoadScene("StartScreen");
        
    }
}
