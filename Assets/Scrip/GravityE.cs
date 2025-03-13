using System;
using System.Collections.Generic;
using UnityEngine;

public class GravityE : MonoBehaviour
{
    private Rigidbody rb;
    private const float G = 0.00674f;
    public static List<GravityE> gravityObjectlist;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (gravityObjectlist == null)
        {
            gravityObjectlist = new List<GravityE>();
        }
        gravityObjectlist.Add(this);
        
    }

    private void FixedUpdate()
    {
        foreach (var obj in gravityObjectlist)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    void Attract(GravityE other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
            float forceMagnitude = G * ((rb.mass * otherRb.mass) / MathF.Pow(distance, 2));
            Vector3 finalForce = forceMagnitude * direction.normalized;
            
            otherRb.AddForce(finalForce);


    }
    
    
    
}
