using UnityEngine;
public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX;
    Vector3 spawnPoint;
    private float spawnRate = 2f;
    float nextSpawn = 0f;
    Rigidbody2D enemyBody;
    float fallSpeed;
    void Start()
    {
        enemyBody = enemy.gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (BulletController.score < 50)
                firstWave();
            else if (BulletController.score >= 50 && BulletController.score < 100)
                secondWave();
            else
                thirdWave();
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-4.8f, +4.8f);
            enemyBody.gravityScale = fallSpeed;
            //Debug.Log(enemyBody.gravityScale);
            spawnPoint = new Vector3(randX, transform.position.y);
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
    void firstWave()
    {
      
        fallSpeed = Random.Range(0.3f, .7f);
        Debug.Log("FirstWave");
    }
    void secondWave()
    {
        spawnRate = 1f;
        fallSpeed = Random.Range(1.5f, 2f);
        Debug.Log("SecondWave");
    }
    void thirdWave()
    {
        spawnRate = .5f;
        fallSpeed = Random.Range(2.5f, 3f);
        Debug.Log("ThirdWave");
    }
    void boss()
    {
        //TODO
    }
}
