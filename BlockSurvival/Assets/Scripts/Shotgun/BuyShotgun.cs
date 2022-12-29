using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShotgun : MonoBehaviour
{
    public ActiveWeapon activeWeapon;
    public Score score;
    public ShotgunClass shotgunClass;
    private int shotgunCost = 500;
    private bool nearShotgun = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nearShotgun)
        {
            BuyingShotgun();
        }
    }

    void BuyingShotgun()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!activeWeapon.shotgunActive)
            {
                if (score.cash >= shotgunCost)
                {
                    activeWeapon.PickedUpShotgun();
                    shotgunClass.ShotgunResetAmmo();

                }
                else
                {
                    Debug.Log("Insufficient Funds");
                }
            }
            else
            {
                if (shotgunClass.shotgunTotalAmmo < shotgunClass.shotgunTotalAmmoForReset)
                {
                    activeWeapon.PickedUpShotgunAmmo();
                }
                else
                {
                    Debug.Log("Ammo Full");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearShotgun = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearShotgun = false;
        }
    }
}
