using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [HideInInspector] public GameController gameController;

    public int charLife;
    public float speed = 5f;
    public float rotationSpeed = 360f;

    public virtual void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public virtual void Damage()
    {
        charLife--;

        if (charLife <= 0)
        {
            CharDeath(); 
        }
    }

    public virtual void CharDeath() 
    {
        Debug.Log("Destroy!");
    }

    public virtual void Move(){ }
    
    public virtual void Rotate(){ }

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Box"))
        {
            Damage();
        }
        if (collision.tag.Equals("Bullet"))
        {
            Damage();
            collision.transform.position = collision.transform.parent.position;
        }
    }
}
