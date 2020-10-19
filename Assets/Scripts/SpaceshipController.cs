using UnityEngine;
using UnityEngine.UI;
/* 
 * To be Read by Faisal & Sunduss only
 * This script is used for the movement of the player spaceship
 * TODO:
 * 
*/
public class SpaceshipController : MonoBehaviour
{
    public float speed=7f;
    public GameObject bullet;
    Vector2 bulletPosition;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    public static int health = 3;
    private int numOfHearts=3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite deadHeart;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        transform.position += MovementDirection * speed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, 0, 15f);
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
        transform.position = clampCamera();
        
    }
    private void fire()
    {
        bulletPosition = transform.position;
        bulletPosition = new Vector2(transform.position.x, transform.position.y+1.5f);
        Instantiate(bullet,bulletPosition,Quaternion.identity);
    }
    private Vector3 clampCamera()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -10f, 10f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5.84f, 5.9f);
        return clampedPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            health--;
            Destroy(collision.gameObject);
            checkHealth();
        }
        //Debug.Log("Current Health" + health);
        if (health == 0)
            Destroy(gameObject);
    }
    void checkHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = deadHeart;
            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
