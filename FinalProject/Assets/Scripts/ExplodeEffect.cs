using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEffect : MonoBehaviour
{
    [SerializeField] private float _secondsLasts = 10f;
    void Start()
    {
        StartCoroutine(nameof(DestroyAfterTimer));
    }

    private IEnumerator DestroyAfterTimer()
    {
        yield return new WaitForSeconds(_secondsLasts);
        Destroy(gameObject);
    }
}
