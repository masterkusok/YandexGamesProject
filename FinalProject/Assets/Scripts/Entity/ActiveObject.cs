using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    private bool active = false;

    public void Activate()
    {
        active = true;
    }

    public bool isActive()
    {
        return active;
    }
        
}
