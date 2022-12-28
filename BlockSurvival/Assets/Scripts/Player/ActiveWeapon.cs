using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public bool pistolActive = true;
    public bool sniperActive = false;
    public SniperClass sniperClass;
    public Score score;


    void Start()
    {
    }

    public void PickedUpSniper()
    {
        pistolActive = false;
        sniperActive = true;
        score.cash -= 500;
        Debug.Log("Picked Up Sniper");
    }

    public void PickedUpSniperAmmo()
    {
        sniperClass.sniperTotalAmmo = sniperClass.sniperTotalAmmoForReset;
        score.cash -= 200;
        Debug.Log("Picked Up Sniper Ammo");
    }
}
