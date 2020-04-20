using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float speed = 1f;

    public Transform spotLeft;
    public Transform spotRight;
    public Transform spotFree;

    protected PlayerController player;
    protected Rigidbody2D rgby;
    protected Collider2D collider;

    private SpriteRenderer sprite;

    private void Start()
    {
        player = PlayerController.one;
        rgby = gameObject.Q<Rigidbody2D>();
        collider = gameObject.Q<Collider2D>();
        sprite = gameObject.Q<SpriteRenderer>();
    }

    private void Update()
    {
        //CloseCombat();
        Twirl();
        Facing();
    }

    protected void CloseCombat ()
    {
        Vector2 target;

        if (player.axisFacing > 0)
        {
            target = spotLeft.position;
        }
        else
        {
            target = spotRight.position;
        }

        Vector2 diff = target - transform.position.XY();
        float length = diff.magnitude;

        if (length > 4f)
        {
            collider.enabled = false;
        }
        else if (!collider.enabled)
        {
            collider.enabled = true;
        }

        // Smooth
        Vector2 dir = diff.normalized * Mathf.Sqrt(length);

        rgby.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    protected void Twirl ()
    {
        Vector2 target;

        target = spotFree.position;

        Vector2 diff = target - transform.position.XY();
        float length = diff.magnitude;

        if (length > 4f)
        {
            collider.enabled = false;
        }
        else if (!collider.enabled)
        {
            collider.enabled = true;
        }
        else if (length < 2f)
        {
            length = length/3f;
        }
        
        // Smooth
        Vector2 dir = diff.normalized * Mathf.Sqrt(length);

        rgby.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    void Facing()
    {
        if(transform.position.x > player.transform.position.x && !sprite.flipX)
        {
            sprite.flipX = !sprite.flipX;
        }
        else if(transform.position.x < player.transform.position.x && sprite.flipX)
        {
            sprite.flipX = !sprite.flipX;
        }
    }
}
