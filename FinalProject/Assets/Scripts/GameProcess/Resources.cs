using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private TMP_Text _energyCounterText;
    [SerializeField] private TMP_Text _coinCounterText;

    public uint Coins { get; private set; }
    public uint Energy { get; private set; } = 10;

    private void Update()
    {
        _energyCounterText.text = Energy.ToString();
        _coinCounterText.text = Coins.ToString();
    }

    public void AddCoin() => Coins++;

    public void AddEnergy() => Energy++;

    public bool UseEnergy(uint amount)
    {
        if (Energy >= amount)
        {
            Energy -= amount;
            return true;
        }

        return false;
    }
}
