using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsPanel : MonoBehaviour
{
    [SerializeField] private Button[] _cards;
    [SerializeField] private WalletRefresher _walletRefresher;
    [SerializeField] private Color _accessibleColor;
    [SerializeField] private Color _notAccessibleColor;

    private void Start()
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            var card = _cards[i];
            var cardName = card.gameObject.name;
            var cardCost = new Config().GetCost(cardName);
            card.GetComponentInChildren<TMP_Text>().text = $"{cardCost}$";
            UpdateCardsColors(card, cardCost);
            card.onClick.AddListener(() => BuyCardHandler(cardName, cardCost));
        }
    }

    private void BuyCardHandler(string cardName, int cost)
    {
        if (Progress.GetInstance().Info.Coins < cost)
        {
            return;
        }

        Progress.GetInstance().Info.Coins -= (uint)cost;

        switch (cardName)
        {
            case "HP":
                Progress.GetInstance().Info.HpLevel++;
                break;
            case "BulletPower":
                Progress.GetInstance().Info.BulletPowerLevel++;
                break;
        }

        Progress.GetInstance().Save();

        foreach (var card in _cards)
        {
            UpdateCardsColors(card, cost);
        }

        _walletRefresher.UpdateWallet();
    }

    private void UpdateCardsColors(Button card, int cardCost)
    {
        var newColor = card.colors;
        var color = Progress.GetInstance().Info.Coins >= cardCost ? _accessibleColor : _notAccessibleColor;
        newColor.highlightedColor = color;
        newColor.normalColor = color;
        newColor.selectedColor = color;
        newColor.pressedColor = color * 0.9f;
        newColor.disabledColor = color;
        card.colors = newColor;
    }
}
