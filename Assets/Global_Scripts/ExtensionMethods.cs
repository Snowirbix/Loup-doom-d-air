using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /**
     * <summary>Query the component</summary>
     */
    public static T Q<T>(this GameObject obj)
    {
        return obj.GetComponent<T>();
    }
    
    /**
     * <summary>Get transform position</summary>
     */
    public static Vector3 position(this GameObject obj)
    {
        return obj.transform.position;
    }
    
    /**
     * <summary>Get transform rotation</summary>
     */
    public static Quaternion rotation(this GameObject obj)
    {
        return obj.transform.rotation;
    }

    public static Rigidbody2D SetVelocity(this Rigidbody2D rb, Vector2 velocity)
    {
        rb.velocity = velocity;
        return rb;
    }

    public static Rigidbody2D SetIsKinematic(this Rigidbody2D rb, bool isKinematic)
    {
        rb.isKinematic = isKinematic;
        return rb;
    }
}
