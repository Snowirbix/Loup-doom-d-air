using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    protected Animator animator;
    protected CircleCollider2D circle;
    public LayerMask enemyLayerMask;
    public float knockBackForce = 20f;
    public float selfKnockBackForce = 15f;
    public GameObject player;

    HashSet<GameObject> colliders = new HashSet<GameObject>();

    private void Start()
    {
        animator = gameObject.Q<Animator>();
        circle   = gameObject.Q<CircleCollider2D>();
    }

    protected void AnimationEvent_Hit()
    {
        foreach (GameObject enemy in colliders)
        {
            Vector2 dir = (enemy.Position() - player.Position()).normalized;
            if (Vector2.Dot(dir, Vector2.down) > 0.707f)
            {
                player.Q<Rigidbody2D>().SetVelocity(-dir * selfKnockBackForce);
            }
            enemy.Q<Rigidbody2D>().AddForce(dir * knockBackForce, ForceMode2D.Impulse);
            enemy.Q<Health>().Hit(1);
        }
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyLayerMask.Contains(collision.gameObject.layer))
        {
            colliders.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemyLayerMask.Contains(collision.gameObject.layer))
        {
            colliders.Remove(collision.gameObject);
        }
    }
}
