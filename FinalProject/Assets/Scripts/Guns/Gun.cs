using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private uint _requiredEnergy;
    [SerializeField] Resources _resources;
    [SerializeField] GameObject _bulletPrefab;

    private bool _isOnCooldown = false;

    public void TryShoot()
    {
        if (_isOnCooldown)
            return;
        if (_resources.Energy < _requiredEnergy)
            return;

        GoOnCooldown();
        _resources.UseEnergy(_requiredEnergy);
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity, null);
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
