using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] GameObject _bulletPrefab;

    private bool _isOnCooldown = false;

    public void TryShoot()
    {
        if (_isOnCooldown)
            return;

        GoOnCooldown();
        Instantiate(_bulletPrefab, transform.position - new Vector3(0, 0, transform.localScale.z * 4), Quaternion.identity, null);
    }

    private void GoOnCooldown()
    {
        _isOnCooldown = true;
        StartCoroutine(nameof(WaitForCooldown));
    }

    private IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _isOnCooldown = false;
    }
}
