using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnrgyTank : Movable
{
    private float _ñountEnergy = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.AddEnergy(_ñountEnergy);
            Destroy(gameObject);
        }

    }
}
