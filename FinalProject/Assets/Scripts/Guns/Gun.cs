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
    [SerializeField] private AudioManager _audioManager;

    private bool _isOnCooldown = false;
    private float _timeLeft;

    public void TryShoot()
    {
        if (_isOnCooldown || _resources.Energy < _requiredEnergy){
            _audioManager.PlaySound("Error");
            return;
        }
        _audioManager.PlaySound("Laser1");
        GoOnCooldown();
        _resources.UseEnergy(_requiredEnergy);
        CreateBullet();
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

    private void CreateBullet()
    {
        Vector3 position = transform.position;
        position.x = nearNum(position.x);
        GameObject bullet = Instantiate(_bulletPrefab, position, Quaternion.identity, null);
    }

    private int nearNum(float num)
    {
        float diff_1 = Config.RowWidth + num;
        float diff_2 = Mathf.Abs(num);
        float diff_3 = Config.RowWidth - num;

        if (diff_1 < diff_2 && diff_1 < diff_3)
        {
            return -Config.RowWidth;
        }
        else if (diff_2 < diff_1 && diff_2 < diff_3)
        {
            return 0;
        }
        else
        {
            return Config.RowWidth;
        }
    }
}
