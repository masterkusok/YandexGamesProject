using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    private bool _active = false;

    public void Activate() => _active = true;

    public bool isActive() => _active;
        
}
