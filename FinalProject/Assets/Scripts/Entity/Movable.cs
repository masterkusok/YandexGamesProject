using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -20)
            Destroy(gameObject);
    }
}
