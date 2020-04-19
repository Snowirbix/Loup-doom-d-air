using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float ttl = 1f;
    protected float start;

    private void Start()
    {
        start = Time.time;
    }

    private void Update()
    {
        if (Time.time > start + ttl)
            Destroy(gameObject);
    }
}
