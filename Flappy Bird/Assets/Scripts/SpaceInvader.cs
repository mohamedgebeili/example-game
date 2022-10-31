using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceInvader : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private AudioSource flySound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private PauseManager paused;
    [SerializeField] private ColorChanger colorChange;
    private Rigidbody rb;
    private PlayerRotation playerRotation;
    private int score = 0;
    private bool isAlive = true;

    public void IncreaseScore()
    {
        scoreSound.Play();
        score++;
        scoreUI.text = score.ToString();
    }

    private void FlyUp()
    {
        
        if (!paused.isPaused)
        {
            flySound.Play();
            rb.AddForce(Vector3.up * speed);
        }
    }

    private void Die()
    {
        deathSound.Play();
        isAlive = false;
        GetComponent<FallApart>().Activate();
        colorChange.StartColorFade();

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
        if (Input.GetButtonDown("Jump")) FlyUp();
        if (isAlive) playerRotation.Rotate(rb.velocity.y);
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
