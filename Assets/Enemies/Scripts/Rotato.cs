using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotato : MonoBehaviour
{
    public float speedoRotato = 1f;
    protected float angle = 0f;
    public float randomInverseChance = 0.05f;
    protected float lastRandom;
    public float sign = 1;

    private void Update()
    {
        if (Time.time > lastRandom + 0.1f)
        {
            lastRandom = Time.time;
            if (Random.value < randomInverseChance)
            {
                sign = -sign;
            }
        }
        angle += 360f * Time.deltaTime * speedoRotato * sign;
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
