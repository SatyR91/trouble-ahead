using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    // Use this for initialization
    public float radius;
    public float power = 2.0F;
    public ParticleSystem[] bumperAnimations;
    private ParticleSystem particleSystem;
    List<GameObject> collidingObjects;
    GameObject owner;

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
        //Debug.Log("BUMP!");
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
    }

    public void PlayBumpAnimation()
    {
        particleSystem.Play();
    }
}
