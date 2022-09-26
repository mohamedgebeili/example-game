using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceInvader : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    private Rigidbody rb;
    private PlayerRotation playerRotation;
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
        print("SCORE: " + score);
    }

    private void FlyUp()
    {
        rb.AddForce(Vector3.up * speed);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRotation = GetComponent<PlayerRotation>();
        FlyUp();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            FlyUp();
        }

        // playerRotation.Rotate(rb.velocity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.ToLower() == "obstacle")
        {
            GetComponent<FallApart>().Activate();
            Invoke(nameof(RestartGame), 2);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
