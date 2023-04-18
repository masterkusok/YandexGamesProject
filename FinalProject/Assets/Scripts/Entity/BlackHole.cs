using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Movable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
            bullet.Delete();

        else if (other.TryGetComponent<HeroTrigger>(out HeroTrigger playerInter))
            playerInter.MoveTo(transform.position);
        else if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bulletE))
        {
            bulletE.Delete();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger playerInter))
            playerInter.StopMove();
    }
}
