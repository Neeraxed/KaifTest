using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public Vector3 diff;
    [SerializeField] private Transform gravityTarget;
    [SerializeField] private float gravity = 50f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessGravity();
    }

    private void ProcessGravity()
    {
        diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass) * Time.fixedDeltaTime);
        Debug.DrawRay(transform.position, diff.normalized, Color.red);
        
        var a = Quaternion.FromToRotation(transform.up, diff.normalized);
        Quaternion.Slerp(transform.rotation, a, 0.5f);
    }
}


//﻿using UnityEngine;
//using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
//public class GravityBody : MonoBehaviour
//{

//    GravityAttractor planet;
//    Rigidbody rigidbody;

//    void Awake()
//    {
//        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
//        rigidbody = GetComponent<Rigidbody>();

//        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
//        rigidbody.useGravity = false;
//        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
//    }

//    void FixedUpdate()
//    {
//        // Allow this body to be influenced by planet's gravity
//        planet.Attract(rigidbody);
//    }
//}