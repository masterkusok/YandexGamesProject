using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Movable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.Delete();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger playerInter))
        {
            playerInter.MoveTo(transform.position);
            if (Mathf.Abs(other.transform.position.x - transform.position.x) < 1)
                playerInter.Damage();
        }
    }
}
