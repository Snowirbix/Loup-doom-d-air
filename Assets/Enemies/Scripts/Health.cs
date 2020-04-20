using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int healthPoint = 2;

    protected SpriteRenderer spriteRenderer;
    protected Material mat;

    public float hitDuration = 0.2f;
    protected float lastHit;

    public bool pendingDeath = false;
    public float lastDeath;
    public float deathDuration = 0.2f;

    public UnityEvent death;

    private void Start()
    {
        spriteRenderer = gameObject.Q<SpriteRenderer>();
        mat = spriteRenderer.material;
    }

    private void Update()
    {
        if (mat.GetFloat("_Hit") == 1.0f && Time.time > lastHit + hitDuration)
        {
            mat.SetFloat("_Hit", 0.0f);
        }

        if (pendingDeath && Time.time > lastDeath + deathDuration)
        {
            Destroy(gameObject);
        }
    }

    public bool Hit (int damage)
    {
        mat.SetFloat("_Hit", 1.0f);
        lastHit = Time.time;
        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            pendingDeath = true;
            lastDeath = Time.time;
            death.Invoke();
            return true;
        }

        return false;
    }
}
