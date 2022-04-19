using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{
    [HideInInspector] public UnityEvent movement;

    public bool canMove;
    public float shootSpeed;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement.AddListener(CanMove);
    }

    void Update()
    {
        if (canMove == true)
        {
            float translation = Time.deltaTime * shootSpeed;
            transform.Translate(translation, 0, 0);
        }
    }

    public void SetColor(Color color) 
    {
        spriteRenderer.color = color;
    }

    public void SetVisible() 
    {
        spriteRenderer.enabled = true;
    }

    private void CanMove() 
    {
        canMove = true;
    }

    private void OnBecameInvisible()
    {
        canMove = false;
        Debug.Log("invisible");
    }

}

