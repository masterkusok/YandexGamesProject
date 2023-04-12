using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Movable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
            bullet.Delete();

        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger playerInter))
            playerInter.MoveTo(transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger playerInter))
        {
            if (Mathf.Abs(other.transform.position.x - transform.position.x) < 1)
                playerInter.Damage();
        }
    }
}
