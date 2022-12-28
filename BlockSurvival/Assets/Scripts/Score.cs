using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject sniper;

    public int score;
    public bool rareDropSpawned = false;

    void Awake()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RareDrop();
    }

    void RareDrop()
    {
        if (score > 1 && !rareDropSpawned)
        {
            GameObject spawnedPrefab = Instantiate(sniper, new Vector2(7, -1), Quaternion.identity);
            rareDropSpawned = true;
        }
    }
}
