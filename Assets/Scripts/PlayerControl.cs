using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string leftXAxis;
    public string leftYAxis;
    public string rightXAxis;
    public string rightYAxis;
    public string fire1;
    public float bumpCoolDown;
    public float lastBumpTime;
    public Bump bump;

    private Vector3 turnVector;
    public float turnSpeed = 5.0f;


    internal void SetAxisName(int id)
    {
        leftXAxis = "L_XAxis_" + id;
        leftYAxis = "L_YAxis_" + id;
        rightXAxis = "R_XAxis_" + id;
        rightYAxis = "R_YAxis_" + id;
        fire1 = "A_" + id;
    }

    public float deadZone;
    private Rigidbody rb;
    public float acceleration;
    public float basicAcceleration;
    public float maxVelocity;


    public GameObject cooldown1;
    public GameObject cooldown2;
    private Color originalColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bump = GetComponentInChildren<Bump>();
        //float idealDrag = acceleration / maxVelocity;
        //rb.drag = idealDrag / (idealDrag * Time.fixedDeltaTime + 1);
        lastBumpTime = Time.time - bumpCoolDown - 1f;
        basicAcceleration = acceleration;
        originalColor = cooldown1.GetComponent<MeshRenderer>().materials[1].GetColor("_EmissionColor");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 orientation = Vector3.zero;
        if (isStunned && stunEndTime <= Time.time)
        {
            isStunned = false;
        }
        if (isStunned)
        {
            return;
        }
        Vector3 force = Vector3.zero;
        if (Input.GetAxis(leftXAxis) > deadZone)
        {
            force += Vector3.right * acceleration;
        }
        if (Input.GetAxis(leftXAxis) < -deadZone)
        {
            force += Vector3.left * acceleration;
        }
        if (Input.GetAxis(leftYAxis) > deadZone)
        {
            force += Vector3.forward * acceleration;
        }
        if (Input.GetAxis(leftYAxis) < -deadZone)
        {
            force += Vector3.back * acceleration;
        }
        orientation = new Vector3(Input.GetAxisRaw(leftXAxis), 0, Input.GetAxisRaw(leftYAxis));
        if (orientation.sqrMagnitude > 0.3f)
            transform.forward = orientation;
        if (Input.GetButtonDown(fire1) && !bumpLock)
        {
            bumpaxis = Input.GetAxis(fire1);
            bumpLock = true;

            if (Time.time - lastBumpTime > bumpCoolDown)
            {
                lastBumpTime = Time.time;
                bump.TriggerBump();

                cooldown1.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.black);
                cooldown2.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.black);
            }
        }
        if (Input.GetButtonUp(fire1) && bumpLock)
            bumpLock = false;
        if ((Time.time - lastBumpTime) < bumpCoolDown)
        {
            Color transitionColor = Color.black + originalColor * (Time.time - lastBumpTime) / bumpCoolDown;
            cooldown1.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", transitionColor);
            cooldown2.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", transitionColor);
        }





        force += Vector3.ClampMagnitude(force, acceleration);
        rb.AddForce(force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        //if (!hasInput)
        //{
        //    rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        //}
    }


    //IEnumerator Turn()
    //{

    //    Quaternion oldRotation = transform.rotation;
    //    Quaternion newRotation = new Quaternion();
    //    newRotation.eulerAngles = turnVector;

    //    for (float t = 0.0f; t < 1.0f; t += (turnSpeed * Time.deltaTime))
    //    {
    //        transform.rotation = Quaternion.Lerp(oldRotation, newRotation, t);
    //        yield return null;
    //    }

    //}




    public void Stun()
    {
        isStunned = true;
        stunEndTime = Time.time + stunLength;
    }

    public float bumpaxis;
    private bool bumpLock;
    private bool isStunned;
    private float stunEndTime;
    private float stunLength;
    public bool isBoosted;
    public float speedBoost;
    public void SetBoost(bool input)
    {
        if (input)
        {
            if (!isBoosted)
            {
                acceleration += speedBoost;
                isBoosted = input;
            }
        }
        else
        {
            if (isBoosted)
            {
                isBoosted = false;
                acceleration -= speedBoost;
            }
        }
    }
}
