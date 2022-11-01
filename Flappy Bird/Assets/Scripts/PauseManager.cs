using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    public bool hasGameStarted;
   [SerializeField] private GameObject pausedText;
    [SerializeField] private GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
    }

    // Update is called once per frame
    void Update()

    {
        if(hasGameStarted)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (isPaused)
                {
                    ResumeGame();
                    isPaused = false;
                    pausedText.SetActive(false);
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
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}