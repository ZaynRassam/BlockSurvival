using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Declare a variable for the player GameObject
    private Score logicManager;
    public int health = 2;
    private float headshotChance = 0.2f;
    private Transform enemyPosition;
    public GameObject deathParticles;

    void Start()
    {
        enemyPosition = gameObject.GetComponent<Transform>();
        logicManager = GameObject.FindWithTag("LogicManager").GetComponent<Score>();
    }
    private void Update()
    {
        deleteEnemyIfHealthZero();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            bulletCollision(other);
        }

        if (other.gameObject.tag == "SniperBullet")
        {
            sniperBulletCollision(other);
        }
    }

    void bulletCollision(Collider2D col)
    {
        if (Random.value < headshotChance)
        {
            health -= 2;
        }
        else
        {
            health--;
        }
    }

    void sniperBulletCollision(Collider2D col)
    {
        if (Random.value < headshotChance)
        {
            health -= 2;
        }
        else
        {
            health--;
        }
    }

    void deleteEnemyIfHealthZero()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject particles = Instantiate(deathParticles, enemyPosition.position, enemyPosition.rotation);
            Destroy(particles);
            logicManager.kills++;
            logicManager.increaseCash("Enemy");
        }
    }
}