using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private HeroInput _heroInput;
    [SerializeField] private float _maxTapDistance;

    private Vector2 _touchStart;
    private Vector2 _touchEnd;
    private Vector2 _swipeDirection;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _touchStart = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _touchEnd = Input.GetTouch(0).position;
            _swipeDirection = _touchEnd - _touchStart;
            if (_swipeDirection.magnitude < _maxTapDistance)
                Tapped();
            else
                Swiped();
        }

    }

    private void Tapped()
    {
        _heroInput.Shoot();
    }

    private void Swiped()
    {
        _swipeDirection = new Vector2(_swipeDirection.x, 0).normalized;
        _heroInput.Turn(_swipeDirection);
    }

}
