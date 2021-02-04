using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{
    public string sceneName;
    public VideoPlayer video;
    void Start()
    {
       video.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void LoadScene(VideoPlayer player)
    {
        SpaceshipController.endLevel();
        SceneManager.LoadScene(sceneName);
    }
}
