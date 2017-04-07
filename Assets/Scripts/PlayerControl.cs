
    public float RightStickDeadzone = 0.02f;
    public float turnAxisThreshold = 0.1f;


    internal void SetAxisName(int id)
    {
        leftXAxis = "L_XAxis_" + id;
        leftYAxis = "L_YAxis_" + id;
        rightXAxis = "R_XAxis_" + id;
        rightYAxis = "R_YAxis_" + id;
        fire1 = "RB_" + id;
    }

    public float deadZone;
    private Rigidbody rb;
    public float acceleration;
    public float basicAcceleration;
    private float trueAcceleration;
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
    //public bool hasInput = false;
    private void FixedUpdate()
    {
        if (isStunned && stunEndTime <= Time.time)
            isStunned = false;
        if (isStunned)
            return;
        trueAcceleration = acceleration / Time.fixedDeltaTime;
        //hasInput = false;
        Vector3 force = Vector3.zero;
        if (Input.GetAxis(leftXAxis) > deadZone)
        {
            //hasInput = true;
            force += Vector3.right * acceleration;
            //rb.velocity = rb.velocity + trueAcceleration * Vector3.right;
            //Debug.Log("Right");
        }
        if (Input.GetAxis(leftXAxis) < -deadZone)
        {
            //hasInput = true;
            force += Vector3.left * acceleration;
            //rb.velocity = rb.velocity + trueAcceleration * Vector3.left;
            //Debug.Log("Left");
        }
        if (Input.GetAxis(leftYAxis) > deadZone)
        {
            //hasInput = true;
            force += Vector3.forward * acceleration;
            //rb.velocity = rb.velocity + trueAcceleration * Vector3.forward;
            //Debug.Log("Up");
        }
        if (Input.GetAxis(leftYAxis) < -deadZone)
        {
            //hasInput = true;
            force += Vector3.back * acceleration;
            //rb.velocity = rb.velocity + trueAcceleration * Vector3.back;
            //Debug.Log("Down");
        }
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
        if ((Time.time - lastBumpTime) < bumpCoolDown) {
            Color transitionColor = Color.black + originalColor * (Time.time - lastBumpTime) / bumpCoolDown;
            cooldown1.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor",transitionColor);
            cooldown2.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor",transitionColor);
        }
        
        



        force += Vector3.ClampMagnitude(force, acceleration);
        rb.AddForce(force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        //if (!hasInput)
        //{
        //    rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        //}

    public void SetBoost(bool input)
    {
        if(input)
        {
            if(!isBoosted)
            {
                acceleration += speedBoost;
                isBoosted = input;
            }
        }
        else
        {
            if(isBoosted)
            {
                isBoosted = false;
                acceleration -= speedBoost;
            }
        }
    }
    public float bumpaxis;
    private bool bumpLock;
    private bool isStunned;
    private float stunEndTime;
    private float stunLength;
}

//Color originalColor1 = cooldown1.GetComponent<MeshRenderer>().materials[1].GetColor("_EmissionColor");
//cooldown1.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", newColor1);