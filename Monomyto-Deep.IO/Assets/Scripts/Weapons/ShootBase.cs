using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBase : MonoBehaviour
{
    public WeaponTypeScriptable startWeapon;
    public WeaponTypeScriptable currentWeapon;
    public GameObject[] spawnAnchor;
    public BulletController[] bullet;
    public int ammo;
    public bool canShoot;
    public float delay;

    private int currentBulletPooling;

    public virtual void Shoot()
    {
        if (canShoot == true)
        {
            for (int i = 0; i < currentWeapon.projectiles; i++)
            {
                BulletSpawn(bullet[currentBulletPooling], i);
                IncrementCurrentBullet();
            }
            if (currentWeapon.weaponType != WeaponTypeScriptable.WeaponType.Start)
            {
                SubtractAmmo();
            }
            canShoot = false;
            Invoke(nameof(ResetCanShoot), delay);
        }
    }

    private void BulletSpawn(BulletController bulletSelected,int i)
    {
        bulletSelected.SetVisible();
        bulletSelected.transform.position = spawnAnchor[i].transform.position;
        bulletSelected.transform.rotation = transform.rotation;
        bulletSelected.SetColor(currentWeapon.bulletCollor);
        bulletSelected.movement.Invoke();
    }

    private void IncrementCurrentBullet()
    {
        currentBulletPooling++;

        if (currentBulletPooling >= bullet.Length)
        {
            currentBulletPooling = 0;
        }
    }

    public virtual void SubtractAmmo()
    {
        ammo--;
        if (ammo <= 0)
        {
            currentWeapon = startWeapon;
        }
    }

    public void ResetCanShoot() 
    {
        canShoot = true;
    }
}
