using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX;
    Vector3 spawnPoint;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    Rigidbody2D enemyBody;
    float randomFallSpeed;
    void Start()
    {
        enemyBody = enemy.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-4.8f, +4.8f);
            randomFallSpeed = Random.Range(0.3f, .7f);
            enemyBody.gravityScale = randomFallSpeed;
            //Debug.Log(enemyBody.gravityScale);
            spawnPoint = new Vector3(randX, transform.position.y);
            Instantiate(enemy, spawnPoint, Quaternion.identity);
            //for testing only
            
        }
    }
}
