using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    // Use this for initialization
    public float radius;
    public float power = 2.0F;
    List<GameObject> collidingObjects;
    GameObject owner;

    private void Awake()
    {
        collidingObjects = new List<GameObject>();
        owner = transform.parent.gameObject;
        radius = GetComponent<SphereCollider>().radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Add(other.gameObject);
    }

    public void TriggerBump()
    {
        Debug.Log("BUMP!");
        Vector3 explosionPos = transform.position;
        foreach (GameObject hit in collidingObjects)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && !rb.gameObject.Equals(owner))
            {
                rb.AddForce((rb.transform.position - explosionPos).normalized * power, ForceMode.Impulse);
                hit.GetComponent<PlayerControl>().Stun();
            }

            //rb.AddExplosionForce(power, explosionPos, radius, 0f, ForceMode.Impulse);
        }
    }
}
