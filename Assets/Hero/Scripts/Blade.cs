using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    protected Animator animator;
    protected CircleCollider2D circle;
    protected AudioSource audioSource;
    public LayerMask enemyLayerMask;
    public float knockBackForce = 20f;
    public float selfKnockBackForce = 15f;
    public GameObject player;
    public PlayAudio hitAudio;

    public GameObject prefabHitPixel;
    public GameObject prefabHitPixelLine;

    HashSet<GameObject> colliders = new HashSet<GameObject>();

    private void Start()
    {
        animator = gameObject.Q<Animator>();
        circle   = gameObject.Q<CircleCollider2D>();
        audioSource = gameObject.Q<AudioSource>();
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
        
            float angle = Mathf.Atan2(dir.y, dir.x);

            Instantiate(prefabHitPixel, enemy.transform.position, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward), enemy.transform);
            Instantiate(prefabHitPixelLine, enemy.transform.position, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward), enemy.transform);

            enemy.Q<Rigidbody2D>().AddForce(dir * knockBackForce, ForceMode2D.Impulse);
            enemy.Q<Health>().Hit(1);

            hitAudio.Play(Random.Range(1f, 1.2f));
        }
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
        if (!audioSource.isPlaying)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
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
