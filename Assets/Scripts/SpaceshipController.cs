using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * To be Read by Faisal & Sunduss only
 * This script is used for the movement of the player spaceship
 * This will move at the speed of 5.
 * Gravity has been set to 0 so that the player does not fall
 * after moving vertically and stays in its location 
 * unless its updated
 * TODO:
 * 1- Refine Movement
 * 2- Add Collision detectors on the side of the map-DONE
 * 3- (Related to Level_001) Add textures and sprites  
 * 4- Issues with movement; automatically moves to the Left/Right-
 * 5- Finiky Bullet Physics???-DONE
 * 
 * right after collision-
*/
public class SpaceshipController : MonoBehaviour
{
    public float speed=5f;
    public GameObject bullet;
    Vector2 bulletPosition;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    public static int health = 10;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        transform.position += MovementDirection * speed * Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }

    }
    void fire()
    {
        bulletPosition = transform.position;
        bulletPosition = new Vector2(transform.position.x, 0.76f);
        Instantiate(bullet,bulletPosition,Quaternion.identity);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
            health--;
        Debug.Log("Current Health" + health);
        if (health == 0)
            Destroy(gameObject);
    }
}
