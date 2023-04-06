using UnityEngine;

public class LevelEnd : Movable
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<HeroTrigger>(out HeroTrigger other))
        {
            other.LevelSucceeded();
        }
    }
}
