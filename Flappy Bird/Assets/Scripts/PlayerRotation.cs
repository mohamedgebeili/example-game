using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float maxZRotation = 15f;
    [SerializeField] private float rotationDuration = 0.5f;

    private float rotationTimer = 0;
    private bool isGoingUp = false;

    public void Rotate(float yVelocity)
    {
        if (yVelocity > 0 && !isGoingUp)
        {
            isGoingUp = true;
            rotationTimer = 0;
        }
        else if (yVelocity < 0 && isGoingUp)
        {
            isGoingUp = false;
            rotationTimer = 0;
        }
        rotationTimer += Time.deltaTime;

        float targetZ = isGoingUp ? maxZRotation : -maxZRotation;
        Quaternion endRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, targetZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, rotationTimer / rotationDuration);
    }

}
