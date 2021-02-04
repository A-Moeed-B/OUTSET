using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
   
    public static int bossHealth=10;
    // Update is called once per frame
    void Update()
    {
        if (bossHealth == 0)
        {
            BulletController.score += 1000;
            Destroy(gameObject);
            SceneManager.LoadScene("MissionSuccess");
        }
        else if (transform.position.y <= -5.84f)
            SceneManager.LoadScene("GameOver");
    }
}
