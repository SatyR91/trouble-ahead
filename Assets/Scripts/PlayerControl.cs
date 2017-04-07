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

    internal void SetAxisName(int id)
    {
        leftXAxis = "Horizontal_P" + id;
        leftYAxis = "Vertical_P" + id;
        fire1 = "Fire1_P" + id;
    }

    public float deadZone;
    private Rigidbody rb;
    public float acceleration;
    private float trueAcceleration;
    public float maxVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //float idealDrag = acceleration / maxVelocity;
        //rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
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
        //if (!hasInput)
        //{
        //    rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        //}
    }
}
