using System.Collections;
using UnityEngine;

public class InvincibilityBlink : MonoBehaviour
{
    
    [SerializeField] private GameObject _model;
    [SerializeField] private float _frequency = 10;

    public void StartBlink(float duration)
    {
        StartCoroutine(nameof(Blink), duration);
    }

    public void StopBlink()
    {
        StopAllCoroutines();
        _model.SetActive(true);
    }

    private IEnumerator Blink(float duration)
    {
        float i = 0;
        float waitK = 1 / (_frequency);
        while (i < duration)
        {
            i += waitK;
            _model.SetActive(false);
            yield return new WaitForSeconds(waitK);
            i += waitK;
            _model.SetActive(true);
            yield return new WaitForSeconds(waitK);
        }
    }
}
