using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HeroInput))]
public class HeroInput : MonoBehaviour
{
    [SerializeField] private Gun _defaultGun;
    [SerializeField] private GameState _gameState;
    private HeroMovement _heroMovement;

    private void Start()
    {
        _heroMovement = GetComponent<HeroMovement>();
    }

    public void LeftMouseClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Shoot();
        }
    }

    public void WASD(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            Turn(direction);
        }
    }

    public void Turn(Vector2 direction) 
    {
        if (_gameState.IsPlaying)
        {
            _heroMovement.Turn(direction);
        }
    }

    public void Shoot()
    {
        if(_gameState.IsPlaying && !EventSystem.current.IsPointerOverGameObject())
        {
            _defaultGun.TryShoot();
        }
    }

}