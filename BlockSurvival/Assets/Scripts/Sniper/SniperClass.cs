using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperClass : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject sniperBullet;
    public ActiveWeapon activeWeaponScript;
    [System.NonSerialized] public int sniperTotalAmmoForReset = 20;
    private int sniperMagazineSize = 3;
    public int sniperClipAmmo = 3;
    public int sniperTotalAmmo = 20;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeWeaponScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ActiveWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        if (activeWeaponScript.sniperActive)
        {
            SniperBulletSpawn();
        }

        if ((Input.GetKeyDown(KeyCode.R) || sniperClipAmmo == 0) && sniperTotalAmmo > 0)
        {
            Reload();
        }
    }

    void SniperBulletSpawn()
    {
        if (sniperClipAmmo <= sniperMagazineSize && sniperClipAmmo > 0 && sniperTotalAmmo >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject spawnedPrefab = Instantiate(sniperBullet, playerTransform.position, playerTransform.rotation);
                sniperClipAmmo--;
            }
        }
    }

    void Reload()
    {
        int bulletsMissing = sniperMagazineSize - sniperClipAmmo;
        if (sniperTotalAmmo >= bulletsMissing)
        {
            sniperClipAmmo += bulletsMissing;
            sniperTotalAmmo -= bulletsMissing;
        }
        else
        {
            sniperClipAmmo += sniperTotalAmmo;
            sniperTotalAmmo = 0;
        }
    }
}
