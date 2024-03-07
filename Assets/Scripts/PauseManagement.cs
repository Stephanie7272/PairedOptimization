using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManagement : MonoBehaviour
{
    public GameObject pauseScreen;
  
    public static bool isPaused = false;

    public void Update ()
     {
       if (Input.GetKeyDown(KeyCode.P))
       {
        if(isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
       } 
     }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        isPaused = false;
    }

}
