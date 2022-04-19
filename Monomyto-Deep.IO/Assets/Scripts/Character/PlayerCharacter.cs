using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    private UIController uIController;

    public override void Start()
    {
        base.Start();
       
        uIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        uIController.SetLife(charLife);
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public override void Move()
    {
        float translation = Input.GetAxis("Vertical") * speed;

        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0);
    }

    public override void Rotate()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    public override void Damage()
    {
        base.Damage();
        uIController.SetLife(charLife);
    }

    public override void CharDeath()
    {
        base.CharDeath();
        gameController.EndGame();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.tag.Equals("Enemy"))
        {
            base.Damage();
        }
    }
}
