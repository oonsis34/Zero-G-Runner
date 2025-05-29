using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Update()
    {
        if (CoinManager.Instance != null)
        {
            coinText.text = "" + CoinManager.Instance.Coins;
        }
    }
}