using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    protected Animator animator;
    protected CircleCollider2D circle;
    protected AudioSource audioSource;
    public LayerMask enemyLayerMask;
    public LayerMask groundLayerMask;
    public float knockBackForce = 20f;
    public float selfKnockBackForce = 15f;
    public GameObject player;
    public PlayAudio hitAudio;
    public PlayAudio hitGroundAudio;
    public PlayAudio finalBlowAudio;

    public GameObject prefabHitPixel;
    public GameObject prefabHitPixelLine;
    public GameObject prefabHitPixelLine2;

    HashSet<GameObject> colliders = new HashSet<GameObject>();

    private void Start()
    {
        animator = gameObject.Q<Animator>();
        circle   = gameObject.Q<CircleCollider2D>();
        audioSource = gameObject.Q<AudioSource>();
    }

    protected void AnimationEvent_Hit()
    {
        bool hitEnemy = false;
        bool hitGround = false;

        foreach (GameObject collider in colliders)
        {
            if (enemyLayerMask.Contains(collider.layer))
            {
                hitEnemy = true;
                Vector2 dir = (collider.Position() - player.Position()).normalized;

                if (Vector2.Dot(dir, Vector2.down) > 0.707f)
                {
                    player.Q<Rigidbody2D>().SetVelocity(-dir * selfKnockBackForce);
                }
        
                float angle = Mathf.Atan2(dir.y, dir.x);

                Instantiate(prefabHitPixelLine, collider.transform.position, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward), collider.transform);
                Instantiate(prefabHitPixelLine2,  player.transform.position, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward), player.transform);

                collider.Q<Rigidbody2D>().AddForce(dir * knockBackForce, ForceMode2D.Impulse);
                if (collider.Q<Health>().Hit(1))
                {
                    finalBlowAudio.Play(Random.Range(0.95f, 1.05f));
                    Instantiate(prefabHitPixel, collider.transform.position, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward));
                }
                else
                {
                    hitAudio.Play(Random.Range(1f, 1.2f));
                }
            }
            else if (groundLayerMask.Contains(collider.layer))
            {
                hitGround = true;
            }
        }

        if (hitEnemy && hitGround)
        {
            hitGroundAudio.Play(Random.Range(1.15f, 1.20f));
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
        colliders.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision.gameObject);
    }
}
