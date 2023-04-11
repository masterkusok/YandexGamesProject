using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ActiveObject>(out ActiveObject activeObj))
        {
            activeObj.Activate();

        }
    }
}
