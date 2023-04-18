using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private TMP_Text _energyCounterText;
    [SerializeField] private TMP_Text _coinCounterText;
    [SerializeField] private TMP_Text _hpCounter;
    [SerializeField] private TMP_Text _bulletPowerCounter;

    public uint Coins { get; private set; }
    public uint Energy { get; private set; } = 10;
    public uint HpLevel { get; private set; } = Progress.GetInstance().Info.HpLevel;
    public uint BulletPowerLevel { get; private set; } = Progress.GetInstance().Info.BulletPowerLevel;

    private void Update()
    {
        _energyCounterText.text = Energy.ToString();
        _coinCounterText.text = Coins.ToString();
        _hpCounter.text = HpLevel.ToString();
        _bulletPowerCounter.text = BulletPowerLevel.ToString();
    }

    public void AddCoin() => Coins++;

    public void AddEnergy() => Energy++;

    public void DecreaseHpLevel()
    {
        if (HpLevel > 0)
        {
            HpLevel--;
        }
    }

    public void KnockHpLevel()
    {
        HpLevel = 0;
    }

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
