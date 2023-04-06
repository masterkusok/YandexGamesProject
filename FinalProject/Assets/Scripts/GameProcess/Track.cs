using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] GameState _gameState;
    void Update()
    {
        if(_gameState.IsPlaying)
            transform.Translate(Vector3.back * Config.EnvironmentSpeed * Time.deltaTime);
    }
}
