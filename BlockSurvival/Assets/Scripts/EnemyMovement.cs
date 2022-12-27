using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Declare a variable for the player GameObject
    private Score logicManager;
    public Transform target;
    private NavMeshAgent agent;
    private int health = 2;
    private float bulletHeadshotChance = 0.5f;

    void Start()
    {
        logicManager = GameObject.FindWithTag("LogicManager").GetComponent<Score>();
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
            bulletCollision(other);
        }
    }

    void bulletCollision(Collider2D col)
    {
        if (Random.value < bulletHeadshotChance)
        {
            health -= 2;
            Debug.Log("HEADSHOT");
        }
        else
        {
            health--;
        }
    }

    void deleteEnemyIfHealthZero()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            logicManager.score++;
        }
    }
}