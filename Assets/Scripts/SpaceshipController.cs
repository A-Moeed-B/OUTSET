using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 7f;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public static int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite deadHeart;
    public Joystick input;
    public Button fireButton;
    public static float scoreRate = 0.8f;
    private float nextScore = 0f;
    private Vector2 bulletPosition;
    private float nextFire = 0f;
    private int numOfHearts = 3;
    // Start is called before the first frame update
    void Start()
    {
        fireButton.onClick.AddListener(fire);
    }
    void Update()
    {
        //for mobile
        Vector3 MovementDirection = new Vector3(input.Horizontal, input.Vertical, 0);
        transform.position += MovementDirection * speed * Time.deltaTime;
        scoreUpdate();
        addTilt();

        transform.position = clampCamera();

    }
    void scoreUpdate()
    {

        if (Time.time > nextScore)
        {
            nextScore = Time.time + scoreRate;
            BulletController.score += 10;
        }
    }
    private void fire()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bulletPosition = transform.position;
            bulletPosition = new Vector2(transform.position.x, transform.position.y + 1.5f);
            Instantiate(bullet, bulletPosition, Quaternion.identity);

        }

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
        else if (collision.gameObject.name == "Boss(Clone)")
            Destroy(gameObject);
        if (health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    private void checkHealth()
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
    private void addTilt()
    {
        if (input.Horizontal < 0)
            transform.localEulerAngles = new Vector3(0, 0, 15f);
        else if (input.Horizontal > 0)
            transform.localEulerAngles = new Vector3(0, 0, -15f);
        else
            transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    public static void endLevel()
    {
        PlayerPrefs.SetInt("SCORE", BulletController.score);
        BulletController.score = 0;
        health = 3;
        BackgroundController.backSpeed = 0.1f;
        BossController.bossHealth = 10;
    }
}
