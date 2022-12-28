using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletClass : MonoBehaviour
{
    public float speed = 15;
    private int pistolBulletMaxCollision = 1;
    private int numberOfCollisions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PistolBulletMove();
    }

    void PistolBulletMove()
    {
        Vector3 movement = Quaternion.Euler(0f, 0f, transform.eulerAngles.z) * Vector3.up * speed * Time.deltaTime;
        transform.position += movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            numberOfCollisions++;
            MaxedCollisionsReached();
        }
    }

    void MaxedCollisionsReached()
    {
        if (numberOfCollisions >= pistolBulletMaxCollision)
        {
            Destroy(gameObject);
        }
    }
}
