using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public GameObject gameOverUI; // เชื่อมโยง Game Over UI
    public Button restartButton; // ปุ่ม Restart
    private float originalSpeed;
    private bool isGameOver = false; // ตัวแปรสถานะเกม
    [SerializeField] InterstitialAdExample interstitialAdExample;

    void Start()
    {
        originalSpeed = speed;
        if (restartButton != null)
        {
            // เชื่อมต่อฟังก์ชัน RestartGame กับปุ่ม Restart
            restartButton.onClick.AddListener(() => StartCoroutine(RestartGame()));
        }
    }

    void Update()
    {
        // หากเกมจบแล้วหรือไม่มี player ให้หยุดการทำงาน
        if (isGameOver || player == null) return;

        // Enemy ไล่ตาม player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

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
        // ตรวจสอบไม่ให้เกมจบซ้ำซ้อน
        if (isGameOver) return;

        isGameOver = true; // ตั้งสถานะว่าเกมจบแล้ว
        speed = 0; // หยุดการเคลื่อนที่ของ Enemy
        Time.timeScale = 0; // หยุดเวลา

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // แสดง Game Over UI
        }
    }

    public IEnumerator RestartGame()
    {

        Time.timeScale = 1; // กลับมาเล่นต่อ
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // ซ่อน Game Over UI
        }

        // ลดความเร็วของ Enemy
        speed = 0.2f;
        Debug.Log("Enemy speed reduced!");

        // หน่วงเวลา 5 วินาที
        yield return new WaitForSeconds(5);

        // คืนค่าความเร็วของ Enemy
        speed = originalSpeed;
        Debug.Log("Enemy speed restored!");

        isGameOver = false; // รีเซ็ตสถานะเกม
    }



}