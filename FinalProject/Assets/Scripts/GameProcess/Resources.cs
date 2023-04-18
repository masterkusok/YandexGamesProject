using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private TMP_Text _energyCounterText;
    [SerializeField] private TMP_Text _coinCounterText;
    [SerializeField] private TMP_Text _hpCounterText;

    public uint Coins { get; private set; }
    public uint Energy { get; private set; }
    public uint Hp { get; private set; }

    private void Start()
    {
        Hp = Progress.GetInstance().Info.HpLevel;
        _hpCounterText.text = Hp.ToString();
        _energyCounterText.text = Energy.ToString();
        _coinCounterText.text = Coins.ToString();
    }


    public void Damage()
    {
        Hp--;
        _hpCounterText.text = Hp.ToString();
    }

    public void AddCoin()
    {
        Coins++;
        _coinCounterText.text = Coins.ToString();
    }

    public void AddEnergy() 
    { 
        Energy++;
        _energyCounterText.text = Energy.ToString();
    }

    public bool UseEnergy(uint amount)
    {
        if (Energy >= amount)
        {
            Energy -= amount;
            return true;
        }
        _energyCounterText.text = Energy.ToString();
        return false;
    }
}
