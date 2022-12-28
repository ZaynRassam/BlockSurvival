using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayAmmo : MonoBehaviour
{
    public TMP_Text ammoUI;

    public ActiveWeapon activeWeapon;
    public SniperClass sniperClass;
    public PistolClass pistolClass;

    private int clipAmmo;
    private int totalAmmo;


    void Update()
    {
        if (activeWeapon.sniperActive)
        {
            clipAmmo = sniperClass.sniperClipAmmo;
            totalAmmo = sniperClass.sniperTotalAmmo;
        }
        else
        {
            clipAmmo = pistolClass.pistolClipAmmo;
            totalAmmo = pistolClass.pistolTotalAmmo;
        }

        ammoUI.text = "Ammo: " + clipAmmo.ToString() + '/' + totalAmmo.ToString();
    }
}
