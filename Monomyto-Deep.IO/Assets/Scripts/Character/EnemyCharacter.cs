using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    public enum State { Idle, Awareness, Chase, Attack }
    public State charState;
    public int pointsValue;

    [SerializeField] private int awarenessDistance = 10;
    [SerializeField] private int chaseDistance = 5;
    [SerializeField] private int attackDistance = 2;

    private PlayerCharacter player;
    private EnemyShoot EnemyShoot;

    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        EnemyShoot = GetComponent<EnemyShoot>();
    }

    public void Update()
    {
        CalculateDistance();
        switch (charState)
        {
            case State.Idle:
                break;
            case State.Awareness:
                Awareness();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                Attack();
                break;
        }
    }

    private void Awareness()
    {
        Rotate();
        EnemyShoot.attackEnd.Invoke();
    }

    private void Chase() 
    {
        Move();
        Rotate();
        EnemyShoot.attackEnd.Invoke();
    }

    private void Attack() 
    {
        Rotate();
        EnemyShoot.attackStart.Invoke();
    }

    public override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public override void Rotate()
    {
        float angle = AngleBetweenTwoPoints(player.transform.position, transform.position);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void CalculateDistance()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance > awarenessDistance)
        {
            charState = State.Idle;
        }
        else if (distance < awarenessDistance && distance > chaseDistance)
        {
            charState = State.Awareness;
        }
        else if (distance < chaseDistance && distance > attackDistance)
        {
            charState = State.Chase;
        }
        else if (distance < attackDistance)
        {
            charState = State.Attack;
        }
    }

    public override void CharDeath()
    {
        base.CharDeath();
        gameController.AddPoint(pointsValue);
        Destroy(gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.tag.Equals("Player"))
        {
            base.Damage();
        }
    }
}
