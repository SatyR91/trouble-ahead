using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string leftXAxis;
    public string leftYAxis;
    //public string rightXAxis;
    //public string rightYAxis;
    public string fire1;
    public float bumpCoolDown;
    public float lastBumpTime;
    public Bump bump;

    internal void SetAxisName(int id)
    {
        leftXAxis = "L_XAxis_" + id;
        leftYAxis = "L_YAxis_" + id;
        fire1 = "RB_" + id;
    }

    public float deadZone;
    private Rigidbody rb;
    public float acceleration;
    private float trueAcceleration;
    public float maxVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bump = GetComponent<Bump>();
        //float idealDrag = acceleration / maxVelocity;
        //rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
        lastBumpTime = Time.time;
    }

    // Update is called once per frame
    //public bool hasInput = false;
    private void FixedUpdate()
    {
        trueAcceleration = acceleration / Time.fixedDeltaTime;
        //hasInput = false;
        if (Input.GetAxis(leftXAxis) > deadZone)
        {
            //hasInput = true;
            //rb.AddForce(Vector3.right * acceleration);
            rb.velocity = rb.velocity + trueAcceleration * Vector3.right;
            Debug.Log("Right");
        }
        if (Input.GetAxis(leftXAxis) < -deadZone)
        {
            //hasInput = true;
            //rb.AddForce(Vector3.left * acceleration);
            rb.velocity = rb.velocity + trueAcceleration * Vector3.left;
            Debug.Log("Left");
        }
        if (Input.GetAxis(leftYAxis) > deadZone)
        {
            //hasInput = true;
            //rb.AddForce(Vector3.forward * acceleration);
            rb.velocity = rb.velocity + trueAcceleration * Vector3.forward;
            Debug.Log("Up");
        }
        if (Input.GetAxis(leftYAxis) < -deadZone)
        {
            //hasInput = true;
            //rb.AddForce(Vector3.back * acceleration);
            rb.velocity = rb.velocity + trueAcceleration * Vector3.back;
            Debug.Log("Down");
        }
        if (Input.GetAxis(fire1) > 0f)
        {
            if (Time.time - lastBumpTime > bumpCoolDown)
            {
                bump.TriggerBump();
                lastBumpTime = Time.time;
            }
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        //if (!hasInput)
        //{
        //    rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        //}
    }
    public float bumpaxis;
}
