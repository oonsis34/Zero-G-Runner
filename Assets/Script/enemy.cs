using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public GameObject gameOverUI; // ������§ Game Over UI
    public Button restartButton; // ���� Restart
    private float originalSpeed;
    private bool isGameOver = false; // �����ʶҹ���
    [SerializeField] InterstitialAdExample interstitialAdExample;

    void Start()
    {
        originalSpeed = speed;
        if (restartButton != null)
        {
            // �������Ϳѧ��ѹ RestartGame �Ѻ���� Restart
            restartButton.onClick.AddListener(() => StartCoroutine(RestartGame()));
        }
    }

    void Update()
    {
        // �ҡ����������������� player �����ش��÷ӧҹ
        if (isGameOver || player == null) return;

        // Enemy ����� player
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
        // ��Ǩ�ͺ������������ӫ�͹
        if (isGameOver) return;

        isGameOver = true; // ���ʶҹ������������
        speed = 0; // ��ش�������͹���ͧ Enemy
        Time.timeScale = 0; // ��ش����

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // �ʴ� Game Over UI
        }
    }

    public IEnumerator RestartGame()
    {

        Time.timeScale = 1; // ��Ѻ����蹵��
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // ��͹ Game Over UI
        }

        // Ŵ�������Ǣͧ Enemy
        speed = 0.2f;
        Debug.Log("Enemy speed reduced!");

        // ˹�ǧ���� 5 �Թҷ�
        yield return new WaitForSeconds(5);

        // �׹��Ҥ������Ǣͧ Enemy
        speed = originalSpeed;
        Debug.Log("Enemy speed restored!");

        isGameOver = false; // ����ʶҹ���
    }



}