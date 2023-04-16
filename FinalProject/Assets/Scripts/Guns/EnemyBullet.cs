using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Start()
    {
        _speed = -_speed;
    }


}
