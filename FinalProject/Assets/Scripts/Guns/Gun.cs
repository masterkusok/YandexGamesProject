using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private uint _requiredEnergy;
    [SerializeField] Resources _resources;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] private Image _cooldownImage;

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
        _cooldownImage.fillAmount = 0;
        StartCoroutine(nameof(WaitForCooldown));
        StartCoroutine(nameof(FillCooldownImageRoutine));
    }

    private IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _isOnCooldown = false;
    }

    private IEnumerator FillCooldownImageRoutine()
    {
        while (_isOnCooldown)
        {
            if (_cooldownImage.fillAmount < 1)
            {
                float circleFillPercents = 360f;
                _cooldownImage.fillAmount += (circleFillPercents / _cooldown) / circleFillPercents;
            }

            if (_cooldownImage.fillAmount > 1)
            {
                _cooldownImage.fillAmount = 1;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
