using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject _meteor;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _blackHole;
    [SerializeField] private GameObject _money;
    [SerializeField] private GameObject _energyTank;

    [SerializeField] private Transform _parentLeft;
    [SerializeField] private Transform _parentMid;
    [SerializeField] private Transform _parentRight;

    [SerializeField] private int _scale;
    [SerializeField] private int _shift; 

    private void Awake()
    {
        Load(0);
        _scale = Config.RowWidth;
    }

    public void Load(int level)
    {
        string path = @"./Assets/Levels/level.txt";
        using (StreamReader reader = new StreamReader(path))
        {
            path = @"./Assets/Levels/level" + reader.ReadLine() + ".txt";
        }

            using (StreamReader reader = new StreamReader(path))
        {
            string line;
            int numLine = 0;
            while ((line = reader.ReadLine()) != null)
            {

                for (int i = -1; i < 2; i++)
                {
                    switch (line[i + 1])
                    { 
                        case '2':
                            InstantiateObject(_finish, new Vector3(0, 0, (numLine * _scale) + _shift));
                            break;
                        case '3':
                            InstantiateObject(_meteor, new Vector3(i * _scale, 0, (numLine * _scale) + _shift));
                            break;
                        case '4':
                            InstantiateObject(_enemy, new Vector3(i * _scale, 0, (numLine * _scale) + _shift));
                            break;
                        case '5':
                            InstantiateObject(_blackHole, new Vector3(i * _scale, 0, (numLine * _scale) + _shift));
                            break;
                        case '6':
                            InstantiateObject(_money, new Vector3(i * _scale, 0, (numLine * _scale) + _shift));
                            break;
                        case '7':
                            InstantiateObject(_energyTank, new Vector3(i * _scale, 0, (numLine * _scale) + _shift));
                            break;
                    }
                }
                numLine++;
            }
        }
    }

    private void InstantiateObject(GameObject obj, Vector3 pos) {
        if (pos.x < 0)
        {
            Instantiate(obj, new Vector3(pos.x, 0, pos.z), Quaternion.identity, _parentLeft);
        }
        if (pos.x == 0)
        {
            Instantiate(obj, new Vector3(pos.x, 0, pos.z), Quaternion.identity, _parentMid);
        }
        if (pos.x > 0)
        {
            Instantiate(obj, new Vector3(pos.x, 0, pos.z), Quaternion.identity, _parentRight);
        }

    }

}
