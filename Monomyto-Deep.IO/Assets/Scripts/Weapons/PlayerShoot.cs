using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootBase
{
    private UIController uIController;
    void Start()
    {
        ammo = currentWeapon.ammo;

        uIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        UpdateAmmo();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public override void SubtractAmmo()
    {
        base.SubtractAmmo();
        UpdateAmmo();
    }

    public void UpdateAmmo()
    {
        uIController.SetAmmo(ammo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag.Equals("Drop"))
        {
            WeaponTypeScriptable weapon = collision.GetComponent<Drop>().weaponType;
            currentWeapon = weapon;
            ammo = weapon.ammo;

            uIController.SetAmmo(ammo);
            Destroy(collision.gameObject);
        }
    }
}
