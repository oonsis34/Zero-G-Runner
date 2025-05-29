using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.Instance?.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}