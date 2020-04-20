﻿using System.Collections;
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

    private void Start()
    {
        player = PlayerController.one;
        rgby = gameObject.Q<Rigidbody2D>();
    }

    private void Update()
    {
        //CloseCombat();
        Twirl();
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

        if (length < 2f)
        {
            length = length/3f;
        }
        
        // Smooth
        Vector2 dir = diff.normalized * Mathf.Sqrt(length);

        rgby.AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
