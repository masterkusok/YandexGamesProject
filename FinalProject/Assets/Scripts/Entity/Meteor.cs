using UnityEngine;

public class Meteor : Movable
{
    [SerializeField] private GameObject _asteroidExplodePrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.Damage();
        }

        if(other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
            Instantiate(_asteroidExplodePrefab, transform.position, Quaternion.identity, GetComponentInParent<Track>().gameObject.transform);
            Destroy(gameObject);
        }
    }
}
