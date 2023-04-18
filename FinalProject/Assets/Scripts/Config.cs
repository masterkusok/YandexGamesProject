using System;
using System.Collections.Generic;

public enum CostsKeys
{
    HP = 30,
    BulletPower = 30
}

public class Config
{
    public const int RowWidth = 4;
    public const float EnvironmentSpeed = 20f;
    private Dictionary<string, int> _costs = new Dictionary<string, int> {
        {"HP", Convert.ToInt32(CostsKeys.HP)},
        {"BulletPower", Convert.ToInt32(CostsKeys.BulletPower)}
    };

    public int GetCost(string key)
    {
        return _costs[key];
    }
}
