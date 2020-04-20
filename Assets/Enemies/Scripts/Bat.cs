using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bat : MonoBehaviour
{
    public Transform[] targetPoints;
    public float range = 5f;
    public float reachRange = 0.2f;
    public float moveSpeed = 2f;

    protected Rigidbody2D rgby;
    protected Animator animator;
    protected Collider2D collider;
    protected Transform player;

    protected int currentTarget = 0;
    protected bool targetPlayer = false;

    public Transform clawRotato;
    public Claw claw;

    public float attackCooldown = 2.5f;
    public float lastAttack;

    private void Awake()
    {
        rgby     = gameObject.Q<Rigidbody2D>();
        collider = gameObject.Q<Collider2D>();
        animator = gameObject.Q<Animator>();
    }

    private void Start()
    {
        player   = PlayerController.one.transform;
    }

    private void Update()
    {
        if (targetPlayer == false && (player.position - transform.position).sqrMagnitude < range * range)
        {
            targetPlayer = true;
            PlayerController.one.activeEnemies.Add(gameObject);
        }
        if (targetPlayer && (player.position - transform.position).magnitude > range * 2)
        {
            targetPlayer = false;
            if (PlayerController.one.activeEnemies.Contains(gameObject))
                PlayerController.one.activeEnemies.Remove(gameObject);
        }
        if (targetPlayer)
        {
            MoveAttackPlayer();
        }
        else
        {
            Patrol();
        }
    }

    public void Death ()
    {
        if (PlayerController.one.activeEnemies.Contains(gameObject))
        {
            PlayerController.one.activeEnemies.Remove(gameObject);
            collider.enabled = false;
        }
    }

    protected void MoveAttackPlayer ()
    {
        Vector2 diff = player.position.XY() - transform.position.XY();

        if (diff.magnitude < 2)
        {
            rgby.AddForce(-diff.normalized * moveSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rgby.AddForce(diff.normalized * moveSpeed, ForceMode2D.Impulse);
        }
        
        if (Time.time > lastAttack + attackCooldown)
        {
            lastAttack = Time.time;

            float angle = Mathf.Atan2(diff.normalized.y, diff.normalized.x);
            clawRotato.rotation = Quaternion.AngleAxis((angle * 180 / Mathf.PI) + 180f, Vector3.forward);

            animator.SetTrigger("attack");
            claw.Attack();
        }
    }

    protected void Patrol ()
    {
        Vector2 diff = targetPoints[currentTarget].position.XY() - transform.position.XY();
        
        if (diff.sqrMagnitude < reachRange * reachRange)
        {
            currentTarget++;

            if (currentTarget == targetPoints.Length)
            {
                currentTarget = 0;
            }

            diff = targetPoints[currentTarget].position.XY() - transform.position.XY();
        }
        
        rgby.AddForce(diff.normalized * moveSpeed, ForceMode2D.Impulse);
    }
}
