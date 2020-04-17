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
    public static Vector2 Position(this GameObject obj)
    {
        return (Vector2)obj.transform.position;
    }
    
    /**
     * <summary>Set transform position</summary>
     */
    public static void Position(this GameObject obj, Vector2 position)
    {
        obj.transform.position = new Vector3(position.x, position.y, 0);
    }
    
    /**
     * <summary>Get transform rotation</summary>
     */
    public static Quaternion Rotation(this GameObject obj)
    {
        return obj.transform.rotation;
    }
    
    /**
     * <summary>Set transform rotation</summary>
     */
    public static void Rotation(this GameObject obj, Quaternion rotation)
    {
        obj.transform.rotation = rotation;
    }

    public static Rigidbody2D SetVelocity(this Rigidbody2D rb, Vector2 velocity)
    {
        rb.velocity = velocity;
        return rb;
    }

    public static Rigidbody2D SetKinematic(this Rigidbody2D rb, bool kinematic)
    {
        rb.isKinematic = kinematic;
        return rb;
    }
}
