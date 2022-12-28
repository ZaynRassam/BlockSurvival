using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    // Public field for the prefab to spawn
    public GameObject bullet;
    public GameObject sniperBullet;
    public PickUpSniper sniperScript;
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
            if (sniperScript.sniperActive)
            {
                GameObject spawnedPrefab = Instantiate(sniperBullet, playerTransform.position, playerTransform.rotation);
                Debug.Log(sniperScript.sniperActive);

            }
            else
            {
                GameObject spawnedPrefab = Instantiate(bullet, playerTransform.position, playerTransform.rotation);
                Debug.Log(sniperScript.sniperActive);

            }
        }
    }
}
