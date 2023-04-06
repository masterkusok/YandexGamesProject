using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HeroMovement))]
public class HeroInput : MonoBehaviour
{
    [SerializeField] private Gun _defaultGun;
    private HeroMovement _heroMovement;

    private void Start()
    {
        _heroMovement = GetComponent<HeroMovement>();
    }

    public void Turn(InputAction.CallbackContext context) 
    {
        // ѕроверка фазы нужна дл€ того, чтобы действие вызывалось только один раз

        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            _heroMovement.Turn(direction);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            _defaultGun.TryShoot();
        }
    }

}