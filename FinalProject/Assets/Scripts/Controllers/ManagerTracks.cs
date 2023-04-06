using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTracks : MonoBehaviour
{
    [SerializeField] private GameObject _trackPrefab;
    private Vector3 _spawnPosition;
    private Vector3 _step;
    private int _generateLenght;
    private List<Track> _tracks = new List<Track>();
    [SerializeField] private List<GameObject> _elementsTrack;


    public void Init(Vector3 spawnPoint, Vector3 step, int generateLenght)
    {
        _spawnPosition = spawnPoint;
        _step = step;
        _generateLenght = generateLenght;
    }

    public void Generate()
    {
        Track track = Instantiate(_trackPrefab, _spawnPosition, Quaternion.identity).GetComponent<Track>();
        List<GameObject> els = GenerateElements();
        _tracks.Add(track);
        foreach (GameObject el in els)
        {
            track.addObject(el);
        }

    }

    public List<GameObject> GenerateElements()
    {
        List<GameObject> elements = new List<GameObject>();
        int countEls = Random.Range(3, 10);
        List<Vector2> positions = new List<Vector2>();
        for (int i = 0; i < countEls; i++)
        {
            Vector2 pos = new Vector2(-1, -1);
            do
            {

                pos.x = Random.Range(-1, 2);
                pos.y = Random.Range(0, 15);
            }
            while (positions.Contains(pos));
            pos.x *= _generateLenght;
            pos.y *= _generateLenght;
            positions.Add(pos);
        }
        for (int i = 0; i < countEls; i++)
        {
            GameObject el = Instantiate(_elementsTrack[Random.Range(0, _elementsTrack.Count)], new Vector3(positions[i].x + _spawnPosition.x, _spawnPosition.y, positions[i].y + _spawnPosition.z), Quaternion.identity);
            elements.Add(el);
        }
        return elements;
    }

    public void UpdateTracks(float dT)
    {
        for (int i = 0; i < _tracks.Count; i++)
        {
            _tracks[i].Move(_step * dT);
            if (_tracks[i].getPosition().z < -15)
            {
                Track el = _tracks[i];
                _tracks.Remove(el);
                el.Del();
                Generate();
            }
        }

    }
}
