using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] private GameObject pausedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

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
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}