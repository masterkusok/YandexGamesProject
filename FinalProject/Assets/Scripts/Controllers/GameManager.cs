using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ManagerTracks _managerTracks;
    [SerializeField] private Vector3 _spawnPointTrack;
    [SerializeField] private Vector3 _speedTrack;
    [SerializeField] private int _generateLenght;
    void Start()
    {
        _managerTracks = GetComponent<ManagerTracks>();
        _managerTracks.Init(_spawnPointTrack, _speedTrack, _generateLenght);
        _managerTracks.Generate();
    }

    // Update is called once per frame
    void Update()
    {
        _managerTracks.UpdateTracks(Time.deltaTime);
    }
}
