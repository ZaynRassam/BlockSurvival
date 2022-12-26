using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Public field for the prefab to spawn
    public GameObject prefab;
    public Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        // Check if the mouse button has been pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Create an instance of the prefab and set its transform to match the player's transform
            GameObject spawnedPrefab = Instantiate(prefab, playerTransform.position, playerTransform.rotation);
        }
    }
}
