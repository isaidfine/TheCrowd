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
    public void GoToScene0()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene(2);
    }
}
