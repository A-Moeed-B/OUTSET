using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused=false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (GameIsPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //        {
    //            Pause();
    //        }
    //    }

    //}
    //void Resume()
    //{
    //   // PauseMenu.SetActive(false);
    //   // Time.timeScale = 1f;
    //   // GameIsPaused = false;
    //}
    //void pause()
    //{
    //    //PauseMenu.SetActive(true);
    //    //Time.timeScale = 0f;
    //    //GameIsPaused = true;
    //}
    public void loadmenu()
    {
        Debug.Log("Loading meanu");
    }
    public void Quit()
    {
        Debug.Log("Quit");
    }
}
