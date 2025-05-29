using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextPro;
    public float scoreMultiplier = 1f;
    public float cooldownTime = 10f;

    private float score = 0f;
    private float timer = 0f;
    private bool isCooldownOver = false;

    void Update()
    {
        if (!isCooldownOver)
        {
            timer += Time.deltaTime;
            if (timer >= cooldownTime)
            {
                isCooldownOver = true;
            }
        }
        else
        {
            if (player != null)
            {
                score += Time.deltaTime * scoreMultiplier;
                scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
                scoreTextPro.text ="Score: " + Mathf.FloorToInt(score).ToString();
            }
        }
    }
}