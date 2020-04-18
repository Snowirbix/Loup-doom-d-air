using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /**
     * <summary>Vec3 to Vec2</summary>
     */
    public static Vector2 XY (this Vector3 vec3)
    {
        return (Vector2)vec3;
    }
    
    /**
     * <summary>Vec2 to Vec3</summary>
     */
    public static Vector3 XY0 (this Vector2 vec2)
    {
        return new Vector3(vec2.x, vec2.y, 0);
    }

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
        return obj.transform.position.XY();
    }
    
    /**
     * <summary>Set transform position</summary>
     */
    public static GameObject Position(this GameObject obj, Vector2 position)
    {
        obj.transform.position = position.XY0();
        return obj;
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
    public static GameObject Rotation(this GameObject obj, Quaternion rotation)
    {
        obj.transform.rotation = rotation;
        return obj;
    }
    
    /**
     * <summary>Set position and rotation</summary>
     */
    public static GameObject SetPositionAndRotation(this GameObject obj, Vector2 position, Quaternion rotation)
    {
        obj.transform.SetPositionAndRotation(position.XY0(), rotation);
        return obj;
    }
    
    /**
     * <summary>Set velocity</summary>
     */
    public static Rigidbody2D SetVelocity(this Rigidbody2D rb, Vector2 velocity)
    {
        rb.velocity = velocity;
        return rb;
    }
    
    /**
     * <summary>Set kinematic rigidbody</summary>
     */
    public static Rigidbody2D SetKinematic(this Rigidbody2D rb, bool kinematic)
    {
        rb.isKinematic = kinematic;
        return rb;
    }

    public static bool Contains(this LayerMask layerMask, int layer)
    {
        return (1 << layer & layerMask) != 0;
    }
}
