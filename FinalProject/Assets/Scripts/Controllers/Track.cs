using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    private List<GameObject> _objects = new List<GameObject>();

    public void Move(Vector3 _step)
    {
        transform.position = transform.position + _step;
        for (int i = 0; i < _objects.Count; i++)
        {
            _objects[i].transform.position = _objects[i].transform.position + _step;
        }
    }

    public void addObject(GameObject Object)
    {
        _objects.Add(Object);
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void Del()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            Destroy(_objects[i]);
        }
        Destroy(gameObject);
    }
}
