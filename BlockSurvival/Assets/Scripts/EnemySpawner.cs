using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;



public class EnemySpawner : MonoBehaviour
{
    // Declare variables for the minimum and maximum x and y values for the random position
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Declare a variable for the player GameObject
    public GameObject player;
    public GameObject enemy;
    // Declare a variable for the minimum distance from the player
    public float minDistance;
    // Declare a variable to store the current number of prefabs that have been spawned
    private int maxNumberEnemies = 5;

    public List<GameObject> enemiesList = new List<GameObject>();

    public void Start()
    {
        StartTimer(enemy);
    }

    public void Update()
    {
        enemiesList.RemoveAll(GameObject => GameObject == null);
    }


    // Function to start the timer
    public void StartTimer(GameObject enemy)
    {
        InvokeRepeating("SpawnPrefab", 0, Random.Range(0f, 5f));
    }



    // Function to spawn the prefab
    public void SpawnPrefab()
    {

        // Check if the current number of prefabs is less than the maximum allowed
        if (enemiesList.Count < maxNumberEnemies)
        {
            // Generate a random float value for the x position
            float x = Random.Range(minX, maxX);
            // Generate a random float value for the y position
            float y = Random.Range(minY, maxY);

            // Calculate the distance between the player and the randomly generated position
            float distance = Vector2.Distance(new Vector2(x, y), player.transform.position);

            // If the distance is less than the minimum distance, adjust the position to be at the minimum distance away from the player
            if (distance < minDistance)
            {
                // Calculate the angle between the player and the position
                float angle = Mathf.Atan2(y - player.transform.position.y, x - player.transform.position.x);
                // Calculate the new x and y positions at the minimum distance from the player
                x = player.transform.position.x + minDistance * Mathf.Cos(angle);
                y = player.transform.position.y + minDistance * Mathf.Sin(angle);
            }

            GameObject spawnedPrefab = Instantiate(enemy, new Vector2(x, y), Quaternion.identity);
            setRotationToZero(spawnedPrefab);
            enemiesList.Add(spawnedPrefab);
        }
    }

    private GameObject setRotationToZero(GameObject ob)
    {
        Debug.Log(ob.transform.rotation.x);
        Debug.Log(ob.transform.rotation.y);
        Debug.Log(ob.transform.rotation.z);
        if (ob.transform.rotation.x == -90)
        {
            ob.transform.rotation = new Quaternion(0, 0, 0, 0);
            return ob;
        }
        else
        {
            return ob;
        }
    }
}

