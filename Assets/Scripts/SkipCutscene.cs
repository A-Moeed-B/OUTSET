using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
   public string sceneName;
   public void loadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
