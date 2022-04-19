using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShoot : ShootBase
{
    public enum WeaponState { Active, Inactive }
    public WeaponState currentWeaponState;

    [HideInInspector] public UnityEvent attackStart;
    [HideInInspector] public UnityEvent attackEnd;

    private float attackDelay = 1f;
    private bool canAttack = true;

    void Start()
    {
        if (attackStart == null)
            attackStart = new UnityEvent();

        attackStart.AddListener(ActivateAttack);
        attackEnd.AddListener(InactivateAttack);
    }
 
    private void Update()
    {
        if (canAttack == true)
        {
            base.Shoot();
            Invoke(nameof(ResetAttack), attackDelay);
            canAttack = false;
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    public void ActivateAttack()
    {
        canShoot = true;

    }

    public void InactivateAttack()
    {
        canShoot = false;
    }
}
