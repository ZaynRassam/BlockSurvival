using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Declare a variable for the player GameObject
    public Transform target;
    private NavMeshAgent agent;
    private int health = 1;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(target.position);
        deleteEnemyIfHealthZero();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            health--;
        }
    }

    void deleteEnemyIfHealthZero()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}