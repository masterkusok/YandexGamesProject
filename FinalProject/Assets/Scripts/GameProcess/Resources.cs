using UnityEngine;

public class Resources : MonoBehaviour
{
    public uint Coins { get; private set; } = 0;
    public uint Energy { get; private set; } = 0;

    public void AddCoin() => Coins++;

    public void AddEnergy() => Energy++;

    public bool UseEnergy(uint amount)
    {
        if(Energy >= amount)
        {
            Energy -= amount;
            return true;
        }

        return false;
    }
}
