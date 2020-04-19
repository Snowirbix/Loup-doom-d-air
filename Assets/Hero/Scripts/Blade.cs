using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    protected Animator animator;
    protected CircleCollider2D circle;
    public LayerMask enemyLayerMask;

    private void Start()
    {
        animator = gameObject.Q<Animator>();
        circle   = gameObject.Q<CircleCollider2D>();
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position.XY() + circle.offset, circle.radius, enemyLayerMask.value);
        
        //foreach (Collider2D collider in colliders)
        //{
        //    Debug.Log(collider);
        //}
    }
}
