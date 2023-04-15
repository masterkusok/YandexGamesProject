using UnityEngine;
using TMPro;

public class WalletRefresher : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    private void Start()
    {
        UpdateWallet();
    }

    public void UpdateWallet()
    {
        _coinsText.text = Progress.GetInstance().Info.Coins.ToString();
    }
}
