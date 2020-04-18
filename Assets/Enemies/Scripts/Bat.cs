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
    protected Collider2D collider;
    protected Transform player;

    protected int currentTarget = 0;
    protected bool targetPlayer = false;

    private void Awake()
    {
        rgby     = gameObject.Q<Rigidbody2D>();
        collider = gameObject.Q<Collider2D>();
    }

    private void Start()
    {
        player   = PlayerController.one.transform;
    }

    private void Update()
    {
        if ((player.position - transform.position).sqrMagnitude < range * range)
        {
            targetPlayer = true;
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

    protected void MoveAttackPlayer ()
    {
        Vector2 diff = player.position.XY() - transform.position.XY();
        
        // todo : use forces
        rgby.SetVelocity(diff.normalized * moveSpeed);
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
        
        // todo : use forces
        rgby.SetVelocity(diff.normalized * moveSpeed);
    }
}
