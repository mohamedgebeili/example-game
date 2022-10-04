using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallApart : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    public void Activate()
    {
        // TODO
    }

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }
}
