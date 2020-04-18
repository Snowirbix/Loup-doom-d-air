using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask plateformsLayerMask;
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

    public float distanceGrounded; 

    protected bool grounded = false;

    protected HashSet<GameObject> colliders = new HashSet<GameObject>();

    private void Awake()
    {
        one = this;

        controls = new Controls();

        controls.FreeMovement.Jump.started += Jump_started;

        rgby = gameObject.Q<Rigidbody2D>();
        spriteRenderer = gameObject.Q<SpriteRenderer>();
        boxCollider2D = gameObject.Q<BoxCollider2D>();
    }

    private void Jump_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // 100ms bonus to jump off platform !
        if (colliders.Count > 0 || Time.time < lastTimeGrounded + bonusTimeJump)
        {
            lastJump = Time.time;
            rgby.SetVelocity(Vector2.up * jumpVelocity);
        }
    }

    private void Update()
    {
        Vector2 movement = controls.FreeMovement.Move.ReadValue<Vector2>();

        Move(movement);
    }

    public void Move(Vector2 direction)
    {
        float xMovement = 0;
        float right = 1;
        float left = -1;

        if(direction.x > 0)
        {
            xMovement = right;
        }

        if(direction.x < 0)
        {
            xMovement = left;
        }

        Vector2 directionWithoutHeight = Vector2.zero;

        float mouvementSpeed = xMovement * speed;
        if (grounded)
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


        if (xMovement != axisFacing && xMovement != 0)
        {
            axisFacing = -axisFacing;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        colliders.Add(collision.gameObject);
    }
    
    public void OnCollisionExit2D(Collision2D collision)
    {
        colliders.Remove(collision.gameObject);

        if (colliders.Count == 0)
        {
            lastTimeGrounded = Time.time;
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
