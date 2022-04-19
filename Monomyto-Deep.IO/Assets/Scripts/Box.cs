using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameController gameController;

    [SerializeField] private int pointsValue;
    [SerializeField] private int dropChance = 5;
    [SerializeField] private Drop drop;
    [SerializeField] private WeaponTypeScriptable simple;
    [SerializeField] private WeaponTypeScriptable composed;

    public void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void SpawnDrop()
    {
        int chance = Random.Range(1, 10);

        if (chance > dropChance)
        {
            Debug.Log("Drop Weapon");
            int weaponChance = Random.Range(1, 10);
            Instantiate(drop.gameObject, transform.position, Quaternion.identity);

            if (weaponChance <= 5)
            {
                drop.weaponType = simple;
            }
            else if (weaponChance > 5)
            {
                drop.weaponType = composed;
            }
        }
    }

    private void DestroyObj() 
    {
        gameController.AddPoint(pointsValue);
        Destroy(gameObject);
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") || collision.tag.Equals("Player") || collision.tag.Equals("Bullet"))
        {
            SpawnDrop();
            DestroyObj();
        }
    }
}
