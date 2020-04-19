using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    protected Animator animator;

    private void Start()
    {
        animator = gameObject.Q<Animator>();
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }
}
