using UnityEngine;

public class Meteor : Movable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.damage();
        }
        if(other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }
}
