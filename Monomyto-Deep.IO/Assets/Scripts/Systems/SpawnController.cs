using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int enemyAmmount;

    [SerializeField] private GameObject box;
    [SerializeField] private int boxAmmount;

    void Awake()
    {
        Spawn(enemy, enemyAmmount);
        Spawn(box, boxAmmount);
    }

    private void Spawn(GameObject prefab, int ammount) 
    {
        for (int i = 0; i < ammount; i++)
        {
            Vector3 pos = new Vector3(Random.value, Random.value, 10);
            pos = Camera.main.ViewportToWorldPoint(pos);

            Instantiate(prefab, pos, Quaternion.identity);

            Debug.Log("enemy created");
        }
    } 
}
