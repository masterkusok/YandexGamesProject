using UnityEngine;

public class Resources : MonoBehaviour
{
    public uint Coins { get; private set; } = 0;
    public uint Enegry { get; private set; } = 10;

    public void AddCoin() => Coins++;

    public void AddEnegry() => Enegry++;

    public bool UseEnergy(uint amount)
    {
        if(Enegry >= amount)
        {
            Enegry -= amount;
            return true;
        }

        return false;
    }
}
