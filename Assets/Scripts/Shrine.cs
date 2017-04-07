using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{

    public float fallSpeed = 20f;
    public int type;
    // Use this for initialization
    void Awake()
    {

    }

    void Start()
    {
        // DROP IT !
        GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;
    }

    void OnColliderEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Do Stuff based on type
        }
    }

    // Update is called once per frame

}
