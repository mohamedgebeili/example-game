using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCombo : MonoBehaviour
{
    private float speed = 0;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
