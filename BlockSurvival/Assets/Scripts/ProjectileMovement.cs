using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // Speed at which the object moves
    public float speed = 10f;
    private int bulletMaxCollision = 1;
    private int sniperBulletMaxCollision = 2;
    private int numberOfCollisions;

    // Use this for initialization
    void Start()
    {
        // Set the initial position of the object
    }

    // Update is called once per frame
    void Update()
    {
        FireProjectile();
    }

    void FireProjectile()
    {
        Vector3 movement = Quaternion.Euler(0f, 0f, transform.eulerAngles.z) * Vector3.up * speed * Time.deltaTime;
        transform.position += movement;
    }

    void offScreen()
    {
        // Check if the object is offscreen
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
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
        if (gameObject.tag == "Bullet")
        {
            if (numberOfCollisions >= bulletMaxCollision)
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "SniperBullet")
        {
            if (numberOfCollisions >= sniperBulletMaxCollision)
            {
                Destroy(gameObject);
            }
        }
    }
}
