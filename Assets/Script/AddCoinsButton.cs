using UnityEngine;

public class AddCoinsButton : MonoBehaviour
{
    public int coinsToAdd = 100;

    public void OnButtonClick()
    {
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.AddCoins(coinsToAdd);
        }
        else
        {
            Debug.LogError("CoinManager instance not found!");
        }
    }
}