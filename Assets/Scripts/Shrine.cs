using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{

    public float fallSpeed = 20f;

    public bool activated = false;


    // Use this for initialization
    void Awake()
    {

    }

    void Start()
    {
        // DROP IT !
        GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // speedCapture
            ActivateCaptureBoost(other.gameObject.GetComponent<Player>());
            Debug.Log("Boost Activated !");
        }
    }

    // CAPTURE BOOST
    void ActivateCaptureBoost(Player p)
    {
        int normalCaptureSpeed = p.captureSpeed;
        p.captureSpeed = 2;
        StartCoroutine(CaptureBoostCoroutine(2, p, normalCaptureSpeed));
    }

    IEnumerator CaptureBoostCoroutine(float waitTime, Player p, int normalCaptureSpeed)
    {
        yield return new WaitForSeconds(waitTime);
        p.captureSpeed = normalCaptureSpeed;
    }

    // SUPER BUMP
    void ActivateBumpBoost(Player p)
    {
        Bump bump = p.transform.GetComponentInChildren<Bump>();
        float normalRadius = bump.radius;
        float normalPower = bump.power;
    }
}
