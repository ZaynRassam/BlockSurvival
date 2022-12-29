using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayAmmo : MonoBehaviour
{
    public TMP_Text ammoUI;

    public ActiveWeapon activeWeapon;
    public SniperClass sniperClass;
    public ShotgunClass shotgunClass;
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
        else if (activeWeapon.shotgunActive)
        {
            clipAmmo = shotgunClass.shotgunClipAmmo;
            totalAmmo = shotgunClass.shotgunTotalAmmo;
        }
        else
        {
            clipAmmo = pistolClass.pistolClipAmmo;
            totalAmmo = pistolClass.pistolTotalAmmo;
        }

        ammoUI.text = "Ammo: " + clipAmmo.ToString() + '/' + totalAmmo.ToString();
    }
}
