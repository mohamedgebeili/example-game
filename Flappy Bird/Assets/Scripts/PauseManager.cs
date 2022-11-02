using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    public bool hasGameStarted;
    [SerializeField] private GameObject pausedText;
    [SerializeField] private GameObject startText;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausedText.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void Start()
    {
        PauseGame();
    }

    private void Update()
    {
        if(hasGameStarted)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                    isPaused = true;
                    pausedText.SetActive(true);
                }
            }
           
                
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                hasGameStarted = true;
                ResumeGame();
                startText.SetActive(false);
            }

        }
        
    }
}