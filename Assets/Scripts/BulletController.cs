using UnityEngine;
public class BulletController : MonoBehaviour
{
    private float velX = 0f;
    public float velY = 8F;
    Rigidbody2D bullet;
    public static int score = 0;
    void Start()
    {
        bullet = GetComponent <Rigidbody2D>() ;
     
    }

    
    void Update()
    {
        bullet.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().play("destruction");
            Destroy(gameObject);
            score += 100;
        }
        else if (collision.gameObject.name == "Boss(Clone)")
        {
            BossController.bossHealth--;
            FindObjectOfType<AudioManager>().play("destruction");
            Destroy(gameObject);
            Debug.Log("Health Boss:" + BossController.bossHealth);
        }
        

    }
}
