using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Movable
{
    [SerializeField] private int _countMoney = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HeroTrigger>(out HeroTrigger hero))
        {
            hero.addMoney(_countMoney);
            Destroy(gameObject);
        }

    }
}
