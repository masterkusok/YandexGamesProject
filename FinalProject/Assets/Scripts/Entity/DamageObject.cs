using UnityEngine;

public class DamageObject : Movable
{
    [SerializeField] private GameObject _asteroidExplodePrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.Damage();
        }

        else if(other.TryGetComponent<PlayerBullet>(out PlayerBullet bulletP))
        {
            bulletP.Delete();
            Instantiate(_asteroidExplodePrefab, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }

        else if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bulletE))
        {
            bulletE.Delete();
       
        }
    }
}
