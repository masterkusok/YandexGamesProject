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
    private float _timeLeft;

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
        _cooldownImage.fillAmount = 0;
        _timeLeft = 0f;
        _isOnCooldown = true;
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
        while (_isOnCooldown && _timeLeft < _cooldown)
        {
            _timeLeft += Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / _cooldown, 0.0f, 1.0f);
            _cooldownImage.fillAmount = normalizedValue;
            yield return null;
        }
    }
}
