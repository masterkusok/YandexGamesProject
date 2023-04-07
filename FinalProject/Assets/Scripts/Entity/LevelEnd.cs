using UnityEngine;

public class LevelEnd : Movable
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.LevelSucceeded();
        }
    }
}
