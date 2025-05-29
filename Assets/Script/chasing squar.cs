using UnityEngine;

public class BoundarySquare : MonoBehaviour
{
    public GameObject gameOverUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }

    void GameOver()
    {
        
        Time.timeScale = 0;
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); 
        }
        
    }
}
