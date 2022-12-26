using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed at which the player moves
    public float speed = 30f;

    private Rigidbody2D rb;
    public GameObject region;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Movement();
        LookAtMouse();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

     private void LookAtMouse()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");
        }
    }
}