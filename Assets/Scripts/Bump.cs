using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    // Use this for initialization
    public float radius;
    public float power = 2.0F;

    public float superRadius = 30f;
    public float superPower = 100f;
    public ParticleSystem[] bumperAnimations;
    private ParticleSystem particleSystem;
    List<GameObject> collidingObjects;
    GameObject owner;
    public bool superBump = false;

    private void Awake()
    {
        collidingObjects = new List<GameObject>();
        owner = transform.parent.gameObject;
        radius = GetComponent<SphereCollider>().radius;
    }

    internal void SetBumpColor(int id)
    {
        id--;
        particleSystem = bumperAnimations[id];
        particleSystem = Instantiate(particleSystem, transform.position, transform.rotation, transform);
        //throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Remove(other.gameObject);
    }

    public void TriggerBump()
    {
        float normalPower = power;
        float normalRadius = radius;

        if (superBump)
        {
            power = superPower;
            radius = superRadius;
        }
        Vector3 explosionPos = transform.position;
        PlayBumpAnimation();
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
        if (superBump)
        {
            radius = normalRadius;
            power = normalPower;
            superBump = false;
        }
    }

    public void PlayBumpAnimation()
    {
        particleSystem.Play();
    }

}
