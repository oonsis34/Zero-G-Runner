using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 

    private bool isPaused = false; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); 
        }
        Time.timeScale = 0; 
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); 
        }
        Time.timeScale = 1; 
        isPaused = false;
    }
}
