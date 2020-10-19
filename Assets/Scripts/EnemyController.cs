using UnityEngine;
public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    float rotZ;
    void Start()
    {
        rotZ = transform.rotation.z;
    }
    // Update is called once per frame
    void Update()
    {
        /*Rigidbody2D obj=gameObject.GetComponent<Rigidbody2D>();
        var dir = obj.velocity;
      
        if (dir != Vector2.zero)
            transform.rotation = Quaternion.LookRotation(dir);*/
        transform.Rotate(new Vector3(0, 0,rotZ+2.0f ));
        Destroy(gameObject, 3f);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
