using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask plateformsLayerMask;
    [SerializeField] private LayerMask wallsLayerMask;
    private Controls controls;

    private Rigidbody2D rgby;
    protected AudioSource audioSource;

    public PlayAudio dashAudio;
    public PlayAudio landAudio;
    public PlayAudio jumpAudio;
    public PlayAudio painAudio;

    public float speed = 6;
    public float jumpVelocity = 15f;
    public float dashVelocity = 15f;
    public float velocityToLand = -5f;
    protected bool falling;

    protected float lastJump;
    protected float lastTimeGrounded;
    public float bonusTimeJump = 0.1f;

    protected float lastDash;
    public float timeToDash = 0.5f;
    public float timeToControlDash = 0.2f;
    public float delayBetweenDash = 1f;

    public float attackCooldown = 0.7f;
    public float lastAttack;

    public float axisFacing = 1;

    public int hp = 3;

    public float midAirControl = 0.2f;

    private Vector2 dashDir;

    private SpriteRenderer spriteRenderer;

    public static PlayerController one;
    private BoxCollider2D boxCollider2D;

    public Transform bladoRotato;
    public Blade blade;
    private Animator animator;

    public HashSet<GameObject> activeEnemies = new HashSet<GameObject>();

    protected Dictionary<GameObject, Vector2> colliders = new Dictionary<GameObject, Vector2>();

    private void Awake()
    {
        one = this;

        controls = new Controls();

        controls.FreeMovement.Jump.started += Jump_started;
        controls.FreeMovement.Attack.started += Attack_started;
        controls.FreeMovement.Dash.started += Dash_started;

        rgby = gameObject.Q<Rigidbody2D>();
        spriteRenderer = gameObject.Q<SpriteRenderer>();
        boxCollider2D = gameObject.Q<BoxCollider2D>();
        animator = gameObject.Q<Animator>();
        audioSource = gameObject.Q<AudioSource>();
    }

    private void Start()
    {
        audioSource.Play();
        audioSource.Pause();
    }

    private void Dash_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(Time.time > lastDash + delayBetweenDash)
        {
            dashDir = controls.FreeMovement.Move.ReadValue<Vector2>();
            if (dashDir.x == 0)
            {
                dashDir = new Vector2(axisFacing, 0);
            }
            else
            {
                dashDir = new Vector2(dashDir.x, 0);
            }

            dashAudio.Play();
            animator.SetTrigger("dash");
            lastDash = Time.time;
        }
    }

    private void Attack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.time > lastAttack + attackCooldown)
        {
            lastAttack = Time.time;

            Vector2 dir = controls.FreeMovement.Move.ReadValue<Vector2>();

            if (dir.Equals(Vector2.zero))
            {
                dir = new Vector2(axisFacing, 0);
            }

            float angle = Mathf.Atan2(dir.y, dir.x);
            bladoRotato.rotation = Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward);
            blade.Attack();
        }
    }

    private void Jump_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // 100ms bonus to jump off platform !
        if (colliders.Count > 0 || Time.time < lastTimeGrounded + bonusTimeJump)
        {
            lastJump = Time.time;
            animator.SetTrigger("jump");
            jumpAudio.Play(Random.Range(1.2f, 1.3f));

            // si au moins une collision est proche de l'horizontal
            if (colliders.Any(x => Vector2.Dot(Vector2.up, x.Value) > 0.2f))
            {
                rgby.velocity = Vector2.up * jumpVelocity;
            }
            else
            {
                Vector2 dir = (Vector2.up + colliders.FirstOrDefault().Value).normalized;
                rgby.velocity = dir * jumpVelocity;
            }
        }
    }

    private void Update()
    {
        Vector2 movement = controls.FreeMovement.Move.ReadValue<Vector2>();
        if(Time.time > lastDash + timeToDash || Time.time < 1f)
        {
            Move(movement);
        }
        else if (Time.time > lastDash + timeToControlDash)
        {
            // give some control for the second part
            float mouvementSpeed = movement.x * speed;

            rgby.velocity = new Vector2(dashDir.x * dashVelocity + mouvementSpeed * 0.15f, rgby.velocity.y);
        }
        else if (Time.time > lastDash)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            rgby.velocity = dashDir * dashVelocity;
        }

        if(rgby.velocity.y < velocityToLand && !falling) 
        {
            falling = true;
            animator.SetTrigger("fly");
        }

        animator.SetFloat("Blend", Mathf.Sqrt(rgby.velocity.x * rgby.velocity.x));

        if(hp == 0)
        {
            Death death = gameObject.Q<Death>();
            death.death();
        }
    }

    public void Move(Vector2 direction)
    {
        float xMovement = direction.x;
        float mouvementSpeed = xMovement * speed;

        // si au moins une collision est proche de l'horizontal
        if (colliders.Any(x => Vector2.Dot(Vector2.up, x.Value) > 0.2f))
        {
            if (xMovement != 0 && !audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
            if (xMovement == 0 && audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            rgby.velocity = new Vector2(mouvementSpeed, rgby.velocity.y);
        }
        else
        // flying
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            rgby.velocity += new Vector2(mouvementSpeed * midAirControl * Time.deltaTime, 0);
            // clamp velocity
            rgby.velocity = new Vector2(Mathf.Clamp(rgby.velocity.x, -speed, speed), rgby.velocity.y);            
        }


        if (Mathf.Sign(xMovement) != axisFacing && xMovement != 0)
        {
            axisFacing = -axisFacing;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector2.Dot(Vector2.up, collision.contacts[0].normal) >= -0.1f)
        {
            if (colliders.Count == 0)
            {
                // if enough down speed and horizontal collision
                if (falling && Vector2.Dot(Vector2.up, collision.contacts[0].normal) > 0.2f)
                {
                    animator.SetTrigger("land");
                    landAudio.Play(Random.Range(1.1f, 1.2f));
                }
                else
                {
                    animator.SetTrigger("quickland");
                }
                animator.ResetTrigger("fly");
                animator.ResetTrigger("jump");
            }
            colliders.Add(collision.gameObject, collision.contacts[0].normal);
            falling = false;
        }
        else
        {
            Debug.Log("Collision upward ignored");
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (colliders.ContainsKey(collision.gameObject))
        {
            colliders[collision.gameObject] = collision.contacts[0].normal;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (colliders.ContainsKey(collision.gameObject))
        {
            colliders.Remove(collision.gameObject);

            if (colliders.Count == 0)
            {
                lastTimeGrounded = Time.time;
            }
        }
    }

    private void OnEnable()
    {
        controls.FreeMovement.Enable();
    }

    private void OnDisable()
    {
        controls.FreeMovement.Disable();
    }
    
    public void Hit ()
    {
        painAudio.Play();
    }
}
