using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceInvader : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private AudioSource flySound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private TMP_Text scoreUI;
    private Rigidbody rb;
    private PlayerRotation playerRotation;
    private int score = 0;
    private bool isAlive = true;

    public void IncreaseScore()
    {
        score++;
        scoreUI.text = score.ToString();
        scoreSound.Play();
    }

    private void FlyUp()
    {
        rb.AddForce(Vector3.up * speed);
        flySound.Play();
    }

    private void Die()
    {
        isAlive = false;
        deathSound.Play();
        GetComponent<FallApart>().Activate();
        Invoke(nameof(RestartGame), 2);
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
        if (isAlive && collision.gameObject.tag.ToLower() == "obstacle")
        {
            Die();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
