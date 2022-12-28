using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSniper : MonoBehaviour
{
    public bool sniperActive = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sniper")
        {
            PickedUpSniper();
            Destroy(other.gameObject);
        }
    }

    private void PickedUpSniper()
    {
        sniperActive = true;
        Debug.Log("Picked Up Sniper");
    }
}
