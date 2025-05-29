using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public int Coins { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        Debug.Log($"Coins added: {amount}. Total: {Coins}");
    }

    public void RemoveCoins(int amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            Debug.Log($"Coins removed: {amount}. Total: {Coins}");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}