using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallApart : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    public void Activate()
    {
        for (int i = 0; i < Mathf.Min(rigidbodies.Length, colliders.Length); i++)
        {
            colliders[i].enabled = true;
            rigidbodies[i].isKinematic = false;
        }
    }

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }
}
