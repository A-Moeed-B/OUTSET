using UnityEngine;
/** This script is used to spawn the enemes
 * TODO: update description
 * 
 * 
 *
 *
 */
public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject enemy;
    public GameObject [] randomEnemies;
    float randX;
    Vector3 spawnPoint;
    private float spawnRate = 2f;
    float nextSpawn = 0f;
    Rigidbody2D enemyBody;
    float fallSpeed;
    int randomNumber;
    public GameObject bossEnemy;
    private bool bossSpawn=false;
    void Start()
    {
        //enemyBody = enemy.gameObject.GetComponent<Rigidbody2D>();
        for (int i = 0; i < 8; i++)
            randomEnemies[i].gameObject.name = "Enemy";
        bossEnemy.gameObject.name = "Boss";
    }
    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, 7);
        enemyBody = randomEnemies[randomNumber].GetComponent<Rigidbody2D>();
    
        if (Time.time > nextSpawn)
        {
            if (BulletController.score < 500)
                firstWave();
            else if (BulletController.score >= 500 && BulletController.score < 1000)
                secondWave();
            else if (BulletController.score >= 1000 && BulletController.score < 1500)
                thirdWave();
            else if (BulletController.score >= 1500 && !bossSpawn) 
                boss();
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-4.8f, +4.8f);
            enemyBody.gravityScale = fallSpeed;
            //Debug.Log(enemyBody.gravityScale);
            spawnPoint = new Vector3(randX, transform.position.y);
            if(!bossSpawn)
                Instantiate(randomEnemies[randomNumber], spawnPoint, Quaternion.identity);
        }
    }
    
    void firstWave()
    {
       
        fallSpeed = Random.Range(0.3f, .7f);
        Debug.Log("FirstWave");
    }
    void secondWave()
    {
        BackgroundController.backSpeed = 0.5f;
        SpaceshipController.scoreRate = 0.5f;
        spawnRate = 1f;
        fallSpeed = Random.Range(1.5f, 2f);
        Debug.Log("SecondWave");
    }
    void thirdWave()
    {
        BackgroundController.backSpeed = 0.7f;
        SpaceshipController.scoreRate = 0.3f;
        spawnRate = .5f;
        fallSpeed = Random.Range(2.5f, 3f);
        Debug.Log("ThirdWave");
    }
    void boss()
    {
        //TODO
        enemyBody = bossEnemy.GetComponent<Rigidbody2D>();
        fallSpeed = 0.02f;
        spawnPoint.x = transform.position.x;
        spawnPoint.y = transform.position.y;
        enemyBody.gravityScale = fallSpeed;
        Instantiate(bossEnemy, spawnPoint,bossEnemy.transform.rotation);
        bossSpawn = true;
    }
}
