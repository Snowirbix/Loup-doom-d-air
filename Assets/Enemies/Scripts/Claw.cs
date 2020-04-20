using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    protected Animator animator;
    protected CircleCollider2D circle;
    protected AudioSource audioSource;

    public float knockBackForce = 20f;
    protected PlayerController player;
    protected bool playerIn = false;

    private void Start()
    {
        animator = gameObject.Q<Animator>();
        circle = gameObject.Q<CircleCollider2D>();
        audioSource = gameObject.Q<AudioSource>();
        player = PlayerController.one;
    }

    public void Attack ()
    {
        animator.SetTrigger("attack");
        
        if (!audioSource.isPlaying)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
    }
    
    protected void AnimationEvent_Hit()
    {
        if (playerIn)
        {
            Vector2 diff = player.gameObject.Position() - transform.position.XY();
            Debug.Log("HIT");
            player.hp--;
            player.gameObject.Q<Rigidbody2D>().SetVelocity(diff.normalized * knockBackForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            playerIn = false;
        }
    }
}
