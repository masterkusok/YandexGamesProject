using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private EnemyGun _gun;
    private ActiveObject _activeObj;
    private void Start()
    {
        _gun = gameObject.GetComponent<EnemyGun>();
        _activeObj = gameObject.GetComponent<ActiveObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_activeObj.isActive())
        {
            _gun.TryShoot();
        }
    }
}
