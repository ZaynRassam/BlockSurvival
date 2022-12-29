using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int kills = 0;
    public int cash = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increaseCash(string enemyType)
    {
        if (enemyType == "Enemy") {
            cash += 100;
        }
    }
}
