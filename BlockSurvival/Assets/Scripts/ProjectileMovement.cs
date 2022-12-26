using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // Speed at which the object moves
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {
        // Set the initial position of the object
    }

    // Update is called once per frame
    void Update()
    {
        FireProjectile();
        offScreen();
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
}
