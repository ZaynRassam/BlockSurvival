using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public Score score;
    public TMP_Text scoreUI;


    void Update()
    {
        scoreUI.text = "Kills: " + score.kills.ToString()
                      +"\nCash: " + score.cash.ToString();
    }
}
