using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGunPicture : MonoBehaviour
{
    public ActiveWeapon activeWeapon;
    public GameObject pistol;
    public GameObject sniper;
    public GameObject shotgun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWeapon.sniperActive)
        {
            sniper.SetActive(true);
            shotgun.SetActive(false);
            pistol.SetActive(false);
        }
        else if (activeWeapon.shotgunActive)
        {
            sniper.SetActive(false);
            shotgun.SetActive(true);
            pistol.SetActive(false);
        }
        else if (activeWeapon.pistolActive)
        {
            sniper.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(true);
        }
    }
}
