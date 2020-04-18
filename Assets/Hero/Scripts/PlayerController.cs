using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask plateformsLayerMask;
    private Controls controls;

    private Rigidbody2D rgby;

    public float speed;

    private float axisFacing = 1;

    private SpriteRenderer spriteRenderer;

    private BoxCollider2D boxCollider2D;

    public float distanceGrounded; 


    void Awake()
    {
        controls = new Controls();
        rgby = gameObject.Q<Rigidbody2D>();
        spriteRenderer = gameObject.Q<SpriteRenderer>();
        boxCollider2D = gameObject.Q<BoxCollider2D>();
    }

    void Update()
    {
        Vector2 movement = controls.FreeMovement.Move.ReadValue<Vector2>();
        if(movement.y > 0 && isGrounded())
        {
            MoveUp(movement);
        }
            Move(movement);

    }
    void Move(Vector2 direction)
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
        if (isGrounded())
        {
           directionWithoutHeight = new Vector2(mouvementSpeed, rgby.velocity.y);
           rgby.SetVelocity(directionWithoutHeight);
        }
        else
        {
            float midAirControl = 5f;
            directionWithoutHeight = new Vector2(mouvementSpeed * Time.deltaTime * midAirControl, 0);
            rgby.velocity +=(directionWithoutHeight);
            if(mouvementSpeed > 0)
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

    void MoveUp(Vector2 direction)
    {
        float jumpVelocity = 30f;
        rgby.SetVelocity(Vector2.up * jumpVelocity);
    }
    void Start()
    {
        
    }

    bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down ,distanceGrounded, plateformsLayerMask);
        return raycastHit2D.collider != null;
    }

    void OnEnable()
    {
        controls.FreeMovement.Enable();
    }

    void OnDisable()
    {
        controls.FreeMovement.Disable();
    }
    
}
