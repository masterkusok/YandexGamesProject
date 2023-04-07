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

        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }
}
