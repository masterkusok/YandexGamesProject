using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Movable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.Damage();
        }
    }
}
