using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Controls controls;

    private Rigidbody2D rgby;

    public float speed;

    private float axisFacing = 1;

    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        controls = new Controls();
        rgby = gameObject.Q<Rigidbody2D>();

        spriteRenderer = gameObject.Q<SpriteRenderer>();
    }

    void Move(Vector2 direction)
    {
        Vector2 directionWithoutHeight = new Vector2(direction.x, 0);
        rgby.SetVelocity(directionWithoutHeight * speed);
        if( NotFacingTheSameAxis(direction.x) && direction.x != 0)
        {
            axisFacing = -axisFacing;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
    void Update()
    {
        Vector2 movement = controls.FreeMovement.Move.ReadValue<Vector2>();
        Move(movement);
    }
    void Start()
    {
        
    }

    void OnEnable()
    {
        controls.FreeMovement.Enable();
    }

    void OnDisable()
    {
        controls.FreeMovement.Disable();
    }

    bool NotFacingTheSameAxis(float direction)
    {
        float left = -1;
        float right = 1;
        float facingSide = axisFacing;
        float newFacingSide = 0;
        if(direction > 0)
        {
            newFacingSide = right;
        }

        if(direction < 0)
        {
            newFacingSide = left;
        }

        return facingSide != newFacingSide;
    }

}
