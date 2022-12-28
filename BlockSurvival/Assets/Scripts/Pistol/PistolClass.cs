using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolClass : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject pistolBullet;
    public ActiveWeapon activeWeaponScript;
    [System.NonSerialized] public int pistolTotalAmmoForReset = 20;
    private int pistolMagazineSize = 3;
    public int pistolClipAmmo = 3;
    public int pistolTotalAmmo = 20;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeWeaponScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ActiveWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWeaponScript.pistolActive)
        {
            PistolBulletSpawn();
        }

        if ((Input.GetKeyDown(KeyCode.R) || pistolClipAmmo == 0) && pistolTotalAmmo > 0)
        {
            Reload();
        }
    }

    void PistolBulletSpawn()
    {
        if (pistolClipAmmo <= pistolMagazineSize && pistolClipAmmo > 0 && pistolTotalAmmo >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject spawnedPrefab = Instantiate(pistolBullet, playerTransform.position, playerTransform.rotation);
                pistolClipAmmo--;
            }
        }
    }

    void Reload()
    {
        int bulletsMissing = pistolMagazineSize - pistolClipAmmo;
        if (pistolTotalAmmo >= bulletsMissing)
        {
            pistolClipAmmo += bulletsMissing;
            pistolTotalAmmo -= bulletsMissing;
        }
        else
        {
            pistolClipAmmo += pistolTotalAmmo;
            pistolTotalAmmo = 0;
        }
    }
}
