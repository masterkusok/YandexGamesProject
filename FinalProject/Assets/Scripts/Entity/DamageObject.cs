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
            if(!TryGetComponent<EnemyBullet>(out EnemyBullet bullet))
            {
                bulletP.BulletPenetration--;
                if (bulletP.BulletPenetration <= 0)
                    Destroy(bulletP.gameObject);
                Instantiate(_asteroidExplodePrefab, transform.position,
                Quaternion.identity, GetComponentInParent<Track>().gameObject.transform);
            }

            Destroy(gameObject);
        }

        else if (other.TryGetComponent<EnemyBullet>(out EnemyBullet bulletE))
        {
            bulletE.Delete();
        }
    }
}
