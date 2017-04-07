using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    // Use this for initialization
    public float radius = 200.0F;
    public float power = 2.0F;

    public void TriggerBump()
    {
        Debug.Log("BUMP!");
        Vector3 explosionPos = transform.position;
        LayerMask mask = 1 << LayerMask.NameToLayer("Player");
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius, mask);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && !rb.gameObject.Equals(transform.gameObject))
                rb.AddExplosionForce(power, explosionPos, radius);
        }
    }
}
