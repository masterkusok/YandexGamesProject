using UnityEngine;

public class HeroShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _fireStartPoint;

    public void Shoot()
    {
        Instantiate(_bulletPrefab, _fireStartPoint.transform.position, Quaternion.identity, null);
    }
}
