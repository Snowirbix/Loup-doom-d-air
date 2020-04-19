using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask plateformsLayerMask;
    [SerializeField] private LayerMask wallsLayerMask;
    private Controls controls;

    private Rigidbody2D rgby;

    public float speed = 6;
    public float jumpVelocity = 15f;

    protected float lastJump;
    protected float lastTimeGrounded;
    public float bonusTimeJump = 0.1f;

    private float axisFacing = 1;

    private SpriteRenderer spriteRenderer;

    public static PlayerController one;
    private BoxCollider2D boxCollider2D;

    public Transform bladoRotato;
    public Blade blade;
    private Animator animator;

    protected Dictionary<GameObject, Vector2> colliders = new Dictionary<GameObject, Vector2>();

    private void Awake()
    {
        one = this;

        controls = new Controls();

        controls.FreeMovement.Jump.started += Jump_started;
        controls.FreeMovement.Attack.started += Attack_started;

        rgby = gameObject.Q<Rigidbody2D>();
        spriteRenderer = gameObject.Q<SpriteRenderer>();
        boxCollider2D = gameObject.Q<BoxCollider2D>();
        animator = gameObject.Q<Animator>();
    }

    private void Attack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 dir = controls.FreeMovement.Move.ReadValue<Vector2>();
        float angle = Mathf.Atan2(dir.y, dir.x);
        bladoRotato.rotation = Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward);
        blade.Attack();
    }

    private void Jump_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // 100ms bonus to jump off platform !
        if (colliders.Count > 0 || Time.time < lastTimeGrounded + bonusTimeJump)
        {
            lastJump = Time.time;
            animator.SetTrigger("jump");
            // si au moins une collision est proche de l'horizontal
            if (colliders.Any(x => Vector2.Dot(Vector2.up, x.Value) > 0.2f))
            {
                rgby.SetVelocity(Vector2.up * jumpVelocity);
            }
            else
            {
                Vector2 dir = (Vector2.up + colliders.FirstOrDefault().Value).normalized;
                rgby.SetVelocity(dir * jumpVelocity);
            }
        }
    }

    private void Update()
    {
        Vector2 movement = controls.FreeMovement.Move.ReadValue<Vector2>();

        Move(movement);
    }

    public void Move(Vector2 direction)
    {
        float xMovement = direction.x;

        Vector2 directionWithoutHeight = Vector2.zero;

        float mouvementSpeed = xMovement * speed;
        // si au moins une collision est proche de l'horizontal
        if (colliders.Any(x => Vector2.Dot(Vector2.up, x.Value) > 0.2f))
        {
            directionWithoutHeight = new Vector2(mouvementSpeed, rgby.velocity.y);
            rgby.SetVelocity(directionWithoutHeight);
        }
        else
        {
            float midAirControl = 5f;
            directionWithoutHeight = new Vector2(mouvementSpeed * Time.deltaTime * midAirControl, 0);
            rgby.velocity +=(directionWithoutHeight);

            if (mouvementSpeed > 0)
            {
                rgby.velocity = new Vector2(Mathf.Clamp(rgby.velocity.x, -mouvementSpeed, mouvementSpeed), rgby.velocity.y);
            }
            else
            {
                rgby.velocity = new Vector2(Mathf.Clamp(rgby.velocity.x, mouvementSpeed, -mouvementSpeed), rgby.velocity.y);
            }
            
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
                animator.SetTrigger("land");
            }
            colliders.Add(collision.gameObject, collision.contacts[0].normal);
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
    
}
