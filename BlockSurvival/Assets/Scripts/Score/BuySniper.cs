using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySniper : MonoBehaviour
{
    public ActiveWeapon activeWeapon;
    public Score score;
    public SniperClass sniperClass;
    private int sniperCost = 500;
    private bool nearSniper = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nearSniper)
        {
            BuyingSniper();
        }
    }

    void BuyingSniper()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!activeWeapon.sniperActive)
            {
                if (score.cash >= sniperCost)
                {
                    activeWeapon.PickedUpSniper();
                }
                else
                {
                    Debug.Log("Insufficient Funds");
                }
            }
            else
            {
                if (sniperClass.sniperTotalAmmo < sniperClass.sniperTotalAmmoForReset)
                {
                    activeWeapon.PickedUpSniperAmmo();
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
            nearSniper = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearSniper = false;
        }
    }
}
