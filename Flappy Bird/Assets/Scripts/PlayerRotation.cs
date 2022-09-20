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
            print("GOING UP");
        }
        else if (yVelocity < 0 && isGoingUp)
        {
            isGoingUp = false;
            print("GOING DOWN");
        }


        Quaternion startRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, maxZRotation);
        Quaternion endRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -maxZRotation);

        rotationTimer += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, rotationTimer / rotationDuration);
    }

}
