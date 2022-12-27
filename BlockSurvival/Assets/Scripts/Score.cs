using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score;

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
        Debug.Log(score);
        RareDrop();
    }

    void RareDrop()
    {
        if (score > 3)
        {
            Debug.Log("Rare Drop");
        }
    }
}
