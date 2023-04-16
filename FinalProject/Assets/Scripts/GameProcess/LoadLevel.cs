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

    [SerializeField] private Transform _parent;

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
                            Instantiate(_finish, new Vector3(i * _scale, 0, (numLine * _scale) +_shift), Quaternion.identity, _parent);
                            break;
                        case '3':
                            Instantiate(_meteor, new Vector3(i * _scale, 0, (numLine * _scale) +_shift), Quaternion.identity, _parent);
                            break;
                        case '4':
                            Instantiate(_enemy, new Vector3(i * _scale, 0, (numLine * _scale) +_shift), Quaternion.identity, _parent);
                            break;
                        case '5':
                            Instantiate(_blackHole, new Vector3(i * _scale, 0, (numLine * _scale) +_shift), Quaternion.identity, _parent);
                            break;
                        case '6':
                            Instantiate(_money, new Vector3(i * _scale, 0, (numLine * _scale) +_shift), Quaternion.identity, _parent);
                            break;
                        case '7':
                            Instantiate(_energyTank, new Vector3(i * _scale, 0, (numLine * _scale) +_shift), Quaternion.identity, _parent);
                            break;
                    }
                }
                numLine++;
            }
        }
    }

}
