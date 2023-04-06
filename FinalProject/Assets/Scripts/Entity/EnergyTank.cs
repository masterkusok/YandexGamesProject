using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnergyTank : Movable
{
    private float _сountEnergy = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.AddEnergy(_сountEnergy);
            Destroy(gameObject);
        }

    }
}
