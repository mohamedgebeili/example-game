using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRotation : MonoBehaviour
{
    [SerializeField] private float zRotationMax = 45;
    [SerializeField] private float secondsToMaxRotation = 1;

    private Rigidbody rb;
    private bool isGoingUp = false;
    private float nextRotationDuration = 0;
    private float timeSinceDirectionChange = 0;

    private Quaternion rotationAtDirectionChange;
    private Quaternion rotationTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateDirection();
        Rotate();
    }

    private void Rotate()
    {
        if (rotationAtDirectionChange.eulerAngles != rotationTarget.eulerAngles)
        {
            transform.rotation = Quaternion.Lerp(rotationAtDirectionChange, rotationTarget, timeSinceDirectionChange / secondsToMaxRotation);
        }
    }

    private void UpdateDirection()
    {
        timeSinceDirectionChange += Time.deltaTime;
        bool newIsGoingUp = rb.velocity.y > 0;
        if (isGoingUp != newIsGoingUp)
        {
            // DIRECTION CHANGED!
            timeSinceDirectionChange = 0;
            isGoingUp = newIsGoingUp;
            rotationAtDirectionChange = transform.rotation;

            // Determine next target
            if (isGoingUp)
            {
                rotationTarget = Quaternion.Euler(0, 0, zRotationMax);                
            }
            else
            {
                rotationTarget = Quaternion.Euler(0, 0, -zRotationMax);
            }


            // TODO Work in progress, wanted to make it so that smaller rotations take less time

            //// Determine rotation duration
            //float eulerCorrected = transform.eulerAngles.z >= 180 ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
            //print(transform.eulerAngles.z);
            //float amountToRotate = zRotationMax - eulerCorrected;
            ////print(amountToRotate);
            //float maxPossibleRotation = zRotationMax * 2;
            //nextRotationDuration = amountToRotate / maxPossibleRotation * secondsToMaxRotation;
            ////print(nextRotationDuration);
        }
    }
}
