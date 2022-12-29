using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunClass : MonoBehaviour
{
    [System.NonSerialized] public Transform playerTransform;
    public GameObject shotgunBullet;
    public ActiveWeapon activeWeaponScript;
    public int shotgunClipAmmoForReset = 3;
    public int shotgunTotalAmmoForReset = 20;
    private int shotgunMagazineSize = 3;
    public int shotgunClipAmmo = 3;
    public int shotgunTotalAmmo = 20;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeWeaponScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ActiveWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        if (activeWeaponScript.shotgunActive)
        {
            ShotgunBulletSpawn();
        }

        if ((Input.GetKeyDown(KeyCode.R) || shotgunClipAmmo == 0) && shotgunTotalAmmo > 0)
        {
            StartCoroutine(Reload());
        }
    }

    void ShotgunBulletSpawn()
    {
        if (shotgunClipAmmo <= shotgunMagazineSize && shotgunClipAmmo > 0 && shotgunTotalAmmo >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject spawnedPrefab = Instantiate(shotgunBullet, playerTransform.position, playerTransform.rotation);
                GameObject spawnedPrefab2 = Instantiate(shotgunBullet, playerTransform.position, playerTransform.rotation);
                spawnedPrefab2.transform.Rotate(0, 0, 10);
                GameObject spawnedPrefab3 = Instantiate(shotgunBullet, playerTransform.position, playerTransform.rotation);
                spawnedPrefab3.transform.Rotate(0, 0, -10);
                shotgunClipAmmo--;
            }
        }
    }


    IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(2);

        int bulletsMissing = shotgunMagazineSize - shotgunClipAmmo;
        if (shotgunTotalAmmo >= bulletsMissing)
        {
            shotgunClipAmmo += bulletsMissing;
            shotgunTotalAmmo -= bulletsMissing;
        }
        else
        {
            shotgunClipAmmo += shotgunTotalAmmo;
            shotgunTotalAmmo = 0;
        }
    }

    public void ShotgunResetAmmo()
    {
        shotgunClipAmmo = shotgunClipAmmoForReset;
        shotgunTotalAmmo = shotgunTotalAmmoForReset;
    }
}
