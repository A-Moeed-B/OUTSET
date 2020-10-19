using UnityEngine;
public class BulletController : MonoBehaviour
{
    private float velX = 0f;
    public float velY = 8F;
    Rigidbody2D bullet;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent <Rigidbody2D>() ;
    }

    // Update is called once per frame
    void Update()
    {
        bullet.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Enemy(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            score+=10;
        }
     
    }
}
